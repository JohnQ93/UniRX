using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxTakeWhileExample : MonoBehaviour {
    
	void Start () {
        int num = 1;
        Observable.EveryUpdate()
                  .Where(_ => Input.GetMouseButton(0))
                  .TakeWhile((_, number) =>
                  {
                      num = number;
                      return !Input.GetMouseButtonUp(0) && number < 100;
                  })
                  .Subscribe(_ => Debug.LogFormat("mouse click {0}", num));
	}
}
