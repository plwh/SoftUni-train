namespace News.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using News.Data;
    using News.Data.Models;

    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly NewsDbContext context;

        public NewsController(NewsDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetAllNews()
        {
            return this.Ok(this.context.News);
        }

        [HttpGet("id")]
        public IActionResult GetSingleNews([FromRoute] int id)
        {
            News newsFromDb = this.context.News.Find(id);

            if (newsFromDb == null)
            {
                return NotFound();
            }

            return this.Ok(newsFromDb);
        }

        [HttpPost]
        public IActionResult PostNews([FromBody] News news)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.context.Add(news);
            this.context.SaveChanges();

            return CreatedAtAction("GetSingleNews", new { id = news.Id }, news);
        }

        [HttpPut("{id}")]
        public IActionResult PutNews([FromRoute] int id, [FromBody] News newNews)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            News oldNews = this.context.News.Find(id);

            if (oldNews == null)
            {
                return BadRequest();
            }

            oldNews.Title = newNews.Title;
            oldNews.Content = newNews.Content;
            oldNews.PublishDate = newNews.PublishDate;

            this.context.Update(oldNews);
            this.context.SaveChanges();

            return this.Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNews([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            News newsToDelete = this.context.News.Find(id);

            if (newsToDelete == null)
            {
                return BadRequest();
            }
            
            this.context.Remove(newsToDelete);
            this.context.SaveChanges();

            return this.Ok();
        }
    }
}
