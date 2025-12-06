using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.Wrappers;

public class ApplicationResponse<TData>
{
    public ApplicationResponse()
    {
        
    }

    public ApplicationResponse(TData data , string message=null)
    {
        Succeeded = true;
        Message = message;
        Data = data;

    }

    public ApplicationResponse(string message)
    {
        Succeeded=false;
        Message=message;
    }

    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
    public TData Data { get; set; }

}
