using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Instagraph.Data;
using Instagraph.DataProcessor.DtoModels;
using Instagraph.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Instagraph.DataProcessor
{
    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var posts = context.Posts
                .Where(p => p.Comments.Count() == 0)
                .OrderBy(p => p.Id)
                .Select(p => new
                {
                    p.Id,
                    Picture = p.Picture.Path,
                    User = p.User.Username
                });

            var jsonString = JsonConvert.SerializeObject(posts, Formatting.Indented);

            return jsonString;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var users = context.Users
                .Where(u => u.Posts
                    .Any(p => p.Comments
                        .Any(c => u.Followers
                            .Select(f => f.Follower)
                            .Any(fol => fol == c.User))))
                .Select(u => new
                {
                    u.Username,
                    Followers = u.Followers.Count
                })
                .ToArray();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var users = context.Users
                .Select(u => new
                {
                    u.Username,
                    PostsCommentCount = u.Posts.Select(p => p.Comments.Count).ToArray()
                });

            var userDtos = new List<UserTopPostDto>();

            var xDoc = new XDocument(new XElement("users"));

            foreach (var u in users)
            {
                int mostComments = 0;

                if (u.PostsCommentCount.Any())
                {
                    mostComments = u.PostsCommentCount.OrderByDescending(c => c).First();
                }

                var userDto = new UserTopPostDto()
                {
                    Username = u.Username,
                    MostComments = mostComments
                };

                userDtos.Add(userDto);
            }

            userDtos = userDtos
                .OrderByDescending(u => u.MostComments)
                .ThenBy(u => u.Username)
                .ToList();

            foreach (var u in userDtos)
            {
                xDoc.Root.Add(new XElement("user",
                    new XElement("Username", u.Username),
                    new XElement("MostComments", u.MostComments)
                    ));
            }
            string result = xDoc.Root.Elements()
                .OrderByDescending(e => e.Element("MostComments"))
                .ThenBy(e => e.Element("Username")).ToString();

            //string result = xDoc.ToString();
            return result;
        }
    }
}
