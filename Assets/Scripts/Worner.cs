using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worner : MonoBehaviour
{
    [SerializeField] private bool _isAlarme = false;
    [SerializeField] private float _volume = 0.0f;
    [SerializeField] private float _deltaTimeForVolume = 0.001f;
    [SerializeField] private float _alarmeLenghtZone = 9.0f;
    private AudioSource _audioSurse;

    private void Start()
    {
        _audioSurse = this.gameObject.GetComponent<AudioSource>();
        _audioSurse.volume = 0.0f;
    }

    private void Update()
    {
        _isAlarme = Physics2D.Raycast(this.transform.position, transform.up, _alarmeLenghtZone);

        Debug.DrawRay(this.transform.position, transform.up * _alarmeLenghtZone, Color.red);

        if (_isAlarme == true)
        {
            if (_volume < 1)
                _volume += _deltaTimeForVolume;
        }

        if (_isAlarme == false)
        {
            if (_volume > 0)
                _volume -= _deltaTimeForVolume;
        }

        _audioSurse.volume = _volume;

        if (_volume <= 0.0f)
            _audioSurse.Play();

    }
}
