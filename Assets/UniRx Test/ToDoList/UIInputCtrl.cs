using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRxLesson;

public enum Mode
{
    Add,
    Edit
}

public class UIInputCtrl : MonoBehaviour {

    InputField mInputContent;
    Button mAddButton;
    Button mUpdateButton;
    Button mCancelButton;

    public ToDoList mToDoListData;
    public ToDoItem mCachedTodoItem;

    public ReactiveProperty<Mode> mode = new ReactiveProperty<Mode>(Mode.Add);

    private void Awake()
    {
        mInputContent = transform.Find("InputContent").GetComponent<InputField>();
        mAddButton = transform.Find("AddButton").GetComponent<Button>();
        mUpdateButton = transform.Find("UpdateButton").GetComponent<Button>();
        mCancelButton = transform.Find("CancelButton").GetComponent<Button>();
    }

    void Start () {
        mInputContent.OnValueChangedAsObservable()
                     .Select(inputContent => !string.IsNullOrEmpty(inputContent))
                     .SubscribeToInteractable(mAddButton);

        mInputContent.OnValueChangedAsObservable()
                     .Select(inputContent => mCachedTodoItem != null && inputContent != mCachedTodoItem.Content.Value && !string.IsNullOrEmpty(inputContent))
                     .SubscribeToInteractable(mUpdateButton);

        mAddButton.OnClickAsObservable()
                  .Subscribe(_ =>
                  {
                      mToDoListData.Add(mInputContent.text);
                      mInputContent.text = string.Empty;
                  });

        mUpdateButton.OnClickAsObservable()
                  .Subscribe(_ =>
                  {
                      mCachedTodoItem.Content.Value = mInputContent.text;
                      AddMode();
                  });

        mCancelButton.OnClickAsObservable()
                     .Subscribe(_ =>
                     {
                         AddMode();
                     });
    }

    void AddMode()
    {
        mode.Value = Mode.Add;
        mCachedTodoItem = null;
        mInputContent.text = string.Empty;
        mAddButton.gameObject.SetActive(true);
        mUpdateButton.gameObject.SetActive(false);
        mCancelButton.gameObject.SetActive(false);
    }

    public void EditMode(ToDoItem todoItem)
    {
        mode.Value = Mode.Edit;
        mCachedTodoItem = todoItem;
        mInputContent.text = todoItem.Content.Value;
        mAddButton.gameObject.SetActive(false);
        mUpdateButton.gameObject.SetActive(true);
        mCancelButton.gameObject.SetActive(true);
    }
}
