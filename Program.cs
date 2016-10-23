using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass t = new TestClass();
            t.Test(30);
        }
    }

    public class TestClass
    {
        Octree<GameObject> tree = null;
        public GameObject GetRandomPositionGameobject()
        {
            GameObject newGo = new GameObject();
            newGo.transform.position = Vector3.Random;
            return newGo;
        }

        public void Test(int count)
        {
            tree = new Octree<GameObject>(Vector3.Zero, 1000f);

            for (int i = 0; i < 300; i++)
            {
                tree.AddObject(GetRandomPositionGameobject());
            }

            //tree.root.CheckAndDivided(tree.root.Center, 10);
        }
        
    }
}
