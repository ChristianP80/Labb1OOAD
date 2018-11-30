using System;
using System.Collections.Generic;

namespace Labb1OOAD.NewFolder
{
    public class AddStringCommand : ICommand<string>
    {

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
            return input;

        }

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
