using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;


namespace CompAndDel.Filters
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Parte1();
            Parte2();
            
        }

        public static void Parte1()
        {
            // Parte 2

            PipeNull pipeNull = new PipeNull();

            PipeSerial pipeSerial1 = new PipeSerial(new FilterNegative(), pipeNull);

            PipeSerial pipeSerial2 = new PipeSerial(new FilterGreyscale(), pipeSerial1);

            PictureProvider provider = new PictureProvider();

            IPicture picture = provider.GetPicture(@"beer.jpg");

            IPicture modifiedImage = pipeSerial2.Send(picture);

            provider.SavePicture(modifiedImage, @"modifiedBeer1.jpg");
        }
        public static void Parte2()
        {
            // Parte 2


            PictureProvider provider = new PictureProvider();

            PipeNull pipeNull = new PipeNull();

            PipeSerial pipeSerialE = new(new FilterPersistente(@"luke-final2.jpg"), pipeNull);
            PipeSerial pipeSerialD = new(new FilterNegative(), pipeSerialE);
            PipeSerial pipeSerialC = new(new FilterPersistente(@"luke-intermediate2.jpg"), pipeSerialD);
            PipeSerial pipeSerialB = new(new FilterGreyscale(), pipeSerialC);
            PipeSerial pipeSerialA = new(new FilterPersistente(@"luke-initial2.jpg"), pipeSerialB);

            IPicture picture = provider.GetPicture(@"luke.jpg");

            pipeSerialA.Send(picture);
        }
    }
}
