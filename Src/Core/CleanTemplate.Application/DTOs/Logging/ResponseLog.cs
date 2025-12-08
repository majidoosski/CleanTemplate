using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.DTOs.Logging;

public class ResponseLog
{
    /// <summary>
    /// 
    /// </summary>
    public DateTime? ResponseTimestamp { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ResponseBody { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int ResponseStatusCode { get; set; }

    public override string ToString()
    {
        return base.ToString();
    }
}
