using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Signaling))]

public class VolumeChanger : MonoBehaviour
{
    private Signaling _signaling;
    private AudioSource _audioSurce;
    private float _minVolume = 0.0f;
    private float _maxVolume = 1.0f;

    private Coroutine _corutineChangeVolume;

    private void Start()
    {
        _audioSurce = GetComponent<AudioSource>();
        _audioSurce.volume = _minVolume;
    }

    private void OnEnable()
    {
        _signaling = GetComponent<Signaling>();
        _signaling.EventChangeVolume.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _signaling.EventChangeVolume.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume()
    {
        if (_corutineChangeVolume != null)
            StopCoroutine(_corutineChangeVolume);

        if (_signaling.EnemyIsInAreaOnImpulse)
            _corutineChangeVolume = StartCoroutine(CorutineChangeVolume(_maxVolume));

        if (_signaling.EnemyIsInAreaOffImpulse)
            _corutineChangeVolume = StartCoroutine(CorutineChangeVolume(_minVolume));
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





