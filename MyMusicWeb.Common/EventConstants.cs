using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWeb.Common
{
    public class EventConstants
    {
        public const int EventNameMaxLength = 50;
        public const int EventLengthMinLength = 5;
        public const int EventDescriptionMaxLength = 500;
        public const int EventDescriptionMinLength = 5;
        public const string DateFormat = "dd-MM-yyyy";
        //Genra
        public const int GenraNameMaxLength = 50;
        public const int GenraNameMinLength = 2;
        //Location
        public const int LocationAdressMaxLength = 500;
        public const int LocationAdressMinLength = 5;
        public const int LocationNameMaxLength = 100;
        public const int LocationNameMinLength = 2;

    }
}
