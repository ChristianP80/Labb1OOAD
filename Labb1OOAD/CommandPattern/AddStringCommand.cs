using System;
namespace Labb1OOAD.NewFolder
{
    public class AddStringCommand : ICommand<string>
    {
        private string _text;
        public string Text { get => _text; set => _text = value; }

        public AddStringCommand()
        {

        }

        public AddStringCommand(string input)
        {
            _text = input;
        }


        public string Do(string input)
        {
            return input;
        }

        public string Undo(string input)
        {
            return input;
        }
    }
}
