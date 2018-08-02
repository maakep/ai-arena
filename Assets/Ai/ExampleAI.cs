using UnityEngine;
using System.Collections;

public class ExampleAI : MonoBehaviour
{
    Unit unit;
    Vector2 dir;

    void Start()
    {
        unit = GetComponent<Unit>();
        unit.OpponentUnit.Weapon.OnFire += HandleEnemyFire;
        dir = Vector2.down;
    }

    void HandleEnemyFire()
    {
        dir *= -1;
    }


    void Update()
    {
        unit.Weapon.Shoot(unit.OpponentDirection);
        unit.Move(dir);
    }
}
