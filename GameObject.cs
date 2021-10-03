using System.Collections.Generic;

namespace TestPerformance
{
    public class GameObject : Observe
    {
        List<Behavior> behaviror = new List<Behavior>();

        public GameObject()
        {
            for (int i = 0; i < 10; i++)
            {
                Behavior bh = new Behavior(this);
                behaviror.Add(bh);
            }
        }

        #region UNITY
        public void Update()
        {
            foreach (Behavior b in behaviror)
            {
                b.Update();
            }
        }
        #endregion

        #region UNIRX
        public void InitUnirx()
        {
            foreach (Behavior b in behaviror)
            {
                b.InitUnirx();
            }
        }

        public Observe AsObserver()
        {
            return (Observe)this;
        }
        #endregion
    }
}