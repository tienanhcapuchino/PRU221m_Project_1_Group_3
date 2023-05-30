using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseManager : MonoBehaviour
{
    public void SettingGame()
    {
    }
    public void ContinueGame()
    {
        Time.timeScale = 0f;
    }
    public void QuitGame()
    {
        SceneManager.LoadScene(1); // V? trang Menu
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(2);
    }
}
