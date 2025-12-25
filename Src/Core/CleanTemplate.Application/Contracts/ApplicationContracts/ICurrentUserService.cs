using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.Contracts.ApplicationContracts;

public interface ICurrentUserService
{
    public int? GetUserId();
}
