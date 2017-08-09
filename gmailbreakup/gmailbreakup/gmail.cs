using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmailbreakup
{
    public class gmail
    {
        public string gmailusername(string mailid)
        {
            string str = mailid;
            if (str != null)
            {

                string userid = null;
                int length = str.IndexOf("@");
                userid = str.Substring(0, length);
                return userid;

            }
            else
            {
                string p = "Enter correct Email ID";
                return p;
            }
        }
    }
}
