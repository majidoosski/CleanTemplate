using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Domain.Common;

public abstract class AuditableEntity
{
    public virtual int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public string CreatedBy{ get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
    public bool IsDeleted { get; set; }

}
