using System;
using LegacyApp.Core;
using LegacyApp.Core.Validators;
using LegacyApp.Core.Validators.Users;

namespace LegacyApp
{
    public class UserService
    {
        private IInputValidator _inputValidator;
        private IClientRepository _clientRepository;
        private ICreditLimitService _creditLimitService;
        private UserDataAccessAdapter _UserDataAccessAdapter;

        
        //Adding to remove/fix that code for example after 2 releases 
        [Obsolete]
        public UserService()
         {
             
            _inputValidator = new InputValidator();
            _clientRepository = new ClientRepository();
            _creditLimitService = new UserCreditService();
            _UserDataAccessAdapter = new UserDataAccessAdapter();
         }
        
        //SRP
        //Extract validation
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!_inputValidator.ValidateName(firstName, lastName))
            {
                return false;
            }

            if (!_inputValidator.ValidateEmail(email))
            {
                return false;
            }

            if (!_inputValidator.ValidateAge(dateOfBirth))
            {
                return false;
            }

            //DIP
            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                    int creditLimit = _creditLimitService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
            }
            else
            {
                user.HasCreditLimit = true;
                    int creditLimit = _creditLimitService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }
            _UserDataAccessAdapter.AddUser(user);
            return true;
        }
    }
}
