using Net01_1.Enums;
using Net01_1.Materials;
using System;

namespace Net01_1
{
    class TrainingLesson : TrainingBase, IVersionable, ICloneable
    {
        const byte MAX_VERSION_LENGTH = 8;
        const int MAX_MATERIALS_LENGTH = 10;
        const byte START_COPY_FROM_INDEX = 0;
        TrainingMaterial[] _materials = new TrainingMaterial[MAX_MATERIALS_LENGTH];
        byte[] _version = new byte[MAX_VERSION_LENGTH];

        public TrainingLesson() { }

        public TrainingLesson(TrainingMaterial[] materials, byte[] version = null, byte[] id = null) : base(id)
        {
            materials.CopyTo(_materials, START_COPY_FROM_INDEX);
            _version = version;
        }

        public void AddMaterial(TrainingMaterial addMaterial)
        {
            try
            {
                for (int i = 0; i < _materials.Length; i++)
                {
                    if (_materials[i] == null)
                    {
                        _materials[i] = addMaterial;
                        break;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new Exception("The maximum amount of materials has been exceeded!");
            }
        }

        public TypeLesson GetTypeLesson()
        {
            TypeLesson typeLesson = TypeLesson.TextLesson;

            for (int i = 0; i < _materials.Length; i++)
            {
                if (_materials[i] is VideoMaterial)
                {
                    typeLesson = TypeLesson.VideoLesson;
                    break;
                }
            }

            return typeLesson;
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

        public object Clone()
        {
            TrainingMaterial[] materials = new TrainingMaterial[MAX_MATERIALS_LENGTH];
            byte[] version = new byte[MAX_VERSION_LENGTH];
            byte[] id = new byte[Id.Length];

            _materials.CopyTo(materials, START_COPY_FROM_INDEX);
            _version.CopyTo(version, START_COPY_FROM_INDEX);
            Id.CopyTo(id, START_COPY_FROM_INDEX);

            return new TrainingLesson(materials, version, id);
        }
    }
}
