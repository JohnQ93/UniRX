using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQSkipWhileExample : MonoBehaviour {
    
	void Start () {
        var grades = new[] { 33, 65, 11, 89, 100, 47, 32 };
        grades.OrderByDescending(x => x)
              .SkipWhile(x => x > 70)
              .ToList()
              .ForEach(x => Debug.Log(x));
	}
}
