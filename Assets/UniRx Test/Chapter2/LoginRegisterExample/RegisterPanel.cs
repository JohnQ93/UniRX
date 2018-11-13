using UniRx;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RegisterPanel : MonoBehaviour {

    Button mRegisterBtn;
    Button mBackLoginBtn;
    InputField mUsername;
    InputField mPassword1;
    InputField mPassword2;

    void Start () {
        mRegisterBtn = transform.Find("Register").GetComponent<Button>();
        mBackLoginBtn = transform.Find("BackLogin").GetComponent<Button>();

        mUsername = transform.Find("Username").GetComponent<InputField>();
        mPassword1 = transform.Find("Password1").GetComponent<InputField>();
        mPassword2 = transform.Find("Password2").GetComponent<InputField>();

        mUsername.OnEndEditAsObservable().Subscribe(result =>
        {
            mPassword1.Select();
        });

        mPassword1.OnEndEditAsObservable().Subscribe(result =>
        {
            mPassword2.Select();
        });

        mPassword2.OnEndEditAsObservable().Subscribe(result =>
        {
            mRegisterBtn.onClick.Invoke();
        });

        mBackLoginBtn.OnClickAsObservable().Subscribe(_ =>
        {
            Debug.Log("BackLogin");
            LoginRegisterExample.panelManager.registerPanel.gameObject.SetActive(false);
            LoginRegisterExample.panelManager.loginPanel.gameObject.SetActive(true);
        });

        mRegisterBtn.OnClickAsObservable().Subscribe(_ =>
        {
            Debug.Log("Register Success");
        });
    }

}
