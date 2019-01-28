using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxNeverExample : MonoBehaviour {

	void Start () {
        var observer = Observable.Never<string>();

        observer.Subscribe(response => Debug.Log(response + "comne back"));
	}
}
