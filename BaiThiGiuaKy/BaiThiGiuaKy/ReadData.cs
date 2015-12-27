using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaiThiGiuaKy
{
    class ReadData
    {
        private string sbd, kv, uutien, dantoc, ten, ngaysinh;


        private string[,] nguyenvong = new string[4, 2];

        private string[] diemthi = new string[13];
        public string Sbd
        {
            get { return sbd; }

        }
        public string Ten
        {
            get { return ten; }

        }
        public string Ngaysinh
        {
            get { return ngaysinh; }

        }
        public string Khuvuc
        {
            get { return kv; }

        }
        public string Dantoc
        {
            get { return dantoc; }

        }
        public string Uutien
        {
            get { return uutien; }

        }

        public string[,] Nguyenvong
        {
            get { return nguyenvong; }
        }

        public string[] Diemthi
        {
            get { return diemthi; }
        }

        public void dangkynv(int stt)
        {
            string filePath1 = @"C:\Users\Asus\Documents\Visual Studio 2013\Projects\BaiThiGiuaKy\BaiThiGiuaKy\Input\dangkynv-bk.txt";
            string[] test1 = File.ReadAllLines(filePath1);
            string[] sr = test1[stt + 1].Split('"');
            int n = sr.Length;
            for (int i = 0; i < n; i++)
                if (sr[i] == ",")
                {
                    for (int j = i; j < n - 1; j++)
                        sr[j] = sr[j + 1];
                    n--;
                }
            n--;
            int dem = 0;
            for (int i = 2; i < n; i++)
            {
                int j = 0;
                if (i % 2 == 0)
                    nguyenvong[dem, j] = sr[i];
                else
                { nguyenvong[dem, j + 1] = sr[i]; dem++; }
            }

            string filePath2 = @"C:\Users\Asus\Documents\Visual Studio 2013\Projects\BaiThiGiuaKy\BaiThiGiuaKy\Input\csdl-bk.txt";
            string[] test2 = File.ReadAllLines(filePath2);
            string[] tr = test2[stt + 1].Split(',');
            int m = tr.Length;
            sbd = tr[0];
            ten = tr[1];
            ngaysinh = tr[2];
            kv = tr[3];
            dantoc = tr[4];
            uutien = tr[5];
            for (int i = 6; i < m; i++)
                diemthi[i - 6] = tr[i];

        }
    }
}
