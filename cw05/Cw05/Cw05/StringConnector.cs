using System.Linq;

namespace Cw05
{
    public class StringConnector
    {
        public string Join(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
            {
                return null;
            }
            else
            {
                return s1 + s2;
            }
        }
    }
}