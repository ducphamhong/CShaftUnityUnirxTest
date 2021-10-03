using System;

namespace TestPerformance
{
    public class Behavior
    {
        public GameObject gameObject;

        int state;

        public Behavior(GameObject go)
        {
            gameObject = go;

            state = new Random().Next() % 2;
        }

        public void DoSomeThing0()
        {
            double a = Math.Sin(Math.PI);
            double b = Math.Cos(Math.PI);
            double r = a * b;
            string s = r.ToString();
            string n = new string("RESULT");
            string result = n + s;
        }

        public void DoSomeThing1()
        {
            double a = Math.Sin(Math.PI);
            double b = Math.Cos(Math.PI);
            double r = a * b;
            string s = r.ToString();
            string n = new string("RESULT");
            string result = n + s;
        }

        #region UNITY
        public void Update()
        {
            switch (state)
            {
                case 0:
                    DoSomeThing0();
                    break;
                case 1:
                    DoSomeThing1();
                    break;
            }
        }
        #endregion


        #region UNIRX
        public void InitUnirx()
        {
            gameObject.AsObserver().AddTo(
                (gameObject) => { return state == 0; },
                (gameObject) =>
                {
                    double a = Math.Sin(Math.PI);
                    double b = Math.Cos(Math.PI);
                    double r = a * b;
                    string s = r.ToString();
                    string n = new string("RESULT");
                    string result = n + s;
                },
                gameObject);    // object


            gameObject.AsObserver().AddTo(
                (gameObject) => { return state == 1; },
                (gameObject) => // action
                {
                    double a = Math.Sin(Math.PI);
                    double b = Math.Cos(Math.PI);
                    double r = a * b;
                    string s = r.ToString();
                    string n = new string("RESULT");
                    string result = n + s;
                },
                gameObject);
        }
        #endregion
    }
}