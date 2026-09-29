using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Entidades.EnUsuarios;
using Obligatorio.LogicaNegocio.Entidades.Equipo;
using Obligatorio.LogicaNegocio.VO.Equipo;
using Obligatorio.LogicaNegocio.VO.Equipo.Camara;
using Obligatorio.LogicaNegocio.VO.Equipo.Montura;
using Obligatorio.LogicaNegocio.VO.Equipo.Ocular;
using Obligatorio.LogicaNegocio.VO.Equipo.Telescopio;
using Obligatorio.LogicaNegocio.VO.ObjCeleste;
using Obligatorio.LogicaNegocio.VO.Prestamo;
using Obligatorio.LogicaNegocio.VO.VOObservacion;
using Obligatorio.LogicaNegocio.VO.VOPrestamo;
using Obligatorio.LogicaNegocio.VO.VOPrestamo.VOAuditoria;
using Obligatorio.LogicaNegocio.VO.VOUsuarios;

namespace Obligatorio.Infraestructura.AccesoDatos.EF;

public class SeedData
{
    private ObservatorioContext _context;

    public SeedData(ObservatorioContext context)
    {
        _context = context;
    }

    public void Run()
    {
        if (!_context.Usuarios.Any())
            CrearUsuarios();
        if (!_context.Equipos.Any())
            CrearEquipos();
        if (!_context.ObjCelestes.Any())
            CrearObjCelestes();
        if (!_context.Prestamos.Any())
            CrearPrestamos();
        if (!_context.Observaciones.Any())
            CrearObservaciones();
        if (!_context.AuditoriaPrestamos.Any())
            CrearAuditoria();
    }

    private void CrearUsuarios()
    {
        _context.Usuarios.Add(
            new UserAdmin(
                new VOName("Administrador"),
                new VOAddress("Observatorio Central"),
                new VOPhone(99999999),
                new VOEmail("admin@observatorio.com"),
                new VOUserName("admin"),
                new VOPassword("Admin@1234"),
                new VORol("Administrador")
            ));

        for (int i = 1; i <= 5; i++)
        {
            _context.Usuarios.Add(
                new UserCoordinador(
                    new VOName($"Coordinador {i}"),
                    new VOAddress($"Dirección {i}"),
                    new VOPhone(90000000 + i),
                    new VOEmail($"coord{i}@mail.com"),
                    new VOUserName($"coord{i}"),
                    new VOPassword($"Coord@{i}234"),
                    new VORol("Coordinador")
                ));
        }

        for (int i = 1; i <= 5; i++)
        {
            _context.Usuarios.Add(
                new UserSocio(
                    new VOName($"Socio {i}"),
                    new VOAddress($"Dirección Socio {i}"),
                    new VOPhone(91000000 + i),
                    new VOEmail($"socio{i}@mail.com"),
                    new VOUserName($"socio{i}"),
                    new VOPassword($"Socio@{i}234"),
                    new VORol("Socio")
                ));
        }

        _context.SaveChanges();
    }

    private void CrearEquipos()
    {
        // 10 Telescopios — pesos entre 9 y 18 kg
        for (int i = 1; i <= 10; i++)
        {
            _context.Equipos.Add(
                new Telescopio(
                    new VOMarca($"Celestron {i}"),
                    new VOModelo($"T{i}"),
                    new VOCantDisp(5),
                    new VOApertura(150 + i),
                    new VORelacionFocal(5 + i),
                    new VODistanciaFocal(750 + (i * 10)),
                    new VOPeso(8 + i)
                ));
        }

        // 10 Monturas — carga soportada entre 21 y 30 kg (siempre >= peso telescopio)
        for (int i = 1; i <= 10; i++)
        {
            _context.Equipos.Add(
                new Montura(
                    new VOMarca($"SkyWatcher {i}"),
                    new VOModelo($"M{i}"),
                    new VOCantDisp(5),
                    new VOTipoMontura(
                        i % 2 == 0
                            ? VOTipoMontura.VOTipoMonturaEnum.Ecuatorial.ToString()
                            : VOTipoMontura.VOTipoMonturaEnum.Hibrida.ToString()),
                    new VOCargaMontura(20 + i),
                    new VOComputarizado(true)
                ));
        }

        // 10 Cámaras
        for (int i = 1; i <= 10; i++)
        {
            _context.Equipos.Add(
                new Camara(
                    new VOMarca($"ZWO {i}"),
                    new VOModelo($"C{i}"),
                    new VOCantDisp(5),
                    new VOPixel(2.4m + i),
                    new VOResolucion(4000 + i),
                    new VOTipoSensor("CMOS")
                ));
        }

        // 10 Oculares
        for (int i = 1; i <= 10; i++)
        {
            _context.Equipos.Add(
                new Ocular(
                    new VOMarca($"Explore Scientific {i}"),
                    new VOModelo($"O{i}"),
                    new VOCantDisp(5),
                    new VOAngulo(50 + i),
                    new VODiametro(25 + i)
                ));
        }

        _context.SaveChanges();
    }

    private void CrearObjCelestes()
    {
        string[] nombres =
        {
            "Luna",
            "Marte",
            "Jupiter",
            "Saturno",
            "Venus",
            "Andromeda",
            "Betelgeuse",
            "Sirio",
            "Orión",
            "Pléyades"
        };

        for (int i = 0; i < nombres.Length; i++)
        {
            _context.ObjCelestes.Add(
                new ObjCeleste(
                    new VONombreObjCeleste(nombres[i]),
                    new VOTipoObjCeleste("Planeta"),
                    new VOMagnitud(i + 1)
                ));
        }

        _context.SaveChanges();
    }

    private void CrearPrestamos()
    {
        var socios = _context.Usuarios.OfType<UserSocio>().ToList();
        var coords = _context.Usuarios.OfType<UserCoordinador>().ToList();

        var telescopios = _context.Equipos.OfType<Telescopio>().ToList();
        var monturas = _context.Equipos.OfType<Montura>().ToList();
        var camaras = _context.Equipos.OfType<Camara>().ToList();
        var oculares = _context.Equipos.OfType<Ocular>().ToList();

        int prestamoIndex = 0;

        for (int i = 0; i < telescopios.Count; i++)
        {
            var telescopio = telescopios[i];

            // Buscar una montura compatible (carga >= peso del telescopio)
            var montura = monturas.FirstOrDefault(m => m.CargaSoportada.Value >= telescopio.Peso.Value);
            if (montura == null)
                continue;

            var socio = socios[prestamoIndex % socios.Count];
            var coord = coords[prestamoIndex % coords.Count];

            // Alternar entre préstamos con Cámara y préstamos con Ocular
            Camara? camara = null;
            Ocular? ocular = null;

            if (prestamoIndex % 2 == 0)
            {
                // Préstamo con Cámara (sin Ocular)
                // La cámara requiere montura Ecuatorial o Híbrida, lo cual ya está garantizado
                camara = camaras[prestamoIndex % camaras.Count];
            }
            else
            {
                // Préstamo con Ocular (sin Cámara)
                ocular = oculares[prestamoIndex % oculares.Count];
            }

            var fechaInicio = DateTime.Today.AddDays(prestamoIndex + 1);
            var fechaFin = fechaInicio.AddDays(7);

            _context.Prestamos.Add(
                new Prestamo(
                    0,
                    socio,
                    telescopio,
                    montura,
                    camara,
                    ocular,
                    new VOFchInicio(fechaInicio),
                    new VOFchFin(fechaFin),
                    coord
                )
            );

            prestamoIndex++;
        }

        _context.SaveChanges();
    }

    private void CrearObservaciones()
    {
        var prestamos = _context.Prestamos.ToList();
        var objetos = _context.ObjCelestes.ToList();

        var obsCount = Math.Min(prestamos.Count, objetos.Count);

        for (int i = 0; i < obsCount; i++)
        {
            var prestamo = prestamos[i];

            // Generar una fecha válida dentro del período del préstamo
            var fechaInicio = prestamo.FchInicio.Value;
            var fechaFin = prestamo.FchFin.Value;
            var totalDias = (int)(fechaFin - fechaInicio).TotalDays;
            var diasOffset = totalDias > 0 ? (i % totalDias) : 0;
            var fechaObs = fechaInicio.AddDays(diasOffset);

            _context.Observaciones.Add(
                new Observacion(
                    0,
                    prestamo,
                    objetos[i],
                    new VOFechaObs(fechaObs)
                )
            );
        }

        _context.SaveChanges();
    }

    private void CrearAuditoria()
    {
        var prestamos = _context.Prestamos.ToList();

        foreach (var p in prestamos)
        {
            if (p.Coord == null) continue;

            _context.AuditoriaPrestamos.Add(
                new AuditoriaPrestamo(
                    new VOId(p.Id),
                    new VOFchAuditoriaP(DateTime.Now),
                    new VOId(p.Coord.Id),
                    new VOName(p.Coord.Nombre.Value),
                    new VOEstadoPrestamo("Alta")
                )
            );
        }
        _context.SaveChanges();
    }
}
