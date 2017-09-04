using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionClient.Settings
{
    public class Assess
    {
        public int QuestionnaireID;

        public List<AssessResult> Results;

        public Assess()
        {
            Results = new List<AssessResult>();
        }
    }


    public class AssessResult
    {
        public string Name;
        public string Code;
        public string Text;
    }
}
