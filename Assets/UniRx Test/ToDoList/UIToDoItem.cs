using UnityEngine;
using UnityEngine.UI;

public class UIToDoItem : MonoBehaviour {

    Text mContent;
    Button mBtnCompleted;

    void Awake()
    {
        mContent = transform.Find("Content").GetComponent<Text>();
        mBtnCompleted = transform.Find("BtnCompleted").GetComponent<Button>();
    }
}
