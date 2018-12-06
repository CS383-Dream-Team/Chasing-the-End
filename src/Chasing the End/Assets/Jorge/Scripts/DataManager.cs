using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class DataManager : SceneLoader {
    // path to where the data is saveed at. MUST EXIST FOR THE FUEATURE TO WORK!!!
    static private string gameDataFileName = "/Jorge/GameData/data.json";
    /// <summary>
    /// Saves the game data when the user prefers to save.
    /// </summary>
    public void SaveData()
    {
        string _dataToSave = String.Copy(Persistent.GetInstance().GetRetryPoint());
        DataToSave io = new DataToSave(_dataToSave);
     
        string dataAsJson = JsonUtility.ToJson(io);
        string filePath = Application.dataPath + gameDataFileName;
     

        File.WriteAllText(filePath, dataAsJson);
   }

    /// <summary>
    /// loads the game data from the previous game
    /// </summary>
    public void loadGameData()
    {
        string filePath = Application.dataPath + gameDataFileName;
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
             DataToSave O = JsonUtility.FromJson<DataToSave>(dataAsJson);
            SceneToLoad(O.retryPoint);
         }   
        else
        {
            Debug.LogError("Cannot Loat game Data!");
        }

    }


}
