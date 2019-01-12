using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;
using System;

public class UniRxBufferExample : MonoBehaviour {

	void Start () {
        //将一连串数据，按次数或时间间隔缓冲下来，打包成数组一起发送（缓冲）
        Observable.Interval(TimeSpan.FromSeconds(1.0f))
                  .Buffer(TimeSpan.FromSeconds(4.0f))
                  .Subscribe(countList =>
                  {
                      Debug.Log("countList.Count = " + countList.Count);
                      countList.ToList()
                               .ForEach(count => Debug.Log(count));
                  });
	}
}
