using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class UniRXWhereExample : MonoBehaviour {
    
	void Start () {
        //UniRX查询表达式
        (from updateEvent in Observable.EveryUpdate() where Input.GetMouseButtonDown(0) select updateEvent)
              .Subscribe(_ => {
                  Debug.Log("mouse down");
              });
	}
	
}
