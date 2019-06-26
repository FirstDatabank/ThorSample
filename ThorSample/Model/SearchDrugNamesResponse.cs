using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ThorSample.Model
{
    [DataContract]
    public class SearchDrugNamesResponse
    {
        public SearchDrugNamesResponse(string ServiceCallId = default(string), int? Limit = default(int?),
            int? Offset = default(int?), int? TotalResultCount = default(int?),
            List<DrugName> Items = default(List<DrugName>))
        {
            this.ServiceCallId = ServiceCallId;
            this.limit = Limit;
            this.offset = Offset;
            this.TotalResultCount = TotalResultCount;
            this.Items = Items;
        }

        /// <summary>
        /// Returns the unique identifier for each service call.
        /// </summary>
        /// <value>Returns the unique identifier for each service call.</value>
        [DataMember(Name = "ServiceCallId", EmitDefaultValue = false)]
        public string ServiceCallId { get; set; }

        /// <summary>
        /// Returns the maximum number of results that are returned; format: int32
        /// </summary>
        /// <value>Returns the maximum number of results that are returned; format: int32</value>
        [DataMember(Name = "Limit", EmitDefaultValue = false)]
        public int? limit { get; set; }

        /// <summary>
        /// Returns the index page number of the data that is returned; format: int32
        /// </summary>
        /// <value>Returns the index page number of the data that is returned; format: int32</value>
        [DataMember(Name = "Offset", EmitDefaultValue = false)]
        public int? offset { get; set; }

        /// <summary>
        /// Returns the total number of available results; format: int32
        /// </summary>
        /// <value>Returns the total number of available results; format: int32</value>
        [DataMember(Name = "TotalResultCount", EmitDefaultValue = false)]
        public int? TotalResultCount { get; set; }

        /// <summary>
        /// Gets or Sets Items
        /// </summary>
        [DataMember(Name = "Items", EmitDefaultValue = false)]
        public List<DrugName> Items { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SearchDevicesResponse {\n");
            sb.Append("  ServiceCallId: ").Append(ServiceCallId).Append("\n");
            sb.Append("  Limit: ").Append(limit).Append("\n");
            sb.Append("  Offset: ").Append(offset).Append("\n");
            sb.Append("  TotalResultCount: ").Append(TotalResultCount).Append("\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
