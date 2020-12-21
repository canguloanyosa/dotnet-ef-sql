namespace LeerData
{
    public class Curso_Instructor
    {
        public int CursoId {get; set;}
        public int InstructorId {get; set;}
        public Curso Curso {get; set;}
        public Instructor Instructor {get; set;}
    }
}