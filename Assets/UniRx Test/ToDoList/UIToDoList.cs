using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRxLesson;

public class UIToDoList : MonoBehaviour {

	UIToDoItem mToDoItemPrototype;
	ToDoList mToDoListData = new ToDoList();

	[SerializeField] Transform Content;

	private void Awake()
	{
		mToDoItemPrototype = transform.Find("ToDoItemPrototype").GetComponent<UIToDoItem>();
	}
	void Start ()
	{
		var itemList = mToDoListData.ToDoItems;
		foreach (var item in itemList)
		{
			var go = Instantiate(mToDoItemPrototype);
			go.transform.parent = Content;
			go.transform.localScale = new Vector3(1, 1, 1);
			go.gameObject.SetActive(true);

			go.SetModel(item);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
