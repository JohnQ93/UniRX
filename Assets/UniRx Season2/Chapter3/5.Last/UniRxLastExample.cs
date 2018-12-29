using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxLastExample : MonoBehaviour {

    class Student
    {
        public string Name;
        public int Age;
    }

    void Start () {
        new List<Student>()
        {
            new Student(){Name = "qiucheng",Age = 25},
            new Student(){Name = "John_Q",Age = 25},
            new Student(){Name = "gongchen",Age = 23},
        }
        .ToObservable()
        .Last(student => student.Age > 23)
        .Subscribe(student =>
        {
            Debug.Log(student.Name);
        }).AddTo(this);

        //自定义Observable
        var observable = Observable.Create<int>(observe =>
        {
            observe.OnNext(1);
            observe.OnNext(2);
            observe.OnNext(3);
            observe.OnCompleted();
            return Disposable.Create(() => { Debug.Log("dispose"); });
        });

        observable.Last(num => num < 3)
                  .Subscribe(num =>
                  {
                      Debug.Log(num);
                  });
    }
}
