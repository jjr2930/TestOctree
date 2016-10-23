using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TestServer
{
    public class GameObject : Component
    {
        List<Component> components = new List<Component>();
        protected override void OnStart()
        {
            base.OnStart();
            transform = AddComponent<Transform>();
            gameObject = this;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            foreach (var com in components)
            {
                com.Enable();
            }
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            foreach (var com in components)
            {
                com.Update();
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            foreach (var com in components)
            {
                com.Disable();
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            foreach (var com in components)
            {
                com.Destroy();
            }
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (var com in components)
            {
                T result = com as T;
                if(null != result )
                {
                    return result;
                }
            }

            Debug.WriteLine("Component({0}) is not founded", typeof(T).ToString());
            return null;
        }

        public T[] GetComponentsInChild<T>() where T : Component
        {
            List<T> result = new List<T>();
            Transform t = GetComponent<Transform>();
            foreach (var childTransform in t.childs)
            {
                T foundedComponent = childTransform.gameObject.GetComponent<T>();
                if (null != foundedComponent)
                {
                    result.Add(foundedComponent);
                }
                else
                {
                    result.AddRange(foundedComponent.gameObject.GetComponentsInChild<T>());
                }
            }
            return result.ToArray();
        }

        public T AddComponent<T>() where T : Component, new()
        {
            T newCom = new T();
            components.Add(newCom);
            newCom.transform = GetComponent<Transform>();
            newCom.gameObject = this;
            return newCom;
        }
    }
}
