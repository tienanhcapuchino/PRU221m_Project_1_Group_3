using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    [SerializeField]
    private Image _selectLevelDialog;

    public void StartGame()
    {
        _selectLevelDialog.gameObject.SetActive(true);
    }

    public void ChooseLevel()
    {
        _selectLevelDialog.gameObject.SetActive(false);
        SceneManager.LoadScene(1);

    }

}
