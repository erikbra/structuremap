using NUnit.Framework;
using StructureMap.Graph;
using StructureMap.Testing.TestData;
using StructureMap.Testing.Widget;

namespace StructureMap.Testing.Configuration
{
    [TestFixture]
    public class DefaultInstanceNodeTester
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            _graph = DataMother.GetPluginGraph("DefaultInstance.xml");
            _manager = new InstanceManager(_graph);
        }

        #endregion

        private InstanceManager _manager;
        private PluginGraph _graph;

        [Test]
        public void DefaultNameOfRule()
        {
            PluginFamily family = _graph.FindFamily(typeof (Rule));
            Assert.AreEqual("TheBlueOne", family.DefaultInstanceKey);
        }

        [Test]
        public void GetTheRule()
        {
            ColorRule rule = (ColorRule) _manager.CreateInstance<Rule>();
            Assert.AreEqual("Blue", rule.Color);

            ColorRule rule2 = (ColorRule) _manager.CreateInstance<Rule>();
            Assert.AreSame(rule, rule2);
        }

        [Test]
        public void GetTheWidget()
        {
            ColorWidget widget = (ColorWidget) _manager.CreateInstance<IWidget>();
            Assert.AreEqual("Red", widget.Color);

            ColorWidget widget2 = (ColorWidget) _manager.CreateInstance<IWidget>();
            Assert.AreNotSame(widget, widget2);
        }
    }
}