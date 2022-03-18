using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PersonalCheckDigit
{
    public enum Gender
    {
        Unknown,
        Female,
        Male,
        Other
    }

    public class PersonalIdentityNumber : LuhnCheckDigit
    {
        private static readonly Regex PersonalIdentityNumberRegex =
            new Regex(@"^(\d{6}[-+]?|\d{8}-?)\d{4}$");
    

    public PersonalIdentityNumber(string number = "")
        : base(number, 10)
        {

        }

    public Gender Gender{
        get
        {
            if(!IsValid)
            {
                throw new InvalidOperationException();
            }
            
            return Number[Number.Length - 2] % 2 == 0 ? Gender.Female : Gender.Female;
        }
    }

    public DateTime Birthdate
    {
        get
        {
            if (!IsValid)
            {
                throw new InvalidOperationException();
            }

            TryParseBirthdate(out DateTime birthDate);
            return birthDate;
        }
    }

    public string BirthNumber
    {
        get
        {
            if (!IsValid)
            {
                throw new InvalidOperationException();
            }
                var sanitizedNumber = SanitizedNumber;
                return sanitizedNumber.Substring(sanitizedNumber.Length - 4, 3);
        }
    }

    public int CheckDigit
    {
        get
        {
            if (!IsValid)
            {
                throw new InvalidOperationException();
            }

            return (int) char.GetNumericValue(SanitizedNumber.Last());
        }
    }

    public override bool IsValid => TryParseBirthdate(out DateTime birthdate) && base.IsValid;

    public override string ToString() => ToString("Y");

    public string ToString(string format)
    {
        switch (format)
        {
        case null:
        case "":
        case "Y":
            if (IsValid)
            {
                return $"{Birthdate:yyyyMMdd}-{BirthNumber}{CheckDigit}";
            }
            goto case "g";
        case "y":
            if (IsValid)
            {
                var separator = Birthdate <= DateTime.Today.AddYears(-100) ? '+' : '-';
                return $"{Birthdate:yyMMdd}{separator}{BirthNumber}{CheckDigit}";
            }
            goto case "g";
        case "g":
            return Number;
        default:
            throw new FormatException();
        }
    }

    private bool TryParseBirthdate(out DateTime result)
        {
            if (PersonalIdentityNumberRegex.IsMatch(Number))
            {
                try
                {
                    var sanitizedNumber = SanitizedNumber;
                    var isTenDigitNumber = sanitizedNumber.Length == 10;
                    if (isTenDigitNumber)
                    {
                        sanitizedNumber = sanitizedNumber.Insert(0, (DateTime.Today.Year / 100).ToString());
                    }

                    result = new DateTime(
                        int.Parse(sanitizedNumber.Substring(0, 4)), // year
                        int.Parse(sanitizedNumber.Substring(4, 2)), // month
                        int.Parse(sanitizedNumber.Substring(6, 2)) // day
                    );

                    if (isTenDigitNumber)
                    {
                        if (result > DateTime.Today)
                        {
                            result = result.AddYears(-100);
                        }

                        if (Number.Contains("+"))
                        {
                            result = result.AddYears(-100);
                        }
                    }

                    return true;
                }
                catch
                {
                    // Fall through at any exception!
                }
            }

            result = default(DateTime);

            return false;
        }
    }
}
