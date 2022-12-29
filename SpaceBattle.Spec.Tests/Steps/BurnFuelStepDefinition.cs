using FluentAssertions;
using Moq;
using TechTalk.SpecFlow;


namespace SpaceBattle.Spec.Tests.Steps
{
    [Binding]
    public class BurnFuelStepDefinitions
    {
        Mock<IFuelObject> mockFuel = new Mock<IFuelObject>();

        private readonly ScenarioContext _scenarioContext;

        public BurnFuelStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"объект имеет топлива (.*)")]
        public void GivenVolume(int volume)
        {
            mockFuel.SetupGet(x => x.Volume).Returns(volume).Verifiable();
        }

        [Given(@"расход топлива (.*)")]
        public void GivenFlowRate(int rate)
        {
            mockFuel.SetupGet(x => x.FlowRate).Returns(rate);
        }

        [When(@"выполнить команду сжигания")]
        public void WhenCreateCommand()
        {
            new BurnFuelCommand(mockFuel.Object).Execute();
        }

        [Then(@"объем топлива уменьшен до (.*)")]
        public void BurnSuccess(int newVolume)
        {
            mockFuel.VerifySet(x => x.Volume = newVolume);
            mockFuel.Verify();
        }

        [Then(@"объем топлива НЕ изменился")]
        public void VolumeDescFailed()
        {
            mockFuel.VerifySet(x => x.Volume = It.IsAny<int>(), Times.Once);
            mockFuel.Verify();
        }
    }

}