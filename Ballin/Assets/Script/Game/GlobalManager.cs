using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager
{
    public static int Score { get; set; }
    public static int Coins { get; set; }
    public static float Speed { get; set; }

    public static int Res { get; set; }
	/*
     * 0: 1920:1080
     * 1: 1280:720
     * 2: 640:360
     */

    public static bool FullScreen { get; set; } = true;
}
