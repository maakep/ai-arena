using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    // Opponent components
    public GameObject Opponent;
    public Unit OpponentUnit { get; private set; }
    public Vector2 OpponentDirection { get { return Opponent.transform.position - transform.position; } }
    public Vector2 OpponenetMovingDirection { get { return OpponentRigidbody.velocity.normalized; } }
    public Rigidbody2D OpponentRigidbody { get; private set; }

    // Self components
    public Rigidbody2D Rb { get; private set; }
    public Weapon Weapon { get; private set; }
    public Vector2 Direction { get { return Rb.velocity.normalized; } }

    // Properties
    public float Health { get; private set; }
    private float _speed = 1;
    public Color randomTint { get; private set; }

    void Awake()
    {
        randomTint = Random.ColorHSV(0, 1, 0, 1, 0, 1, 1, 1);
        GetComponent<SpriteRenderer>().color = randomTint;

        Rb = GetComponent<Rigidbody2D>();

        OpponentUnit = Opponent.GetComponent<Unit>();
        OpponentRigidbody = Opponent.GetComponent<Rigidbody2D>();

        Weapon = new Weapon(Resources.Load<GameObject>("Projectile"), gameObject);

        Health = 50;
    }

    public void Move(Vector2 direction)
    {
        Rb.velocity = direction.normalized * _speed;
    }

    public void Stop()
    {
        Move(Vector2.zero);
    }

    public bool Shoot(Vector2 direction)
    {
        return Weapon.Shoot(direction);
    }


    private void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
            Destroy(gameObject);
    }
}
