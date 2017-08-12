﻿namespace SiAp_Parser.Enums
{
    /// <summary>
    /// 
    /// </summary>
    /// Imported from SiAp
    /// To update this enum follow these steps:
    /// 1: Export the "Comprobantes_Compras" table inside the "CITI Compras y Ventas" module
    /// 2: Replace " " -> "_"
    /// 3: Replace "__" -> "_"
    /// 4: Replace "." -> ""
    /// 5: Replace "/" -> "_"
    /// 6: Replace "_-_" -> "_"
    /// 7: Using the following RegEx ([0-9]+);(.*) replace for $2 = $1,
    public enum TipoComprobante
    {
        FACTURAS_A = 001,
        NOTAS_DE_DEBITO_A = 002,
        NOTAS_DE_CREDITO_A = 003,
        RECIBOS_A = 004,
        NOTAS_DE_VENTA_AL_CONTADO_A = 005,
        FACTURAS_B = 006,
        NOTAS_DE_DEBITO_B = 007,
        NOTAS_DE_CREDITO_B = 008,
        RECIBOS_B = 009,
        NOTAS_DE_VENTA_AL_CONTADO_B = 010,
        FACTURAS_C = 011,
        NOTAS_DE_DEBITO_C = 012,
        NOTAS_DE_CREDITO_C = 013,
        RECIBOS_C = 015,
        NOTAS_DE_VENTA_AL_CONTADO_C = 016,
        LIQUIDACION_DE_SERVICIOS_PUBLICOS_CLASE_A = 017,
        LIQUIDACION_DE_SERVICIOS_PUBLICOS_CLASE_B = 018,
        FACTURAS_DE_EXPORTACION = 019,
        NOTAS_DE_DEBITO_POR_OPERACIONES_CON_EL_EXTERIOR = 020,
        NOTAS_DE_CREDITO_POR_OPERACIONES_CON_EL_EXTERIOR = 021,
        FACTURAS_PERMISO_EXPORTACION_SIMPLIFICADO_DTO_855_97 = 022,
        CPTES_A_DE_COMPRA_PRIMARIA_PARA_EL_SECTOR_PESQUERO_MARITIMO = 023,
        CPTES_A_DE_COSIGNACION_PRIMARIA_PARA_EL_SECTOR_PESQUERO_MARITIMO = 024,
        CPTES_B_DE_COMPRA_PRIMARIA_PARA_EL_SECTOR_PESQUERO_MARITIMO = 025,
        CPTES_B_DE_CONSIGNACION_PRIMARIA_PARA_EL_SECTOR_PESQUERO_MARITIMO = 026,
        LIQUIDACION_UNICA_COMERCIAL_IMPOSITIVA_CLASE_A = 027,
        LIQUIDACION_UNICA_COMERCIAL_IMPOSITIVA_CLASE_B = 028,
        COMPROBANTES_DE_COMPRA_DE_BIENES_USADOS = 030,
        COMPROBANTES_PARA_RECICLAR_MATERIALES = 032,
        LIQUIDACION_PRIMARIA_DE_GRANOS = 033,
        COMPROBANTES_A_DEL_APARTADO_A_INCISO_F_R_G_N_1415 = 034,
        COMPROBANTES_B_DEL_ANEXO_I_APARTADO_A_INC_F_RG_N_1415 = 035,
        COMPROBANTES_C_DEL_ANEXO_I_APARTADO_A_INC_F_RG_N_1415 = 036,
        NOTAS_DE_DEBITO_O_DOCUMENTO_EQUIVALENTE_QUE_CUMPLAN_CON_LA_RG_N_1415 = 037,
        NOTAS_DE_CREDITO_O_DOCUMENTO_EQUIVALENTE_QUE_CUMPLAN_CON_LA_RG_N_1415 = 038,
        OTROS_COMPROBANTES_A_QUE_CUMPLEN_CON_LA_R_G_1415 = 039,
        OTROS_COMPROBANTES_B_QUE_CUMPLAN_CON_LA_RG_1415 = 040,
        OTROS_COMPROBANTES_C_QUE_CUMPLAN_CON_LA_RG_1415 = 041,
        NOTA_DE_CREDITO_LIQUIDACION_UNICA_COMERCIAL_IMPOSITIVA_CLASE_B = 043,
        NOTA_DE_DEBITO_LIQUIDACION_UNICA_COMERCIAL_IMPOSITIVA_CLASE_A = 045,
        NOTA_DE_DEBITO_LIQUIDACION_UNICA_COMERCIAL_IMPOSITIVA_CLASE_B = 046,
        NOTA_DE_CREDITO_LIQUIDACION_UNICA_COMERCIAL_IMPOSITIVA_CLASE_A = 048,
        COMPROBANTES_DE_COMPRA_DE_BIENES_NO_REGISTRABLES_A_CONSUMIDORES_FINALES = 049,
        RECIBO_FACTURA_A_REGIMEN_DE_FACTURA_DE_CREDITO = 050,
        FACTURAS_M = 051,
        NOTAS_DE_DEBITO_M = 052,
        NOTAS_DE_CREDITO_M = 053,
        RECIBOS_M = 054,
        NOTAS_DE_VENTA_AL_CONTADO_M = 055,
        COMPROBANTES_M_DEL_ANEXO_I_APARTADO_A_INC_F_R_G_N_1415 = 056,
        OTROS_COMPROBANTES_M_QUE_CUMPLAN_CON_LA_R_G_N_1415 = 057,
        CUENTAS_DE_VENTA_Y_LIQUIDO_PRODUCTO_M = 058,
        LIQUIDACIONES_M = 059,
        CUENTAS_DE_VENTA_Y_LIQUIDO_PRODUCTO_A = 060,
        CUENTAS_DE_VENTA_Y_LIQUIDO_PRODUCTO_B = 061,
        LIQUIDACIONES_A = 063,
        LIQUIDACIONES_B = 064,
        DESPACHO_DE_IMPORTACION = 066,
        RECIBOS_FACTURA_DE_CREDITO = 070,
        TIQUE_FACTURA_A_CONTROLADORES_FISCALES = 081,
        TIQUE_FACTURA_B = 082,
        TIQUE = 083,
        NOTA_DE_CREDITO_OTROS_COMP_QUE_NO_CUMPLEN_CON_LA_R_G_1415_Y_SUS_MODIF = 090,
        OTROS_COMP_QUE_NO_CUMPLEN_CON_LA_R_G_1415_Y_SUS_MODIF = 099,
        TIQUE_NOTA_DE_CREDITO = 110,
        TIQUE_FACTURA_C = 111,
        TIQUE_NOTA_DE_CREDITO_A = 112,
        TIQUE_NOTA_DE_CREDITO_B = 113,
        TIQUE_NOTA_DE_CREDITO_C = 114,
        TIQUE_NOTA_DE_DEBITO_A = 115,
        TIQUE_NOTA_DE_DEBITO_B = 116,
        TIQUE_NOTA_DE_DEBITO_C = 117,
        TIQUE_FACTURA_M = 118,
        TIQUE_NOTA_DE_CREDITO_M = 119,
        TIQUE_NOTA_DE_DEBITO_M = 120,
        LIQUIDACION_SECUNDARIA_DE_GRANOS = 331,
        CERTIFICADO_DE_DEPOSITO_DE_GRANOS_EN_PLANTA = 332
    }
}
