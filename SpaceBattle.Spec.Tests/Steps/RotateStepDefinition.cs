using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using Moq;
using SpaceBattle;
using SpaceBattle.Interface;

namespace SpaceBattle.Spec.Tests
{
    [Binding]
    public class RotateStepDefinition
    {
        Mock<IRotable> mockAdapter = new Mock<IRotable>();

        private readonly ScenarioContext _scenarioContext;

        public RotateStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"объект имеет направление (.*)")]
        public void GivenDirection(int x)
        {
            mockAdapter.SetupGet<int>(o => o.Direction).Returns(x).Verifiable();
        }

        [Given(@"угловая скорость (.*)")]
        public void AndVelocity(int x)
        {
            mockAdapter.SetupGet<int>(o => o.AngularVelocity).Returns(x).Verifiable();
        }

        [Given(@"количество секторов (.*)")]
        public void AndDirectionsNumber(int x)
        {
            mockAdapter.SetupGet<int>(o => o.DirectionsNumber).Returns(x).Verifiable();
        }

        [Then(@"установить направление (.*)")]
        public void ThenTestableOutcome(int x)
        {
            mockAdapter.VerifySet(o => o.Direction = x);
            mockAdapter.Verify();
        }

        [When(@"выполнить поворот")]
        public void WhenMove()
        {
            new RotateCommand(mockAdapter.Object).Execute();
        }

        [Given(@"направление объекта null")]
        public void GivenDirectionNull()
        {
            mockAdapter.SetupGet<int>(m => m.Direction).Throws<Exception>().Verifiable();
        }

        [Then(@"при повороте произошло исключение")]
        public void WhenRotateFail()
        {
            Action act = () => new RotateCommand(mockAdapter.Object).Execute();
            act.Should().Throw<Exception>();
        }

        [Given(@"угловая скорость объекта null")]
        public void AndVelocityNull()
        {
            mockAdapter.SetupGet<int>(m => m.AngularVelocity).Throws<Exception>().Verifiable();
        }

        [Then(@"свойство направление НЕ изменено")]
        public void ThenPositionNotChanged()
        {
            mockAdapter.VerifySet(o => o.Direction = It.IsAny<int>(), Times.Once);
            mockAdapter.Verify();
        }
    }
}