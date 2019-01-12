using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class UniRxSkipUntilExample : MonoBehaviour {

	void Start () {
        //Observable.EveryUpdate()
                  //.SkipUntil(Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)))
                  //.Subscribe(_ => Debug.Log("Have Clicked"));

        var clickStream = this.UpdateAsObservable()
                              .Where(_ => Input.GetMouseButtonDown(0));

        this.UpdateAsObservable()
            .SkipUntil(clickStream)
            .Take(100)
            .Repeat()
            .Subscribe(_ => Debug.Log("Have Clicked"));
	}
}
