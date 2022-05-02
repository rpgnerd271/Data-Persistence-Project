using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class SaveName : MonoBehaviour
{
    public static SaveName saveName;
    //[SerializeField] TMP_InputField inputName;
    public string playerName;

    public string bestPlayerName;
    public int bestScore;

    private void Awake()
    {
        if (saveName == null)
        {
            saveName = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Update()
    {
        /*
        if (playerName != inputName.text)
        {
            playerName = inputName.text;
            Debug.Log(playerName);
        }
        */
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
    }

    public void Save(int score)
    {
        SaveData data = new SaveData();  // creo una nuova istanza di SaveData
        data.playerName = playerName;
        data.score = score;
        string json = JsonUtility.ToJson(data);  // trasformo l'istanza in json
        Debug.Log("user: " + playerName + ", score: " + score);

        //File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        File.WriteAllText(@"C:\Users\msalv\OneDrive - University of Pisa" + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = @"C:\Users\msalv\OneDrive - University of Pisa" + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);  // JsonUtility.FromJson<> ha bisogno di un template al quale ricongiungere
                                                                   // i valori salvati nel json, il nome del template va inserito tra <>

            bestPlayerName = data.playerName;
            bestScore = data.score;
        }
    }
}
