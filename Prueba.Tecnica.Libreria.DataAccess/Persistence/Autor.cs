using System;
using System.Collections.Generic;

namespace Prueba.Tecnica.Libreria.DataAccess.Persistence;

public partial class Autor
{
    public int Id { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string CiudadProcedencia { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
