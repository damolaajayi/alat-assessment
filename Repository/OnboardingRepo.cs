using Contracts;
using Entities.Context;
using Entities.Models;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Repository
{
    public class OnboardingRepo : OnboardingInterface
    {
        private readonly RepositoryContext _db;
        private readonly OTPInterface _otpInterface;
        private readonly ILoggerManager _logger;

        public OnboardingRepo(RepositoryContext db, OTPInterface otpInterface, ILoggerManager logger)
        {
            _db = db;
            _otpInterface = otpInterface;
            _logger = logger;
        }
        public async Task<ResponseModel> CreateNewUser(string PhoneNumber, Onboard onboard)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
               
                if (_db != null)
                {
                    _logger.LogInformation("Creating new user");
                    var re = await _otpInterface.GenerateToken(PhoneNumber);
                    if(re != null)
                    {
                        await _db.Onboarding.AddAsync(onboard);
                        await _db.SaveChangesAsync();
                        resp.responseCode = "00";
                        resp.isSuccessful = true;
                        resp.responseMessage = "User successfully unboarded";
                        return resp;
                    }
                }
                resp.responseCode = "03";
                resp.isSuccessful = false;
                resp.responseMessage = "User not successfully unboarded";
                return resp;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating user" + ex.Message);
                resp.responseCode = "03";
                resp.isSuccessful = false;
                resp.responseMessage = "User not successfully unboarded";
                throw ex;
            }
            
        }

        public async Task<List<Onboard>> GetAllUsers()
        {
            try
            {
                _logger.LogInformation("Getting all user");
                if (_db != null)
                {
                    return await _db.Onboarding.ToListAsync();
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting all user");
                throw ex;
            }     
            
        }

        public async Task<List<BankEnvelope>> GetAllBanks()
        {
            HttpClient client = new HttpClient();
            string uri = $"https://wema-alatdev-apimgt.azure-api.net/alat-test/api/Shared/GetAllBanks";
            HttpResponseMessage response = await client.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<List<BankEnvelope>>(content);
            return resp;
        }

        
    }
}