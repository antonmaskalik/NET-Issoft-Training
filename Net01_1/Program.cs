using Net01_1.Enums;
using Net01_1.Materials;
using System;
using System.Text;

namespace Net01_1
{
    internal class Program
    {
        const string TEXT = "Text";
        const string DESC = "Description of trainingLesson";
        const string URI_VIDEO = "URI of video";
        const string URI_PICTURE = "URI of picture";
        const string URI_CONTENT = "URI of content";
        static void Main(string[] args)
        {
            TextMaterial textMaterial = new TextMaterial(TEXT);
            TrainingLesson trainingLesson = new TrainingLesson();
            trainingLesson.Description = DESC;

            byte[] version = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            VideoFormat videoFormat = VideoFormat.Mp4;
            VideoMaterial videoMaterial = new VideoMaterial(URI_VIDEO, URI_PICTURE, videoFormat);

            videoMaterial.SetVersion(version);
            Console.Write("Version video is ");
            foreach (byte v in videoMaterial.GetVersion())
            {
                Console.Write(v + ".");
            }

            Console.WriteLine();

            TypeLink typeLink = TypeLink.Html;
            LinkMaterial linkMaterial = new LinkMaterial(URI_CONTENT, typeLink);

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
