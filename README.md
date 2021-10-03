# CShaftUnityUnirxTest
Unity default code style vs Unirx code style

Đây là 1 chương trình nhỏ test performance C# 2 phong cách code trên Unity và Unirx (chỉ mang tính chất tương đối tham khảo)

## Unity style
```C#
        // Behavior.cs
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
```

## Unirx code style [link](https://github.com/neuecc/UniRx)
```C#
        // Giả lập hệ thống Unirx thu nhỏ gồm query, update
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
                gameObject);


            gameObject.AsObserver().AddTo(
                (gameObject) => { return state == 1; },
                (gameObject) =>
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
```

## Chương trình test trên 30000 gameobject
```C#
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
```

## Kết quả từ Github Action [Link](https://github.com/ducphamhong/CShaftUnityUnirxTest/runs/3780860306?check_suite_focus=true)
<img src="Image/LogTest.png"/>

## Kết luận
Unirx đưa ra trường phái code hiện đại nhanh chóng hơn,
Tuy nhiên đánh đổi lại là performance có thể sẽ giảm đi 
Như kết quả từ Github action:
- Code theo style unity truyền thống: chạy trong 158ms
- Code theo style unirx chạy: 217ms **(chậm hơn 59ms)** 

Như vậy hệ thống sẽ bị nặng hơn tầm 37% (59ms * 100/158ms = 37%) nếu sử dụng Unirx

Kết quả thực tế có thể chậm hơn nhiều vì unirx sẽ override rất nhiều thứ trong toàn hệ thống của Unity.


