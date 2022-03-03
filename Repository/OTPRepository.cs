using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Repository
{
    public class OTPRepository : OTPInterface
    {
        public async Task<ResponseModel> GenerateToken(string PhoneNumber)
        {
            ResponseModel resp = new ResponseModel();
            if (!string.IsNullOrEmpty(PhoneNumber) && PhoneNumber.StartsWith("234"))
            {
                PhoneNumber = "0" + PhoneNumber.Substring(3, PhoneNumber.Length - 3);

            }
            var res = SendOTP(PhoneNumber);
            if(res == true)
            {
                resp.isSuccessful = true;
                resp.responseCode = "00";
                resp.responseMessage = "OTP Sent successfully";
            }
            else
            {
                resp.isSuccessful = false;
                resp.responseCode = "03";
                resp.responseMessage = "OTP Sending failed";
            }
            return resp;


        }

        public Task<ResponseModel> ValidateToken(ValidateOTPRequest requestModel)
        {
            throw new NotImplementedException();
        }

        private string Generate_otp()
        {
            char[] charArr = "0123456789".ToCharArray();
            string strrandom = string.Empty;
            Random objran = new Random();
            for (int i = 0; i < 4; i++)
            {
                int pos = objran.Next(1, charArr.Length);
                if (!strrandom.Contains(charArr.GetValue(pos).ToString())) strrandom += charArr.GetValue(pos);
                else i--;
            }
            return strrandom;
        }

        private bool SendOTP(string PhoneNumber)
        {
            string otp = Generate_otp();
            string mobileNo = PhoneNumber;
            string SMSContents = "", smsResult = "";
            SMSContents = otp + " is your One-Time Password, valid for 10 minutes only, Please do not share your OTP with anyone.";
            var resp = SendSMS(mobileNo, SMSContents);
            if(resp == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetResponse(string smsURL)
        {
            try
            {
                WebClient objWebClient = new WebClient();
                System.IO.StreamReader reader = new System.IO.StreamReader(objWebClient.OpenRead(smsURL));
                string ResultHTML = reader.ReadToEnd();
                return ResultHTML;
            }
            catch (Exception)
            {
                return "Fail";
            }
        }

        public static bool SendSMS(string MblNo, string Msg)
        {
            string MainUrl = "SMSAPIURL";
            string UserName = "username";
            string Password = "Password"; 
            string SenderId = "SenderId";
            string strMobileno = MblNo;
            string URL = "";
            URL = MainUrl + "username=" + UserName + "&msg_token=" + Password + "&sender_id=" + SenderId + "&message=" + HttpUtility.UrlEncode(Msg).Trim() + "&mobile=" + strMobileno.Trim() + "";
            string strResponce = GetResponse(URL);
            string msg = "";
            if (strResponce.Equals("Fail"))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
