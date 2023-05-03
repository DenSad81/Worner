using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChainger : MonoBehaviour
{
    [SerializeField] private float _volume = 0.0f;
    [SerializeField] private float _deltaTimeForVolume = 0.001f;

    [SerializeField] private Signaling signaling;
    private AudioSource _audioSurse;

    void Start()
    {
        if (GetComponent<AudioSource>() != null)
            _audioSurse = /*this.gameObject.*/GetComponent<AudioSource>();

        _audioSurse.volume = 0.0f;
        _audioSurse.Play();
    }

    void Update()
    {
        if ((signaling._isAlarme == false) & (_volume <= 0.0f))
            return;

        if (signaling._isAlarme == true)
        {
            if (_volume < 1)
                _volume += _deltaTimeForVolume;
        }

        if (signaling._isAlarme == false)
        {
            if (_volume > 0)
                _volume -= _deltaTimeForVolume;
        }

        _audioSurse.volume = _volume;

        if (_volume <= 0.0f)
            _audioSurse.Play();
    }
}
