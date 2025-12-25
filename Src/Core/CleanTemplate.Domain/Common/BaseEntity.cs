using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Domain.Common;

public  class BaseEntity<TKey>:AuditableEntity   
{
    public TKey Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}
