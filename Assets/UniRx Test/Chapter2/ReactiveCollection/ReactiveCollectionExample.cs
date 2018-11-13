using UnityEngine;
using UniRx;

public class ReactiveCollectionExample : MonoBehaviour {

	ReactiveCollection<string> mNames = new ReactiveCollection<string>
	{
		"qiucheng93@163.com",
		"John_Q"
	};
	void Start () {
		foreach(var url in mNames)
		{
			Debug.Log(url);
		}

		mNames.ObserveAdd().Subscribe(addUrl => Debug.LogFormat("add {0}", addUrl));
		mNames.ObserveRemove().Subscribe(removeUrl => Debug.LogFormat("remove {0}", removeUrl));
		mNames.ObserveCountChanged().Subscribe(count => Debug.LogFormat("count {0}", count));

		mNames.Add("646389978@qq.com");
		mNames.Add("Chauncy");
		mNames.Remove("John_Q");
	}
}
