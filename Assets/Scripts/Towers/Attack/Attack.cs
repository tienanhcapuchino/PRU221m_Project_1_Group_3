using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
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

    public virtual void TryAttack(Transform target)
    {

    }

    public virtual void Fire(Transform target)
    {

    }
}
