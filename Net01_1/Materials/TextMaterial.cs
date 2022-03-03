using System;
using System.Text;

namespace Net01_1.Materials
{
    class TextMaterial : TrainingMaterial
    {
        StringBuilder text = new StringBuilder(0,100000);

        public TextMaterial(string text)
        {
            if (text != null)
            {
                this.text.Append(text);
            }
            else
            {
                Console.WriteLine("Text can't be null!");
            }
        }
    }
}
