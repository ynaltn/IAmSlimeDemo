using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIStandart : MonoBehaviour
{
    public static UIStandart instance;
    [Header("LoadingWindow")]
    public GameObject LoadingWindow;
    public TextMeshProUGUI LoadingTitle;
    public TextMeshProUGUI LoadingMessage;
    [Header("InfoWindow")]
    public GameObject InfoWindow;
    public TextMeshProUGUI InfoTitle;
    public TextMeshProUGUI InfoMessage;
    public Button InfoButton;

    [Header("PlayerText")]
    public GameObject playerTextWindow;
    public TextMeshProUGUI PlayerTextMessage;
    public TextMeshProUGUI playerTextTitle;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
   public void ShowLoading(string Title , string Message)
   {
       
       LoadingTitle.text = Title;
       LoadingMessage.text = Message; 
       LoadingWindow.SetActive(true);
    }
   
   public void HideLoading()
    {
        LoadingWindow.SetActive(false);

    }
    public void ShowInfoWindow(string Title , string Message, Action onComplete)
    {
        InfoTitle.text = Title;
        InfoMessage.text = Message; 
        InfoButton.onClick.RemoveAllListeners();
        InfoWindow.SetActive(true);
        InfoButton.onClick.AddListener(() =>
        {
           onComplete?.Invoke();
           InfoWindow.SetActive(false);
        });
    }

    public void ShowPlayerTextWindow(string title,string Message)
    {
        playerTextTitle.text = title;
        PlayerTextMessage.text = Message;
        playerTextWindow.SetActive(true);
    }
    public void TitleChange(string title)
    {
        playerTextTitle.text = title;
    }

   
}
