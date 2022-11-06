using Moq;
using FluentAssertions;
using SpaceBattle.Interface;
using TechTalk.SpecFlow;
using System.Collections;

namespace SpaceBattle.Spec.Tests
{
    [Binding]
    public class ErrorHandlerStepDefinitions
    {
        readonly ErrorHandler handler = new ErrorHandler();

        readonly Mock<Queue<ICommand>> mockQueue = new Mock<Queue<ICommand>>();
        
        ICommand cmdMove;

        Exception exp;
        DictionaryEntry strategy;

        private readonly ScenarioContext _scenarioContext;

        public ErrorHandlerStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"есть команда MoveCommand")]
        public void GivenMoveCommand()
        {
            cmdMove = new MoveCommand(new Mock<IMovable>().Object);
        }

        [Given(@"стратегия логировать исключения во время MoveCommand")]
        public void AndLogStrategy()
        {
            handler.Setup(
                typeof(MoveCommand),
                typeof(NullReferenceException),
                (ICommand cmd, Exception ex) => mockQueue.Object.Enqueue(new LogCommand(ex, cmd)));
        }

        [Given(@"стратегия повторять команду после исключения")]
        public void AndRepeatStrategy()
        {
            handler.Setup(
                typeof(MoveCommand),
                typeof(NullReferenceException),
                (ICommand cmd, Exception ex) => mockQueue.Object.Enqueue(new OneCommand(cmd)));
        }

        [Given(@"стратегия повторять MoveCommand еще раз")]
        public void AndTwoRepeatStrategy()
        {
            handler.Setup(
                typeof(OneCommand),
                typeof(NullReferenceException),
                (ICommand cmd, Exception ex) => mockQueue.Object.Enqueue(new TwoCommand(cmd)));
        }

        [Given(@"стратегия логировать исключения после исключения")]
        public void AndOneRepeatLogStrategy()
        {
            handler.Setup(
                typeof(OneCommand),
                typeof(NullReferenceException),
                (ICommand cmd, Exception ex) => mockQueue.Object.Enqueue(new LogCommand(ex, cmd)));
        }

        [Given(@"стратегия логировать исключения после повторного исключения")]
        public void AndTwoRepeatLogStrategy()
        {
            handler.Setup(
                typeof(TwoCommand),
                typeof(NullReferenceException),
                (ICommand cmd, Exception ex) => mockQueue.Object.Enqueue(new LogCommand(ex, cmd)));
        }

        [Then(@"поставить команду LogCommand в очередь")]
        public void LogInfo()
        {           
            handler.Proccess(exp, cmdMove);
            mockQueue.Object.Dequeue().Should().BeOfType<LogCommand>();
        }

        [Then(@"поставить команду OneCommand в очередь")]
        public void OneCommand()
        {
            handler.Proccess(exp, cmdMove);
            mockQueue.Object.Dequeue().Should().BeOfType<OneCommand>();
        }

        [Then(@"поставить в очередь команду OneCommand и лог")]
        public void OneLogCommand()
        {
            Action act = () => cmdMove.Execute();
            act.Should().Throw<Exception>();
            handler.Proccess(exp, cmdMove);
            mockQueue.Object.Dequeue().Should().BeOfType<OneCommand>();

            var one = new OneCommand(cmdMove);
            act = () => one.Execute();
            act.Should().Throw<Exception>();          
            handler.Proccess(exp, one);
            mockQueue.Object.Dequeue().Should().BeOfType<LogCommand>(); 
        }


        [Then(@"поставить команду TwoCommand в очередь")]
        public void TwoCommand()
        {            
            Action act = () => cmdMove.Execute();
            act.Should().Throw<Exception>();
            handler.Proccess(exp, cmdMove);
            mockQueue.Object.Dequeue().Should().BeOfType<OneCommand>();

            var one = new OneCommand(cmdMove);
            act = () => one.Execute();
            act.Should().Throw<Exception>();          
            handler.Proccess(exp, one);
            mockQueue.Object.Dequeue().Should().BeOfType<TwoCommand>();

            var two = new TwoCommand(one);
            act = () => two.Execute();
            act.Should().Throw<Exception>();

            handler.Proccess(exp, two);
            mockQueue.Object.Dequeue().Should().BeOfType<LogCommand>();
        }
    }
}