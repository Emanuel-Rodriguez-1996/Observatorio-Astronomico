using Obligatorio.LogicaAplicacion.Dtos.Equipo;
using Obligatorio.LogicaNegocio.Entidades.Equipo;
using Obligatorio.LogicaNegocio.VO.Equipo;
using Obligatorio.LogicaNegocio.VO.Equipo.Camara;
using Obligatorio.LogicaNegocio.VO.Equipo.Montura;
using Obligatorio.LogicaNegocio.VO.Equipo.Ocular;
using Obligatorio.LogicaNegocio.VO.Equipo.Telescopio;

namespace Obligatorio.LogicaAplicacion.Mappers
{
    public class EquipoMapper
    {
        // DTO → ENTIDAD

        public static Telescopio ToEntity(AltaTelescopioDTO dto)
        {
            return new Telescopio(
                new VOMarca(dto.Marca),
                new VOModelo(dto.Modelo),
                new VOCantDisp(dto.Cantidad),
                new VOApertura(dto.Apertura),
                new VORelacionFocal(dto.RelacionFocal),
                new VODistanciaFocal(dto.DistanciaFocal),
                new VOPeso(dto.Peso)
            );
        }

        public static Camara ToEntity(AltaCamaraDTO dto)
        {
            return new Camara(
                new VOMarca(dto.Marca),
                new VOModelo(dto.Modelo),
                new VOCantDisp(dto.Cantidad),
                new VOPixel(dto.Pixel),
                new VOResolucion(dto.Resolucion),
                new VOTipoSensor(dto.TipoSensor)
            );
        }

        public static Ocular ToEntity(AltaOcularDTO dto)
        {
            return new Ocular(
                new VOMarca(dto.Marca),
                new VOModelo(dto.Modelo),
                new VOCantDisp(dto.Cantidad),
                new VOAngulo(dto.Angulo),
                new VODiametro(dto.Diametro)
            );
        }

        public static Montura ToEntity(AltaMonturaDTO dto)
        {
            return new Montura(
                new VOMarca(dto.Marca),
                new VOModelo(dto.Modelo),
                new VOCantDisp(dto.Cantidad),
                new VOTipoMontura(dto.TipoMontura),
                new VOCargaMontura(dto.CargaSoportada),
                new VOComputarizado(dto.EsComputarizado)
            );
        }

        public static AltaTelescopioDTO ToDto(Telescopio t)
        {
            return new AltaTelescopioDTO(
                t.Id,
                t.Marca.Value,
                t.Modelo.Value,
                t.Cantidad.Value,
                t.Apertura.Value,
                t.RelacionFocal.Value,
                t.DistanciaFocal.Value,
                t.Peso.Value
            );
        }

        public static AltaCamaraDTO ToDto(Camara c)
        {
            return new AltaCamaraDTO(
                c.Id,
                c.Marca.Value,
                c.Modelo.Value,
                c.Cantidad.Value,
                c.Pixel.Value,
                c.Resolucion.Value,
                c.TipoSensor.GetTString()
            );
        }

        public static AltaOcularDTO ToDto(Ocular o)
        {
            return new AltaOcularDTO(
                o.Id,
                o.Marca.Value,
                o.Modelo.Value,
                o.Cantidad.Value,
                o.Angulo.Value,
                o.Diametro.Value
            );
        }

        public static AltaMonturaDTO ToDto(Montura m)
        {
            return new AltaMonturaDTO(
                m.Id,
                m.Marca.Value,
                m.Modelo.Value,
                m.Cantidad.Value,
                m.TipoMontura.GetTString(),
                m.CargaSoportada.Value,
                m.EsComputarizado.Value
            );
        }

        public static void UpdateEntity(AltaTelescopioDTO dto, Telescopio existente)
        {
            var datosNuevos = new Telescopio(
                new VOMarca(dto.Marca),
                new VOModelo(dto.Modelo),
                new VOCantDisp(dto.Cantidad),
                new VOApertura(dto.Apertura),
                new VORelacionFocal(dto.RelacionFocal),
                new VODistanciaFocal(dto.DistanciaFocal),
                new VOPeso(dto.Peso)
            );

            existente.Update(datosNuevos);
        }

        public static void UpdateEntity(AltaCamaraDTO dto, Camara existente)
        {
            var datosNuevos = new Camara(
                new VOMarca(dto.Marca),
                new VOModelo(dto.Modelo),
                new VOCantDisp(dto.Cantidad),
                new VOPixel(dto.Pixel),
                new VOResolucion(dto.Resolucion),
                new VOTipoSensor(dto.TipoSensor)
            );

            existente.Update(datosNuevos);
        }

        public static void UpdateEntity(AltaOcularDTO dto, Ocular existente)
        {
            var datosNuevos = new Ocular(
                new VOMarca(dto.Marca),
                new VOModelo(dto.Modelo),
                new VOCantDisp(dto.Cantidad),
                new VOAngulo(dto.Angulo),
                new VODiametro(dto.Diametro)
            );

            existente.Update(datosNuevos);
        }

        public static void UpdateEntity(AltaMonturaDTO dto, Montura existente)
        {
            var datosNuevos = new Montura(
                new VOMarca(dto.Marca),
                new VOModelo(dto.Modelo),
                new VOCantDisp(dto.Cantidad),
                new VOTipoMontura(dto.TipoMontura),
                new VOCargaMontura(dto.CargaSoportada),
                new VOComputarizado(dto.EsComputarizado)
            );

            existente.Update(datosNuevos);
        }
    }
}