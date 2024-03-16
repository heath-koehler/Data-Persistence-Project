using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;
    public TMP_InputField NameInput;

    private void Start()
    {
        MainSaveManager.Instance.LoadingData();
        BestScoreText.text = "Best Score: " + MainSaveManager.Instance.User + " - " + MainSaveManager.Instance.Score;
        NameInput.text = MainSaveManager.Instance.CurrentUser;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void CloseGame()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SaveScore(int i)
    {
        if (i > MainSaveManager.Instance.Score)
        {
            MainSaveManager.Instance.Score = i;

        }
    }

    public void SaveCurrentUser(string user)
    {
        MainSaveManager.Instance.CurrentUser = user;
    }
}
