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
    protected List<GameObject> _listEnermy = new List<GameObject>();


    public virtual void TryAttack(Transform target)
    {
    }

    public virtual void Fire(Transform target)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enermy") || collision.gameObject.CompareTag("FlyingEnermy"))
        {
            _listEnermy.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enermy") || collision.CompareTag("FlyingEnermy"))
        {
            if (_listEnermy.Contains(collision.gameObject))
            {
                _listEnermy.Remove(collision.gameObject);
            }
        }
    }

}
