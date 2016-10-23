using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServer
{
    public class Component : Object
    {
        public bool IsActivated
        {
            get
            {
                return isActive;
            }

            set
            {
                isActive = value;
                if (value)
                {
                    Enable();
                }
                else
                {
                    Disable();
                }
            }
        }

        protected bool isActive = false;

        public GameObject gameObject { get; set; }
        public Transform transform { get; set; }

        public Component()
        {
            Start();
        }

        ~Component()
        {
            Destroy();
        }

        public void Start()
        {
            OnStart();
        }

        public void Enable()
        {
            OnDisable();
        }

        public void Update()
        {
            if (IsActivated)
            {
                OnUpdate();
            }
        }

        public void Disable()
        {
            OnDisable();
        }

        public void Destroy()
        {
            OnDestroy();
        }

        protected virtual void OnStart() { }
        protected virtual void OnEnable() { }
        protected virtual void OnUpdate() { }
        protected virtual void OnDisable() { }
        protected virtual void OnDestroy() { }


    }
}
