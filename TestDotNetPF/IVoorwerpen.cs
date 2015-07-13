using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestDotNetPF.Model
{
    interface IVoorwerpen
    {
        decimal Winst
        {
            get;
        }

        void GegevensTonen();
    }
}
