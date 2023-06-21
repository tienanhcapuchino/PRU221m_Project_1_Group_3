using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Referemces")]
    [SerializeField] private Rigidbody2D rb;
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Vector3 target;

    private WayPoint wayPoint;
    private int _pathIndex = 1;

    private void Start()
    {
        wayPoint = GameObject.Find("Path").GetComponent<WayPoint>();
        
        target = wayPoint.Points[1];
    }

    private void Update()
    {
        if(Vector3.Distance(target, transform.position) <= 0.1f)
        {
            _pathIndex++;
            if(_pathIndex == wayPoint.Points.Length)
            {
                EnemiesSpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = wayPoint.Points[_pathIndex];
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = (target - transform.position).normalized;   
        rb.velocity = direction * moveSpeed;
    }
}
