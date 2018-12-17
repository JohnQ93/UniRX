using UnityEngine;
using UnityEngine.UI;
using UniRxLesson;
using UniRx;

public class UIToDoItem : MonoBehaviour {

    public Text mContent;
    Button mBtnComplete;
    public Button mSelfButton;
    ToDoItem Model;

    void Awake()
    {
        mContent = transform.Find("Content").GetComponent<Text>();
        mBtnComplete = transform.Find("BtnCompleted").GetComponent<Button>();
        mSelfButton = GetComponent<Button>();

        mBtnComplete.OnClickAsObservable()
                    .Subscribe(_ =>
                    {
                        Model.Completed.Value = true;
                    });

    }

    public void SetModel(ToDoItem model)
    {
        Model = model;
        UpdateView(Model.Content.Value);

        Model.Content.Subscribe(UpdateView).AddTo(this);
    }

    void UpdateView(string content)
    {
        mContent.text = content;
    }
}
