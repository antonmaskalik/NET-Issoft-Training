using Net01_1.Enums;
using System;

namespace Net01_1.Materials
{
    class LinkMaterial : TrainingMaterial
    {
        string _uriContent;
        TypeLink _typeLink;

        public LinkMaterial(string uriContent, TypeLink typeLink)
        {
            _typeLink = typeLink;

            if (uriContent != null)
            {
                _uriContent = uriContent;
            }
            else
            {
                throw new ArgumentNullException("Content URI can't be null!");
            }
        }
    }
}
