using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz
    {
        private double jelenlegiHomerseklet;
        private double celHomerseklet;

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
                })
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
    } 
}
