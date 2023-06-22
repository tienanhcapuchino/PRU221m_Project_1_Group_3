using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpell : MonoBehaviour
{
    public GameObject Spell;
    public int Damage;
    public int Duration;
    public int Coins;
    // Machine state
    private enum MyState
    {
        WaitForClick,
        WaitForFX
    }
    // Current state for this instance
    private MyState myState = MyState.WaitForClick;
    // Start is called before the first frame update
    /// <summary>
    /// Awake this instance.
    /// </summary>
    void Awake()
    {
    }
    /// <summary>
    /// Raises the enable event.
    /// </summary>
    private void OnEnable()
    {
        EventManager.StartListening("ButtonPressed", ButtonPressed);
        EventManager.StartListening("UserUiClick", UserUiClick);
    }
    /// <summary>
    /// Raises the disable event.
    /// </summary>
    private void OnDisable()
    {
        EventManager.StopListening("ButtonPressed", ButtonPressed);
        EventManager.StopListening("UserUiClick", UserUiClick);
    }
    void Start()
    {

    }

    private void ButtonPressed(GameObject obj, string param)
    {
        if (myState == MyState.WaitForClick)
        {

        }
    }
    private void UserUiClick(GameObject obj, string param)
    {
        // If clicked on UI instead game map
        if (myState == MyState.WaitForClick)
        {
            Destroy(gameObject);
        }
    }
}
