using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServer
{
    public class Transform :Component
    {
        public Vector3 position { get; set; }
        public List<Transform> childs { get; set; }
    }
}
