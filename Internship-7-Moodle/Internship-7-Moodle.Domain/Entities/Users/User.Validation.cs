using Internship_7_Moodle.Domain.Common.Helper;
using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;

namespace Internship_7_Moodle.Domain.Entities.Users;

public partial class User
{
      private ValidationResult Validate()
    {
        var validationResult = new ValidationResult();
        
        CheckFirstName(validationResult);
        
        CheckLastName(validationResult);
        
        CheckEmail(validationResult);
        
        CheckBirthDate(validationResult);
        
        CheckPassword(validationResult);
        
        return validationResult;
    }

    private void CheckFirstName(ValidationResult validationResult)
    {
        if (string.IsNullOrWhiteSpace(FirstName))
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(User),"Ime korisnika"));
            return;
        }

        if(FirstName.Length>MaxFirstNameLength)
            validationResult.Add(EntityValidation.UserValidation.MaxFirstNameLength);      
        
        if (!NameRegex.IsMatch(FirstName))
            validationResult.Add(EntityValidation.UserValidation.NameFormat);
        
        
    }
    
    private void CheckLastName(ValidationResult validationResult)
    {
        if (string.IsNullOrWhiteSpace(LastName))
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(User),"Prezime korisnika"));
            return;
        }

        if(LastName.Length>MaxLastNameLength)
            validationResult.Add(EntityValidation.UserValidation.MaxLastNameLength);

        if (!NameRegex.IsMatch(LastName))
            validationResult.Add(EntityValidation.UserValidation.NameFormat);
    }

    private void CheckEmail(ValidationResult validationResult)
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(User),"Email korisnika"));
            return;
        }
        
        if(!CheckEmailFormat(Email))
            validationResult.Add(EntityValidation.UserValidation.EmailFormat);
        
        if(Email.Length>MaxEmailLength)
            validationResult.Add(EntityValidation.UserValidation.EmailLength);
    }

    private static bool CheckEmailFormat(string email)
    {
        return EmailRegex.IsMatch(email);
    }

    private void CheckBirthDate(ValidationResult validationResult)
    {
        var isAdult = DomainHelper.IsAdult(BirthDate);
        var isTooOld = DomainHelper.IsTooOld(BirthDate);

        if (BirthDate == null)
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(User),"Datum rođenja korisnika"));
            return;
        }
        
        if (isAdult.HasValue && !isAdult.Value)
            validationResult.Add(EntityValidation.UserValidation.IsNotAdult);
        
        if(isTooOld.HasValue && isTooOld.Value)
            validationResult.Add(EntityValidation.UserValidation.IsTooOld);
    }

    private void CheckPassword(ValidationResult validationResult)
    {
        if (string.IsNullOrWhiteSpace(Password))
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(User),"Lozinka korisnika"));
            return;
        }
        if(Password.Length<MinPasswordLength)
            validationResult.Add(EntityValidation.UserValidation.MinPasswordLength);

        if (!PasswordUpperRegex.IsMatch(Password))
            validationResult.Add(EntityValidation.UserValidation.PasswordMissingUppercase);
        
        if(!PasswordLowerRegex.IsMatch(Password))
            validationResult.Add(EntityValidation.UserValidation.PasswordMissingLowercase);

        if (!PasswordNoSpacesRegex.IsMatch(Password))
            validationResult.Add(EntityValidation.UserValidation.PasswordContainsSpaces);

        if (!PasswordSpecialRegex.IsMatch(Password))
            validationResult.Add(EntityValidation.UserValidation.PasswordMissingSpecialChar);        
    }  
}