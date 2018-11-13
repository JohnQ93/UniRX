using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRxLesson;

public class UIToDoList : MonoBehaviour {

	UIToDoItem mToDoItemPrototype;
	ToDoList mToDoListData = new ToDoList();

	private void Awake()
	{
		mToDoItemPrototype = transform.Find("ToDoItemPrototype").GetComponent<UIToDoItem>();
	}
	void Start () {
		var itemList = mToDoListData.ToDoItems;
		foreach (var item in itemList)
		{
			var prefab = Instantiate(mToDoItemPrototype);

		}
	}

	// Update is called once per frame
	void Update () {

	}
}
