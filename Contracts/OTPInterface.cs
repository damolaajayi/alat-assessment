using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface OTPInterface
    {
        Task<ResponseModel> GenerateToken(string PhoneNumber);
        Task<ResponseModel> ValidateToken(ValidateOTPRequest requestModel);

    }
}
