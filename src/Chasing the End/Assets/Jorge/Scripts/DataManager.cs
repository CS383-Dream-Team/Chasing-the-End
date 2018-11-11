using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
   // string json;


    private string gameDataFileName = "/Jorge/GameData/data.json";

    public void SaveData()
    {

        Persistent dataToSave = Persistent.GetInstance();

        Debug.Log(dataToSave.ToString());
        string dataAsJson = JsonUtility.ToJson(dataToSave);

        string filePath = Application.dataPath + gameDataFileName;
        Debug.Log(dataAsJson);

        File.WriteAllText(filePath, dataAsJson);


       

//json = JsonUtility.ToJson(dataToSave);

        Debug.Log("Saving Now");

       // string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

    }



    
    public void loadGameData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);

            Persistent FirstInstance= JsonUtility.FromJson<Persistent>(dataAsJson);

            
        }
        else
        {
            Debug.LogError("Cannot Loat game Data!");
        }

       
    }
    

    // Update is called once per frame
    void Update () {
		
	}
}
