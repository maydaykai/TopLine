using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VoteUserModel : BaseModel
    {
        public string username { get; set; }
        public string nickName { get; set; }
        public string img { get; set; }
        public string desc { get; set; }
    }
}
