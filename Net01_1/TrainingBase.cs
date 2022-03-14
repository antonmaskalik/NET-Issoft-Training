using System;

namespace Net01_1
{
    public abstract class TrainingBase
    {
        const int MAX_DESC_LENGTH = 256;
        readonly byte[] _id;
        string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                if (value.Length <= MAX_DESC_LENGTH)
                {
                    _description = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid description length.");
                }
            }
        }

        public byte[] Id
        {
            get { return _id; }
        }



        public TrainingBase(byte[] id = null)
        {
            _id = id ?? Guid.NewGuid().ToByteArray();
        }

        public override string ToString()
        {
            if (_description != null)
            {
                return _description;
            }
            else
            {
                return "Description is null!";
            }
        }

        public override bool Equals(object obj)
        {
            TrainingBase trainingBase = obj as TrainingBase;

            if (trainingBase != null)
            {
                return IsEqualsId(_id, trainingBase.Id);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        private bool IsEqualsId(byte[] arrayA, byte[] arrayB)
        {
            bool _flag = false;

            if (arrayA.Length == arrayB.Length)
            {
                for (int i = 0; i < arrayA.Length; i++)
                {
                    if (arrayA[i] == (arrayB[i]))
                    {
                        if (i == arrayA.Length - 1)
                        {
                            _flag = true;
                        }
                        continue;
                    }
                    else
                    {
                        _flag = false;
                        break;
                    }
                }
            }
            else
            {
                _flag = false;
            }

            return _flag;
        }
    }
}
