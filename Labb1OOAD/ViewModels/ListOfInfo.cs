using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Labb1OOAD.NewFolder;
using Xamarin.Forms;

namespace Labb1OOAD.ViewModels
{
    public class ListOfInfo : INotifyPropertyChanged
    {
        private string _someText;
        public string SomeText
        {
            get { return _someText; }
            set { SetProperty(ref _someText, value); }
        }
        private string _tempText;
        public string TempText 
        {
            get { return _tempText; }
            set { _tempText = value; }
        }

        private ObservableCollection<string> _listOfSomeText = new ObservableCollection<string>();
        public ICommand SaveCommand { get; private set; }
        public ICommand UndoCommand { get; private set; }
        public ICommand RedoCommand { get; private set; }

        public ObservableCollection<string> ListOfSomeText
        {
            get { return _listOfSomeText; }
            private set { SetProperty(ref _listOfSomeText, value); }

        }


        public UndoRedoStack<string> UndoRedo = new UndoRedoStack<string>();
        public AddStringCommand AddString = new AddStringCommand();


        public ListOfInfo()
        {
            SaveCommand = new Command(
                execute: SaveEntryText,
                canExecute: obj => { return true; }
            );
            UndoCommand = new Command(
                execute: Undo,
                canExecute: obj => { return true; }
            );
            RedoCommand = new Command(
                execute: Redo,
                canExecute: obj => { return true; }
            );
        }

        private void Redo(object obj)
        {
            if(UndoRedo._redoStack.Count > 0)
                _listOfSomeText.Add(UndoRedo.Redo());
        }

        private void Undo(object obj)
        {
            if(_listOfSomeText.Count > 0)
            _listOfSomeText.Remove(UndoRedo.Undo(_listOfSomeText[_listOfSomeText.Count - 1]));
        }

        private void SaveEntryText(object obj)
        {
            _listOfSomeText.Add(UndoRedo.Do(AddString, SomeText));
            int test = UndoRedo._undoStack.Count;
            SomeText = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
