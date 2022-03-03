using System;
using System.Text;

namespace Net01_1
{
    public abstract class TrainingBase
    {
        readonly byte[] id;
        StringBuilder description = null;

        public byte[] Id
        {
            get { return id; }
        }

        public StringBuilder Description
        {
            get { return description; }
            set
            {
                try
                {
                        description = new StringBuilder(0, 256);
                        description.Append(value);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Number of allowed characters exceeded!");
                }
            }
        }

        public TrainingBase(byte[] id = null)
        {
            this.id = id ?? Guid.NewGuid().ToByteArray();
        }

        public override string ToString()
        {
            if (description != null)
            {
                return description.ToString();
            }
            else
            {
                return "Description is null!";
            }
        }

        public override bool Equals(Object obj)
        {
            TrainingBase idGenerator = (TrainingBase)obj;

            return id == idGenerator.id;
        }
    }
}
