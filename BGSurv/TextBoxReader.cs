using System.Collections.Generic;
using System.IO;

namespace BGSurv
{
    public class TextBoxReader
    {

        public bool open;
        public string currentText;
        private List<string> text;
        private int index;
        public object sender;

        public List<string> instructions;

        public void OpenText(string name, object sender)
        {
            this.sender = sender;
            open = true;
            StreamReader reader = new StreamReader(@"Text\" + name + ".txt");
            text = new List<string>();
            index = 0;

            instructions = new List<string>();

            //read all the text for this string
            while (!reader.EndOfStream)
            {
                text.Add(reader.ReadLine());
            }

            Next();

            //remember to close
            reader.Close();
        }

        public void Next()
        {
            currentText = text[index];

            string i = currentText[0].ToString();

            //Add instructions to list to be executed
            if (string.Equals(i, "!"))
            {
                instructions.Clear();

                while (index < text.Count)
                {
                    instructions.Add(text[index]);
                    index++;
                }
                open = false;
            }

            index++;
        } 
    }
}