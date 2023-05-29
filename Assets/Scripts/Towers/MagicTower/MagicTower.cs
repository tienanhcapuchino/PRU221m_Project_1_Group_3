using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTower : TowerFactory
{
    [SerializeField]
    private GameObject _bulletsPrefab;
    // From this position arrows will fired
    [SerializeField]
    private Transform _firePoint;

    // Animation controller for this AI
    private Animator anim;
    // Counter for cooldown calculation
    private float cooldownCounter;

    /// <summary>
    /// Awake this instance.
    /// </summary>
    void Awake()
    {
        anim = GetComponentInParent<Animator>();
        cooldownCounter = _cooldown;
        Debug.Assert(_bulletsPrefab && _firePoint, "Wrong initial parameters");
    }

    /// <summary>
    /// Update this instance.
    /// </summary>
    void FixedUpdate()
    {
        if (cooldownCounter < _cooldown)
        {
            cooldownCounter += Time.fixedDeltaTime;
        }
    }

    /// <summary>
    /// Attack the specified target if cooldown expired
    /// </summary>
    /// <param name="target">Target.</param>
    public override void TryAttack(Transform target)
    {
        if (cooldownCounter >= _cooldown)
        {
            cooldownCounter = 0f;
            Fire(target);
        }
    }

    private IEnumerator FireCoroutine(Transform target, GameObject bulletPrefab)
    {
        if (target != null && bulletPrefab != null)
        {
            // If unit has animator
            if (anim != null && anim.runtimeAnimatorController != null)
            {
                // Search for clip
                foreach (AnimationClip clip in anim.runtimeAnimatorController.animationClips)
                {
                    if (clip.name == "Attack")
                    {
                        // Play animation
                        anim.SetTrigger("attack");
                        break;
                    }
                }
            }
            // Delay to synchronize with animation
            yield return new WaitForSeconds(_fireDelay);
            if (target != null)
            {
                // Create bullet
                GameObject arrow = Instantiate(bulletPrefab, _firePoint.position, _firePoint.rotation);
                IBullet bullet = arrow.GetComponent<IBullet>();
                bullet.SetDamage(_damage);
                bullet.Fire(target);
            }
        }
    }

    /// <summary>
    /// Make ranged attack
    /// </summary>
    /// <param name="target">Target.</param>
    public override void Fire(Transform target)
    {
        StartCoroutine(FireCoroutine(target, _bulletsPrefab));
    }

    /// <summary>
    /// Make ranged attack with special bullet
    /// </summary>
    /// <param name="target">Target.</param>
    /// <param name="bulletPrefab">Bullet prefab.</param>
    public void Fire(Transform target, GameObject bulletPrefab)
    {
        StartCoroutine(FireCoroutine(target, bulletPrefab));
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }
}
