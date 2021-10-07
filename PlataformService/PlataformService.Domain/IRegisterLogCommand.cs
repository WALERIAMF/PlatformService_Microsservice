using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformService.Domain
{
    public interface IRegisterLogCommand
    {
        string Source { get; set; }
        string Name { get; set; }
        DateTime TimeStamp { get; set; }
        string Data { get; set; }
        string Type { get; set; }
    }
}