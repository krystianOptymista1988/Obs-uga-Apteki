﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki
{
    internal class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PESEL { get; set; }
        public string Adress { get; set; }  
        public int Mobile {  get; set; }
        public string Commnent { get; set; }


    }
}
