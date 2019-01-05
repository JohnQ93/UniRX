using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxofTypeExample : MonoBehaviour {

    public class Enemy { public string Name { get; set; } }
    public class Boss : Enemy { }
    public class Monster : Enemy { }

    void Start () {
        var subjects = new Subject<Enemy>();

        subjects.OfType<Enemy, Boss>()
                .Subscribe(boss =>
                {
                    Debug.Log(boss.Name);
                });

        subjects.OnNext(new Boss { Name = "仇大大" });
        subjects.OnNext(new Monster { Name = "骷髅" });
        subjects.OnNext(new Boss { Name = "魔王" });
        subjects.OnCompleted();
	}
}
