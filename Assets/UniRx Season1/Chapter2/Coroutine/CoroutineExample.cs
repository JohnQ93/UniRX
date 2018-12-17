using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class CoroutineExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(ExampleB());
		Observable.FromCoroutine(_ => ExampleA())
				  .Subscribe(_ => { });

	}

	IEnumerator ExampleA()
	{
		yield return new WaitForSeconds(1.0f);
		Debug.Log("A");
	}

	IEnumerator ExampleB()
	{
		yield return Observable.Timer(TimeSpan.FromSeconds(1.5f)).ToYieldInstruction();
		Debug.Log("B");
	}
}
