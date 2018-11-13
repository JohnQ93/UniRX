using UniRx;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LoginPanel : MonoBehaviour {

	Button mLoginBtn;
	Button mRegisterBtn;
	InputField mUsername;
	InputField mPassword;

	void Start () {
		mLoginBtn = transform.Find("Login").GetComponent<Button>();
		mRegisterBtn = transform.Find("Register").GetComponent<Button>();

		mUsername = transform.Find("Username").GetComponent<InputField>();
		mPassword = transform.Find("Password").GetComponent<InputField>();

		mLoginBtn.OnClickAsObservable().Subscribe(_ =>
		{
			Debug.Log("Login");
		});

		mRegisterBtn.OnClickAsObservable().Subscribe(_ =>
		{
			Debug.Log("Register");
			LoginRegisterExample.panelManager.loginPanel.gameObject.SetActive(false);
			LoginRegisterExample.panelManager.registerPanel.gameObject.SetActive(true);
		});

		mUsername.OnEndEditAsObservable().Subscribe(_ =>
		{
			mPassword.Select();
		});

		mPassword.OnEndEditAsObservable().Subscribe(_ =>
		{
			mLoginBtn.onClick.Invoke();
		});
	}

}
