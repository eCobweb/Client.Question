using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestionClient.Settings
{
    public class Question
    {
        public string NO { get; set; }

        public string Text { get; set; }
        
        public List<Option> Options { get; set; }

        public Question()
        {
            Options = new List<Option>();
        }
    }

    public class Option
    {
        public string Text { get; set; }

        public int Weight { get; set; }
    }

    public class OptionJson
    {

        public string Options { get; set; }
        public string Values { get; set; }
    }
    
}
