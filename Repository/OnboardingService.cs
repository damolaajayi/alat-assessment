using Contracts;
using Entities.Context;
using Entities.Models;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Repository
{
    public class OnboardingService : OnboardingInterface
    {
        private readonly RepositoryContext _db;
        private readonly OTPInterface _otpInterface;
        private readonly ILoggerManager _logger;
        private IConfiguration _configuration;

        public OnboardingService(RepositoryContext db, OTPInterface otpInterface, ILoggerManager logger, IConfiguration configuration)
        {
            _db = db;
            _otpInterface = otpInterface;
            _logger = logger;
            _configuration = configuration;
        }
        public async Task<ResponseModel> CreateNewUser(Onboard onboard)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
               _logger.LogInformation("Creating new user");
               var sendandvalidateOTP = await _otpInterface.GenerateAndValidateToken(onboard.PhoneNumber);
               if(sendandvalidateOTP.isSuccessful)
               {
                    await _db.Onboarding.AddAsync(onboard);
                    await _db.SaveChangesAsync();
                    resp.responseCode = "00";
                    resp.isSuccessful = true;
                    resp.responseMessage = "User successfully unboarded";
               }
               else
               {
                   resp.responseCode = "03";
                   resp.isSuccessful = false;
                   resp.responseMessage = "OTP could not be validated";
               }
               return resp;           

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating user" + ex.Message);
                resp.responseCode = "03";
                resp.isSuccessful = false;
                resp.responseMessage = "User not successfully unboarded";
                return resp;
            }
            
        }

        public async Task<List<Onboard>> GetAllUsers()
        {
            try
            {
                _logger.LogInformation("Getting all user");
                return await _db.Onboarding.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting all user" + ex.Message + ex.StackTrace );
                return null;
                
            }     
            
        }

        public async Task<BankEnvelope> GetAllBanks()
        {
            HttpClient client = new HttpClient();
            var tokenType = "Ocp-Apim-Subscription-Key";
            var token = _configuration.GetSection("Token").GetValue<string>("ApiKey");
            client.DefaultRequestHeaders.Add(tokenType, token);
            string uri = $"https://wema-alatdev-apimgt.azure-api.net/alat-test/api/Shared/GetAllBanks";
            HttpResponseMessage response = await client.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<BankEnvelope>(content);
            return resp;
        }

        
    }
}