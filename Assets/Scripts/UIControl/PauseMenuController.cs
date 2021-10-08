using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private RectTransform pausePanel;
    [SerializeField] private RectTransform gameUI;

    [SerializeField] private UnityEvent unpausedGame;
    [SerializeField] private GameObject firstSelected;

    public void Pause()
    {
        pausePanel.gameObject.SetActive(true);
        gameUI.gameObject.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
    public void Unpause()
    {
        pausePanel.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);
        unpausedGame.Invoke();
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void ExitGame()
    {
        //return to title screen
    }
}
