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
        public int status { get; set; }
        public string statusStr{
            get
            {
                switch (status)
                {
                    case -1:
                        return "审核不通过";
                    case 0:
                        return "审核中";
                    case 1:
                        return "审核通过";
                }
                return "审核中";
            }
        }
    }
}
