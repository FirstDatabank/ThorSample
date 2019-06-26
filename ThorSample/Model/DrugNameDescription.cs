using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ThorSample.Model
{
    public class DrugNameDescription
    {
        [DataMember]
        public string DrugNameDesc { get; set; }

        [DataMember]
        public string DrugNameLanguage { get; set; }
    }
}
