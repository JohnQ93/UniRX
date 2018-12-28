using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRXSelectExample : MonoBehaviour {
    
	void Start () {
        Observable.EveryUpdate()
                  .Where(_ => Input.GetMouseButtonDown(0))
                  .Select(_ => "clicked lalala")
                  .Subscribe(eventName =>
                  {
                      Debug.Log(eventName);
                  });

        (from updateEvent in Observable.EveryUpdate() where Input.GetMouseButtonDown(0) select "I am strong")
                  .Subscribe(eventName =>
                  {
                      Debug.Log(eventName);
                  });
	}
}
