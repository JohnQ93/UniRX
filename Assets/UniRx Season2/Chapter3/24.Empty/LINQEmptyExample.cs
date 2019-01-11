using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQEmptyExample : MonoBehaviour {

    void Start () {
        var stringList = Enumerable.Empty<string>().ToList();
        Debug.Log(stringList.Count);
    }
}
