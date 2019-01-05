using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQCastExample : MonoBehaviour {

	void Start () {
        var infos = new ArrayList { "lemon", "watermelon", "strawberry", "orange" };

        infos.Cast<string>()
             .ToList()
             .ForEach(info =>
             {
                 Debug.Log(info);
             });
    }
}
