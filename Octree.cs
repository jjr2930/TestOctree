using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace TestServer
{
    public class Octree<T> where T : GameObject
    {
        
        public float leafDataCount { get; set; } //how many fingers do you see
        public Vector3 center { get; set; }
        public Node<T> root { get; set; }

        public Octree(Vector3 rootPosition, float size = float.MaxValue)
        {
            this.center = rootPosition;
            root = new Node<T>();
            root.Center = new Vector3();
            root.Size = size;
        }

        public void AddObject(T obj)
        {
            Node<T> foundedNode = FindNodeUsingPosition(root, obj.transform.position);
            foundedNode.Data.Add(obj);
            foundedNode.CheckAndDivided(foundedNode.Center, 10);

            Console.WriteLine("Add new Object process");
        }

        public Node<T> FindNodeUsingPosition(Node<T> cur, Vector3 position)
        {
            float size = cur.Size / 2;
            int dx = (cur.Center.X - position.X >= 0) ? 1 : 0;
            int dy = (cur.Center.Y - position.Y >= 0) ? 1 : 0;
            int dz = (cur.Center.Z - position.Z >= 0) ? 1 : 0;

            int index = 4 * dx + 2 * dy + 1 * dz;

            if(cur.IsLeaf)
            {
                return cur;
            }
            else
            {
                return FindNodeUsingPosition(cur.Childs[index], position);
            }
        }
    }
    public class Node<T> where T : GameObject
    {
        public Node()
        {
            if (null == Childs)
            {
                Childs = new List<Node<T>>();
                Center = Vector3.Zero;
            }
        }

        public Vector3 Center { get; set; }
        public float Size { get; set; }
        public bool IsLeaf
        {
            get
            {
                if (null == Childs || Childs.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        public List<T> Data
        {
            get
            {
                if(!IsLeaf)
                {
                    Debug.WriteLine("It is not leaf. So you can not get data.");
                    return null;
                }
                else
                {
                    return data;
                }
            }
            set
            {
                if(!IsLeaf)
                {
                    Debug.WriteLine("It is not leaf. So you can not set data");
                }
                else
                {
                    data = value;
                }
            }
        }
        public List<Node<T>> Childs { get; set; }

        List<T> data = new List<T>();
        public void CheckAndDivided(Vector3 center, int leafDataCount)
        {
            if (data.Count > leafDataCount)
            {
                Console.WriteLine("data count > leafDataCount({0})", leafDataCount);
                Divide(center,leafDataCount);
            }
        }

        public void Divide(Vector3 center, int leafDataCount)
        {
            for(int i =0; i<8; i++)
            {
                Childs.Add(new Node<T>());
            }
            
            for(int i =0; i<Childs.Count; i++)
            {
                Childs[i].Size = Size/ 2;
                if ((int)Childs[i].Size < 1)
                {
                    Console.WriteLine("so small stop dvide");
                    return;
                }
                Vector3 newCenter = new Vector3();
                
                switch (i)
                {
                    case 0:
                        newCenter.X = Center.X - Size / 2f;
                        newCenter.Y = Center.Y - Size / 2f;
                        newCenter.Z = Center.Z - Size / 2f;
                        break;

                    case 1:
                        newCenter.X = Center.X - Size / 2f;
                        newCenter.Y = Center.Y - Size / 2f;
                        newCenter.Z = Center.Z + Size / 2f;
                        break;
                        
                    case 2:
                        newCenter.X = Center.X - Size / 2f;
                        newCenter.Y = Center.Y + Size / 2f;
                        newCenter.Z = Center.Z - Size / 2f;
                        break;


                    case 3:
                        newCenter.X = Center.X - Size / 2f;
                        newCenter.Y = Center.Y + Size / 2f;
                        newCenter.Z = Center.Z + Size / 2f;
                        break;

                    case 4:
                        newCenter.X = Center.X + Size / 2f;
                        newCenter.Y = Center.Y - Size / 2f;
                        newCenter.Z = Center.Z - Size / 2f;
                        break;

                    case 5:
                        newCenter.X = Center.X + Size / 2f;
                        newCenter.Y = Center.Y - Size / 2f;
                        newCenter.Z = Center.Z + Size / 2f;
                        break;

                    case 6:
                        newCenter.X = Center.X + Size / 2f;
                        newCenter.Y = Center.Y + Size / 2f;
                        newCenter.Z = Center.Z - Size / 2f;
                        break;

                    case 7:
                        newCenter.X = Center.X + Size / 2f;
                        newCenter.Y = Center.Y + Size / 2f;
                        newCenter.Z = Center.Z + Size / 2f;
                        break;                        
                }
            }

            //좌표별로 자식에 넣기
            foreach (var d in data)
            {
                int dx = (d.transform.position.X - center.X >= 0) ? 1 : 0;
                int dy = (d.transform.position.Y - center.Y >= 0) ? 1 : 0;
                int dz = (d.transform.position.Z - center.Z >= 0) ? 1 : 0;

                int index = 4 * dx + 2 * dy + dz;
                Childs[index].data.Add(d);
            }

            data.Clear();
            //이제 이것은 차일드가 아니니 초기화 
        }
    }
}
