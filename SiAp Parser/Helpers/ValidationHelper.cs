using System.Linq;

namespace SIAP.Parser.Helpers
{
    public static class ValidationHelper
    {
        // https://es.wikipedia.org/wiki/Clave_Única_de_Identificación_Tributaria
        public static bool IsValidCuit(string cuit)
        {
            if (cuit.Length != 11)
                return false;

            int acumulado = 0;
            var digitos = cuit.ToArray().Select(n => (int)char.GetNumericValue(n)).ToArray();
            int digito = digitos.Last();

            for (int i = 0; i < digitos.Length - 1; i++)
                acumulado += digitos[9 - i] * (2 + i % 6);

            int verif = 11 - acumulado % 11;

            if (verif == 11)
                verif = 0;

            return digito == verif;
        }
    }
}
