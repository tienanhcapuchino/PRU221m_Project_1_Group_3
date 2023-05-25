using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public AudioManager AudioManager { get; private set; }
    public UIManager UIManager { get; private set; }

    private float _health = 5;

    private float _coin = 15;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            //AudioManager = GetComponentInChildren<AudioManager>();
            //UIManager = GetComponentInChildren<UIManager>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private List<IObserver> observers = new List<IObserver>();

    public void AttachObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void DetachObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnNotify();
        }
    }

    // Example method that triggers UI updates
    private void ChangeGameState()
    {
        // Update game state here

        // Notify observers of the change
        NotifyObservers();
    }
}
