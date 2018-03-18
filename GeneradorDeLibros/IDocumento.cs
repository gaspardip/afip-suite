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
