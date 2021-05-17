using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Other { get; set; }
        public DateTime Created { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

        public int OptionId { get; set; }
        public Option Option { get; set; }

    }
}
