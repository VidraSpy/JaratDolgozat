using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repcsi_forgalom
{
    class Jaratkezelo
    {
        public class Jarat
        {
            public string jaratSzam { get; set; }           
            public string honnanRepter { get; set; }
            public string hovaRepter { get; set; }
            public DateTime indulas { get; set; }
            public int keses;

            public Jarat(string jaratSzam, string honnanRepter, string hovaRepter, DateTime indulas)
            {
                this.jaratSzam = jaratSzam;
                this.honnanRepter = honnanRepter;
                this.hovaRepter = hovaRepter;
                this.indulas = indulas;
                this.keses = 0;
            }
        }
        List<Jarat> jaratok = new List<Jarat>();

        public void UjJarat(string jaratSzam, string honnanRepter, string hovaRepter, DateTime indulas)
        {
            var r = new Jarat(jaratSzam, honnanRepter, hovaRepter, indulas);
            foreach (var item in jaratok)
            {
                if (item.jaratSzam.Equals(jaratSzam))
                {
                    throw new ArgumentException("már van ilyen járat");
                }
            }
            jaratok.Add(r);


        }
        public DateTime MikorIndul(string jaratSzam)
        {
            foreach (var jarat in jaratok)
            {
                if (jaratSzam.Equals(jarat.jaratSzam))
                {
                    return jarat.indulas.AddMinutes(jarat.keses);
                }
            }
            throw new ArgumentException("Nincs ilyen járat");
        }

        public List<string> jaratokRepuloterrol(string repter)
        {
            List<string> jaratokLista = new List<string>();
            foreach (var item in jaratok)
            {
                if (repter.Equals(item.honnanRepter))
                {
                    jaratokLista.Add(item.jaratSzam);
                }
            }
            if (jaratokLista.Count==0)
            {
                throw new ArgumentException();
            }
            return jaratokLista;
        }
        public void Keses(string jaratszam, int keses)
        {
            foreach (var item in jaratok)
            {
                if (jaratszam.Equals(item.jaratSzam))
                {
                    if ((item.keses+keses)<0)
                    {
                        throw new NegativKesesException(keses);
                    }
                    else
                    {
                        item.keses += keses;
                    }
                }
            }
        }
        class NegativKesesException : Exception
        {
            public NegativKesesException(int keses)
                    : base("nemtom " + keses)
            {

            }
        }
    }
}
