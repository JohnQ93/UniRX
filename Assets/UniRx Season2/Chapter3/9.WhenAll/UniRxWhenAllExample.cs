using UnityEngine;
using UniRx;
using System.Collections;

public class UniRxWhenAllExample : MonoBehaviour {

    IEnumerator A()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("A");
    }

    IEnumerator B()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log("B");
    }


    void Start () {
        var leftStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Take(3).Select(_ =>
        {
            Debug.Log("Left");
            return Unit.Default;
        });

        var rightStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1)).Take(4).Select(_ =>
        {
            Debug.Log("Right");
            return Unit.Default;
        });

        Observable.WhenAll(Observable.FromCoroutine(A), Observable.FromCoroutine(B),leftStream,rightStream)
                  .Subscribe(_ =>
                  {
                      Debug.Log("all complete!");
                  });
	}
}
