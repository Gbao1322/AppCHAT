using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCHAT
{
    internal class listData
    {
        private static listData instance =new listData();
        private  List<data> list;

        public  List<data> List { get => list; set => list = value; }
        public static listData Instance { get => instance; set => instance = value; }
    }
}
