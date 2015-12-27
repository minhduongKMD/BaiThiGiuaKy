using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace BaiThiGiuaKy
{
    class SinhVien
    {
        private string sbd, kv, uutien, dantoc, ten, ngaysinh;
        private string[,] nguyenvong = new string[4, 2];
        private double[] diemthi = new double[13];
        private double[] ketqua = new double[4];
        public double[] Ketqua
        {
            get { return ketqua; }
        }
        public string SBd
        {
            get { return sbd; }
        }
        public string[,] Nguyenvong
        {
            get { return nguyenvong; }
        }

        public void DSSV(int stt)
        {
            ReadData sv = new ReadData();
            sv.dangkynv(stt);
            sbd = sv.Sbd;
            kv = sv.Khuvuc;
            uutien = sv.Uutien;
            dantoc = sv.Dantoc;
            ten = sv.Ten;
            ngaysinh = sv.Ngaysinh;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 2; j++)
                    nguyenvong[i, j] = sv.Nguyenvong[i, j];
            for (int i = 0; i < 13; i++)
            {

                if (sv.Diemthi[i] == "NA") diemthi[i] = -1;
                else diemthi[i] = double.Parse(sv.Diemthi[i]);
            }
            Console.WriteLine("{0}", diemthi[1]);
        }
        private double diem;
        private double diemcacmon(string str)
        {
            switch (str)
            {
                case "Toan": diem = diemthi[0]; break;
                case "Van": diem = diemthi[1]; break;
                case "Ly": diem = diemthi[2]; break;
                case "Hoa": diem = diemthi[3]; break;
                case "Sinh": diem = diemthi[4]; break;
                case "Su": diem = diemthi[5]; break;
                case "Dia": diem = diemthi[6]; break;
                case "Anh": diem = diemthi[7]; break;
                case "Nga": diem = diemthi[8]; break;
                case "Phap": diem = diemthi[9]; break;
                case "Trung": diem = diemthi[10]; break;
                case "Duc": diem = diemthi[11]; break;
                case "Nhat": diem = diemthi[12]; break;
                default: break;
            }
            return diem;
        }
        private double diemkv;
        private double diemkhuvuc(string s)
        {
            switch (s)
            {
                case "\"KV1\"": diemkv = 1.5; break;
                case "\"KV2-NT\"": diemkv = 1; break;
                case "\"KV2\"": diemkv = 0.5; break;
                case "\"KV3\"": diemkv = 0; break;
            }
            return diemkv;
        }
        private double diemUT;
        private double diemuutien(string s)
        {
            if (s == "UT") diemUT = 1;
            else diemUT = 0;
            return diemUT;
        }

        public void TinhDiem()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 1; j < 2; j++)
                {
                    if (nguyenvong[i, j] == null) ketqua[i] = -1;
                    else
                    {
                        string[] s = nguyenvong[i, j].Split(',');
                        Console.WriteLine("{0}", diemthi[0]);
                        if (s[3] == "1")
                        {
                            ketqua[i] = (diemcacmon(s[0]) * 2 + diemcacmon(s[1]) + diemcacmon(s[2])) / 4 + (diemkhuvuc(kv) + diemuutien(uutien)) / 3;
                        }
                        else
                            ketqua[i] = (diemcacmon(s[0]) + diemcacmon(s[1]) + diemcacmon(s[2])) / 3 + (diemkhuvuc(kv) + diemuutien(uutien)) / 3;
                    }
                }
        }
        public void Getdata(string sql)
        {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source = E:\Tai Lieu Mon Hoc\LT Huong Doi Tuong\SQLiteStudio\10.db");
            conn.Open();
            SQLiteCommand cmd;
            cmd = new SQLiteCommand();
            cmd.Connection = conn;

            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.Write("Loi");
            }
            cmd.Dispose();
            cmd = null;
        }       
    }
}
