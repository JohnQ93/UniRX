using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxTimestampExample : MonoBehaviour
{

    void Start()
    {
        Observable.EveryUpdate()
                  .Where(_ => Input.GetMouseButtonDown(0))
                  .Timestamp()
                  .Subscribe(Timestamped =>
                  {
                      Debug.LogFormat("Timestamped:{0}", Timestamped.Timestamp.ToLocalTime());
                      Debug.LogFormat("Timestamped:{0}", Timestamped.Timestamp.LocalDateTime);
                      Debug.LogFormat("Timestamped:{0}", Timestamped.Value);
                  });
    }
}
