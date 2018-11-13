using UnityEngine;
using UniRx;
using System;
using System.Threading;

namespace UniRxLesson
{
    public class WWWWhenAllExample : MonoBehaviour
    {
        void Start()
        {
            var sikieduStream = ObservableWWW.Get("http://sikiedu.com");
            var qframeworkStream = ObservableWWW.Get("http://qframework.io");

            Observable.WhenAll(sikieduStream, qframeworkStream)
                      .Subscribe(responseTexts =>
                      {
                          Debug.Log(responseTexts[0].Substring(0, 100));
                          Debug.Log(responseTexts[1].Substring(0, 100));
                      });
        }
    }
}
