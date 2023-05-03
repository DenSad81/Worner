using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private float _alarmeLenghtZone = 9.0f;

    public bool _isAlarme { get; private set; }

    private void Start()
    {
    }

    private void Update()
    {
        _isAlarme = Physics2D.Raycast(this.transform.position, transform.up, _alarmeLenghtZone);
        Debug.DrawRay(this.transform.position, transform.up * _alarmeLenghtZone, Color.red);
    }
}
