using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animaonline.Weather.Exceptions
{
    public class DownloadDataException : Exception
    {
        public DownloadDataException()
        {

        }

        public override string Message
        {
            get
            {
                return "Failed to download data!";
            }
        }
    }
}
