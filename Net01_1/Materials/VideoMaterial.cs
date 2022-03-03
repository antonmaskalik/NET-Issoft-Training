using Net01_1.Enums;
using System;

namespace Net01_1.Materials
{
    class VideoMaterial : TrainingMaterial, IVersionable
    {
        string uriVideo;
        string uriPicture;
        VideoFormat videoFormat;
        byte[] version = new byte[8];

        public VideoMaterial(string uriVideo, string uriPicture, VideoFormat videoFormat)
        {
            this.uriPicture = uriPicture;
            this.videoFormat = videoFormat;

            if (uriVideo != null)
            {
                this.uriVideo = uriVideo;
            }
            else
            {
                Console.WriteLine("Video URI can't be null!");
            }
        }

        public void SetVersion(byte[] version)
        {
            if (version != null)
            {
                this.version = new byte[8];

                for (int i = 0; i < version.Length; i++)
                {
                    if (i < this.version.Length)
                    {
                        this.version[i] = version[i];
                    }
                    else
                    {
                        Console.WriteLine("Maximum version size exceeded!");
                        break;
                    }
                }
            }
        }

        public byte[] GetVersion()
        {
            return version;
        }
    }
}
