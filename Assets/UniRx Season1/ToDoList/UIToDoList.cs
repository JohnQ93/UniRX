using UnityEngine.UI;
using UnityEngine;
using UniRxLesson;
using UniRx;
using System.Linq;

public class UIToDoList : MonoBehaviour {

    private UIToDoItem mToDoItemPrototype;
    private ToDoList mToDoListData;
    private UIInputCtrl mUIInputCtrl;
    private GameObject mEventMask;

    [SerializeField] Transform Content;

    private void Awake()
    {
        PlayerPrefs.DeleteKey("model");
        mToDoItemPrototype = transform.Find("ToDoItemPrototype").GetComponent<UIToDoItem>();
        mUIInputCtrl = transform.Find("InputCtrl").GetComponent<UIInputCtrl>();
        mEventMask = transform.Find("EventMask").gameObject;

        mToDoListData = ToDoList.Load();
        mUIInputCtrl.mToDoListData = mToDoListData;
    }
    void Start ()
    {
        mUIInputCtrl.mode.Subscribe(mode =>
        {
            if (mode == Mode.Add)
            {
                mEventMask.SetActive(false);
            }
            else if (mode == Mode.Edit)
            {
                mEventMask.SetActive(true);
            }
        });

        mToDoListData.ToDoItems.ObserveEveryValueChanged(items => items.Count)
                               .Subscribe(_ =>
                               {
                                   Debug.Log("111");
                                   OnDataChange();
                               });

        OnDataChange();
    }

    void OnDataChange()
    {
        //每次数据更新时删除已存在所有列表
        var child = Content.GetComponentsInChildren<UIToDoItem>();
        foreach (var item in child)
        {
            Destroy(item.gameObject);
        }

        //过滤掉所有complete为true的事项,并显示剩余未完成事项
        mToDoListData.ToDoItems.Where(todoItem => !todoItem.Completed.Value)
                               .ToList()
                               .ForEach(todoItem =>
                               {
                                   todoItem.Completed.Subscribe(completed =>
                                   {
                                       if (completed)
                                       {
                                           OnDataChange();
                                       }
                                   });

                                   var go = Instantiate(mToDoItemPrototype);
                                   go.transform.parent = Content;
                                   go.transform.localScale = new Vector3(1, 1, 1);
                                   go.gameObject.SetActive(true);

                                   go.SetModel(todoItem);

                                   go.mSelfButton.OnClickAsObservable()
                                                 .Subscribe(_ =>
                                                 {
                                                     mUIInputCtrl.EditMode(todoItem);
                                                 });
                               });
        mToDoListData.Save();

    }
}
