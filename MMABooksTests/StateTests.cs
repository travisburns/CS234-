using NUnit.Framework;
using MMABooksBusinessClasses;
using System;

namespace MMABooksTests
{
    [TestFixture]
    public class StateTests
    {

        [Test]
        public void Test1()
        {
            int expected = 5;
            Assert.AreEqual(expected, 3 + 2);
        }

        [Test]
        public void TestStateConstructor()
        {
            State state1 = new State();
            Assert.IsNotNull(state1);
            Assert.AreEqual(null, state1.StateCode);
            Assert.AreEqual(null, state1.StateName);

            string newCode = "OR";
            string newName = "Oregon";
            State state2 = new State(newCode, newName);
            Assert.IsNotNull(state2);
            Assert.AreEqual(newCode, state2.StateCode);
            Assert.AreEqual(newName, state2.StateName);
        }

        [Test]
        public void TestStateSetters()
        {
            State state1 = new State("NY", "New York");
            string newCode = "OR";
            string newName = "Oregon";
            // call the setters
            state1.StateCode = newCode;
            state1.StateName = newName;
            // assert that the property now returns the new values
            Assert.AreEqual(newCode, state1.StateCode);
            Assert.AreEqual(newName, state1.StateName);
            // the previous part of the test isn't sufficient because the setters might ALWAYS set the properties to oregon
            // make sure that's not the case by providing a different set of values
            newCode = "CA";
            newName = "California";
            state1.StateCode = newCode;
            state1.StateName = newName;
            Assert.AreEqual(newCode, state1.StateCode);
            Assert.AreEqual(newName, state1.StateName);
        }

        [Test]
        public void TestStateGetters()
        {
            // The previous test wouldn't pass if the getters didn't work so I'll omit this one
            // notice that it passes
        }  

        [Test]
        public void TestStateToString()
        {
            State state1 = new State("NY", "New York");
            Assert.IsTrue(state1.ToString().Contains("NY"));
            Assert.IsTrue(state1.ToString().Contains("New York"));
        }


        // you may have noticed that I need a state object in each test
        // a better solution is to create an instance variable for the state
        // and create a method, annotated with [SetUp], to instantiate the object
        // all tests could then use state (rather than state1) 
        private State state;

        // this method gets called BEFORE EVERY TEST to recreate the state object
        // so that every test gets a "fresh" state and the results of one test
        // don't impact the results of the next
        [SetUp]
        public void SetUp()
        {
            state = new State("NY", "New York");
        }

        [Test]
        public void TestSettersInvalidValueTryCatch()
        {
            try
            {
                state.StateCode = "123";
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.Pass("If the exception IS thrown, the property IS doing the right thing.");
            }
        }

        [Test]
        public void TestSettersInvalidValueThrows()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => state.StateCode = "123");
        }
    }
}

