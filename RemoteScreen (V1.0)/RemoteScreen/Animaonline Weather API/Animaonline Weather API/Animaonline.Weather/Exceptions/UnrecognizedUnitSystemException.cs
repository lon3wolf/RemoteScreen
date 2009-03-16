using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animaonline.Weather.Exceptions
{
    public class UnrecognizedUnitSystemException : Exception
    {
        private string unitSystem;
        public string UnitSystem
        {
            get { return unitSystem; }
            set { unitSystem = value; }
        }

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The error message that explains the reason for the exception, or an empty string("").
        /// </returns>
        public override string Message
        {
            get
            {
                return unitSystem + " is an unrecognized UnitSystem , please report the bug"; //CONSTANT ERROR MESSAGE + ERROR CODE [TODO]
            }
        }
    }
}
