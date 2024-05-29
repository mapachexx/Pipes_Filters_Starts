using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel.Filters
{
    public class FilterPersistente : IFilter
    {
        
        public string ImagePath;

        private PictureProvider PictureSaver;

        public FilterPersistente(string imagePath)
        {
            this.PictureSaver = new PictureProvider();
            this.ImagePath = imagePath;
        }

        public IPicture Filter(IPicture image)
        {
            IPicture result = image;
            this.SavePicture(image);
            return result;
        }

        private void SavePicture(IPicture image)
        {
            this.PictureSaver.SavePicture(image, this.ImagePath);
        }
    }
}