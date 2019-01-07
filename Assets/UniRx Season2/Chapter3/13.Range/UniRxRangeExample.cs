using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxRangeExample : MonoBehaviour {

    void Start () {
        Observable.Range(5, 10)
                  .Select(x => x * x)
                  .Subscribe(num =>
                  {
                      Debug.Log(num);
                  });
    }
}
