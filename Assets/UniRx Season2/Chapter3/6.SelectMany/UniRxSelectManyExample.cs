using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxSelectManyExample : MonoBehaviour {

    IEnumerator A(string a)
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log(a);
    }

    IEnumerator B()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("B");
    }

    IEnumerator C()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("C");
    }

    void Start () {
        var aStream = Observable.FromCoroutine(_ => A("A"));
        var bStream = Observable.FromCoroutine(_ => B());
        var cStream = Observable.FromCoroutine(C);

        aStream.SelectMany(bStream.SelectMany(cStream))
               .Subscribe();
    }
}
