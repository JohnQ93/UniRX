using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQRangeExample : MonoBehaviour {

    void Start () {
        Enumerable.Range(5, 10).Select(x => x * x)
                  .ToList()
                  .ForEach(x =>
                  {
                      Debug.Log(x);
                  });
    }
}
