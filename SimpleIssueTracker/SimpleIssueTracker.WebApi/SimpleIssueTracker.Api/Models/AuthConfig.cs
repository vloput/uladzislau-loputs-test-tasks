using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SimpleIssueTracker.Api.Models
{
    public class AuthConfig
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Key { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }
}
