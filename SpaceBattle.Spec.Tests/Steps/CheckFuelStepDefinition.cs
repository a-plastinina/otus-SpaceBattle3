using Moq;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace SpaceBattle.Spec.Tests.Steps
{
    [Binding]
    public class CheckFuelStepDefinition
    {
        Mock<IFuelObject> mockFuel = new Mock<IFuelObject>();
        Action checkCommandExecute;

        private readonly ScenarioContext _scenarioContext;

        public CheckFuelStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"объект имеет объем топлива (.*)")]
        public void GivenVolume(int volume)
        {
            mockFuel.SetupGet(x => x.Volume).Returns(volume);
        }

        [Given(@"скорость расхода топлива (.*)")]
        public void GivenFlowRate(int rate)
        {
            mockFuel.SetupGet(x => x.FlowRate).Returns(rate);
        }

        [When(@"создана команда проверки")]
        public void WhenCreateCommand()
        {
           checkCommandExecute = () => new CheckFuelCommand(mockFuel.Object).Execute();
        }

        [Then(@"проверка проходит успешно")]
        public void CheckSuccess()
        {
            checkCommandExecute.Should().NotThrow<CommandException>();
        }

        [Then(@"получено исключение")]
        public void CheckFailed()
        {
            checkCommandExecute.Should().Throw<CommandException>();
        }
     
    }

}