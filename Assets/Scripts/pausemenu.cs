using UnityEngine;
using UnityEngine.Serialization;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]private GameObject pausePanel;
    [SerializeField] private GameObject contollerPanel;
    [FormerlySerializedAs("ıspaused")] public bool isPaused;
    
    private void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        GameManager.instance.isGameStop = isPaused;
    }

    public void OpenControllerPanel()
    {
        contollerPanel.SetActive(true);
    }

    public void CloseControllerPanel()
    {
        contollerPanel.SetActive(false);
    }

    public void ResumeGame()
    {
        GameManager.instance.isGameStop = false;
        pausePanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}