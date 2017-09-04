using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestionClient.Settings
{
    public class Questionnaire
    {
        public int QuestionnaireID { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public string GroupName { get; set; }

        public List<Question> Questions { get; set; }

        public Questionnaire()
        {
            Questions = new List<Question> ();
        }
    }

    public class Questionnaires
    {
        public List<Questionnaire> QuestionnaireRoot { get; set; }
    }
}
