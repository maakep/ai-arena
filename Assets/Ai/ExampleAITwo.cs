using UnityEngine;
using System.Collections;

public class ExampleAITwo : MonoBehaviour
{

    Unit unit;

    void Start()
    {
        unit = GetComponent<Unit>();
    }


    void Update()
    {
        unit.Move(Vector2.up * Mathf.Sin(Time.time));
        unit.Weapon.Shoot(unit.OpponentDirection);
    }
}
