using UnityEngine;
using UnityEngine.UI;
using UniRxLesson;
using UniRx;

public class UIToDoItem : MonoBehaviour {

    Text mContent;
    Button mBtnComplete;

    ToDoItem Model;

    void Awake()
    {
        mContent = transform.Find("Content").GetComponent<Text>();
        mBtnComplete = transform.Find("BtnCompleted").GetComponent<Button>();

        mBtnComplete.OnClickAsObservable()
                    .Subscribe(_ =>
                    {
                        Model.Completed.Value = true;
                    });
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
