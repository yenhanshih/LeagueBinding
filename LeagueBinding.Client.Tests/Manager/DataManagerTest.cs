using System.Linq;
using LeagueBinding.Client.Common;
using LeagueBinding.Client.Manager.Interfaces;
using LeagueBinding.Client.Models;
using NUnit.Framework;

namespace LeagueBinding.Client.Tests.Manager
{
    [TestFixture]
    public class DataManagerTest
    {
        [Test]
        public void CreateCastSpellGameEventsResource_ShouldCreateFourGameEvents()
        {
            var sut = Ioc.Container.GetInstance<IDataManager>();

            var events = sut.CreateCastSpellGameEventsResource();

            Assert.AreEqual(events.Count, 4);
            Assert.IsTrue(events.All(_ => _.GetType() == typeof(GameEvent)));
        }

        [Test]
        public void CreateCastSpellQuickbindsResource_ShouldCreateFourQuickbinds()
        {
            var sut = Ioc.Container.GetInstance<IDataManager>();

            var events = sut.CreateCastSpellQuickbindsResource();

            Assert.AreEqual(events.Count, 4);
            Assert.IsTrue(events.All(_ => _.GetType() == typeof(Quickbind)));
        }

        [Test]
        public void CreateCastSpellGameEventsResource_ShouldCreateFourGameEventNames()
        {
            var sut = Ioc.Container.GetInstance<IDataManager>();

            var events = sut.CreateUseItemGameEventsResource();

            Assert.AreEqual(events.Count, 6);
            Assert.IsTrue(events.All(_ => _.GetType() == typeof(GameEvent)));
        }

        [Test]
        public void CreateUseItemQuickbindsResource_ShouldCreateFourQuickbinds()
        {
            var sut = Ioc.Container.GetInstance<IDataManager>();

            var events = sut.CreateUseItemQuickbindsResource();

            Assert.AreEqual(events.Count, 6);
            Assert.IsTrue(events.All(_ => _.GetType() == typeof(Quickbind)));
        }
    }
}
