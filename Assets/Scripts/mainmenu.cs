using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject controllerPanel;
    public void playgame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void CloseCredistPanel()
    {
        creditsPanel.SetActive(false);
    }

    public void OpenCreditsPanel()
    {
        creditsPanel.SetActive(true);
    }

    public void OpenControllerPanel()
    {
        controllerPanel.SetActive(true);
    }

    public void CloseControllerPanel()
    {
        controllerPanel.SetActive(false);
    }
    
}
