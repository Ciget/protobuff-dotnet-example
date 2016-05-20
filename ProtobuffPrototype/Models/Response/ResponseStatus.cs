using ProtoBuf;

namespace ProtobuffPrototype.Models.Response
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllFields)]
    public enum ResponseStatus
    {
        Success = 1,
        Failed = 2,
        NotFound = 3,
        Error = 4
    }
}