using Isw3.Dao.Implementation;
using Isw3.Dao.Interface;
using Isw3_Integrador.Models;
using Moq;
using NUnit.Framework.Internal;

namespace Isw3_Test
{
    public class Tests
    {
        private Mock<IAlumnoDao> dataAccess;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void GetAll_Is_Not_Null()
        {

            //arrange
            List<Alumno> alumnos = new List<Alumno>();
            Alumno alumno = new Alumno()
            {
                Id = 1,
                Nombre = "Juan",
                Apellido = "Perez",
                Dni = "12345678",
                Email = "juanpe@ucc.edu.ar"
            };
            alumnos.Add(alumno);

            dataAccess = new Mock<IAlumnoDao>();
            
            dataAccess.Setup(a => a.GetAlumno()).Returns(alumnos);

            //act
            var result = dataAccess.Object.GetAlumno();

            //assert

            Assert.IsNotEmpty(result);
            Assert.AreEqual(alumno, result[0]);
        }
    }
}