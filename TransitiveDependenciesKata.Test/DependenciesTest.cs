using NUnit.Framework;

namespace TransitiveDependenciesKata.Test
{
    [TestFixture]
    public class DependenciesTest
    {
        Dependencies _dependencies;

        [SetUp]
        public void SetUp()
        {
            _dependencies = new Dependencies();
            _dependencies.AddDirect("A", new[] { "B", "C" });
            _dependencies.AddDirect("B", new[] { "C", "E" });
            _dependencies.AddDirect("C", new[] { "G" });
            _dependencies.AddDirect("D", new[] { "A", "F" });
            _dependencies.AddDirect("E", new[] { "F" });
            _dependencies.AddDirect("F", new[] { "H" });
        }

        [TestCase("A", new[] { "B", "C", "E", "F", "G", "H" })]
        [TestCase("B", new[] { "C", "E", "F", "G", "H" })]
        [TestCase("C", new[] { "G" })]
        [TestCase("D", new[] { "A", "B", "C", "E", "F", "G", "H" })]
        [TestCase("E", new[] { "F", "H" })]
        [TestCase("F", new[] { "H" })]
        public void FindsDependencies(string item, string[] dependencies)
        {
            Assert.That(_dependencies.For(item), Is.EqualTo(dependencies));
        }
    }
}
