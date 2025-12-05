using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.MVVM.Models
{
    public class ContadorDeKikadasModel
    {
        int contador;

        public int contar()
        {
            return contador++;
        }
    }
}
