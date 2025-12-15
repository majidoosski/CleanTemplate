using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.Contracts;

public interface ICurrentUserService
{
    public int? GetUserId();
}
