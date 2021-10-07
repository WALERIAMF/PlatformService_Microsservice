using System;

namespace PlataformService.MsgContracts
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
