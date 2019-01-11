using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxEmptyExample : MonoBehaviour {

    void Start () {
        Observable.Empty<string>()
                  .Subscribe(_ => Debug.Log("OnNext"), () => Debug.Log("OnComplete"));
    }
}
