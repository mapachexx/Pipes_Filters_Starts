using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel.Filters
{
    public class FilterTwitter : IFilter
    {
    
        private readonly string Text;
        
        
        private readonly FilterPersistente FilterPersister;

        private readonly TwitterImage TwitterImage;

        public FilterTwitter(string textToPublish, string imagePath)
        {
            this.TwitterImage = new TwitterImage();
            this.Text = textToPublish;
            this.FilterPersister = new FilterPersister(imagePath);
        }

        public IPicture Filter(IPicture image)
        {
            IPicture result = this.SavePicture(image);
            this.PublishPicture();
            return result;
        }

        private void PublishPicture()
        {
            Console.WriteLine(this.TwitterImage.PublishToTwitter(this.Text, this.FilterPersister.ImagePath));
        }

        private IPicture SavePicture(IPicture image)
        {
            return this.FilterPersister.Filter(image);
        }
    }
}