using Isw3.models;
using Isw3_Integrador.Models;

namespace Isw3.Dao.Interface
{
    public interface IAlumnoDao
    {
        public List<Alumno> GetAlumno();
        public Alumno SetAlumnio(Alumno alumnos);
        
    }
}
