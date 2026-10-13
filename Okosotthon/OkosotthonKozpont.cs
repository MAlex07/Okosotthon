using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosotthonKozpont
    {
        private readonly List<OkosEszkoz> eszkozok;

        public void EszkozHozzaadasa(OkosEszkoz eszkoz)
        {
            this.eszkozok.Add(eszkoz);
        }

     
        public void OsszesCsatlakoztatasa()
        {
            foreach (var eszkoz in eszkozok)
            {
                eszkoz.Csatlakozas();
            }
        }

        public int RendszerDiagnosztikaFuttatasa()
        {
            int sikeresTesztSzam = 0;

            foreach (var eszkoz in eszkozok)
            {
                if (eszkoz.DiagnosztikaFuttatasa())
                {
                    sikeresTesztSzam++;
                }
            }

            return sikeresTesztSzam;
        }

    }
}
