using System;
using System.Collections.Generic;

namespace Prueba.Tecnica.Libreria.DataAccess.Persistence;

public partial class Genero
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
