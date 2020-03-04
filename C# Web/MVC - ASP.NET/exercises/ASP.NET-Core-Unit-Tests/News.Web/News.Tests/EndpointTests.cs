namespace News.Tests
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using News.Data;
    using News.Data.Models;
    using News.Web.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Xunit;

    public class EndpointTests
    {
        private NewsDbContext Context
        {
            get
            {
                DbContextOptions<NewsDbContext> dbOptions = new DbContextOptionsBuilder<NewsDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new NewsDbContext(dbOptions);
            }
        }

        private IEnumerable<News> GetTestData()
        {
            return new List<News>()
            {
                new News () { Id = 1, Title = "Neshto", Content = "Neshto si a", PublishDate = DateTime.ParseExact("05/05/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new News () { Id = 2, Title = "Neshtoo", Content = "Neshto si b", PublishDate = DateTime.ParseExact("10/02/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new News () { Id = 3, Title = "Neshtooo", Content = "Neshto si c", PublishDate = DateTime.ParseExact("23/03/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new News () { Id = 4, Title = "Neshtoooo", Content = "Neshto si d", PublishDate = DateTime.ParseExact("30/04/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture)}
            };
        }

        private void PopulateData(NewsDbContext context)
        {
            context.News.AddRange(this.GetTestData());
            context.SaveChanges();
        }

        private bool CompareNewsExact(News thisNews, News otherNews)
        {
            return thisNews.Id == otherNews.Id
                && thisNews.Title == otherNews.Title
                && thisNews.Content == otherNews.Content
                && thisNews.PublishDate == otherNews.PublishDate;
        }

        [Fact]
        public void NewsControllerGetAllNewsShould_ReturnOkStatusCode()
        {
            NewsDbContext context = this.Context;

            this.PopulateData(context);

            NewsController newsController = new NewsController(context);

            Assert.IsType<OkObjectResult>(newsController.GetAllNews());
        }

        [Fact]
        public void NewsControllerGetAllNewsShould_ReturnCorrectData()
        {
            NewsDbContext context = this.Context;

            this.PopulateData(context);

            NewsController newsController = new NewsController(context);

            IEnumerable<News> returnedData = (newsController.GetAllNews() as OkObjectResult).Value as IEnumerable<News>;

            IEnumerable<News> testData = this.GetTestData();

            foreach (var returnedModel in returnedData)
            {
                News testModel = testData.First(n => n.Id == returnedModel.Id);

                Assert.NotNull(testModel);

                Assert.True(this.CompareNewsExact(returnedModel, testModel));
            }
        }

        [Fact]
        public void NewsControllerPostNewsWithCorrectDataShould_ReturnCreatedStatusCode()
        {
            NewsDbContext context = this.Context;

            News testModel = this.GetTestData().First();

            NewsController newsController = new NewsController(context);

            Assert.IsType<CreatedAtActionResult>(newsController.PostNews(testModel));
        }

        [Fact]
        public void NewsControllerPostNewsWithCorrectDataShould_ReturnCreatedNews()
        {
            NewsDbContext context = this.Context;

            News testModel = this.GetTestData().First();

            NewsController newsController = new NewsController(context);

            News returnedModel = (newsController.PostNews(testModel) as CreatedAtActionResult).Value as News;

            Assert.True(this.CompareNewsExact(returnedModel, testModel));
        }

        [Fact]
        public void NewsControllerPostNewsWithIncorrectDataShould_ReturnBadRequestStatusCode()
        {
            NewsDbContext context = this.Context;

            News testModel = this.GetTestData().First();

            NewsController newsController = new NewsController(context);

            newsController.ModelState.AddModelError("Invalid Data", "Invalid Data");

            Assert.IsType<BadRequestObjectResult>(newsController.PostNews(testModel));
        }
    }
}
