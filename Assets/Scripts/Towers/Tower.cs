using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private GameObject _actions;
    [SerializeField]
    private UnityEvent onClick;

    private void Start()
    {
        Debug.Assert(_actions != null, "Have the asssert");
        CloseActions();
    }
    private void OnMouseDown()
    {
        if (onClick != null)
        {
            if (_actions.activeSelf)
            {
                CloseActions();
            }
            else
            {
                OpenActions();
            }
        }
    }
    private void OpenActions()
    {
        _actions.SetActive(true);
    }
    private void CloseActions()
    {
        _actions.SetActive(false);
    }
    public void BuildTower(GameObject towerPrefab)
    {
        // Close active actions tree
        CloseActions();
        // If anough gold
        GameObject newTower = Instantiate<GameObject>(towerPrefab, transform.parent);
        newTower.name = towerPrefab.name;
        newTower.transform.position = transform.position;
        newTower.transform.rotation = transform.rotation;
        // Destroy old tower
        Destroy(gameObject);
    }
    public void SellTower(GameObject emptyPlacePrefab)
    {
        CloseActions();
        // Place building place
        GameObject newTower = Instantiate<GameObject>(emptyPlacePrefab, transform.parent);
        newTower.name = emptyPlacePrefab.name;
        newTower.transform.position = transform.position;
        newTower.transform.rotation = transform.rotation;
        // Destroy old tower
        Destroy(gameObject);
    }
}
