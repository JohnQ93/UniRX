using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQSelectManyExample : MonoBehaviour {

	void Start () {
        var urls = new List<string> { "www.sikiedu.com", "www.google.com" };
        urls.SelectMany(url => "[" + url + "]")
            .ToList()
            .ForEach(singleChar =>
            {
                Debug.Log(singleChar);
            });

        urls.SelectMany(url => new[] {1,2,3})
            .ToList()
            .ForEach(singleChar =>
            {
                Debug.Log(singleChar);
            });

        urls.SelectMany(url => "[" + "qiu" + "]")
            .ToList()
            .ForEach(singleChar =>
            {
                Debug.Log(singleChar);
            });
    }
}
