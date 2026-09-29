using Obligatorio.LogicaNegocio.Exepciones.Equipo;
using Obligatorio.LogicaNegocio.VO;

public record VOTipoSensor : VOString
{
    public VOTipoSensor(string value) : base(value)
    {
    }
    public enum VOTipoSensorEnum
    {
        CMOS,
        CCD
    }

    protected override Exception CreateInvalidValueException(string value, string errorMsg)
    {
        return new EquipoInvalidExeption($"Tipo de sensor inválido: {value}");
    }
}