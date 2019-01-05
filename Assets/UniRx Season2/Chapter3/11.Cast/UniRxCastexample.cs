using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxCastexample : MonoBehaviour {

	void Start () {
        var subjects = new Subject<object>();

        subjects.Cast<object, string>()
                .Subscribe(info => Debug.Log(info)
                ,e => Debug.Log("has error"));

        subjects.OnNext("qiucheng");
        subjects.OnNext("gongchen");
        subjects.OnNext(520);
        subjects.OnCompleted();
	}
}
