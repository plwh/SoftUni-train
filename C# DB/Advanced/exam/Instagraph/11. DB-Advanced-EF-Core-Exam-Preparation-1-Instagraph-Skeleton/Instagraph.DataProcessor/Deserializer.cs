using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

using Newtonsoft.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Instagraph.Data;
using Instagraph.Models;
using Instagraph.DataProcessor.DtoModels;

namespace Instagraph.DataProcessor
{
    public class Deserializer
    {
        public static string errorMsg = "Error: Invalid data.";
        public static string successMsg = @"Successfully imported {0}.";

        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            Picture[] picturesData = JsonConvert.DeserializeObject<Picture[]>(jsonString);
            StringBuilder result = new StringBuilder();

            foreach (var pic in picturesData)
            {
                bool hasSamePath = false;

                if (context.Pictures.Count() > 0)
                {
                    hasSamePath = context.Pictures.Any(p => p.Path == pic.Path);
                }

                if (!hasSamePath && !string.IsNullOrEmpty(pic.Path) && pic.Size > 0)
                {
                    context.Pictures.Add(pic);
                    context.SaveChanges();
                    result.AppendLine(string.Format(successMsg, "Picture {pic.Path}"));
                }
                else
                {
                    result.AppendLine(errorMsg);
                }
            }

            return result.ToString().Trim();
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            StringBuilder result = new StringBuilder();

            UserDto[] deserializedUsers = JsonConvert.DeserializeObject<UserDto[]>(jsonString);

            var users = new List<User>();

            foreach (var userDto in deserializedUsers)
            {
                bool isValid = !String.IsNullOrWhiteSpace(userDto.Username) &&
                    userDto.Username.Length <= 30 &&
                    !String.IsNullOrWhiteSpace(userDto.Password) &&
                    userDto.Password.Length <= 20 &&
                    !String.IsNullOrWhiteSpace(userDto.ProfilePicture);

                var picture = context.Pictures.FirstOrDefault(p => p.Path == userDto.ProfilePicture);

                bool userExists = users.Any(u => u.Username == userDto.Username);

                if (!isValid || picture == null || userExists)
                {
                    result.AppendLine(errorMsg);
                    continue;
                }

                var user = Mapper.Map<User>(userDto);
                user.ProfilePicture = picture;

                users.Add(user);
                result.AppendLine(string.Format(successMsg, $"User {user.Username}"));
            }

            context.Users.AddRange(users);
            context.SaveChanges();
            return result.ToString().Trim();
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            var deserializedFollowers = JsonConvert.DeserializeObject<UserFollowerDto[]>(jsonString);

            StringBuilder result = new StringBuilder();

            var followers = new List<UserFollower>();

            foreach (var dto in deserializedFollowers)
            {
                int? userId = context.Users.FirstOrDefault(u => u.Username == dto.User)?.Id;
                int? followerId = context.Users.FirstOrDefault(u => u.Username == dto.Follower)?.Id;

                if (userId == null || followerId == null)
                {
                    result.AppendLine(errorMsg);
                    continue;
                }

                bool alreadyFollowed = followers.Any(f => f.UserId == userId && f.FollowerId == followerId);

                if (alreadyFollowed)
                {
                    result.AppendLine(errorMsg);
                    continue;
                }

                var userFollower = new UserFollower()
                {
                    UserId = userId.Value,
                    FollowerId = followerId.Value
                };

                followers.Add(userFollower);
                result.AppendLine(string.Format(successMsg, $"Follower {dto.Follower} to User {dto.User}"));
            }

            context.UserFollowers.AddRange(followers);
            context.SaveChanges();

            return result.ToString().Trim();
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var xDoc = XDocument.Parse(xmlString);

            var elements = xDoc.Root.Elements();

            StringBuilder result = new StringBuilder();

            var posts = new List<Post>();

            foreach (var element in elements)
            {
                string caption = element.Element("caption")?.Value;
                string username = element.Element("user")?.Value;
                string picturePath = element.Element("picture")?.Value;

                bool inputIsValid = !String.IsNullOrWhiteSpace(caption) &&
                                    !String.IsNullOrWhiteSpace(username) &&
                                    !String.IsNullOrWhiteSpace(picturePath);

                if (!inputIsValid)
                {
                    result.AppendLine(errorMsg);
                    continue;
                }

                int? userId = context.Users.FirstOrDefault(u => u.Username == username)?.Id;
                int? pictureId = context.Pictures.FirstOrDefault(p => p.Path == picturePath)?.Id;

                if (userId == null || pictureId == null)
                {
                    result.AppendLine(errorMsg);
                    continue;
                }

                var post = new Post()
                {

                    Caption = caption,
                    UserId = userId.Value,
                    PictureId = pictureId.Value
                };

                posts.Add(post);
                result.AppendLine(string.Format(successMsg, $"Post {caption}"));
            }

            context.Posts.AddRange(posts);
            context.SaveChanges();

            return result.ToString().Trim();
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var xDoc = XDocument.Parse(xmlString);
            var elements = xDoc.Root.Elements();

            StringBuilder result = new StringBuilder();
            var comments = new List<Comment>();

            foreach (var element in elements)
            {
                string content = element.Element("content")?.Value;
                string userName = element.Element("user")?.Value;
                string postIdString = element.Element("post")?.Attribute("id")?.Value;

                bool noNullInput = !String.IsNullOrWhiteSpace(content) &&
                                 !String.IsNullOrWhiteSpace(userName) &&
                                 !String.IsNullOrWhiteSpace(postIdString);

                if (!noNullInput)
                {
                    result.AppendLine(errorMsg);
                    continue;
                }

                int postId = int.Parse(postIdString);

                int? userId = context.Users.FirstOrDefault(u => u.Username == userName)?.Id;
                bool postExists = context.Posts.Any(p => p.Id == postId);

                if (userId == null || !postExists)
                {
                    result.AppendLine(errorMsg);
                    continue;
                }

                var comment = new Comment()
                {
                    Content = content,
                    UserId = userId.Value,
                    PostId = postId
                };

                comments.Add(comment);
                result.AppendLine(string.Format(successMsg, $"Comment {content}"));
            }

            context.Comments.AddRange(comments);
            context.SaveChanges();

            return result.ToString().Trim();
        }
    }
}
