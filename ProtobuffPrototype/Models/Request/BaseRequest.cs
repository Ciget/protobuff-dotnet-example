using System;
using ProtoBuf;

namespace ProtobuffPrototype.Models.Request
{
    [ProtoContract]
    [ProtoInclude(10, typeof(CreateClientRequest))]
    public class BaseRequest
    {
        [ProtoMember(1)]
        public Guid? RequestId { get; set; }
        [ProtoMember(2)]
        public string Culture{ get; set; }
    }
}
