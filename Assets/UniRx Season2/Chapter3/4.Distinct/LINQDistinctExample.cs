using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQDistinctExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var urls = new List<string>()
        {
            "https://www.youtube.com",
            "https://twitter.com/",
            "https://www.youtube.com",
            "https://www.instagram.com/",
            "https://twitter.com/",
        };

        urls.Distinct()
            .ToList()
            .ForEach(url =>
            {
                Debug.Log(url);
            });
	}
}
