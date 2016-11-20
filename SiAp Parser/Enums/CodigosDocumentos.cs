using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAp_Parser.Enums
{
    /// <summary>
    /// 
    /// </summary>
    /// Imported from SiAp
    /// To update this enum follow these steps:
    /// 1: Export the "Documentos" table inside the "CITI Compras y Ventas" module
    /// 2: Replace " " -> "_"
    /// 3: Replace "_/" -> ""
    /// 4: Using the following RegEx ([0-9]+);(.*) replace for $2 = $1,
    public enum CodigosDocumentos
    {
        C_I_CAPITAL_FEDERAL = 00,
        C_I_BUENOS_AIRES = 01,
        C_I_CATAMARCA = 02,
        C_I_CORDOBA = 03,
        C_I_CORRIENTES = 04,
        C_I_ENTRE_RIOS = 05,
        C_I_JUJUY = 06,
        C_I_MENDOZA = 07,
        C_I_LA_RIOJA = 08,
        C_I_SALTA = 09,
        C_I_SAN_JUAN = 10,
        C_I_SAN_LUIS = 11,
        C_I_SANTA_FE = 12,
        C_I_SGO_DEL_ESTERO = 13,
        C_I_TUCUMAN = 14,
        C_I_CHACO = 16,
        C_I_CHUBUT = 17,
        C_I_FORMOSA = 18,
        C_I_MISIONES = 19,
        C_I_NEUQUEN = 20,
        C_I_LA_PAMPA = 21,
        C_I_RIO_NEGRO = 22,
        C_I_SANTA_CRUZ = 23,
        C_I_TIERRA_DEL_FUEGO = 24,
        C_U_I_T = 80,
        C_U_I_L = 86,
        C_D_I = 87,
        LIBRETA_DE_ENROLAMIENTO = 89,
        LIBRETA_CIVICA = 90,
        C_I_EXTRANJERA = 91,
        EN_TRAMITE = 92,
        ACTA_DE_NACIMIENTO = 93,
        PASAPORTE = 94,
        C_I_BS_AS_R_N_P = 95,
        DOC_NACIONAL_DE_IDENTIDAD = 96,
        SIN_IDENTIFICAR_VENTA_GLOBAL_DIARIA = 99
    }
}
