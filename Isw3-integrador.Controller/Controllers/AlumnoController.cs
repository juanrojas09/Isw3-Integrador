using Isw3.Dao.Interface;
using Isw3_Integrador.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Isw3_integrador.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoDao _alumnoDao;
        public AlumnoController(IAlumnoDao alumnoDao)
        {
            _alumnoDao = alumnoDao;
        }

        [HttpGet("Get")]
        public List<Alumno> GetAlumno()
        {
            var alumnos = _alumnoDao.GetAlumno();
            return alumnos;
        }

        [HttpPost("Set")]
        public Alumno SetAlumno(Alumno alumno)
        {
            var alumnos = _alumnoDao.SetAlumnio(alumno);
            return alumno;
        }
    }
}
