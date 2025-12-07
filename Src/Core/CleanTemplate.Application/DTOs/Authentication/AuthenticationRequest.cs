using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.DTOs.Authentication;

public class AuthenticationRequest
{
    public string UserName { get; set; }

    public string PassWord { get; set; }
}
