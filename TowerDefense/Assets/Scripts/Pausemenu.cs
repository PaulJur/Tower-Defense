using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pausemenu : MonoBehaviour
{

    [SerializeField] private GameObject PauseUI;
    public bool isPaused = false;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            Time.timeScale = 0;
            PauseUI.SetActive(true);

        }

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseUI.SetActive(false);
    }

}
