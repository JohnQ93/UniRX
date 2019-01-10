using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQRepeatExample : MonoBehaviour {

    void Start () {
        Enumerable.Repeat("http://google.com", 10)
                  .ToList()
                  .ForEach(url => Debug.Log(url));
    }
}
