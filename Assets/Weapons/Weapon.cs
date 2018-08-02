using UnityEngine;
using System.Collections;

public class Weapon
{
    private GameObject _owner;
    private GameObject _projectile;
    private Collider2D _ownerCollider;
    private Color randomTint;
    private float _speed = 1.3f;
    private float _cooldown = 5;
    private float _lastAttack = 0;

    public delegate void FireEvent();
    public event FireEvent OnFire;

    public bool CanAttack {
        get
        {
            return _lastAttack + _cooldown <= Time.time;
        }
    }

    public Weapon(GameObject projectile, GameObject owner)
    {
        _projectile = projectile;
        _owner = owner;
        _ownerCollider = _owner.GetComponent<Collider2D>();
        randomTint = _owner.GetComponent<Unit>().randomTint;
    }


    public bool Shoot(Vector2 direction)
    {
        if (!CanAttack) return false;

        var projectile = MonoBehaviour.Instantiate<GameObject>(_projectile, _owner.transform.position, Quaternion.identity);
        var rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * _speed;

        Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), _ownerCollider);

        projectile.GetComponent<SpriteRenderer>().color = randomTint;

        _lastAttack = Time.time;

        if (OnFire != null)
        {
            OnFire();
        }

        return true;
    }

    public bool Shoot(Quaternion direction)
    {
        return Shoot(direction.eulerAngles.normalized);
    }
}