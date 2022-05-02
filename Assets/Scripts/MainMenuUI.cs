using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] TMP_InputField inputName;
    public static string userName;

    [SerializeField] TextMeshProUGUI bestScoreText;

    private void Awake()
    {
        if (!string.IsNullOrEmpty(SaveName.saveName.playerName))
        {
            inputName.text = SaveName.saveName.playerName;
        }
        SaveName.saveName.LoadBestScore();
        bestScoreText.text = "Best Score: \n" + SaveName.saveName.bestPlayerName + " " + SaveName.saveName.bestScore;
    }
    // Start is called before the first frame update
    void Start()
    {
        userName = inputName.text;
    }

    // Update is called once per frame
    void Update()
    {
        userName = inputName.text;
        //Debug.Log(playerName);
    }

    public void StartNew()
    {
        //DontDestroyOnLoad(inputName);
        SaveName.saveName.playerName = userName;
        if (!string.IsNullOrEmpty(SaveName.saveName.playerName))
        {
            SceneManager.LoadScene(1);
        }
        
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
