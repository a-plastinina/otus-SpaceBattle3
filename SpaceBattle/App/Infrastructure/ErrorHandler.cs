using System;
using System.Collections;
using SpaceBattle.Interface;

namespace SpaceBattle
{
    delegate bool Proccessing(ICommand cmd, Exception ex);

    public class ErrorHandler
    {
        private readonly Hashtable strategies = new Hashtable();

        ICommand Cmd { get; }
        Exception Exception { get; }

        public ErrorHandler(Exception exception, ICommand executing)
        {
            this.Exception = exception;
            this.Cmd = executing;
        }

        public void Setup(Type executingType, Type exceptionType, Action<ICommand, Exception> method)
        {
            strategies[executingType] = new DictionaryEntry(exceptionType, method);
        }

        public ErrorHandler() { }

        public void Proccess(Exception exception, ICommand executing)
        {
            var item = strategies[executing.GetType()];
            if (item == null) throw exception;

            var method = (Action<ICommand, Exception>)((DictionaryEntry)item).Value;
            method(executing, exception);

        }
    }
}