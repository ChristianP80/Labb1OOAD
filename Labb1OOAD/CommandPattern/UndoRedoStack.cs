using System;
using System.Collections.Generic;

namespace Labb1OOAD.NewFolder
{
    public class UndoRedoStack<T>
    {
        private Stack<ICommand<T>> _undoStack;
        private Stack<ICommand<T>> _redoStack;

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
                T output = command.Undo(input);
                _redoStack.Push(command);
                return output;
            }
            else
            {
                return input;
            }
        }

        public T Redo(T input)
        {
            if(_redoStack.Count > 0)
            {
                ICommand<T> command = _redoStack.Pop();
                T output = command.Do(input);
                _undoStack.Push(command);
                return output;
            }
            else
            {
                return input;
            }
        }
    }
}
