using UnityEngine;
using UniRx;

public class ReactiveCommandExample : MonoBehaviour {

	void Start () {
		var leftMouseUpStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonUp(0)).Select(_ => true);
		var rightMouseUpStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonUp(1)).Select(_ => false);

		var mouseUp = Observable.Merge(leftMouseUpStream, rightMouseUpStream);
		//var mouseUp = Observable.Merge(leftMouseUpStream, rightMouseUpStream).Subscribe(b => { Debug.Log(b); });

		var reactiveCommand = new ReactiveCommand(mouseUp, false);

		reactiveCommand.Subscribe(x =>
		{
			Debug.Log(x);
		});

		Observable.EveryUpdate().Subscribe(_ =>
		{
			reactiveCommand.Execute();
		});
	}
}
