using SimpleMvc.Framework.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimpleMvc.Framework.Views
{
    public class View : IRenderable
    {
        public const string BaseLayoutFileName = "Layout";
        public const string ContentPlaceholder = "{{{content}}}";
        public const string PathPrefix = "../../../";
        public const string HtmlExtension = ".html";
        public const string LocalErrorPath = "\\SimpleMvc.Framework\\Errors\\Error.html";

        private readonly string templateFullyQualifiedName;
        private readonly IDictionary<string, string> viewData;

        public View(string templateFullyQualifiedName, IDictionary<string, string> viewData)
        {
            this.templateFullyQualifiedName = templateFullyQualifiedName;
            this.viewData = viewData;
        }

        public string Render()
        {
            string fullHtml = this.ReadFile();

            if (this.viewData.Any())
            {
                foreach (var parameter in viewData)
                {
                    fullHtml = fullHtml.Replace($"{{{{{{{parameter.Key}}}}}}}", parameter.Value);
                }
            }

            return fullHtml;
        }

        private string ReadFile()
        {
            string layoutHtml = this.RenderLayoutHtml();

            string templateFullyQualifiedNameWithExtension = 
               PathPrefix + this.templateFullyQualifiedName + HtmlExtension;

            if (!File.Exists(templateFullyQualifiedNameWithExtension))
            {
                string errorHtmlPath = this.GetErrorPath();
                string errorHtml = File.ReadAllText(errorHtmlPath);

                this.viewData.Add("error", "Requested view does not exist!");
                return errorHtml;
            }

            var templateHtml = File.ReadAllText(templateFullyQualifiedNameWithExtension);
            var fullHtml = layoutHtml.Replace(ContentPlaceholder, templateHtml);

            return fullHtml;
        }

        private string GetErrorPath()
        {
            string applicationDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo parentDirectory = Directory.GetParent(applicationDirectory);
            string parentDirectoryFullPath = parentDirectory.FullName;

            string errorPagePath = parentDirectoryFullPath + LocalErrorPath;

            return errorPagePath;
        }

        private string RenderLayoutHtml()
        {
            string layoutHtmlQualifiedName = string.Format(
                "{0}{1}/{2}{3}",
                PathPrefix,
                MvcContext.Get.ViewsFolder,
                BaseLayoutFileName,
                HtmlExtension
                );

            if (!File.Exists(layoutHtmlQualifiedName))
            {
                var errorHtmlPath = this.GetErrorPath();
                var errorHtml = File.ReadAllText(errorHtmlPath);

                this.viewData.Add("error", "Layout view does not exist!");
                return errorHtml;
            }

            string layoutHtmlFileContent = File.ReadAllText(layoutHtmlQualifiedName);
            return layoutHtmlFileContent;
        }
    }
}
