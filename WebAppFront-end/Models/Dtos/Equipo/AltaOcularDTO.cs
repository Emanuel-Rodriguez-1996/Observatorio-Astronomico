namespace WebAppFront_end.Models.Dtos.Equipo
{
    public record AltaOcularDTO(
     int id,
     string Marca,
     string Modelo,
     int Cantidad,
     decimal Angulo,
     decimal Diametro
        );
}

