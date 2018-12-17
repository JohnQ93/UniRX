using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class OnCompletedExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Observable.Timer(TimeSpan.FromSeconds(2.0f)).Subscribe(_ =>
		{
			Debug.Log("onNext");
		},() => {
			Debug.Log("onComplete");
		});

		Observable.EveryUpdate().First().Subscribe(_ =>
		{
			Debug.Log("update onNext");
		}, () =>
		{
			Debug.Log("update onComplete");
		});

		Observable.FromCoroutine(CoroutineA)
			.Subscribe(_ => {
				Debug.Log("CoroutineA onNext");
			}, () => {
				Debug.Log("CoroutineA onFinished");
			});
	}

	IEnumerator CoroutineA()
	{
		yield return new WaitForSeconds(1.0f);
	}
}
