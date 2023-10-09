using System;
using System.Collections.Generic;

namespace Prueba.Tecnica.Libreria.DataAccess.Persistence;

public partial class Libro
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public int Año { get; set; }

    public int IdGenero { get; set; }

    public int NumeroPaginas { get; set; }

    public int IdAutor { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Autor IdAutorNavigation { get; set; } = null!;

    public virtual Genero IdGeneroNavigation { get; set; } = null!;
}
