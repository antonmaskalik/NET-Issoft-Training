using Net01_1.Enums;
using System;

namespace Net01_1.Materials
{
    class LinkMaterial : TrainingMaterial
    {
        string uriContent;
        TypeLink typeLink;

        public LinkMaterial(string uriContent, TypeLink typeLink)
        {
            this.typeLink = typeLink;

            if (uriContent != null)
            {
                this.uriContent = uriContent;
            }
            else
            {
                Console.WriteLine("Content URI can't be null!");
            }
        }
    }
}
