using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaiThiGiuaKy
{
    class Program
    {
        static void Main(string[] args)
        {
            SinhVien[] sv = new SinhVien[100];

            for (int i = 0; i < 10; i++)
            {
                sv[i] = new SinhVien();
                sv[i].DSSV(i);
                sv[i].TinhDiem();
                for (int j = 0; j < 4; j++)
                    if (sv[i].Ketqua[j] > 0)
                    {
                        int k = j + 1;
                        Console.Write("{0} {1} {2} {3}", sv[i].SBd, k, sv[i].Nguyenvong[j, 0], sv[i].Ketqua[j]);
                        Console.WriteLine();
                    }
            }
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
