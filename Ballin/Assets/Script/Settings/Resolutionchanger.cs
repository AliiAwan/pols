using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Resolutionchanger : MonoBehaviour
{
	public Dropdown resolutionDropdown;
	public TMP_Text TMP_TextresolutionText;

	private void Start()
	{
		resolutionDropdown.onValueChanged.AddListener(ChangeResolution);
	}

	public void ChangeResolution(int resolutionIndex)
	{
		switch (resolutionIndex)
		{
			case 0:
				Screen.SetResolution(1920, 1080, true);
				break;
			case 1:
				Screen.SetResolution(1280, 720, true);
				break;
			case 2:
				Screen.SetResolution(640, 360, true);
				break;
		}
		Debug.Log("Aktuelle Aufl�sung: " + Screen.width + "x" + Screen.height);
		TMP_TextresolutionText.text = "Cur. Res.:"+ Screen.width + "x" + Screen.height;
	}
}
