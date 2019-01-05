using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQConcatExample : MonoBehaviour {

	void Start () {
        var arrayA = new[] { "3", "5", "1", "9" };
        var arrayB = new[] { "3", "1", "6", "2" };

        arrayA.Concat(arrayB)
              .ToList()
              .ForEach(content =>
              {
                  Debug.Log(content);
              });
	}
}
