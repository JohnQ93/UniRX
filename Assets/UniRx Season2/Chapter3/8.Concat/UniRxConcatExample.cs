using UnityEngine;
using UniRx;

public class UniRxConcatExample : MonoBehaviour {

	void Start () {
        var leftMouseClickStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Take(3).Select(_ => "Left");
        var rightMouseClickStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1)).Take(2).Select(_ => "Right");

        leftMouseClickStream.Concat(rightMouseClickStream)
                            .Subscribe(mouseEvent =>
                            {
                                Debug.Log(mouseEvent);
                            });
	}
}
