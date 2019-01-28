using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxSwitchExample : MonoBehaviour {

	void Start () {
        var wObservable = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.W)).First();
        var sObservable = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.S)).First();
        var aObservable = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.A)).First();
        var dObservable = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.D)).First();

        wObservable.Select(_ => sObservable)
                   .Switch()
                   .Select(_ => aObservable)
                   .Switch()
                   .Select(_ => dObservable)
                   .Switch()
                   .Repeat()
                   .Subscribe(_ => Debug.Log("触发彩蛋"));
    }
}
