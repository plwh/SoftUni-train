namespace PhotoShare.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;
    using System.Text;

    public class PrintFriendsListCommand 
    {
        // PrintFriendsList <username>
        public static string Execute(string[] data)
        {
            string username = data[1];
            StringBuilder result = new StringBuilder();

            using (var db = new PhotoShareContext())
            {
                User target = db.Users
                    .Include(u => u.FriendsAdded)
                    .ThenInclude(fa => fa.Friend)
                    .FirstOrDefault(u => u.Username == username);

                if (target == null)
                {
                    throw new ArgumentException($"User {username} not found!");
                }

                if (target.FriendsAdded.Count == 0)
                {
                    return "No friends for this user. :(";
                }

                result.AppendLine("Friends");

                foreach (var friendship in target.FriendsAdded)
                {
                    string friendUsername = friendship.Friend.Username;

                    result.AppendLine($"-{friendUsername}");
                }
            }

            return result.ToString().Trim();
        }
    }
}
