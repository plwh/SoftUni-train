namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Utilities;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class AddTagToCommand 
    {
        // AddTagTo <albumName> <tag>
        public static string Execute(string[] data)
        {
            string albumName = data[1];
            string tagName = data[2].ValidateOrTransform();

            using (var db = new PhotoShareContext())
            {
                Album targetAlbum = db.Albums.FirstOrDefault(a => a.Name == albumName);
                Tag tagToAdd = db.Tags.FirstOrDefault(t => t.Name == tagName);

                if (targetAlbum == null || tagToAdd == null)
                {
                    throw new ArgumentException("Either tag or album do not exist!");
                }

                targetAlbum.AlbumTags.Add(new AlbumTag() { Album = targetAlbum, Tag = tagToAdd});
                db.SaveChanges();
            }

            return $"Tag {tagName} added to {albumName}!";
        }
    }
}
