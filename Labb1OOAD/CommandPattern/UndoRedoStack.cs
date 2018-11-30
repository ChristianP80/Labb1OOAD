using System;
using System.Collections.Generic;

namespace Labb1OOAD.NewFolder
{
    public class UndoRedoStack<T>
    {
        public Stack<ICommand<T>> _undoStack;
        public Stack<ICommand<T>> _redoStack;

        public UndoRedoStack()
        {
            _undoStack = new Stack<ICommand<T>>();
            _redoStack = new Stack<ICommand<T>>();
        }

        public T Do(ICommand<T> command, T input)
        {
            T output = command.Do(input);
            _undoStack.Push(command);
            return output;
        }

        public T Undo(T input)
        {
            if(_undoStack.Count > 0)
            {
                ICommand<T> command = _undoStack.Pop();
                T output = command.Undo();
                _redoStack.Push(command);
                return output;
            }
            else
            {
                return input;
            }
        }

        public T Redo()
        {
                ICommand<T> command = _redoStack.Pop();
                T output = command.Redo();
                _undoStack.Push(command);
                return output;
        }
    }
}
