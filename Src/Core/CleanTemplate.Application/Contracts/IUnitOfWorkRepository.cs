using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.Contracts;

public interface IUnitOfWorkRepository
{
    public Task<int> CommitAsync(CancellationToken cancellationToken);
    public Task RollBack();
}
