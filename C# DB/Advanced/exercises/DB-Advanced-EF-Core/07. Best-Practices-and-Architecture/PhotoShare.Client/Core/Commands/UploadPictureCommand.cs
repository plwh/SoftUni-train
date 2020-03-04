namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class UploadPictureCommand
    {
        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public static string Execute(string[] data)
        {
            string albumName = data[1];
            string pictureTitle = data[2];
            string pictureFilePath = data[3];

            using (var db = new PhotoShareContext())
            {
                Album targetAlbum = db.Albums.Where(a => a.Name == albumName).FirstOrDefault();

                if (targetAlbum == null)
                {
                    throw new ArgumentException($"Album {albumName} not found!");
                }

                Picture pictureToAdd = new Picture() { Album = targetAlbum, Title = pictureTitle, Path = pictureFilePath };

                db.Pictures.Add(pictureToAdd);
            }

            return $"Picture {pictureTitle} added to {albumName}!";
        }
    }
}
