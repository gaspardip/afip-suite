namespace SIAP.Parser.Enums
{
    /// <summary>
    /// 
    /// </summary>
    /// Imported from SiAp
    /// To update this enum follow these steps:
    /// 1: Export the "Monedas" table inside the "CITI Compras y Ventas" module
    /// 2: Replace "  " -> " "
    /// 3: Replace " " -> "_"
    /// 4: Using the following RegEx ([0-9A-Z]+);(.*) replace for $2 = "$1",
    public static class Monedas
    {
        public static string
            OTRAS_MONEDAS = "000",
            DOLAR_LIBRE_EEUU = "002",
            FLORINES_HOLANDESES = "007",
            FRANCO_SUIZO = "009",
            PESOS_MEJICANOS = "010",
            PESOS_URUGUAYOS = "011",
            REAL = "012",
            CORONAS_DANESAS = "014",
            CORONAS_NORUEGAS = "015",
            CORONAS_SUECAS = "016",
            DOLAR_CANADIENSE = "018",
            YENS = "019",
            LIBRA_ESTERLINA = "021",
            BOLIVAR_VENEZOLANO = "023",
            CORONA_CHECA = "024",
            DINAR_YUGOSLAVO = "025",
            DOLAR_AUSTRALIANO = "026",
            DRACMA_GRIEGO = "027",
            FLORIN_ANTILLAS_HOLANDESAS = "028",
            GUARANI = "029",
            SHEKEL_ISRAEL = "030",
            PESO_BOLIVIANO = "031",
            PESO_COLOMBIANO = "032",
            PESO_CHILENO = "033",
            RAND_SUDAFRICANO = "034",
            NUEVO_SOL_PERUANO = "035",
            SUCRE_ECUATORIANO = "036",
            NUEVO_LEV_BULGARO = "039",
            LEI_RUMANO = "040",
            DERECHOS_ESPECIALES_DE_GIRO = "041",
            PESO_DOMINICANO = "042",
            BALBOAS_PANAMENAS = "043",
            CORDOBA_NICARAGUENSE = "044",
            DIRHAM_MARROQUI = "045",
            LIBRA_EGIPCIA = "046",
            RIYAL_SAUDITA = "047",
            GRAMOS_DE_ORO_FINO = "049",
            DOLAR_DE_HONG_KONG = "051",
            DOLAR_DE_SINGAPUR = "052",
            DOLAR_DE_JAMAICA = "053",
            DOLAR_DE_TAIWAN = "054",
            QUETZAL_GUATEMALTECO = "055",
            FORINT_HUNGRIA = "056",
            BAHT_TAILANDIA = "057",
            DINAR_KUWAITI = "059",
            EURO = "060",
            ZLOTY_POLACO = "061",
            RUPIA_HINDU = "062",
            LEMPIRA_HONDURENA = "063",
            YUAN_REP_POP_CHINA = "064",
            DOLAR_ESTADOUNIDENSE = "DOL",
            PESOS_ARGENTINOS = "PES";
    }
}
