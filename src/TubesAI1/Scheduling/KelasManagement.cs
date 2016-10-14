﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using GeneticAlgorithmTesting.StrukturData;

namespace Tubes1AI.Scheduling
{
    class KelasManagement
    {
        private List<Kelas> arrayKelas;

        public KelasManagement()
        {
            this.arrayKelas = new List<Kelas>();
        }

        public KelasManagement(List<Kelas> arrayKelas)
        {
            this.arrayKelas = new List<Kelas>();
            foreach(Kelas k in arrayKelas)
            {
                Kelas k2 = new Kelas(k);
                this.addKelas(k2);
            }
        }

        public void addKelas(Kelas kelas)
        {
            this.arrayKelas.Add(kelas);
        }

        public bool isRange(int a, int min, int max)
        {
            return ((a >= min) && (a <= max));
        }

        public int getConflict()
        {
            int count = 0;
            for(int i=0; i < this.arrayKelas.Count-1; i++)
            {
                for(int j=i+1; j < this.arrayKelas.Count; j++)
                {
                    var a = this.arrayKelas[i];
                    var b = this.arrayKelas[j];
                    if (isConflict(a, b))
                    {
                        int range_a = a.getMulai() + a.getDurasi();
                        int range_b = b.getMulai() + b.getDurasi();
                        //check kalo nilai tidak ada pada range
                        
                        /*if (!Enumerable.Range(b.getMulai(), range_b).Contains(range_a) ||
                            !Enumerable.Range(a.getMulai(), range_a).Contains(range_b))
                        {*/
                        /*if (((range_b < a.getMulai()) || (range_b > range_a)) && 
                            ((range_a < b.getMulai() || (range_a > range_b))))
                        {*/
                        if (!isRange(range_b, a.getMulai(), range_a) || !isRange(range_a, b.getMulai(), range_b) ||
                            !isRange(a.getMulai(), b.getMulai(), range_b) || !isRange(b.getMulai(), a.getMulai(), range_a))
                        {
                            if (a.getMulai() > b.getMulai())
                            {
                                count += b.getMulai() + b.getDurasi() - a.getMulai();
                            }
                            else
                            {
                                count += a.getMulai() + a.getDurasi() - b.getMulai();
                            }
                        }
                        //check untuk nilai di dalam range
                        else
                        {
                            /* Cari durasi minimal kalo sama */
                            if (a.getDurasi() <= b.getDurasi())
                            {
                                count += a.getDurasi();
                            }
                            else
                            {
                                count += b.getDurasi();
                            }
                        }
                    }
                }
            }
            return count;
        }

        private bool isConflict(Kelas k1, Kelas k2)
        {
            if(k1.getNamaRuangan() != k2.getNamaRuangan())
            {
                return false;
            }
            if (k1.getHari() != k2.getHari())
            {
                return false;
            }

            if (k1.getMulai() < k2.getMulai())
            {
                if(k1.getMulai()+k1.getDurasi() <= k2.getMulai())
                {
                    return false;
                }
            }
            else if (k1.getMulai() > k2.getMulai())
            {
                if (k2.getMulai() + k2.getDurasi() <= k1.getMulai())
                {
                    return false;
                }
            }
            return true;
        }

        public List<Kelas> getArrayKelas()
        {
            return this.arrayKelas;
        }

        public void setRandomValue(int i)
        {
            do
            {
                arrayKelas[i].setRandomValue();
                //Console.WriteLine("Try");
            } while (!arrayKelas[i].isCurrentValid());
        }

        public void printall()
         {
             //print all
             int count = this.arrayKelas.Count;
             for (int i = 0; i<count; i++)
             {
                 this.arrayKelas[i].print();
             }
         }

        public bool IsAdaConflict(Kelas k)
        {
                        /* fungsi ini mengmbalikan nilai true jika kelas k memiliki jadwal yang bertabrakan/kkonflik dengan min salah satu dari semua matkul */
                        for (int i = 0; i < this.arrayKelas.Count; i++)
            {
                                if (k.getNama().CompareTo(this.arrayKelas[i].getNama()) != 0)
                {
                                        if (isConflict(k, this.arrayKelas[i]))
                    {
                                                return true;
                                            }
                                    }
                            }
                        return false;
                    }
    }
}
