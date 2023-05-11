using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class VolumeManager : MonoBehaviour
{
    private Signaling _signaling;
    private AudioSource _audioSurce;
    private float _minVolume = 0.0f;
    private float _maxVolume = 1.0f;

    private void Start()
    {
        _audioSurce = GetComponent<AudioSource>();
        _audioSurce.volume = _minVolume;

        _signaling = GetComponent<Signaling>();
        _signaling._eventChangeVolume.AddListener(ChangeVolume);
    }

    private void ChangeVolume()
    {
        if (_signaling.EnemyIsInAreaOnImpulse)
            StartCoroutine(CorutineChangeVolume(_maxVolume));

        if (_signaling.EnemyIsInAreaOffImpulse)
            StartCoroutine(CorutineChangeVolume(_minVolume));
    }

    private IEnumerator CorutineChangeVolume(float setpointVolume)
    {
        if (setpointVolume == _maxVolume)
            _audioSurce.Play();

        while (_audioSurce.volume != setpointVolume)
        {
            _audioSurce.volume = Mathf.MoveTowards(_audioSurce.volume, setpointVolume, Time.deltaTime);
            yield return null;
        }

        if (setpointVolume == _minVolume)
            _audioSurce.Stop();
    }
}





