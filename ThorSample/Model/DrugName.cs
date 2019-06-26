using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ThorSample.Model
{
    [DataContract]
    public class DrugName
    {
        [DataMember(Order = 1, EmitDefaultValue = true)]
        public int DrugNameID { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = true)]
        public List<DrugNameDescription> DrugNameDescriptions { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = true)]
        public string StatusCode { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = true)]
        public string StatusCodeDesc { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = true)]
        public string NameTypeCode { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = true)]
        public string NameTypeCodeDesc { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = true)]
        public string GenericDrugNameID { get; set; }
    }
}
