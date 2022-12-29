using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using SpaceBattle.Interface;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace SpaceBattle.Spec.Tests.Steps
{
    [Binding]
    public class MacroRotateCommandStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        
        Mock<IRotableForMove> mock = new Mock<IRotableForMove>();

        ICommand macrocmd;
        Action macroExecuting;
        public MacroRotateCommandStepDefinition(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;
        
        [Given("создать объект IMovable")]
        public void CreateMovableObject()
        {
            mock.SetupGet(x => x.movable).Returns(It.IsAny<IMovable>());
        }

        [Given("установить направление (.*), угловую скорость (.*) и количество секторов (.*)")]
        public void SetRotateProperties(int d, int av, int n)
        {
            mock.SetupGet(x => x.Direction).Returns(d);
            mock.SetupGet(x => x.AngularVelocity).Returns(av);
            mock.SetupGet(x => x.DirectionsNumber).Returns(n);
        }

        [Given("создать объект с направлением (.*), угловую скорость (.*) и количество секторов (.*)")]
        public void CreateRotateObject(int d, int av, int n)
        {
            mock.SetupGet(x => x.Direction).Returns(d);
            mock.SetupGet(x => x.AngularVelocity).Returns(av);
            mock.SetupGet(x => x.DirectionsNumber).Returns(n);
        }

        [When("выполнить MacroRotateCommand")]
        public void MacroExecute()
        {
            macroExecuting = () => new MacroRotateCommand(mock.Object).Execute();
        }

        [Then("мгновенная скорость изменена")]
        public void SuccessChangeVelocity()
        {
            macroExecuting.Should().NotThrow<CommandException>();
            mock.Verify(m => m.ChangeVelocity(It.IsAny<Vector>()), Times.Never);
        }

        [Then("мгновенная скорость не изменялась")]
        public void SuccessNoChange()
        {
            macroExecuting.Should().NotThrow<CommandException>();
            mock.Verify(m => m.ChangeVelocity(It.IsAny<Vector>()), Times.Never);
        }
            
    }
    
}