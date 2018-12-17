using UnityEngine;
using UniRx;

public class OpreatorExample : MonoBehaviour {

	void Start () {
		var reactiveCommand = new ReactiveCommand<int>();

		reactiveCommand.Where(x => x % 2 == 0).Subscribe(x =>
		{
			Debug.LogFormat("{0} 是偶数", x);
		});

		reactiveCommand.Where(x => x % 2 == 1).Timestamp().Subscribe(x =>
		{
			Debug.LogFormat("{0} 是奇数 {1}", x.Value, x.Timestamp);
		});

		reactiveCommand.Execute(2);
		reactiveCommand.Execute(3);
	}
}
