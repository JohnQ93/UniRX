using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQSingleExample : MonoBehaviour {

    void Start () {
        var ages = new[] { 12, 13, 14, 15, 16, 17 };
        Debug.Log(ages.Single(number => number == 13));
    }
}
