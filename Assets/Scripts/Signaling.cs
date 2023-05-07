using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private float _alarmeLenghtZone = 9.0f;

    private bool _enemyIsInArea;
    private bool _enemyIsInAreaMemory;
    public bool EnemyIsInAreaOnImpulse { get; private set; }
    public bool EnemyIsInAreaOffImpulse { get; private set; }


    private void Update()
    {
        _enemyIsInArea = Physics2D.Raycast(this.transform.position, transform.up, _alarmeLenghtZone);
        Debug.DrawRay(this.transform.position, transform.up * _alarmeLenghtZone, Color.red);

        if (_enemyIsInArea == true & _enemyIsInAreaMemory == false)
        {
            EnemyIsInAreaOnImpulse = true;
            _enemyIsInAreaMemory = true;
        }
        else
            EnemyIsInAreaOnImpulse = false;

        if (_enemyIsInArea == false & _enemyIsInAreaMemory == true)
        {
            EnemyIsInAreaOffImpulse = true;
            _enemyIsInAreaMemory = false;
        }
        else
            EnemyIsInAreaOffImpulse = false;
    }
}
