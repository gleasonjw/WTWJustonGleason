
namespace WTW.Ioc.Test.TestHelpers
{
    public class UsersController : IUsersController
    {
        public UsersController(ICalculator calulator, IEmailService emailService)
        {

        }

        public UsersController(ICalculator calulator, IEmailService emailService, IDataService dataService)
        {

        }
    }
}
