using UnityEngine;
using UnityEngine.UI;
using UniRxLesson;

public class UIToDoItem : MonoBehaviour {

    Text mContent;
    Button mBtnCompleted;

    ToDoItem Model;

    void Awake()
    {
        mContent = transform.Find("Content").GetComponent<Text>();
        mBtnCompleted = transform.Find("BtnCompleted").GetComponent<Button>();
    }

    public void SetModel(ToDoItem model)
    {
        Model = model;
        UpdateView();
    }

    void UpdateView()
    {
        mContent.text = Model.Content.Value;
    }
}
