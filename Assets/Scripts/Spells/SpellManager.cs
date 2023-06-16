using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public GameObject Spell;
    private CoinsManager coinManager;
    // Start is called before the first frame update
    void Start()
    {
        coinManager = FindObjectOfType<CoinsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            coinManager.SpendCoins(50);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            coinManager.AddCoins(50);
        }
    }
}
