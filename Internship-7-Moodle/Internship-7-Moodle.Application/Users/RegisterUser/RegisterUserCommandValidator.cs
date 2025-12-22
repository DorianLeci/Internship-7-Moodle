using FluentValidation;
using Internship_7_Moodle.Domain.Entities.Users;

namespace Internship_7_Moodle.Application.Users.RegisterUser;

public class RegisterUserCommandValidator:AbstractValidator<RegisterUserCommand>
{
    private const string NameRegexString = @"^\p{L}+$";
    private const string EmailRegexString=@"^[^@]{1,}@[^@]{2,}\.[^@]{3,}$";
    public RegisterUserCommandValidator()
    {
        RuleFor(u => u.FirstName).NotEmpty().WithMessage("Ime korisnika je obavezno")
            .Matches(NameRegexString).WithMessage("Ime korisnika ne smije sadržavati brojeve ili specijalne znakove");
        
        RuleFor(u=>u.LastName).NotEmpty().WithMessage("Prezime korisnika je obavezno")
            .Matches(NameRegexString).WithMessage("Prezime korisnika ne smije sadržavati brojeve ili specijalne znakove");

        RuleFor(u => u.Email).NotEmpty().WithMessage("Email je obavezan")
            .Matches(EmailRegexString).WithMessage("Email je neispravnog formata");
        
        RuleFor(u=>u.Password).NotEmpty().WithMessage("Lozinka je obavezna")
            .MinimumLength(8).WithMessage("Lozinka mora biti duga barem 8 znakova.")
            .Matches("[A-Z]").WithMessage("Lozinka mora imati barem jedno veliko slovo.")
            .Matches("[a-z]").WithMessage($"Loziknka mora imati barem jedno malo slovo.")
            .Matches(@"\d").WithMessage("Lozinka mora imati barem jednu brojku.")
            .Matches("[!@#$%^&*]").WithMessage("Lozinka mora imati barem jedan specijalni znak.")
            .Matches(@"^\S*$").WithMessage("Lozinka ne smije imati razmake");
        
    }
}