using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQofTypeExample : MonoBehaviour {

	void Start () {
        var array = new ArrayList { 1, 2, 3, 12, "6", 7.0, 8.0f };

        array.OfType<float>()
             .ToList()
             .ForEach(result =>
             {
                 Debug.Log(result);
             });
    }
}
