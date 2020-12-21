using System.Collections.Generic;

namespace LeerData
{
    public class Curso
    {
      public int CursoId {get; set;}
      public string Titulo {get; set;}
      public string Descripcion {get; set;}
      public System.DateTime FechaPub {get; set;}
      public byte[] FotoPortada {get; set;}
      public Precio Precio {get; set;}
      public ICollection<Comentario> ComentarioLista {get; set;}
      public ICollection<Curso_Instructor> InstructorLink {get; set;}
    }

}