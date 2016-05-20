using ProtoBuf;

namespace ProtobuffPrototype.Models.Response
{
    [ProtoContract]
    public class CreateClientResponse : BaseResponse
    {
        [ProtoMember(1)]
        public ClientModel Client { get; set; }

        [ProtoMember(2)]
        public ResponseStatus Status { get; set; }

        public CreateClientResponse()
        {
            Status = ResponseStatus.Failed;
        }
    }
}