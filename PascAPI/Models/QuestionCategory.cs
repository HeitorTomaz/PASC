using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class QuestionCategory
    {
        public int QuestionCategoryId { get; set; }
        public string Description { get; set; }


        public IList<Question> Questions { get; set; }

        public int? CategoryId { get; set; }
        public QuestionCategory Category { get; set; }

        public IList<QuestionCategory> SubCategories { get; set; }
    }
}
