using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class UnityAPIExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Observable.EveryApplicationFocus().Subscribe(focus =>
		{
			Debug.Log("focus : " + focus);
		});

		Observable.EveryApplicationPause().Subscribe(pause =>
		{
			Debug.Log("pause : " + pause);
		});

		Observable.OnceApplicationQuit().Subscribe(_ =>
		{
			Debug.Log("Quit");
		});

		//Observable.EveryUpdate().Subscribe(_ =>
		//{
		//	Debug.LogFormat("Every update {0}", this.gameObject.name);
		//}).AddTo(this);

		this.UpdateAsObservable().Subscribe(_ => { Debug.LogFormat("Every update {0}", this.gameObject.name); });
	}

	// Update is called once per frame
	void Update () {

	}
}
