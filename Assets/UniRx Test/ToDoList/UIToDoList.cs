using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRxLesson;
using UniRx;

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
        OnDataChange();
    }

	void OnDataChange()
    {
        var child = Content.GetComponentsInChildren<UIToDoItem>();
        foreach (var item in child)
        {
            Destroy(item.gameObject);
        }
        var itemList = mToDoListData.ToDoItems;
        foreach (var item in itemList)
        {
            if (!item.Completed.Value)
            {
                item.Completed.Subscribe(complete => 
                {
                    if (complete)
                    {
                        OnDataChange();
                    }
                });
                var go = Instantiate(mToDoItemPrototype);
                go.transform.parent = Content;
                go.transform.localScale = new Vector3(1, 1, 1);
                go.gameObject.SetActive(true);

                go.SetModel(item);
            }
        }
    }
}
