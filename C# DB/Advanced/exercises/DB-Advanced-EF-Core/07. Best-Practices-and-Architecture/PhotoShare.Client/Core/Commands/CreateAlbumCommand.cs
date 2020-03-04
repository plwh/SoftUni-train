namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CreateAlbumCommand
    {
        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public static string Execute(string[] data)
        {
            string username = data[1];
            string albumTitle = data[2];
            string bgColor = data[3];

            string[] tagsToAdd = data.Skip(4).Take(data.Length - 3).ToArray();
            Color backgroundColor;
            ICollection<Tag> albumTags = new HashSet<Tag>();

            using (var db = new PhotoShareContext())
            {
                if (!db.Users.Any(u => u.Username == username) || db.Users.FirstOrDefault(u => u.Username == username).IsDeleted == true)
                {
                    throw new ArgumentException($"User {username} not found!");
                }

                if (db.Albums.Any(a => a.Name == albumTitle))
                {
                    throw new ArgumentException($"Album {albumTitle} exists!");
                }

                if (!Enum.IsDefined(typeof(Color), bgColor))
                {
                    throw new ArgumentException($"Color {bgColor} not found!");
                }

                backgroundColor = (Color)Enum.Parse(typeof(Color), bgColor); 
                
                foreach (var name in tagsToAdd)
                {
                    string tagName = "#" + name;

                    Tag tagToAdd = db.Tags.FirstOrDefault(t => t.Name == tagName);

                    if (tagToAdd == null)
                    {
                        throw new ArgumentException("Invalid tags!");
                    }

                    albumTags.Add(tagToAdd);
                }

                Album albumToAdd = new Album()
                {
                    Name = albumTitle,
                    IsPublic = true,
                    BackgroundColor = backgroundColor
                };

                db.Albums.Add(albumToAdd);
                db.SaveChanges();

                int userId = db.Users.First(u => u.Username == username).Id;
                int albumId = albumToAdd.Id;

                AlbumRole role = new AlbumRole() {UserId = userId, AlbumId = albumToAdd.Id, Role = Role.Owner};
                albumToAdd.AlbumRoles.Add(role);

                foreach (var tag in albumTags)
                {
                    albumToAdd.AlbumTags.Add(new AlbumTag() {AlbumId = albumToAdd.Id, TagId = tag.Id});
                }

                db.SaveChanges();
            }

            return $"Album {albumTitle} successfully created!";
        }
    }
}
