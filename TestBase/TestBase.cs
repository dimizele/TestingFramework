using NUnit.Framework;

namespace TestBase
{
    public class TestBase
    {
        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            BeforeAll();
        }

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {
            AfterAll();
        }

        [SetUp]
        public virtual void SetUp()
        {
            BeforeEach();
        }

        [TearDown]
        public virtual void TearDown()
        {
            AfterEach();
        }

        public virtual void BeforeAll()
        {

        }

        public virtual void AfterAll()
        {

        }

        public virtual void BeforeEach()
        {

        }

        public virtual void AfterEach()
        {

        }
    }
}
