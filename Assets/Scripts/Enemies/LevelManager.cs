using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    public Transform Startpoint;
    public Transform[] path;

    [SerializeField]
    private Image _pauseDialog;

    private void Awake()
    {
        main = this;
    }
    private void PauseGame()
    {
        Time.timeScale = 0f;
        _pauseDialog.gameObject.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(); // G?i hàm PauseGame khi ng??i ch?i b?m nút Esc
        }
    }
    public void SettingGame()
    {
    }
    public void ContinueGame()
    {
        _pauseDialog.gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        SceneManager.LoadScene(0); // V? trang Menu
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
}
