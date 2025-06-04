Console.Title = "The Password Validator";
Console.Clear();

// ------- Main -------
while (true) {
    PasswordValidator passwordValidator = new PasswordValidator();

    Console.WriteLine("Your password must contain one uppercase letter, one lowercase letter, and one number.");
    Console.WriteLine("Your password cannot contain a capital T or an ampersand(&).");
    Console.Write("Create a Password: ");

    string? password = Console.ReadLine();
    
    if (password == null) break;

        
    if (passwordValidator.IsValidPassword(password)) {
        Console.WriteLine("Password is valid.");
            break;
    }
    else {
        Console.WriteLine("Invalid password. Please try again.");
    }
}

// ------ Class -------

public class PasswordValidator {
    
    public bool IsValidPassword(string password) {

        if (password.Length < 6 || password.Length > 13) {
        return false; 
        }

        bool hasUpper = false;
        bool hasLower = false;
        bool hasDigit = false;
        foreach (char letter in password) {
            if (char.IsUpper(letter)) {
            hasUpper = true;
            }
            else if (char.IsLower(letter)) {
            hasLower = true;
            }
            else if (char.IsDigit(letter)) {
            hasDigit = true;
            }
        }

        if (password.Contains("T") || password.Contains("&")) {
            return false;
        }
        
        return hasUpper && hasLower && hasDigit;
    }
}