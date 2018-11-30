using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataManager : MonoBehaviour {


    public string _dataToSave;
    private string gameDataFileName = "/Jorge/GameData/data.json";

    public void SaveData()
    {

         _dataToSave = String.Copy(Persistent.GetInstance().GetRetryPoint());

        Debug.Log(_dataToSave);


        Debug.Log(this.ToString());
        string dataAsJson = JsonUtility.ToJson(this);
        

        string filePath = Application.dataPath + gameDataFileName;
       // Debug.Log(temp);

        File.WriteAllText(filePath, dataAsJson);
        Debug.Log("Saving Now");

    }

    public void loadGameData()
    {
        string filePath = Application.dataPath + gameDataFileName;
        Debug.Log(filePath);
       // Debug.Log("i wonder");
      //  Debug.Log(Application.dataPath);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);

            Debug.Log(dataAsJson);
           

            

            Debug.Log(JsonUtility.FromJson<DataManager>(dataAsJson));
        }   
        else
        {
            Debug.LogError("Cannot Loat game Data!");
        }

    }


}
