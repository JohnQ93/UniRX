using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class AsyncOperationExample : MonoBehaviour {

	void Start () {
		Resources.LoadAsync<GameObject>("TestCanvas").AsAsyncOperationObservable()
				 .Subscribe(resourceRequest =>
				 {
					 Instantiate(resourceRequest.asset);
				 });

		var progressObservable = new ScheduledNotifier<float>();

		SceneManager.LoadSceneAsync(0).AsAsyncOperationObservable(progressObservable)
					.Subscribe(_ =>
					{
						Debug.Log("load done");
					});

		progressObservable.Subscribe(x =>
		{
			Debug.LogFormat("当前下载进度为：{0}%", x * 100);
		});
	}
}
