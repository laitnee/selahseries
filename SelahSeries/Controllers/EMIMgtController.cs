using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using SelahSeries.Repository.Interfaces;
using SelahSeries.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Controllers
{
    public class EMIMgtController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IEventRepository _eventRepo;
        private readonly ITestimonyRepository _testimonyRepo;
        private readonly IGalleryRepository _galleryRepo;

        public EMIMgtController(IEventRepository eventRepo, ITestimonyRepository testimonyRepo, IGalleryRepository galleryRepo, IMapper mapper, IHostingEnvironment environment)
        {
            _eventRepo = eventRepo;
            _testimonyRepo = testimonyRepo;
            _galleryRepo = galleryRepo;
            _mapper = mapper;
            hostingEnvironment = environment;
        }


        #region Event

        [Route("/emimgt/events")]
        public async Task<ActionResult> EventIndex()
        {
            var pageParam = new PaginationParam
            {
                PageIndex = 1,
                Limit = 20,
                SortColoumn = "CreatedAt"
            };
            if (TempData.ContainsKey("Alert"))
            {
                ViewBag.Alert = TempData["Alert"].ToString();
            }
            if (TempData.ContainsKey("Error"))
            {
                ViewBag.Error = TempData["Error"].ToString();
            }
            var events = _eventRepo.GetEvents();
            return View(events);
        }

        [HttpGet]
        [Route("/emimgt/event/create")]
        public ActionResult EventCreate()
        {
            return View();
        }

        [HttpPost]
        [Route("/emimgt/event/create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EventCreate([FromForm] EventCreateViewModel eventVM)
        {
            if (ModelState.IsValid)
            {
                var uploadedImage = "";
                if (eventVM.EventPhoto != null) uploadedImage = await ProcessPhoto(eventVM.EventPhoto);

                try
                {
                    var e_event = _mapper.Map<Event>(eventVM);
                    e_event.CreatedAt = DateTime.Now;
                    e_event.ImgUrl = uploadedImage;
                    var length = e_event.Description.Length;

                    if (await _eventRepo.AddEvent(e_event))
                    {
                        TempData["Alert"] = "Event Created Successfully";
                        return RedirectToAction(nameof(EventIndex));
                    }

                    ViewBag.Error = "Unable to add event, please try again or contact administrator";
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Unable to add event, please try again or contact administrator";
                    return View();
                }
            }
            ViewBag.Error = "Please correct the error(s) in Form";
            return View(eventVM);

        }

        private async Task<string> ProcessPhoto(IFormFile photo)
        {
            var uniqueFileName = GetUniqueFileName(photo.FileName);
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, uniqueFileName);

            await photo.CopyToAsync(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                + "_"
                + Guid.NewGuid().ToString().Substring(0, 4)
                + Path.GetExtension(fileName);
        }


        [HttpGet]
        [Route("/emimgt/event/edit")]
        public async Task<ActionResult> EventEdit(int id)
        {

            var e_event = await _eventRepo.GetEvent(id);
            var eventVM = _mapper.Map<EventCreateViewModel>(e_event);
            return View(eventVM);
        }

        [HttpPost]
        [Route("/emimgt/event/edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EventEdit([FromForm] EventCreateViewModel eventVM)
        {
            if (ModelState.IsValid)
            {
                var uploadedImage = "";
                var editEvent = _mapper.Map<Event>(eventVM);
                if (eventVM.EventPhoto != null) uploadedImage = await ProcessPhoto(eventVM.EventPhoto);
                try
                {
                    if (!string.IsNullOrWhiteSpace(uploadedImage)) editEvent.ImgUrl = uploadedImage;


                    await _eventRepo.UpdateEvent(editEvent);
                    TempData["Alert"] = "Event Edited Successfully";
                    return RedirectToAction(nameof(EventIndex));
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Unable to add event, please try again or contact administrator";
                    return View();
                }
            }
            ViewBag.Error = "Please correct the error(s) in Form";
            return View();
        }


        [HttpGet]
        [Route("/emimgt/event/delete")]
        public async Task<IActionResult> EventDelete(int id)
        {
            try
            {
                var e_event = _eventRepo.GetEvent(id);
                await _eventRepo.DeleteEventAsync(e_event.Result);
                TempData["Alert"] = "Event Deleted Successfully";
                return RedirectToAction(nameof(EventIndex));


            }
            catch
            {
                TempData["Error"] = "Error occured: Unable to delete event";
                return RedirectToAction(nameof(EventIndex));
            }
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/emimgt/event/delete")]
        public ActionResult EventDelete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(EventIndex));
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Testimony

        [Route("/emimgt/testimonials")]
        public async Task<ActionResult> TestimonyIndex()
        {
            var pageParam = new PaginationParam
            {
                PageIndex = 1,
                Limit = 20,
                SortColoumn = "CreatedAt"
            };
            if (TempData.ContainsKey("Alert"))
            {
                ViewBag.Alert = TempData["Alert"].ToString();
            }
            if (TempData.ContainsKey("Error"))
            {
                ViewBag.Error = TempData["Error"].ToString();
            }
            var testimonies = _testimonyRepo.GetTestimonies();
            return View(testimonies);
        }

        [HttpGet]
        [Route("/emimgt/testimonial/create")]
        public ActionResult TestimonyCreate()
        {
            return View();
        }

        [HttpPost]
        [Route("/emimgt/testimonial/create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TestimonyCreate([FromForm] TestimonialCreateViewModel testimonyVM)
        {
            if (ModelState.IsValid)
            {
                var uploadedImage = "";
                if (testimonyVM.TestimonyPhoto != null) uploadedImage = await ProcessPhoto(testimonyVM.TestimonyPhoto);

                try
                {
                    var testimony = _mapper.Map<Testimonial>(testimonyVM);
                    testimony.CreatedAt = DateTime.Now;
                    testimony.ImgUrl = uploadedImage;

                    if (await _testimonyRepo.AddTestimony(testimony))
                    {
                        TempData["Alert"] = "Testimonial Added Successfully";
                        return RedirectToAction(nameof(TestimonyIndex));
                    }

                    ViewBag.Error = "Unable to add testimonial, please try again or contact administrator";
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Unable to add testimonial, please try again or contact administrator";
                    return View();
                }
            }
            ViewBag.Error = "Please correct the error(s) in Form";
            return View(testimonyVM);

        }

        [HttpGet]
        [Route("/emimgt/testimonial/edit")]
        public async Task<ActionResult> TestimonyEdit(int id)
        {

            var testimony = await _testimonyRepo.GetTestimony(id);
            var testimonyVM = _mapper.Map<TestimonialCreateViewModel>(testimony);
            return View(testimonyVM);
        }

        [HttpPost]
        [Route("/emimgt/testimonial/edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TestimonyEdit([FromForm] TestimonialCreateViewModel testimonyVM)
        {
            if (ModelState.IsValid)
            {
                var uploadedImage = "";
                var editTestimony = _mapper.Map<Testimonial>(testimonyVM);
                if (testimonyVM != null) uploadedImage = await ProcessPhoto(testimonyVM.TestimonyPhoto);
                try
                {
                    if (!string.IsNullOrWhiteSpace(uploadedImage)) editTestimony.ImgUrl = uploadedImage;


                    await _testimonyRepo.UpdateTestimony(editTestimony);
                    TempData["Alert"] = "Testimony Edited Successfully";
                    return RedirectToAction(nameof(TestimonyIndex));
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Unable to add testimony, please try again or contact administrator";
                    return View();
                }
            }
            ViewBag.Error = "Please correct the error(s) in Form";
            return View();
        }


        [HttpGet]
        [Route("/emimgt/testimonial/delete")]
        public async Task<IActionResult> TestimonyDelete(int id)
        {
            try
            {
                var testimony = _testimonyRepo.GetTestimony(id);
                await _testimonyRepo.DeleteTestimonyAsync(testimony.Result);
                TempData["Alert"] = "Testimony Deleted Successfully";
                return RedirectToAction(nameof(TestimonyIndex));
            }
            catch
            {
                TempData["Error"] = "Error occured: Unable to delete testimony";
                return RedirectToAction(nameof(TestimonyIndex));
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/emimgt/testimonial/delete")]
        public ActionResult TestimonyDelete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(TestimonyIndex));
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Gallery

        [Route("/emimgt/gallery")]
        public ActionResult GalleryIndex()
        {
            var pageParam = new PaginationParam
            {
                PageIndex = 1,
                Limit = 20,
                SortColoumn = "CreatedAt"
            };
            if (TempData.ContainsKey("Alert"))
            {
                ViewBag.Alert = TempData["Alert"].ToString();
            }
            if (TempData.ContainsKey("Error"))
            {
                ViewBag.Error = TempData["Error"].ToString();
            }
            var pictures = _galleryRepo.GetPictures();
            var picturesVM = _mapper.Map<List<GalleryListViewModel>>(pictures);
            return View(picturesVM);
        }

        [HttpGet]
        [Route("/emimgt/gallery/add")]
        public ActionResult PictureCreate()
        {
            return View();
        }

        [HttpPost]
        [Route("/emimgt/gallery/add")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PictureCreate([FromForm] GalleryCreateViewModel galleryVM)
        {
            if (ModelState.IsValid)
            {
                var uploadedImage = "";
                if (galleryVM.Photo != null) uploadedImage = await ProcessPhoto(galleryVM.Photo);

                try
                {
                    var picture = _mapper.Map<Picture>(galleryVM);
                    picture.CreatedAt = DateTime.Now;
                    picture.ImgUrl = uploadedImage;

                    if (await _galleryRepo.AddPicture(picture))
                    {
                        TempData["Alert"] = "Picture Added Successfully";
                        return RedirectToAction(nameof(GalleryIndex));
                    }

                    ViewBag.Error = "Unable to add picture, please try again or contact administrator";
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Unable to add picture, please try again or contact administrator";
                    return View();
                }
            }
            ViewBag.Error = "Please correct the error(s) in Form";
            return View(galleryVM);

        }

        [HttpGet]
        [Route("/emimgt/gallery/edit")]
        public async Task<ActionResult> PictureEdit(int id)
        {

            var picture = await _galleryRepo.GetPicture(id);
            var pictureVM = _mapper.Map<GalleryCreateViewModel>(picture);
            return View(pictureVM);
        }

        [HttpPost]
        [Route("/emimgt/gallery/edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PictureEdit([FromForm] GalleryCreateViewModel pictureVM)
        {
            if (ModelState.IsValid)
            {
                var editPicture = _mapper.Map<Picture>(pictureVM);
                try
                {
                    await _galleryRepo.UpdatePicture(editPicture);
                    TempData["Alert"] = "Picture Edited Successfully";
                    return RedirectToAction(nameof(GalleryIndex));
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Unable to add picture, please try again or contact administrator";
                    return View();
                }
            }
            ViewBag.Error = "Please correct the error(s) in Form";
            return View();
        }


        [HttpGet]
        [Route("/emimgt/picture/delete")]
        public async Task<IActionResult> PictureDelete(int id)
        {
            try
            {
                var picture = _galleryRepo.GetPicture(id);
                await _galleryRepo.DeletePictureAsync(picture.Result);
                TempData["Alert"] = "Picture Deleted Successfully";
                return RedirectToAction(nameof(GalleryIndex));
            }
            catch
            {
                TempData["Error"] = "Error occured: Unable to delete picture";
                return RedirectToAction(nameof(GalleryIndex));
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/emimgt/picture/delete")]
        public ActionResult PictureDelete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(GalleryIndex));
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}

