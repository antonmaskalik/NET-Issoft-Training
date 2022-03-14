using System;
using System.Text;

namespace Net01_1.Materials
{
    class TextMaterial : TrainingMaterial
    {        
        const int MAX_TEXT_LENGTH = 10000;
        string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                if (value.Length <= MAX_TEXT_LENGTH)
                {
                    _text = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid text length.");
                }
            }
        }

        public TextMaterial(string text)
        {
            if (text != null)
            {
                Text = text;
            }
            else
            {
                throw new ArgumentNullException("Text can't be null!");
            }
        }
    }
}
