using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorDeLibros
{
    public interface IDocumento
    {
        string Numero { get; }
        TipoDocumento TipoDocumento { get; }
        string Format(string separator = "-");
        bool EsValido { get; set; }
    }

    public enum TipoDocumento
    {
        CUIT,
        CUIL,
        DNI
    }
}
