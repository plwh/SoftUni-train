namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class ShareAlbumCommand
    {
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public static string Execute(string[] data)
        {
            int albumId = int.Parse(data[1]);
            string username = data[2];
            string role = data[3];

            Album targetAlbum;

            using (var db = new PhotoShareContext())
            {
                targetAlbum = db.Albums.FirstOrDefault(a => a.Id == albumId);

                if (targetAlbum == null)
                {
                    throw new ArgumentException($"Album {albumId} not found!");
                }

                User targetUser = db.Users.FirstOrDefault(u => u.Username == username);

                if (targetUser == null)
                {
                    throw new ArgumentException($"User {username} not found!");
                }

                object targetRole;

                if(!Enum.TryParse(typeof(Role), role, out targetRole))
                {
                    throw new ArgumentException("Permission must be either “Owner” or “Viewer”!");
                }

                targetAlbum.AlbumRoles.Add(new AlbumRole() { AlbumId = albumId, UserId = targetUser.Id, Role = (Role)targetRole});
                db.SaveChanges();
            }

            return $"Username {username} added to album {targetAlbum.Name} ({role})";
        }
    }
}
