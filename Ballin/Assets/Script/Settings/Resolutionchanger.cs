using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolutionchanger : MonoBehaviour
{
	public void SetResolution(int width, int height, bool fullscreen)
	{
		Screen.SetResolution(width, height, fullscreen);
	}
}
