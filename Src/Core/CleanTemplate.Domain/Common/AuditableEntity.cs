using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Domain.Common;

public  class AuditableEntity
{
    public DateTime CreateDate { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
}
