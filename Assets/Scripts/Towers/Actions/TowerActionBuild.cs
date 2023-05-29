using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerActionBuild : Actions
{
    public GameObject towerPrefab;
    public UnityEvent onClick;

    private void OnMouseDown()
    {
        if (onClick != null)
        {
            Clicked();
        }
    }
    protected override void Clicked()
    {
        // If player has anough gold
       
            Tower tower = GetComponentInParent<Tower>();
            if (tower != null)
            {
                tower.BuildTower(towerPrefab);
            }
    }
}
