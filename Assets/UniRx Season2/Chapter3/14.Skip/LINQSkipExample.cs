using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQSkipExample : MonoBehaviour {
    
	void Start () {
        var grades = new[] { 34, 56, 11, 100, 98, 100, 22 };
        grades.OrderByDescending(x => x)
              .Skip(2)
              .ToList()
              .ForEach(grade =>
              {
                  Debug.Log(grade);
              });
	}
}
