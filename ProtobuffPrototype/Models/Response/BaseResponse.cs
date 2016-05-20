using ProtoBuf;

namespace ProtobuffPrototype.Models.Response
{
    [ProtoContract]
    [ProtoInclude(10, typeof(CreateClientResponse))]
    public class BaseResponse
    {
        [ProtoMember(1)]
        public string Token { get; set; }
    }
}