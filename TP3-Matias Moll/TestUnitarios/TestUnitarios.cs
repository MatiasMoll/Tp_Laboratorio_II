using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using ClasesInstanciables;
using static EntidadesAbstractas.Persona;
using static ClasesInstanciables.Universidad;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ValidarExcepcionDni()
        {
            Alumno alumno = new Alumno(1, "Matias", "Moll", "asdad", ENacionalidad.Argentino, EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void ValidarProfesores()
        {
            Universidad u = new Universidad();
            Profesor p = u == EClases.Laboratorio;

        }
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void ValidarAlumnoRepetido()
        {
            Alumno a = new Alumno(1, "Matias", "Moll", "40144426", ENacionalidad.Argentino, EClases.Laboratorio);
            Alumno a2 = new Alumno(2, "Santiago", "Gaggia", "40144426", ENacionalidad.Argentino, EClases.Programacion);
            Universidad u = new Universidad();
            u += a;
            u += a2;
        }
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void ValidarNacionalidad()
        {
            Alumno alumno = new Alumno(1, "Matias", "Moll", "25000999", ENacionalidad.Extranjero, EClases.SPD);
        }

        [TestMethod]
        public void ValidarNumero()
        {
            Alumno p = new Alumno(1, "Matias", "Moll", "40144426", ENacionalidad.Argentino, EClases.Programacion);
            int valorEsperado = 40144426;
            Assert.AreEqual(p.Dni, valorEsperado);
        }

        [TestMethod]
        public void VerificarNullJornada()
        {
            Profesor p = new Profesor();
            Jornada j = new Jornada(EClases.Laboratorio, p);
            Assert.IsNotNull(j.Alumnos);
        }

        [TestMethod]
        public void ValidarNullUniversidad()
        {
            Universidad u = new Universidad();
            Assert.IsNotNull(u.Alumnos);
            Assert.IsNotNull(u.Instructores);
            Assert.IsNotNull(u.Jornadas);
        }
    }
}
