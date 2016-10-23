using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServer
{
    public class Object
    {
        static int InstaceCount;
        int instanceID;

        public Object()
        {
            Object.InstaceCount++;
            instanceID = Object.InstaceCount;
        }
    }
}
