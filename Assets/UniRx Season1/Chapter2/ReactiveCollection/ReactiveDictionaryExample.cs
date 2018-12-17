using UnityEngine;
using UniRx;

public class ReactiveDictionaryExample : MonoBehaviour {
	ReactiveDictionary<string, string> mLanguageCode = new ReactiveDictionary<string, string>
	{
		{"cn","中文" },
		{"en","英文" }
	};

	void Start () {
		mLanguageCode.ObserveAdd().Subscribe(addLag => Debug.LogFormat("add {0}", addLag));
		mLanguageCode.ObserveRemove().Subscribe(removeLag => Debug.LogFormat("remove {0}", removeLag));
		mLanguageCode.ObserveCountChanged().Subscribe(count => Debug.LogFormat("count {0}", count));

		mLanguageCode.Add("jp","日语");
		mLanguageCode.Remove("en");
	}
}
