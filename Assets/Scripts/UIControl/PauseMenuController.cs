using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] private UnityEngine.UI.Button firstSelected;
    [SerializeField] private UnityEngine.UI.Button controlViewSelected;

    public void Pause()
    {
        pausePanel.gameObject.SetActive(true);
        gameUI.gameObject.SetActive(false);
        bigMap.gameObject.SetActive(false);
        firstSelected.Select();
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
        controlViewSelected.Select();
    }
    public void HideControls()
    {
        controlView.gameObject.SetActive(false);
        firstSelected.Select();
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
