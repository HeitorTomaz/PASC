using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public string Description { get; set; }
        public DateTime Created  { get; set; }
        public DateTime? Deleted { get; set; }
        public String Type { get; set; }
        

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public IList<Answer> Answers { get; set; }
    
    }
}
