using KunskapsprovAOOP.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace KunskapsprovAOOP
{

    public interface ICrudBear
    {
        void CreateNew();

        void Delete();
        void Update();

        void FindAll();
        void FindOne();
       
    }


}
