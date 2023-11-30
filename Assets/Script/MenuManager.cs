using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject canvas;

    Pause _pause;
    private void Start()
    {
        _pause = new Pause();
    }
    public void Resume()
    {
        _pause.PausedGame(canvas, false, 1); 
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(2);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Reset()
    {
       
        string nombreEscena = SceneManager.GetActiveScene().name;

       
        SceneManager.LoadScene(nombreEscena);
    }
}
