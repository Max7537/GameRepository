using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private WaveController _waveController;

    private void OnEnable()
    {
        _waveController.Win += EndGame;
    }

    private void OnDisable()
    {
        _waveController.Win -= EndGame;
    }

    private void EndGame()
    {
        Time.timeScale = 0;
        _winPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
