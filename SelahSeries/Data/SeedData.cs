using SelahSeries.Models;
using SelahSeries.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Data
{
    public class SeedData
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IPostRepository _postRepo;
        private readonly ICategoryRepository _categoryRepo;
        public  SeedData(ICommentRepository commentRepo, IPostRepository postRepo, ICategoryRepository categoryRepo)
        {
            _commentRepo = commentRepo;
            _postRepo = postRepo;
            _categoryRepo = categoryRepo;
            
            Task.Run(() =>
           {
                   SeedCategories().Wait();
               //SeedPosts().Wait();
               //SeedComments().Wait();
           }).Wait();

        }

        public async Task SeedCategories()
        {
            if ((await _categoryRepo.GetCategoriesAsync()).Count > 0) return;

                var category = new Category
            {
                Title = "Sport",
                Description = "For sports new and debates",
            };
            await _categoryRepo.AddCategory(category);
            category = new Category
            {
                Title = "Politics",
                Description = "Politics"
            };
            await _categoryRepo.AddCategory(category);
            category = new Category
            {
                Title = "Relationship & Marriage",
                Description = "Realationship & Marriage"
            };
            await _categoryRepo.AddCategory(category);
            category = new Category
            {
                Title = "Career",
                Description = "Career"
            };
            await  _categoryRepo.AddCategory(category);

        }
         public async Task  SeedPosts()
        {
            if ((await _postRepo.GetPosts(new Models.DTOs.PaginationParam { PageIndex = 1, Limit = 20, SortColoumn = "CreatedAt" })).TotalCount > 0) return;
            var post = new Post
            {
                Author = "Lois Smart",
                Title = "The path of a champion",
                Content = "It takes training, hardwork, tenacity and little talent to forge a path - Olympiad champion",
                TitleImageUrl = "defaultPostPhoto.jpg",
                Published = false,
                CreatedAt = new DateTime(2013, 11, 23),
                ModifiedAt = new DateTime(2019, 05, 09),
                CategoryId = 1,
            };
            await _postRepo.AddPost(post);
            post = new Post
            {
                Author = "Lekan Agunbiade",
                Title = "Why do we cry",
                Content = "We cry not because we are weak but because we are humans",
                TitleImageUrl = "defaultPostPhoto.jpg",
                Published = true,
                CreatedAt = new DateTime(2009, 11, 23),
                ModifiedAt = new DateTime(2019, 05, 09),
                CategoryId = 2,
            };
            await  _postRepo.AddPost(post);
            post = new Post
            {
                Author = "Titilayo Agunbiade",
                Title = "Marriage Life",
                Content = "What would we be if we are single to stupor",
                TitleImageUrl = "defaultPostPhoto.jpg",
                Published = true,
                CreatedAt = new DateTime(2012, 11, 23),
                ModifiedAt = new DateTime(2019, 05, 09),
                CategoryId = 3,
            };
            await _postRepo.AddPost(post);
        }
        public async Task SeedComments()
        {
            if ((await _categoryRepo.GetCategoriesAsync()).Count > 0) return;
            var comment = new Comment
            {
                Content = "First Comment Lorem Ipsum",
                CreatedAt = new DateTime(2020, 04, 10),
                Author = "YunLa",
                PostId = 2,
            };
            await _commentRepo.AddComment(comment);
           comment = new Comment
            {
                ParentCommentId =   1,
                Content = "First Subcomment for first Comment Lorem Ipsum",
                CreatedAt = new DateTime(2020, 04, 10),
                Author = "YunLa",
                PostId = 2,
            };
            await _commentRepo.AddComment(comment);
            comment = new Comment
            {
                Content = "First Comment Lorem Ipsum",
                CreatedAt = new DateTime(2020, 04, 10),
                Author = "YunLa",
                PostId = 2,
            };
            await  _commentRepo.AddComment(comment);
        }
    }
}
