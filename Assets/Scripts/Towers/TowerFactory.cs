using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject _actions;
    [SerializeField]
    private GameObject _range;

    private void Start()
    {
        Debug.Assert(_actions != null, "Have the asssert");
        CloseActions();
    }
    private void CloseActions()
    {
        if (_actions.activeSelf == true)
        {
            _actions.SetActive(false);
        }
    }
    public enum TowerType
    {
        MAGIC,
        MORTAL,
        BOWMAN,
        BARRACKS,
        BALLISTA
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
}
