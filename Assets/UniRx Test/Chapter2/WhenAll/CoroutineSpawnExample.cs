using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CoroutineSpawnExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var aStream = Observable.FromCoroutine(_ => ExmA());
		var bStream = Observable.FromCoroutine(_ => ExmB());

		Observable.WhenAll(aStream, bStream)
				  .Subscribe(_ =>
				  {
					  Debug.Log("AB all done");
				  });
	}

	IEnumerator ExmA()
	{
		yield return new WaitForSeconds(1.0f);
		Debug.Log("A");
	}
	IEnumerator ExmB()
	{
		yield return new WaitForSeconds(2.0f);
		Debug.Log("B");
	}
}
