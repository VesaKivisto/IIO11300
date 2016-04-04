using System;
using System.Collections.Generic;

namespace Tehtava11
{
    public partial class Pelaajat
    {
        public string Kokonimi
        {
            get { return this.etunimi + " " + this.sukunimi + "@" + this.seura; }
        }
    }
}
