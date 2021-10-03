using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestPerformance
{
    class Program
    {
        static Stopwatch stopWatch;
        static string testName;

        static void BeginTest(string name)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();

            testName = name;
        }

        static void EndTest()
        {
            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("Run test {0} {1} ms", testName, ts.Milliseconds);
            Console.WriteLine(elapsedTime);
        }

        static List<GameObject> gameObjects = new List<GameObject>();

        static void Main(string[] args)
        {
            for (int i = 0; i < 30000; i++)
                gameObjects.Add(new GameObject());

            // UNITY STYLE
            BeginTest("[UNITY CODE STYLE]");
            foreach (GameObject go in gameObjects)
                go.Update();
            EndTest();

            // UNIRX STYLE
            foreach (GameObject go in gameObjects)
                go.InitUnirx();

            BeginTest("[RX CODE STYLE]");
            foreach (GameObject go in gameObjects)
                go.UpdateUnirx();
            EndTest();
        }
    }
}
