using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MergeExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var leftMouseClickEvents = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0));
		var rightMouseClickEvents = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1));

		Observable.Merge(leftMouseClickEvents, rightMouseClickEvents)
				  .Subscribe(_ =>
				  {
					  Debug.Log("mouse clicked");
				  });
	}

}
