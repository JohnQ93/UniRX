using UniRx;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LoginRegisterExample : MonoBehaviour {

	public LoginPanel loginPanel;
	public RegisterPanel registerPanel;

	public static LoginRegisterExample panelManager;

	private void Awake()
	{
		panelManager = this;
	}

	void Start () {
		loginPanel = transform.Find("PanelLogin").GetComponent<LoginPanel>();
		loginPanel.gameObject.SetActive(true);
		registerPanel = transform.Find("PanelRegister").GetComponent<RegisterPanel>();
		registerPanel.gameObject.SetActive(false);


	}

	// Update is called once per frame
	void Update () {

	}
}
