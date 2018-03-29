using System.Runtime.Serialization;

namespace SOAP_VELIB
{
    [DataContract]
    public class City
    {
        [DataMember]
        internal string Name { get; set; }
        [DataMember]
        internal string ContractName { get; set; }           
    }
}