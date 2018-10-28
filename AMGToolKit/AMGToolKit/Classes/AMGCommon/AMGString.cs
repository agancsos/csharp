using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMGCommon
{
    class AMGString
    {
        private String value = "";

        public AMGString(String value = "")
        {
            this.value = value;
        }

        public String PadRight(int length, String pad)
        {
            if(value.Length > length)
                return value.Substring(value.Length - length - 1);
            else
            {
                String final = "";
                for(int i = value.Length; i < length; i++)
                {
                    final += pad;
                }
                return value + final;
            }
        }

        public String PadLeft(int length, String pad)
        {
            if (value.Length > length)
                return value.Substring(0, length - 1);
            else
            {
                String final = "";
                for (int i = value.Length; i < length; i++)
                {
                    final += pad;
                }
                return final + value;
            }
        }
    }
}
