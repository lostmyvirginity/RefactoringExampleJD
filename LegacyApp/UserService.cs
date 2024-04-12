using System;
using LegacyApp.Core;
using LegacyApp.Core.Validators;
using LegacyApp.Core.Validators.Users;


namespace LegacyApp
{
    public class UserService
    {
        public UserService(IInputValidator inputValidator, IClientRepository clientRepository, ICreditLimitService creditLimitService, IUserDataAccessAdapter userDataAccessAdapter, UserFactoryValidator userFactoryValidator, IUserValidator userValidator)
        {
            _inputValidator = inputValidator;
            _clientRepository = clientRepository;
            _creditLimitService = creditLimitService;
            _userDataAccessAdapter = userDataAccessAdapter;
            _userFactoryValidator = userFactoryValidator;
            _userValidator = userValidator;
        }

        private IInputValidator _inputValidator;
        private IClientRepository _clientRepository;
        private ICreditLimitService _creditLimitService;
        private IUserDataAccessAdapter _userDataAccessAdapter;
        private UserFactoryValidator _userFactoryValidator;
        private IUserValidator _userValidator;
        

        
        //Adding to remove/fix that code for example after 2 releases 
        [Obsolete]
        public UserService()
         {
             
            _inputValidator = new InputValidator();
            _clientRepository = new ClientRepository();
            _creditLimitService = new UserCreditService();
            _userDataAccessAdapter = new UserDataAccessAdapter();
            _userFactoryValidator = new UserFactoryValidator();
            _userValidator = new UserValidator();
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
            

            var user = _userFactoryValidator.GetUserFactoryByClientType(client.Type, _creditLimitService).CreateUser(client, dateOfBirth, email, firstName, lastName);

            if (!_userValidator.validateUserCredits(user))
            {
                return false;
            }

            _userDataAccessAdapter.AddUser(user);
            
            return true;
        }
    }
}
