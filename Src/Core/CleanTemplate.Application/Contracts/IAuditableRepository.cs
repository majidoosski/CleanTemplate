using CleanTemplate.Application.DTOs;
using CleanTemplate.Application.Views;
using CleanTemplate.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.Contracts;

public interface IAuditableRepository<TEntity,Tkey> : IApplicationRepository<TEntity,Tkey>
    where TEntity : AuditableEntity
{

}
