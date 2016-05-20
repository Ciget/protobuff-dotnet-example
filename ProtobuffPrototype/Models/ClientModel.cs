
using System;
using ProtoBuf;

namespace ProtobuffPrototype.Models
{
    [ProtoContract]
    public class ClientModel 
    {
        [ProtoMember(1)]
        public string FirstName { get; set; }

        [ProtoMember(2)]
        public string LastName { get; set; }

        [ProtoMember(3)]
        public string MiddleName { get; set; }

        [ProtoMember(4)]
        public string Logon{ get; set; }

        [ProtoMember(5)]
        public string Email{ get; set; }

        [ProtoMember(6)]
        public string Password { get; set; }

        [ProtoMember(7)]
        public long CompanyId { get; set; }

        [ProtoMember(8)]
        public DateTime Created{ get; set; }
    }
}