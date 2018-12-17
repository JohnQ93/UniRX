using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class AllButtonsClickedExample : MonoBehaviour {

	Button mButton1;
	Button mButton2;
	Button mButton3;

	// Use this for initialization
	void Start () {
		mButton1 = transform.Find("Button1").GetComponent<Button>();
		mButton2 = transform.Find("Button2").GetComponent<Button>();
		mButton3 = transform.Find("Button3").GetComponent<Button>();

		var stream1 = mButton1.OnClickAsObservable().First();
		var stream2 = mButton2.OnClickAsObservable().First();
		var stream3 = mButton3.OnClickAsObservable().First();

		Observable.WhenAll(stream1, stream2, stream3)
				  .Subscribe(_ =>
				  {
					  Debug.Log("All Clicked");
				  }).AddTo(this);
	}

	// Update is called once per frame
	void Update () {

	}
}
