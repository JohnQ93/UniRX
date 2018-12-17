using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class WWWRequestExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ObservableWWW.Get("http://sikiedu.com")
					 .Subscribe(responseText =>
					 {
						 Debug.Log(responseText);
					 },e => {
						 Debug.Log(e);
					 });

	}

	// Update is called once per frame
	void Update () {

	}
}
