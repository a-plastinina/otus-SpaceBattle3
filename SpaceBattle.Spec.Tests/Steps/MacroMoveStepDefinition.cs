using System;
	using TechTalk.SpecFlow;
    using SpaceBattle;
    using SpaceBattle.Interface;
	using Moq;
    using FluentAssertions;

	namespace MyNamespace
	{
		[Binding]
		public class MacroMoveStepDefinition
		{
           Mock<IFuelObject> mockFuel;
           //IList<ICommand> _chainCommands = new List<ICommand>();
           ICommand[] _chainCommands = new ICommand[3];
           Action macroExecuting;

			private readonly ScenarioContext _scenarioContext;
 	
			public MacroMoveStepDefinition(ScenarioContext scenarioContext)
			{
				_scenarioContext = scenarioContext;
			}

            [Given("создать объект IFuelObject")]
            public void CreateFuelObject()
            {
                mockFuel = new Mock<IFuelObject>();
            }

            [Given("у объекта топлива (.*), скорость (.*)")]
            public void CreateFuelObject(int volume, int rate)
            {
                mockFuel.SetupGet(x => x.Volume).Returns(volume);
                mockFuel.SetupGet(x => x.FlowRate).Returns(rate);
            }

			[Given("создать команду CheckFuel")]
            public void CreateCheckFuel()
            {
                _chainCommands[0] = new CheckFuelCommand(mockFuel.Object);
            }
            [Given("создать команду BurnFuel")]
            public void CreateBurnFuel()
            {
                _chainCommands[2] = new BurnFuelCommand(mockFuel.Object);
            }

            [Given("создать команду Move")]
            public void CreateMove()
            {
                var mockMovable = new Mock<IMovable>();
                mockMovable.SetupGet(x => x.Position).Returns(It.IsAny<Vector>());
                mockMovable.SetupGet(x => x.Velocity).Returns(It.IsAny<Vector>());

                _chainCommands[1] = new MoveCommand(mockMovable.Object);
            }

            [Given("создать команду Rotate")]
            public void CreateRotate()
            {
                var mockMovable = new Mock<IRotable>();
                mockMovable.SetupGet(x => x.Direction).Returns(It.IsAny<int>());
                mockMovable.SetupGet(x => x.DirectionsNumber).Returns(It.IsAny<int>());
                mockMovable.SetupGet(x => x.AngularVelocity).Returns(It.IsAny<int>());

                _chainCommands[1] = new RotateCommand(new Mock<IRotable>().Object);
            }

            [When("выполнить макрокоманду движение")]
            public void MacroMoveExecute()
            {
                macroExecuting = () => new MacroCommand(_chainCommands).Execute();
            }

            [When("выполнить макрокоманду поворот")]
            public void MacroRotateExecute()
            {
                macroExecuting = () => new MacroCommand(_chainCommands).Execute();
            }

            [When("выполнить макрокоманду")]
            public void MacroExecute()
            {
                macroExecuting = () => new MacroCommand(_chainCommands).Execute();
            }

            [Then("все шаги MacroCommand выполнены")]
            public void Success()
            {
                macroExecuting.Should().NotThrow<CommandException>();
            }

            [Then("выброшено исключение на одном из шагов MacroCommand")]
            public void Failed()
            {
                macroExecuting.Should().Throw<CommandException>();
            }
		}
	}