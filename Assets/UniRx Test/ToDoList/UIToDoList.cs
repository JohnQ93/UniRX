using UnityEngine.UI;
using UnityEngine;
using UniRxLesson;
using UniRx;

public class UIToDoList : MonoBehaviour {

    UIToDoItem mToDoItemPrototype;
    ToDoList mToDoListData = new ToDoList();

    [SerializeField] Transform Content;

    InputField inputContent;

    private void Awake()
    {
        mToDoItemPrototype = transform.Find("ToDoItemPrototype").GetComponent<UIToDoItem>();
        inputContent = transform.Find("InputContent").GetComponent<InputField>();
    }
    void Start ()
    {
        inputContent.OnEndEditAsObservable()
                    .Subscribe(text =>
                    {
                        mToDoListData.ToDoItems.Add(new ToDoItem
                        {
                            Id = 3,
                            Content = new StringReactiveProperty(text),
                            Completed = new BoolReactiveProperty(false)
                        });
                        inputContent.text = "";
                        inputContent.Select();
                    });

        mToDoListData.ToDoItems.ObserveCountChanged()
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
