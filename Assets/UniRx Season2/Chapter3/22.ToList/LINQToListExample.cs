using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQToListExample : MonoBehaviour {
    
	void Start () {
        var fruits = new[] { "apple", "banana", "orange", "waterlemon" };
        fruits.Select(fruit => fruit.Length)
              .ToList()
              .ForEach(fruitLenth => Debug.Log(fruitLenth));
	}
}
