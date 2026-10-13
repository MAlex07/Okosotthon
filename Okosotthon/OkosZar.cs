using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosZar : OkosEszkoz
    {

        private bool zartE;

        private string pinKod;


        public bool ZartE

        {

            get => zartE;

            private set => zartE = value;

        }


        public OkosZar(string azonosito, string nev, string pinKod)

            : base(azonosito, nev)

        {

            this.pinKod = pinKod;

            this.ZartE = true;

        }


        public override void ParancsVegrehajtasa(string parancs)

        {

            if (parancs.StartsWith("NYITAS:"))

            {

                string megadottPin = parancs.Substring(7);


                if (megadottPin == this.pinKod)

                {

                    this.ZartE = false;

                }

            }

            else if (parancs == "ZARAS")

            {

                this.ZartE = true;

            }

        }


        public override string AllapotJelentes()

        {

            return this.ZartE ? "Zárva" : "Nyitva";

        }


        protected override bool OnTesztFuttatasa()

        {

            return true;

        }


        public override void GyariBeallitasokVisszaallitasa()

        {

            base.GyariBeallitasokVisszaallitasa();

            this.pinKod = "0000";

            this.ZartE = true;

        }
    }
}