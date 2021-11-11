using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private RectTransform controlView;

    [SerializeField] private UnityEngine.UI.Button controlsCloseButton;
    [SerializeField] private UnityEngine.UI.Button startGameButton;

    private void Start()
    {
        startGameButton.Select();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("TheLevel");
    }
    public void ShowControls()
    {
        controlsCloseButton.Select();
        controlView.gameObject.SetActive(true);
    }
    public void CloseControls()
    {
        startGameButton.Select();
        controlView.gameObject.SetActive(false);

    }
    public void ExitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.ExitPlaymode();
    }
}
