using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz, IIdozitheto, IStatisztika
    {
        private double jelenlegiHomerseklet;
        private double celHomerseklet;

        private int maradtIdo;
        private List<double> homersekletStatisztika;

        public double JelenlegiHomerseklet { get => jelenlegiHomerseklet; private set => jelenlegiHomerseklet = value; }
        public double CelHomerseklet { get => celHomerseklet; private set => celHomerseklet = value; }

        public Termosztat(string azonosito, string nev, double celHomerseklet)
        : base(azonosito, nev)
        {
            JelenlegiHomerseklet = 21.0;
            this.celHomerseklet = celHomerseklet;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs.StartsWith("Beallit_Homersekletet: "))
            {
                string ertek = parancs.Substring("Beallit_Homersekletet: ".Length);

                if (double.TryParse(ertek, out double homerseklet))
                {
                    CelHomerseklet = homerseklet;
                }
            }
        }

        public override string AllapotJelentes()
        {
            return $"A jelenlegi hőmérséklet: {JelenlegiHomerseklet}";
        }

        protected override bool OnTesztFuttatasa()
        {
            if (this.celHomerseklet >= 5.0 && this.celHomerseklet <= 35.0)
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        public void IdozitestBeallit(int perc)
        {
            maradtIdo = perc;
            while(maradtIdo > 0 && jelenlegiHomerseklet < celHomerseklet)
            {
                jelenlegiHomerseklet += 1;
                maradtIdo--;

                homersekletStatisztika.Add(jelenlegiHomerseklet);
            }
        }

        public int GetMaradtIdo()
        {
            return  maradtIdo;
        }

        public string StatisztikatKeszit()
        {
            if(homersekletStatisztika.Count == 0)
            {
                return "Nincs statisztika.";
            }

            double min = homersekletStatisztika[0];
            double max = homersekletStatisztika[0];
            double osszeg = 0;

            foreach (double homerseklet in homersekletStatisztika)
            {
                if (homerseklet < min)
                {
                    min = homerseklet;
                }
                if (homerseklet > max)
                {
                    max = homerseklet;
                }
                osszeg += homerseklet;
            }

            double atlag = osszeg / homersekletStatisztika.Count;

            return $"Statisztika:\nMinimum hőmérséklet: {min}\nMaximum hőmérséklet: {max}\nÁtlag hőmérséklet: {atlag}";
        }
    } 
}
