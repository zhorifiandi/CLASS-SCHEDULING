﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes1AI.Scheduling
{
    class Ruangan
    {
        private string nama;
        private int jam_buka;
        private int jam_tutup;
        private List<int> hari_buka;
        private int waktu_available;
        private int waktu_terpakai;

        public Ruangan()
        {
            hari_buka = new List<int>();
            waktu_available = 0;
            waktu_terpakai = 0;
        }

        public Ruangan(string nama, int jam_buka, int jam_tutup, List<int> hari)
        {
            this.nama = nama;
            this.jam_buka = jam_buka;
            this.jam_tutup = jam_tutup;
            this.hari_buka = hari;
            int countHari = 0;
            foreach (int i in hari)
            {
                countHari++;
            }
            this.waktu_available = countHari * (jam_tutup - jam_buka);
            this.waktu_terpakai = 0;
        }

        public Ruangan(Ruangan R)
        {
            nama = R.nama;
            jam_buka = R.jam_buka;
            jam_tutup = R.jam_tutup;
            hari_buka = new List<int>();
            if (hari_buka != null)
            {
                for (int i = 0; i < R.hari_buka.Count; i++)
                {
                    hari_buka.Add(R.hari_buka[i]);
                }
            }
            waktu_available = R.waktu_available;
            waktu_terpakai = R.waktu_terpakai;
        }

        public bool isOpen(int mulai, int selesai, int hari)
        {
            if (mulai < this.jam_buka || selesai > this.jam_tutup || !this.isHariOpen(hari))
            {
                return false;
            }
            return true;
        }

        private bool isHariOpen(int hari)
        {
            bool open = false;
            foreach (int h in this.hari_buka)
            {
                if (hari == h)
                {
                    open = true;
                }
            }
            return open;
        }

        public string getName()
        {
            return this.nama;
        }

        public int getBuka()
        {
            return jam_buka;
        }

        public int getTutup()
        {
            return jam_tutup;
        }

        public List<int> getHariBuka()
        {
            return hari_buka;
        }

        public void setBuka(int i)
        {
            jam_buka = i;
        }

        public void setTutup(int i)
        {
            jam_tutup = i;
        }

        public void setHariBuka(List<int> haribuka)
        {
            hari_buka = new List<int>(haribuka.Count);
            if (hari_buka != null)
            {
                foreach(int i in haribuka)
                {
                    hari_buka[i] = haribuka[i];
                }
            }
        }

        public void decrement_waktu_available()
        {
            waktu_terpakai++;
        }

        public double getEfektifitasRuangan()
        {
            return (Convert.ToDouble(waktu_terpakai)/Convert.ToDouble(waktu_available))*100;
        }

        public int getWaktuTerpakai()
        {
            return waktu_terpakai;
        }

        public int getWaktuAvailable()
        {
            return waktu_available;
        }
    }
}
