using CleanTemplate.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.Contracts;

public interface IBaseRepository<TEntity, TKey> : IApplicationRepository<TEntity, TKey>
    where TEntity : BaseEntity
{

}
