using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public DateTime Created  { get; set; }
        public DateTime? Deleted { get; set; }
        public bool Multiple { get; set; }


        public int QuestionCategoryId { get; set; }
        public QuestionCategory QuestionCategory { get; set; }

        public IList<Option> Options { get; set; }


    }
}
