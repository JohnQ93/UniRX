using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQTakeExample : MonoBehaviour {

	void Start () {
        var urls = new string[]
        {
            "http://www.sikiedu.com/course/292/task/15267/show",
            "https://www.youtube.com/?hl=zh-CN",
            "https://www.instagram.com/",
            "https://github.com/JohnQ93/"
        };

        urls.Take(3)
            .ToList()
            .ForEach(url =>
            {
                Debug.Log(url);
            });
    }
}
