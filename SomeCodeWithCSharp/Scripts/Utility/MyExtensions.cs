using BaseClass;
using System.Text;

namespace MyExtensions
{

    public static class FatherExtensions
    {
        public static string SaySomething(this Father f, string something)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.AppendFormat("{0} \nI am {1}, your father~", something, f.Name);
            return sBuilder.ToString();
        }
    }
}