
using ProtoBuf;

namespace ProtobuffPrototype.Models.Request
{
    [ProtoContract]
    public class CreateClientRequest :BaseRequest
    {
        [ProtoMember(1)]
        public ClientModel Client { get; set; }

        [ProtoMember(2)]
        public string Value1 { get; set; }

        [ProtoMember(3)]
        public string Value2 { get; set; }

        [ProtoMember(4)]
        public string Value3 { get; set; }
    }
}