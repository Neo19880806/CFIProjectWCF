using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CFIWCFServiceLiabrary.Model
{
    [DataContract]
    public class SubjectDetail
    {
        [DataMember]
        public String CRN { get; set; }
        [DataMember]
        public String SubjectCode { get; set; }
        [DataMember]
        public String CompetencyName { get; set; }
        [DataMember]
        public String StartDate { get; set; }
        [DataMember]
        public String EndDate { get; set; }
        [DataMember]
        public String DayOfWeek { get; set; }
        [DataMember]
        public String Time { get; set; }
        [DataMember]
        public String Room { get; set; }
        [DataMember]
        public String Lecturer { get; set; }
        [DataMember]
        public String Campus { get; set; }
    }
}
