using System;
	using TechTalk.SpecFlow;
    using SpaceBattle;
    using SpaceBattle.Interface;
	using Moq;
    using FluentAssertions;

	namespace SpaceBattle.Spec.Tests
	{
		[Binding]
		public class MacroMoveStepDefinition
		{
           Mock<IFuelObject> mockFuel;
           //IList<ICommand> _chainCommands = new List<ICommand>();
           ICommand[] _chainCommands = new ICommand[3];
           ICommand macroMove;
           Action macroExecuting;

			private readonly ScenarioContext _scenarioContext;
 	
			public MacroMoveStepDefinition(ScenarioContext scenarioContext)
			{
				_scenarioContext = scenarioContext;
			}

            [Given("создать объект IFuelObject с топливом (.*), скоростью (.*)")]
            public void CreateFuelObject(int volume, int rate)
            {
                mockFuel = new Mock<IFuelObject>();
                mockFuel.SetupGet(x => x.Volume).Returns(volume);
                mockFuel.SetupGet(x => x.FlowRate).Returns(rate);
            }            

            [Given("создать MacroMoveCommand")]
            public void CreateMove()
            {
                macroMove = new MacroMoveCommand(mockFuel.Object);
            }         

            [When("выполнить MacroMoveCommand")]
            public void MacroMoveExecute()
            {
                macroExecuting = () => macroMove.Execute();
            }

            [Then("все шаги MacroMoveCommand выполнены")]
            public void Success()
            {
                macroExecuting.Should().NotThrow<CommandException>();
            }

            [Then("выброшено исключение в MacroMoveCommand")]
            public void Failed()
            {
                macroExecuting.Should().Throw<CommandException>();
            }
		}
	}