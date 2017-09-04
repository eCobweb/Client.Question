using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                output(1986, 8, 21);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("祸祸");

            Console.ReadLine();
        }



        static void output(int year, int month, int day)
        {
            var gua8s = new string[] { };

            var skyBranch10s = new string[] { "子", "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };

            var landBranch12s = new string[] { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };

            var zodiac12s = new string[] { "鼠", "牛", "虎-h", "兔", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };

            var starsign12s = new string[] { "白羊座", "金牛座", "双子座", "巨蟹座", "狮子座", "处女座", "天秤座", "天蝎座", "射手座", "摩羯座", "水瓶座", "双鱼座" };


            var ret_zodiac = zodiac12s[year % 12];


            Console.WriteLine("属相: {0}", ret_zodiac);

        }
    }
}
