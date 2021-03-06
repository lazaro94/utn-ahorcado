using Ahorcado.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ahorcado.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void ProbarLetraAcertada()
        {
            var testWord = "ANDAS";
            var testLetra = "A";
            var jugador = new Jugador("TEST1", testWord);
            var gameManager = new GameManager(jugador);

            var validarLetra = gameManager.ProbarLetra(testLetra);

            Assert.IsTrue(validarLetra);
        }

        [TestMethod]
        public void ProbarLetraFallida()
        {
            var testWord = "ANDAS";
            var testLetra = "L";
            var jugador = new Jugador("TEST1", testWord);
            var gameManager = new GameManager(jugador);

            var validarLetra = gameManager.ProbarLetra(testLetra);

            Assert.IsFalse(validarLetra);
        }

        [TestMethod]
        public void ProbarVictoria()
        {
            var palabraPorAdivinar = "ANDAS";
            var letrasAJugar = new string[] { "A", "N", "L", "D", "S" };
            var jugador = new Jugador("TEST1", palabraPorAdivinar);
            var gameManager = new GameManager(jugador);

            foreach (var letra in letrasAJugar)
            {
                gameManager.ProbarLetra(letra);
            }

            // Definicion de victoria
            Assert.IsTrue(gameManager.Finalizo);
            Assert.IsTrue(gameManager.Resultado.Estado == EstadoJuego.Victoria);
        }

        [TestMethod]
        public void ProbarDerrota()
        {
            var testWord = "ANDAS";
            var letrasAJugar = new string[] { "C", "L", "Z", "P", "R", "J", "X" };
            var jugador = new Jugador("TEST1", testWord);
            var gameManager = new GameManager(jugador);

            foreach (var letra in letrasAJugar)
            {
                gameManager.ProbarLetra(letra);
            }

            // Definicion de derrota
            Assert.IsTrue(gameManager.Finalizo);
            Assert.IsTrue(gameManager.Resultado.Estado == EstadoJuego.Derrota);
        }

        [TestMethod]
        public void ArriesgarPalabraErronea()
        {
            var testWord = "ANDAS";
            var palabraArriesgada = "FAIL";
            var jugador = new Jugador("TEST1", testWord);
            var gameManager = new GameManager(jugador);

            gameManager.ArriesgarPalabra(palabraArriesgada);

            // Definicion de derrota
            Assert.IsTrue(gameManager.Finalizo);
            Assert.IsTrue(gameManager.Resultado.Estado == EstadoJuego.Derrota);
        }

        [TestMethod]
        public void ArriesgarPalabraCorrecta()
        {
            var testWord = "ANDAS";
            var palabraArriesgada = "ANDAS";
            var jugador = new Jugador("TEST1", testWord);
            var gameManager = new GameManager(jugador);

            gameManager.ArriesgarPalabra(palabraArriesgada);

            // Definicion de derrota
            Assert.IsTrue(gameManager.Finalizo);
            Assert.IsTrue(gameManager.Resultado.Estado == EstadoJuego.Victoria);
        }
    }
}