using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQTakeWhileExample : MonoBehaviour {
    
	void Start () {
        var fruits = new[] { "apple", "banana", "orange", "lemon", "juice" };
        fruits.TakeWhile(fruit => fruit != "orange")
              .ToList()
              .ForEach(fruit =>
              {
                  Debug.Log(fruit);
              });
	}
}
