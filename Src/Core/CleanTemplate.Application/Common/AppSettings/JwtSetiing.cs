using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.Common.AppSettings
{
    public class JwtSetiing
    {
        public string AccessTokenKey { get; set; }

        public string RefreshTokenkey { get; set; }

        public double AccessTokenExpirationMinutes { get; set; }

        public double RefreshTokenExpirationMinutes { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

    }
}
