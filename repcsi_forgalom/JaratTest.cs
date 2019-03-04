using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace repcsi_forgalom.Test
{
    [TestFixture]
    public class JaratTest
    {
        Jaratkezelo jaratkezelo;
        [SetUp]
        public void Setup()
        {
            jaratkezelo = new Jaratkezelo();
        }

        [Test]
        public void UjJaratTest()
        {
            jaratkezelo.UjJarat("262", "Kiskunfélegyháza", "Kishalas", new DateTime(2019, 03, 04));          
        }

        [Test]
        public void MikorIndulTest()
        {
            jaratkezelo.UjJarat("262", "Kiskunfélegyháza", "Kishalas", new DateTime(2019, 03, 04));
            Assert.AreEqual(new DateTime(2019, 03, 04), jaratkezelo.MikorIndul("262"));
        }
        [Test]
        public void jaratokRepuloterrolTest()
        {
            jaratkezelo.UjJarat("262", "Kiskunfélegyháza", "Kishalas", new DateTime(2019, 03, 04));
            var elvartLista = new List<string>();
            elvartLista.Add("262");
            Assert.AreEqual(elvartLista, jaratkezelo.jaratokRepuloterrol("Kiskunfélegyháza"));
        }
        [Test]
        public void Ketugyanolyanjarat()
        {
            jaratkezelo.UjJarat("262", "Kiskunfélegyháza", "Kishalas", new DateTime(2019, 03, 04));
            Assert.Throws<ArgumentException>(
                () =>
                {
                    jaratkezelo.UjJarat("262", "Kiskunfélegyháza", "Kishalas", new DateTime(2019, 03, 04));
                }
                );
        }
    }
}
