using System.Runtime.Serialization;

namespace SOAP_VELIB
{
    [DataContract]
    public class Station
    {
        [DataMember]
        internal string Contract_Name { get; set; }

        [DataMember]
        internal string Name { get; set; }

        [DataMember]
        internal int Available_Velib { get; set; }

        [DataMember]
        internal int Station_Number { get; set; }
        
        [DataMember]
        internal double Latitude { get; set; } 

        [DataMember]
        internal double Longitude { get; set; }
    }
}