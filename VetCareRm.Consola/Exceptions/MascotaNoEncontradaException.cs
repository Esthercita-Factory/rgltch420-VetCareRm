namespace VetCareRm.Consola.Exceptions;

public class MascotaNoEncontradaException : Exception
{
    public MascotaNoEncontradaException(string mensaje)
        : base(mensaje)
    {
    }
}
