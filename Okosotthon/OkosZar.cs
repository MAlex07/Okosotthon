using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosZar : OkosEszkoz, IHangjelzo, IStatisztika
    {

        private bool zartE; 
        private string pinKod; 
        
        private int nyitasokSzama; 
        private int hibasPinProbalkozasok;

        public bool ZartE

        {

            get => zartE;

            private set => zartE = value;

        }

        public OkosZar(string azonosito, string nev, string pinKod)

            : base(azonosito, nev)

        {

            this.pinKod = pinKod;

            ZartE = true;

            nyitasokSzama = 0;

            hibasPinProbalkozasok = 0;

        }

        public override void ParancsVegrehajtasa(string parancs)

        {

            if (parancs.StartsWith("NYITAS:"))

            {

                string megadottPin = parancs.Substring(7);


                if (megadottPin == this.pinKod)

                {

                    if (ZartE)

                    {

                        nyitasokSzama++;

                    }


                    ZartE = false;

                    hibasPinProbalkozasok = 0;

                }

                else
                {

                    hibasPinProbalkozasok++;


                    Csipog(1);


                    if (hibasPinProbalkozasok >= 3)

                    {

                        VeszjelzesInditasa();

                    }

                }

            }

            else if (parancs == "ZARAS")

            {

                ZartE = true;

            }

        }

        public override string AllapotJelentes()

        {

            return ZartE ? "Zárva" : "Nyitva";

        }

        protected override bool OnTesztFuttatasa()

        {

            return true;

        }

        public override void GyariBeallitasokVisszaallitasa()

        {

            base.GyariBeallitasokVisszaallitasa();

            ZartE = true;

            nyitasokSzama = 0;

            hibasPinProbalkozasok = 0;

        }

        public void Csipog(int hosszu)

        {

            Console.WriteLine($"Csipogás! Hossz: {hosszu}");

        }

        public void VeszjelzesInditasa()

        {

            Console.WriteLine("VÉSZJELZÉS! Túl sok hibás PIN-kód!");

        }

        public string StatisztikatKeszit()

        {

            return $"Sikeres nyitások száma: {nyitasokSzama}, " +

                   $"Hibás PIN-próbálkozások száma: {hibasPinProbalkozasok}";

        }
    }
}