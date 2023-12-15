using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    public UnityEvent<int, Vector2> damagableHit;
    public UnityEvent<int, int> healthChanged;
    Animator animator;
    
    [SerializeField]
    private int _maxHealth = 100;

    public int MaxHealth {
        get {
            return _maxHealth;
        }
        set {
            _maxHealth = value;
        }
    }

    
    public int _health = 100;

    public int Health {
        get {
            return _health;
        }
        set {
            _health = value;
            healthChanged?.Invoke(_health, MaxHealth);

            if (_health <= 0) {
                IsAlive = false;
            }
        }
    }

    [SerializeField]
    private bool _isAlive = true;
    public bool isInvincible = false;

    public bool IsHit {
        get {
            return animator.GetBool(AnimationStrings.isHit);
        }
        private set {
            animator.SetBool(AnimationStrings.isHit, value);
        }
    }
    private float timeSinceHit;
    public float invinciblityTime = 0.5f;

    public bool IsAlive {
        get {
            return _isAlive;
        }
        set {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("IsAlive set" + value);
        }
    }

    public bool LockVelocity {
        get {
            return animator.GetBool(AnimationStrings.lockVelocity);
        }

        set {
            animator.SetBool(AnimationStrings.lockVelocity, value);
        }
    }

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    
    private void Update() {
        if(isInvincible) {
            if (timeSinceHit > invinciblityTime) {
                isInvincible = false;
                timeSinceHit = 0;
            }

            timeSinceHit += Time.deltaTime;
        }

        //Hit(10, Vector2.right);
    }

    public bool Hit(int damage, Vector2 knockback) {
        if (IsAlive && !isInvincible) {
            Health -= damage;
            isInvincible = true;
            //IsHit = true;

            animator.SetTrigger(AnimationStrings.hitTrigger);
            // LockVelocity = true;
            damagableHit?.Invoke(damage, knockback);
            EnemyEvents.enemyDamaged.Invoke(gameObject, damage);
            return true;
        }

        return false;
    }
}
