using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class GenID
    {
        private static GenID Instance ;

        private GenID()
        {

        }

        public static GenID GetInstance()
        {
            if(Instance == null)
            {
                Instance = new GenID();
            }
            return Instance;
        }

        public string genIDAuto(string s)
        {
            string prefix = "";
            string suffix = "";
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i+1] >= '0' && s[i+1] <= '9')
                {
                    prefix = s.Substring(0, i+1);
                    suffix = s.Substring(i + 1);
                    break;
                }
            }
            int sfPlus;
            int.TryParse(suffix, out sfPlus);
            return prefix + (++sfPlus);
        }


    }
}
