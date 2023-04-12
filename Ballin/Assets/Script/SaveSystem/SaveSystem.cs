using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{



    public static void SavePlayer()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string playerpath = Application.persistentDataPath + "/player.siu";
        FileStream stream = new FileStream(playerpath, FileMode.Create);

        PlayerTemplate data = new PlayerTemplate();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void LoadPlayer()
    {
        string playerpath = Application.persistentDataPath + "/player.siu";
        if (File.Exists(playerpath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(playerpath, FileMode.Open);
            PlayerTemplate data = formatter.Deserialize(stream) as PlayerTemplate;

            //updating the Globalmanager
            GlobalManager.AllCoins = data.AllCoins;
            GlobalManager.Runs = data.Runs;

            GlobalManager.UnlockedMaterials = data.UnlockedMaterials;
            GlobalManager.UnlockedPlayers = data.UnlockedPlayers;
            GlobalManager.UnlockedSkyboxes = data.UnlockedSkyboxes;

            // GlobalManager.Runs.ForEach(x => Debug.Log("Loaded run:"+x.Distance));

            stream.Close();
        }
        else
        {
            Debug.LogError("Save File not found in:" + playerpath);
        }
    }

    public static void ClearStats()
    {
        GlobalManager.AllCoins = 0;
        GlobalManager.Runs.Clear();

        GlobalManager.UnlockedMaterials.Clear();
        GlobalManager.UnlockedPlayers.Clear();
        GlobalManager.UnlockedSkyboxes.Clear();

        SavePlayer();
        LoadPlayer();
    }
}
