using System;
using System.Collections.Generic;

namespace Autocomplete.Extentions
{
    public class ValidateException: Exception
    {
        public string message { get; set; }
        public long errorCode { get; set; }
        public IEnumerable<string> errors { get; set; }

        public ValidateException(string message, long errorCode, IEnumerable<string> errors)
        {
            this.message = message;
            this.errorCode = errorCode;
            this.errors = errors;
        }
    }
}
