using Net01_1.Enums;
using System;

namespace Net01_1.Materials
{
    class VideoMaterial : TrainingMaterial, IVersionable
    {
        const byte MAX_VERSION_LENGTH = 8;
        const byte START_COPY_FROM_INDEX = 0;
        string _uriVideo;
        string _uriPicture;
        VideoFormat _videoFormat;
        byte[] _version = new byte[MAX_VERSION_LENGTH];

        public VideoMaterial(string uriVideo, string uriPicture, VideoFormat videoFormat)
        {
            _uriPicture = uriPicture;
            _videoFormat = videoFormat;

            if (uriVideo != null)
            {
                _uriVideo = uriVideo;
            }
            else
            {
                throw new ArgumentNullException("Video URI can't be null!");
            }
        }

        public void SetVersion(byte[] version)
        {
            if (version.Length <= _version.Length)
            {
                version.CopyTo(_version, START_COPY_FROM_INDEX);
            }
            else
            {
                throw new ArgumentException("Maximum version size exceeded.");
            }
        }

        public byte[] GetVersion()
        {
            return _version;
        }
    }
}
