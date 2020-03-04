using KittenApp.Models;
using KittenApp.Web.Models.BindingModels;
using KittenApp.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Interfaces;
using System.Linq;

namespace KittenApp.Web.Controllers
{
    public class KittensController : BaseController
    {
        [HttpGet]
        public IActionResult Add()
        {
            this.Model.Data["error"] = string.Empty;
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(KittenAddingModel model)
        {
            using (this.Context)
            {
                var breed = this.Context.Breeds
                       .FirstOrDefault(br => br.Name == model.Breed);

                if (breed == null)
                {
                    this.Model.Data["error"] = "Invalid breed";
                    return this.View();
                }

                var kitten = new Kitten()
                {
                    Name = model.Name,
                    Age = model.Age,
                    Breed = breed
                };

                this.Context.Kittens.Add(kitten);
                this.Context.SaveChanges();

                return this.RedirectToAction("/kittens/all");
            }
        }

        [HttpGet]
        public IActionResult All()
        {
            var kittens = this.Context.Kittens
                .Include(c => c.Breed)
                .Select(KittenViewModel.FromKitten)
                .Select(vm => $"<div>Name: {vm.Name} Age: {vm.Age} Breed: {vm.Breed}</div>")
                .ToList();

            this.Model.Data["kittens"] = string.Join("<br />", kittens);
            return this.View();
        }
    }
}
