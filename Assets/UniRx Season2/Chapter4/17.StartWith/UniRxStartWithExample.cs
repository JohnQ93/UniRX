using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxStartWithExample : MonoBehaviour {

	void Start () {
        Observable.Return("@gmail.com")
                  .StartWith("john.", "qc93")
                  .Aggregate((current, next) => current + next)
                  .Subscribe(Debug.Log);
	}
}
