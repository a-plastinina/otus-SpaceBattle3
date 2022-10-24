using System;
using SpaceBattle;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace SpaceBattle.Spec.Tests
{
    [Binding]
    public class VectorStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private Vector? p1;

        public VectorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"первый объект Vector (.*),(.*)")]
        public void SetPosition1(int x, int y)
        {
            p1 = new Vector(x,y);
        }

        [When(@"прибавить объект Vector (.*),(.*)")]
        public void PlusPosition2(int x, int y)
        {
            p1 += new Vector(x,y);
        }

        [Then(@"результат равно (.*),(.*)")]
        public void GetResult(int x, int y)
        {
            p1.Should().Be(new Vector(x,y));
        }
    }
}