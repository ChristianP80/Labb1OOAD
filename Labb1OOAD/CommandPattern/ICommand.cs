using System;
namespace Labb1OOAD.NewFolder
{
    public interface ICommand<T>
    {
        T Do(T input);
        T Undo(T input);
    }
}
