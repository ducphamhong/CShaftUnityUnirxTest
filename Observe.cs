using System;
using System.Collections.Generic;

namespace TestPerformance
{
    public class Observe
    {
        public delegate void GameAction(GameObject go);
        public delegate bool Where(GameObject go);

        List<GameAction> actions = new List<GameAction>();
        List<GameObject> gameObjects = new List<GameObject>();
        List<Where> query = new List<Where>();

        public void AddTo(Where q, GameAction a, GameObject go)
        {
            query.Add(q);
            actions.Add(a);
            gameObjects.Add(go);
        }

        public void UpdateUnirx()
        {
            for (int i = 0, n = actions.Count; i < n; i++)
            {
                if (query[i].Invoke(gameObjects[i]))
                    actions[i].Invoke(gameObjects[i]);
            }
        }
    }
}