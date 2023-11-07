using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA231107
{
    internal class tanulo
    {
        public string TanuloNeve { get; set; }
        public string OktatasiAzonosito { get; set; }

        public List<int> Jegyek;
        public double TanuloAtlag { get; set; }

        public tanulo(string sor)
        {
            var atmeneti = sor.Split("\t");
            this.TanuloNeve = atmeneti[0];
            this.OktatasiAzonosito = atmeneti[1];
            this.Jegyek = new List<int>();
            for (int i = 2; i < atmeneti.Length; i++)
                this.Jegyek.Add(int.Parse(atmeneti[i]));
            this.TanuloAtlag = this.Jegyek.Average();
        }

        public override string ToString()
        {
            return $"{this.TanuloNeve}, {this.OktatasiAzonosito}";
        }
    }
}
