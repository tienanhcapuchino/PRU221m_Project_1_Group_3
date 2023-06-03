using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Referemces")]
    [SerializeField] private Rigidbody2D rb;
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    
    private WayPoint wayPoint { get;set; }
    private int _pathIndex = 0;

    private void Start()
    {
        target = WayPoint.Get;
    }

    private void Update()
    {
        if(Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            _pathIndex++;
            if(_pathIndex == LevelManager.main.path.Length)
            {
                EnemiesSpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[_pathIndex];
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;   
        rb.velocity = direction * moveSpeed;
    }
}
