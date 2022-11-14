using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

namespace KunskapsprovAOOP
{
    public class Menu
    {

        public void RunMainMenu()
        {
            var CrudBear = new CrudBear();
            string[] upDown = 
            {   
                "Show all the best bears",
                "Look for specific bear",
                "Add a new favourite bear",
                "Edit information of a bear",
                "Remove a bear",
                "Exit app" 
            };
            MenuSkeleton menu = new MenuSkeleton(upDown);
            int HighIndex = menu.Nav();

            switch (HighIndex)
            {

                case 0:    
                    
                    CrudBear.FindAll();
                    
                    break;

                case 1:
                    CrudBear.FindOne();
                    break;

                case 2:
                    CrudBear.CreateNew();
                    
                    break;

                case 3:
                    CrudBear.Update();
                    
                    break;

                case 4:
                    CrudBear.Delete();
                    break;
                
                case 5:
                    Environment.Exit(0);
                    break;


            }
            
        }
        public class MenuSkeleton
        {
            public int HighIndex;
            public string[] Choices;
            

            public MenuSkeleton(string[] choices)
            {
                
                Choices = choices;
                HighIndex = 0;
            }

            private void ShowChoices()
            {
                
                for (int i = 0; i < Choices.Length; i++)
                {
                    string markedChoice = Choices[i];
                    string prefix;

                    if (i == HighIndex)
                    {
                        prefix = "■";
                    }
                    else
                    {
                        prefix = " ";
                    }

                    WriteLine($"{prefix} {markedChoice}");
                }
            }

            public int Nav()
            {
                ConsoleKey keyPushed;
                do
                {
                    Clear();
                    ShowChoices();
                    ConsoleKeyInfo keyInfo = ReadKey(true);
                    keyPushed = keyInfo.Key;

                    if (keyPushed == ConsoleKey.UpArrow)
                    {
                        HighIndex--;
                        if (HighIndex == -1)
                        {
                            HighIndex = Choices.Length - 1;
                        }
                    }
                    else if (keyPushed == ConsoleKey.DownArrow)
                    {
                        HighIndex++;
                        if (HighIndex == Choices.Length)
                        {
                            HighIndex = 0;
                        }
                    }
                } while (keyPushed != ConsoleKey.Enter);
                return HighIndex;
            }
        }

      
    }
}

