using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private RectTransform pausePanel;

    [SerializeField] private RectTransform gameUI;
    [SerializeField] private RectTransform bigMap;

    [SerializeField] private RectTransform controlView;

    [SerializeField] private UnityEvent unpausedGame;
    [SerializeField] private GameObject firstSelected;
    [SerializeField] private GameObject controlViewSelected;

    public void Pause()
    {
        pausePanel.gameObject.SetActive(true);
        gameUI.gameObject.SetActive(false);
        bigMap.gameObject.SetActive(false);
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

    public void ShowControls()
    {
        controlView.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controlViewSelected);
    }
    public void HideControls()
    {
        controlView.gameObject.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
