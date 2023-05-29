using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField]
    //Price of tower
    private float _price;
    [SerializeField]
    // Damage amount
    protected int _damage = 1;
    [SerializeField]
    // Cooldown between attacks
    protected float _cooldown = 1f;
    [SerializeField]
    // Delay for fire animation
    protected float _fireDelay = 0f;
    // Sound effect
    [SerializeField]
    protected AudioClip _sfx;
    [SerializeField]
    protected GameObject _range;

    public virtual void TryAttack(Transform target)
    {
    }

    public virtual void Fire(Transform target)
    {

    }

}
