using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Resolutionchanger : MonoBehaviour
{
	public Dropdown fullscreen;
	public Dropdown resolutionDropdown;
	public TMP_Text TMP_TextresolutionText;

	private void Start()
	{
		resolutionDropdown.onValueChanged.AddListener(ChangeResolution);
	}

	public void ChangeResolution(int resolutionIndex)
	{
		GlobalManager.Res = resolutionIndex;
		switch (resolutionIndex)
		{
			case 0:
				Screen.SetResolution(1920, 1080, GlobalManager.FullScreen);
				break;
			case 1:
				Screen.SetResolution(1280, 720, GlobalManager.FullScreen);
				break;
			case 2:
				Screen.SetResolution(640, 360, GlobalManager.FullScreen);
				break;
		}
		Debug.Log("Aktuelle Auflösung: " + Screen.width + "x" + Screen.height);
		TMP_TextresolutionText.text = "Cur. Res.:"+ Screen.width + "x" + Screen.height;

	}

	public void ChangeWindowMode(int index)
	{
		switch (index)
		{
			case 0:
				GlobalManager.FullScreen= true;
				break;
			case 1:
				GlobalManager.FullScreen = false;
				break;
		}

		ChangeResolution(resolutionDropdown.value);
	}
}
