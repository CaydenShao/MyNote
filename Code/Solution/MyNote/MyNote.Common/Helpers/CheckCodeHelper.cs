using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Common.Helpers
{
    public static class CheckCodeHelper
    {
        /// <summary>
        /// 动态生成指定数目的随机数或字母
        /// </summary>
        /// <param name="num">整数</param>
        /// <returns>返回验证码字符串</returns>
        public static string GenerateCheckCode(int num)
        {
            int number;  //定义变量
            char code;
            string checkCode = string.Empty;  //空字符串，只读
            Random random = new Random();    //定义随机变量实例

            for (int i = 0; i < num; i++)
            {
                // 利用for循环生成指定数目的随机数或字母
                number = random.Next(); //返回一个小于指定的最大值的非负的随机数 next有三个构造函数 

                //if (number % 2 == 0)
                //{
                    //产生一个一位数
                    code = (char)('0' + (char)(number % 10));
                //}
                //else
                //{
                //    //产生一个字母
                //    code = (char)('C' + (char)(number % 26));
                //}

                checkCode += code.ToString();
            }

            return checkCode;
        }
    }
}
