﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CFIWCFServiceLiabrary.Model
{
    [DataContract]
    public class Subject
    {
        [DataMember]
        public string Name { get; set; }
    }
}
