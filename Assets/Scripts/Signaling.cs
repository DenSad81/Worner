using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private float _alarmeLenghtZone = 9.0f;

    public bool IsAlarme { get; private set; }

    private void Update()
    {
        IsAlarme = Physics2D.Raycast(this.transform.position, transform.up, _alarmeLenghtZone);
        Debug.DrawRay(this.transform.position, transform.up * _alarmeLenghtZone, Color.red);
    }
}
