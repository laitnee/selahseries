using Microsoft.Extensions.DependencyInjection;
using SelahSeries.Data;
using SelahSeries.Repository;
using SelahSeries.Repository.Interfaces;
using SelahSeries.Services;


namespace SelahSeries.Core
{
    public static class ServiceExtensions
    {

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IEventRepository, EMI_EventsRepository>();
            services.AddTransient<ITestimonyRepository, TestimonyRepository>();
            services.AddTransient<IGalleryRepository, GalleryRepository>();
            services.AddTransient<IPostClapRepository, PostClapRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddLogging();
            services.AddHostedService<QueuedHostedService>();
            services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            return services;
        }
        public static IServiceCollection AddSeedData(this IServiceCollection services)
        {
            services.AddTransient<SeedData>(sp => new SeedData(sp.GetService<ICommentRepository>(), 
                sp.GetService<IPostRepository>(), 
                sp.GetService<ICategoryRepository>()));
            
                return services;
        }
    }
}
