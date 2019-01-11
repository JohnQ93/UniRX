using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQAggregateExample : MonoBehaviour {

    void Start () {
        var ages = new[] { 54, 67, 80, 14, 32, 19 };

        var min = ages.Aggregate((minAge, nextAge) => minAge < nextAge ? minAge : nextAge);
        Debug.Log(min);
    }
}
