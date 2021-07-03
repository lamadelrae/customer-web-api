using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerWebApi.Infrastructure.CrossCutting
{
    public static class Extensions
    {
        public static int ToInt(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        public static bool IsNullOrEmpty(this string inputString)
        {
            return string.IsNullOrEmpty(inputString);
        }

        public static bool IsNotNullOrEmpty(this string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        public static Guid GetGuid(this Guid guid) => guid.Equals(Guid.Empty) ? Guid.NewGuid() : guid;

        public static void IsValid<T>(this T obj)
        {
            ICollection<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
            if (!isValid)
            {
                string errors = string.Empty;
                foreach (var error in results)
                    errors += $"{error}\n";

                throw new ArgumentException(errors);
            }
        }
    }
}
