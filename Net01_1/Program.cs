using Net01_1.Enums;
using Net01_1.Materials;
using System;
using System.Text;

namespace Net01_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Text";
            StringBuilder desc = new StringBuilder("Description of trainingLesson");

            TextMaterial textMaterial = new TextMaterial(text);
            TrainingLesson trainingLesson = new TrainingLesson();
            trainingLesson.Description = desc;

            string uriVideo = "URI of video";
            string uriPicture = "URI of picture";
            byte[] version = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            VideoFormat videoFormat = VideoFormat.Mp4;
            VideoMaterial videoMaterial = new VideoMaterial(uriVideo, uriPicture, videoFormat);

            videoMaterial.SetVersion(version);
            Console.Write("Version video is ");
            foreach (byte v in videoMaterial.GetVersion())
            {
                Console.Write(v + ".");
            }

            Console.WriteLine();

            string uriContent = "URI of content";
            TypeLink typeLink = TypeLink.Html;
            LinkMaterial linkMaterial = new LinkMaterial(uriContent, typeLink);

            trainingLesson.AddMaterial(textMaterial);
            trainingLesson.AddMaterial(videoMaterial);
            trainingLesson.AddMaterial(linkMaterial);

            Console.WriteLine("Description for trainingLesson is " + trainingLesson.ToString());
            Console.WriteLine("Type of trainingLesson is " + trainingLesson.GetTypeLesson());

            TrainingLesson lessonCopy = (TrainingLesson)trainingLesson.Clone();
            Console.WriteLine("The Training lesson should match with lesson copy: " + trainingLesson.Equals(lessonCopy));

        }
    }
}
