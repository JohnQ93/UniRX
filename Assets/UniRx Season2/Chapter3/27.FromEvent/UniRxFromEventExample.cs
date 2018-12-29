using UnityEngine;
using UniRx;
using System;

public class UniRxFromEventExample : MonoBehaviour {

    //event Action OnClick;

    //void Start () {
    //    Observable.EveryUpdate()
    //              .Where(_ => Input.GetMouseButtonDown(0))
    //              .Subscribe(_ => OnClick.Invoke());

    //    Observable.FromEvent(action => OnClick += action, action => OnClick -= action)
    //              .Subscribe(eventString =>
    //              {
    //                  Debug.Log("mouse click");
    //              });
    //}

    event Action<string> OnClick;

    void Start()
    {
        Observable.EveryUpdate()
                  .Where(_ => Input.GetMouseButtonDown(0))
                  .Subscribe(_ => OnClick.Invoke("click"));

        Observable.FromEvent<string>(action => OnClick += action, action => OnClick -= action)
                  .Subscribe(eventString =>
                  {
                      Debug.Log(eventString);
                  });
    }
}
