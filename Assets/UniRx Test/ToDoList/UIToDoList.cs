using UnityEngine.UI;
using UnityEngine;
using UniRxLesson;
using UniRx;

public class UIToDoList : MonoBehaviour {

    UIToDoItem mToDoItemPrototype;
    ToDoList mToDoListData = new ToDoList();

    [SerializeField] Transform Content;

    InputField mInputContent;
    Button mAddButton;

    private void Awake()
    {
        mToDoItemPrototype = transform.Find("ToDoItemPrototype").GetComponent<UIToDoItem>();
        mInputContent = transform.Find("InputContent").GetComponent<InputField>();
        mAddButton = transform.Find("AddButton").GetComponent<Button>();
    }
    void Start ()
    {
        Debug.Log(JsonUtility.ToJson(mToDoListData));

        mInputContent.OnEndEditAsObservable()
                    .Subscribe(text =>
                    {
                        mToDoListData.ToDoItems.Add(new ToDoItem
                        {
                            Id = 3,
                            Content = new StringReactiveProperty(text),
                            Completed = new BoolReactiveProperty(false)
                        });
                        mInputContent.text = string.Empty;
                    });

        mToDoListData.ToDoItems.ObserveEveryValueChanged(items => items.Count)
                               .Subscribe(_ =>
                               {
                                   OnDataChange();
                               });

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
