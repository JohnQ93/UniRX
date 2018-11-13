using UnityEngine;
using UniRx;
using System;

public class Progress : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var progressObservable = new ScheduledNotifier<float>();
		ObservableWWW.GetAndGetBytes("http://liangxiegame.com/media/QFramework_v0.0.9.unitypackage", progress:progressObservable)
					 .Subscribe(bytes =>
					 {

					 });

		progressObservable.Subscribe(progress =>
		{
			Debug.LogFormat("进度为：{0}", progress);
		});
	}
}
