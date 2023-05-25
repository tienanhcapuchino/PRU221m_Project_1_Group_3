using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITower
{
    void BuildTower();
    void SellTower();
    void FindNearestEnemy();
    void UpdateTower();
    void Attack();
}
