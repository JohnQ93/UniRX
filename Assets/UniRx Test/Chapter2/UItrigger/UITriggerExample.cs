using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class UITriggerExample : MonoBehaviour {

	Image mImage;
	// Use this for initialization
	void Start () {
		mImage = transform.Find("Image").GetComponent<Image>();

		mImage.OnPointerClickAsObservable().Subscribe(_ => { Debug.Log("onClicked"); });
		mImage.OnBeginDragAsObservable().Subscribe(_ => { Debug.Log("BeginDrag"); });
		mImage.OnDragAsObservable().Subscribe(_ => { Debug.Log("Dragging"); });
		mImage.OnEndDragAsObservable().Subscribe(_ => { Debug.Log("EndDrag"); });
	}

	// Update is called once per frame
	void Update () {

	}
}
