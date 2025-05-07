using System.Text.RegularExpressions;

namespace EliteBA.Utilities;

public class Validators
{
    /*
     * Validates that the email input is not empty and in valid format via Regex.
     * Returns the email if valid, or a 'null' if invalid.
     */
    public static string? ValidateEmail(string email)
    {
        if (!string.IsNullOrWhiteSpace(email) ||
            Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
        {
            return email.ToLower();
        }

        Console.WriteLine("Invalid email format.Please try again.");
        return null;
    }

    /*
     * Validates that the phone number is not empty and matches the Nigerian telephony system via Regex.
     * Returns the phone number if valid, or a 'null' if invalid.
     */
    public static string? ValidatePhoneNumber(string phoneNumber)
    {
        if (!string.IsNullOrWhiteSpace(phoneNumber) ||
            Regex.IsMatch(phoneNumber, @"^0(70[1-9]|80[2-9]|81[0-9]|90[1-9])[0-9]{7}$"))
        {
            return phoneNumber;
        }

        Console.WriteLine("Invalid phone number format.Please use acceptable Nigerian format.");
        return null;
    }
}