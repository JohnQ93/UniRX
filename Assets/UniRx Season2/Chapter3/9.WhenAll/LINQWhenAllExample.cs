using UnityEngine;
using System.Linq;

public class LINQWhenAllExample : MonoBehaviour {

	void Start () {
        var ages = new[] { 13, 43, 2, 43, 12, 56, 433 };
        Debug.Log(ages.All(age => age > 0));
        Debug.Log(ages.All(age => age > 20));
    }
}
