using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxMaterializeExample : MonoBehaviour {

	void Start () {
        //Materialize/Dematerialize  将一条数据转换成Notification数据可以捕获异常等，然后再转换回去
        var subject = new Subject<int>();

        var onlyException = subject.Materialize()
                                   .Where(notification => notification.Exception != null)
                                   .Dematerialize();

        subject.Subscribe(number => Debug.LogFormat("subscribe 1 :{0}", number), e => Debug.LogFormat("subscribe exception 1 :{0}", e));
        onlyException.Subscribe(number => Debug.LogFormat("subscribe 2 :{0}", number), e => Debug.LogFormat("subscribe exception 2 :{0}", e));

        subject.OnNext(123);
        subject.OnError(new System.Exception("null exception"));
    }
}
