using System;
using System.Collections.Generic;

namespace Labb1OOAD.NewFolder
{
    public class AddStringCommand : ICommand<string>
    {
        //private string _text;
        //public string Text { get => _text; set => _text = value; }

        private List<string> undoList;
        private List<string> redoList;

        public AddStringCommand()
        {
            undoList = new List<string>();
            redoList = new List<string>();
        }

        public string Do(string input)
        {
            undoList.Add(input);
            if(redoList.Count < 1)
            {
                return input;
            }
            else
            {
                return redoList[redoList.Count - 1];
            }

        }


        //public string Undo(string input)
        public string Undo()
        {
            if (undoList.Count < 1)
            {
                return "";
            }
            else
            {
                string stringFromList = undoList[undoList.Count - 1];
                undoList.Remove(stringFromList);
                redoList.Add(stringFromList);
                return stringFromList;
            }

            //return input;
        }

        public string Redo()
        {
            string stringFromList = redoList[redoList.Count - 1];
            redoList.Remove(stringFromList);
            undoList.Add(stringFromList);
            return stringFromList;
        }
    }
}
