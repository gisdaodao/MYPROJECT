using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace 股票新闻
{
   [DataContract]
    public class Info
    {
        [DataMember]
        public string text { get; set; }
        [DataMember]
        public string info { get; set; }
        [DataMember]
        public string dataurl { get; set; }
        [DataMember]
        public string picurl { get; set; }
        public override string ToString()
        {
            return string.Empty;
        }
    } 
}
