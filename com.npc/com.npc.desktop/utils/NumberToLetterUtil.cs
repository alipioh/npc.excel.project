using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.utils
{
    class NumberToLetterUtil
    {
        private  Hashtable numberTable; 

        public NumberToLetterUtil() {
            numberTable = new Hashtable();

            int index = (int)'A';
            int lastIndex = index + 26;
            int occurence = 1;
            
            for (int cntr = index; cntr < lastIndex; cntr++) {
                numberTable.Add(occurence, (char)cntr);
                occurence++;
            }
        }

        public String getLetterByNumber(Int32 occurence) {
            return numberTable[occurence].ToString();
        }

        public String getNumberByLetter(String letter) {
            String number = null;

            foreach (Int32 key in numberTable.Keys)
            {
                if (numberTable[key].ToString().Equals(letter))
                {
                    number = key.ToString();
                    break;
                }
            }
            
            return number;
        }
    }
}
