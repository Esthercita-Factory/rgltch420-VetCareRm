using System.Globalization;

namespace VetCareRm.Consola.Services;

public class Logger
{
    private readonly string _rutaArchivo;

    public Logger(string rutaArchivo = "logs/errors.log")
    {
        _rutaArchivo = rutaArchivo;
    }

    public void LogError(string mensaje, Exception? excepcion = null)
    {
        string fecha = DateTime.Now.ToString(
            "yyyy-MM-dd HH:mm:ss",
            CultureInfo.InvariantCulture
        );

        string linea = $"[{fecha}] ERROR: {mensaje}";

        if (excepcion is not null)
        {
            linea += $" | {excepcion.GetType().Name}: {excepcion.Message}";
        }

        string? directorio = Path.GetDirectoryName(_rutaArchivo);

        if (!string.IsNullOrWhiteSpace(directorio))
        {
            Directory.CreateDirectory(directorio);
        }

        File.AppendAllText(
            _rutaArchivo,
            linea + Environment.NewLine
        );
    }
}
