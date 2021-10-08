using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private RectTransform controlView;

    [SerializeField] private GameObject controlsCloseButton;
    [SerializeField] private GameObject startGameButton;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(startGameButton);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("TheLevel");
    }
    public void ShowControls()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controlsCloseButton);
        controlView.gameObject.SetActive(true);
    }
    public void CloseControls()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(startGameButton);
        controlView.gameObject.SetActive(false);

    }
    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.ExitPlaymode();
    }
}
