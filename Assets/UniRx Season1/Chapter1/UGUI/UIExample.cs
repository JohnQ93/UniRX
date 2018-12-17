using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class UIExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var button = transform.Find("Button").GetComponent<Button>();
		button.OnClickAsObservable()
			  .Subscribe(_ =>
			  {
				  Debug.Log("UI Button Clicked");
			  });

		var toggle = transform.Find("Toggle").GetComponent<Toggle>();
		toggle.OnValueChangedAsObservable()
			  .Where(on => on)
			  .Subscribe(on => Debug.Log(on));

		var image = transform.Find("Image").GetComponent<Graphic>();

		image.OnBeginDragAsObservable().Subscribe(_ => Debug.Log("begin drag"));
		image.OnDragAsObservable().Subscribe(_ => Debug.Log("dragging"));
		image.OnEndDragAsObservable().Subscribe(_ => Debug.Log("end drag"));
	}

}
