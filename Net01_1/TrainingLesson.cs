using Net01_1.Enums;
using Net01_1.Materials;
using System;

namespace Net01_1
{
    class TrainingLesson : TrainingBase, IVersionable, ICloneable
    {

        const int MAX_MATERIALS_ARRAY_LENGTH = 10;
        TrainingMaterial[] materials;
        byte[] version;

        public TrainingLesson()
        {
            materials = new TrainingMaterial[MAX_MATERIALS_ARRAY_LENGTH];
        }

        public TrainingLesson(TrainingMaterial[] materials, byte[] version = null, byte[] id = null) : base(id)
        {
            this.materials = materials;
            this.version = version;
        }

        public void AddMaterial(TrainingMaterial addMaterial)
        {
            try
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    if (materials[i] == null)
                    {
                        materials[i] = addMaterial;
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

            for (int i = 0; i < materials.Length; i++)
            {
                if (materials[i] is VideoMaterial)
                {
                    typeLesson = TypeLesson.VideoLesson;
                    break;
                }
            }

            return typeLesson;
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

        public object Clone()
        {
            return new TrainingLesson(materials, version, Id);
        }
    }
}
