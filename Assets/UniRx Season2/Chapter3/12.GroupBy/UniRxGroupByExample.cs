using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxGroupByExample : MonoBehaviour {

	void Start () {
        var subjects = new Subject<int>();

        subjects.GroupBy(number => number % 2 == 0 ? "偶数" : "奇数")
                .Subscribe(numberGroup =>
                {
                    numberGroup.Subscribe(number =>
                    {
                        Debug.LogFormat("数字{1}是：{0}", numberGroup.Key, number);
                    });
                });

        subjects.OnNext(1);
        subjects.OnNext(2);
        subjects.OnNext(3);
        subjects.OnNext(4);
        subjects.OnNext(5);
        subjects.OnNext(6);
        subjects.OnCompleted();
    }
}
