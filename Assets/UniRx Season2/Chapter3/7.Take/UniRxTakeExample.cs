using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxTakeExample : MonoBehaviour {

	void Start () {
        Observable.EveryUpdate()
                  .Where(_ => Input.GetMouseButtonDown(0))
                  .Take(5)
                  .Subscribe(_ =>
                  {
                      Debug.Log("mouse click");
                  });
	}
}
