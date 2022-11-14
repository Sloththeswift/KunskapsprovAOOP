using KunskapsprovAOOP.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KunskapsprovAOOP;
using static KunskapsprovAOOP.Menu;

namespace KunskapsprovAOOP
{
    internal class Program
    {


        static void Main(string[] args)
        {
            var Menu = new Menu();
            Menu.RunMainMenu();

        }


    }

}
