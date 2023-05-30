using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(); // G?i hàm PauseGame khi ng??i ch?i b?m nút Esc
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(3);
    }

}
