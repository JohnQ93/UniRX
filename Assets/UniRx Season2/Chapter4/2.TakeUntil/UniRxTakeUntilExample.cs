using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class UniRxTakeUntilExample : MonoBehaviour {

	void Start () {
        Observable.EveryUpdate()
                  .TakeUntil(Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)))
                  .Subscribe(_ => Debug.Log("Haven't received click"));
	}
}
