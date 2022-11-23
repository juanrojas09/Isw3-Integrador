
using Isw3.Dao.Interface;
using Isw3.models;
using Isw3_Integrador.Context;
using Isw3_Integrador.Models;
using Microsoft.EntityFrameworkCore;

namespace Isw3.Dao.Implementation
{
    public class AlumnoDao : IAlumnoDao
    {
        private readonly contexto _Context;
        public AlumnoDao(contexto context)
        {
            _Context = context;
        }
        public List<Alumno> GetAlumno()
        {
           List<Alumno> alumnos= _Context.Alumno.ToList();


            return alumnos;
        }

        public Alumno SetAlumnio(Alumno alumnos)
        {
             _Context.Alumno.Add(alumnos);
            _Context.SaveChanges();
            
            return alumnos;
        }
    }
}
