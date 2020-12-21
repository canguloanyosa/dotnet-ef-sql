using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;

namespace LeerData
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new appventaCursosContext()) {
                // var cursos = db.Curso.Include( c => c.ComentarioLista).AsNoTracking();

                var cursos = db.Curso.Include( c => c.InstructorLink).ThenInclude( ci => ci.Instructor);

                foreach (var curso in cursos)
                {
                    Console.WriteLine(curso.Titulo);
                    foreach(var instructor in curso.InstructorLink)
                    {
                        Console.WriteLine("**************" + instructor.Instructor.Nombre + instructor.Instructor.Apellidos);
                    }
                }

                // Insertar nuevo registro

                var nuevoInstructor = new Instructor
                {
                    Nombre = "Mauricio",
                    Apellidos = "Isla",
                    Grado = "Master en computación"
                };

                db.Add(nuevoInstructor);
                var estadoTransaccionSave = db.SaveChanges();
                Console.WriteLine("Estado de la transacción: " + estadoTransaccionSave);

                // Actualizar registro

                var instructorUpdate = db.Instructor.Single( p => p.Nombre == "Nilton");
                if(instructorUpdate != null)
                {
                    instructorUpdate.Apellidos = "Vargas";
                    instructorUpdate.Grado = "Master en computación";
                    var estadoTransaccionUpdate = db.SaveChanges();
                    Console.WriteLine("Estado de la transacción: " + estadoTransaccionUpdate);
                }

                // Eliminar registro

                var instructorDelete = db.Instructor.Single( p => p.InstructorId == 3);
                if(instructorDelete != null)
                {
                    db.Remove(instructorDelete);
                    var estadoTransaccionDelete = db.SaveChanges();
                    Console.WriteLine("Estado de la transacción: " + estadoTransaccionDelete);
                }
            }
        }
    }
}
