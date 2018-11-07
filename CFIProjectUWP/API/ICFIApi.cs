using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFIProjectUWP.Model
{
    public interface ICFIApi
    {
        Task<List<SubjectDetail>> getSubjectDetails(Subject subject);
        Task<List<Subject>> getSubjects();
    }
}
