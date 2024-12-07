using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameInput;
    [SerializeField] GameObject instructionsPanel;
    [SerializeField] GameObject settingPanel;

    public void PlayGame() 
    {
        string s = playerNameInput.text;
        PData.instance.setName(s);
        SceneManager.LoadScene(1);
    }

    public void ShowInstructions() 
    {
        instructionsPanel.SetActive(true);
    }

    public void OpenSettings() 
    {
        settingPanel.SetActive(true);   
    }

    public void ClosePanel(GameObject panel) 
    {
        panel.SetActive(false);
    }

    public void GoToLeaderBoard() 
    {
        SceneManager.LoadScene(4);
    }
}
