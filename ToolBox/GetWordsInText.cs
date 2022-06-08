using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToolBox
{
    public class GetWordsInText
    {
        private HashSet<string> _words = new HashSet<string>();
        public HashSet<string> words 
        {
            get { return _words; } 
            set { _words = value; }
        }
        public GetWordsInText(string b) 
        {
            if (b.Length != 0) 
            {
                string[] lines = System.IO.File.ReadAllLines(@b);
                foreach (string a in lines) 
                {
                    var sb = new StringBuilder();
                    foreach (char c in a)
                    {
                        if (!char.IsPunctuation(c))
                            sb.Append(c);
                    }
                    string ret;
                    ret = sb.ToString();
                    ret = ret.Replace("\n", " ").Replace("\t", " ").Replace("\r", " ");
                    ret = DeleteChineseWordAndNumbers(ret);
                    string[] splitIt = ret.Split(' ');
                    foreach (string i in splitIt)
                    {
                        words.Add(i.ToLower());
                    }
                }
            }
            foreach (string i in words) 
            {
                if (!Regex.Match(i, @"^[A-Za-z]+$").Success) 
                {
                    words.Remove(i);
                }
            }
        }

        /// <summary>
        /// 去除掉中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DeleteChineseWordAndNumbers(string str)
        {
            string retValue = str;
            retValue = retValue.Replace(".", " ").Replace("]", " ").Replace(":", " ").Replace("?", " ").Replace("。", " ").Replace("!", " ");
            if (System.Text.RegularExpressions.Regex.IsMatch(str, @"[\u4e00-\u9fbb]"))
            {
                retValue = string.Empty;
                var strsStrings = str.ToCharArray();
                for (int index = 0; index < strsStrings.Length; index++)
                {
                    if (strsStrings[index] >= 0x4e00 && strsStrings[index] <= 0x9fa5)
                    {
                        continue;
                    }
                    retValue += strsStrings[index];
                }
            }
            retValue = Regex.Replace(retValue, @"^[\d-]*\s*", "", RegexOptions.Multiline);
            
            return retValue;
        }

    }
}
