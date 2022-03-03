using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface OnboardingInterface
    {
        Task<ResponseModel> CreateNewUser(string PhoneNumber, Onboard onboard);
        Task<List<Onboard>> GetAllUsers();
        Task<List<BankEnvelope>> GetAllBanks();
    }
}
