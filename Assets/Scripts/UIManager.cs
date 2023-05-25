using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IObserver
{
    public void OnNotify()
    {
        // Update UI elements based on changes in the game state
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.AttachObserver(this);
    }

    // Update is called once per frame
    void Update()
    {
        // Update UI elements based on changes in the game states
    }
}
