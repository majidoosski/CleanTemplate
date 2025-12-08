using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.DTOs.Logging;

public class RequestLog
{
    /// <summary>
    /// 
    /// </summary>
    public string Application { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime? RequestTimestamp { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string RequestUri { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string RequestMethod { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string RequestBody { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string IpAddress { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string RequestHeaders { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string RequestContentType { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Machine { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string User { get; set; }


    public override string ToString()
    {
        return base.ToString();
    }
}
