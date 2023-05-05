using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class VolumeChainger : MonoBehaviour
{
    [SerializeField] private float _deltaTimeForVolume = 0.001f;
    [SerializeField] private Signaling _signaling;

    private AudioSource _audioSurce;
    private float _actualVolume = 0.0f;
    private float _minVolume = 0.0f;
    private float _maxVolume = 1.0f;

    void Start()
    {
        _audioSurce = GetComponent<AudioSource>();
        _audioSurce.volume = _minVolume;
        _audioSurce.Play();

        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (true)
        {
            while ((_signaling.IsAlarme == true) | (_actualVolume > _minVolume))
            {
                if (_signaling.IsAlarme == true)
                {
                    if (_actualVolume < _maxVolume)
                        _actualVolume += _deltaTimeForVolume;
                }

                if (_signaling.IsAlarme == false)
                {
                    if (_actualVolume > _minVolume)
                        _actualVolume -= _deltaTimeForVolume;
                }

                _audioSurce.volume = _actualVolume;

                if (_actualVolume <= _minVolume)
                    _audioSurce.Play();

                yield return null;
            }

            yield return null;
        }
    }
}
