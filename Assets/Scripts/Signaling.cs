using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private float _alarmeLenghtZone = 9.0f;

    private bool _enemyIsInArea;
    private bool _enemyIsInAreaMemoryOn;
    private bool _enemyIsInAreaMemoryOff;

    public bool EnemyIsInAreaOnImpulse { get; private set; }
    public bool EnemyIsInAreaOffImpulse { get; private set; }

    public UnityEvent EventChangeVolume = new UnityEvent();

    private void FixedUpdate()
    {
        _enemyIsInArea = Physics2D.Raycast(this.transform.position, transform.up, _alarmeLenghtZone);
        Debug.DrawRay(this.transform.position, transform.up * _alarmeLenghtZone, Color.red);

        EnemyIsInAreaOnImpulse = _enemyIsInArea & (!_enemyIsInAreaMemoryOn);
        _enemyIsInAreaMemoryOn = _enemyIsInArea;

        EnemyIsInAreaOffImpulse = (!_enemyIsInArea) & _enemyIsInAreaMemoryOff;
        _enemyIsInAreaMemoryOff = _enemyIsInArea;

        if (EnemyIsInAreaOnImpulse || EnemyIsInAreaOffImpulse)
            EventChangeVolume.Invoke();
    }
}
