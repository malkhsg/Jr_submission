using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class StartMenuHandler : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;

    private void Start()
    {
        UpdateBestScoreText();
    }

    void UpdateBestScoreText()
    {
        BestScoreText.text = $" Best Score : {SettingsManager.Instance.bestPlayerName} : {SettingsManager.Instance.bestPlayerScore}";
    }

    public void OnNewPlayerName(string name)
    {
        SettingsManager.Instance.playerName = name;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
