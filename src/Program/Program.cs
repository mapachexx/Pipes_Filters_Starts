using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;


namespace CompAndDel
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Parte1();
            
        }

        /// <summary>
        /// Parte 1 
        /// </summary>
        public static void Parte1()
        {


            PipeNull pipeNull = new PipeNull();

            PipeSerial pipeSerial1 = new PipeSerial(new FilterNegative(), pipeNull);

            PipeSerial pipeSerial2 = new PipeSerial(new FilterGreyscale(), pipeSerial1);

            PictureProvider provider = new PictureProvider();

            IPicture picture = provider.GetPicture(@"beer.jpg");

            IPicture modifiedImage = pipeSerial2.Send(picture);

            provider.SavePicture(modifiedImage, @"modifiedBeer1.jpg");
        }
    }
}
