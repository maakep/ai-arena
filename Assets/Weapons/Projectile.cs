using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float damage = 5;

    private void Start()
    {
        Invoke("Destroy", 5);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var unit = collider.GetComponent<Unit>();
        if (unit != null)
        {
            unit.SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }
    }
}
