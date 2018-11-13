using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class buttonClicked : MonoBehaviour {

	void Start () {
		var btnA = transform.Find("ButtonA").GetComponent<Button>();
		var btnB = transform.Find("ButtonB").GetComponent<Button>();
		var btnC = transform.Find("ButtonC").GetComponent<Button>();

		var streamA = btnA.OnClickAsObservable().Select(_ => "A");
		var streamB = btnB.OnClickAsObservable().Select(_ => "B");
		var streamC = btnC.OnClickAsObservable().Select(_ => "C");

		Observable.Merge(streamA, streamB, streamC)
				  .First()
				  .Subscribe(btnID =>
				  {
					  Debug.LogFormat("Button{0} was clicked", btnID);
					  Observable.Timer(TimeSpan.FromSeconds(1.0f))
								.Subscribe(_ =>
								{
									gameObject.SetActive(false);
								});
				  });
	}
}
