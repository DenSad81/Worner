using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class VolumeChainger : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private AudioSource _audioSurce;
    private float _minVolume = 0.0f;
    private float _maxVolume = 1.0f;
    private float _actualVolumeNormalized;
    private float _incrementDecrimentVolume = 0.001f;
    private Coroutine _changeVolumeUp;
    private Coroutine _changeVolumeDown;

    private void Start()
    {
        _audioSurce = GetComponent<AudioSource>();
        _audioSurce.volume = _minVolume;
    }

    private void Update()
    {
        if (_signaling.EnemyIsInAreaOnImpulse)
        {
            if (_changeVolumeDown != null)
                StopCoroutine(_changeVolumeDown);

            _changeVolumeUp = StartCoroutine(ChangeVolumeUp());
        }

        if (_signaling.EnemyIsInAreaOffImpulse)
        {
            if (_changeVolumeUp != null)
                StopCoroutine(_changeVolumeUp);

            _changeVolumeDown = StartCoroutine(ChangeVolumeDown());
        }
    }

    private IEnumerator ChangeVolumeUp()
    {
        _audioSurce.Play();

        while (_actualVolumeNormalized < 1.0f)
        {
            ChangeVolume();
            _actualVolumeNormalized += _incrementDecrimentVolume;
            yield return null;
        }
    }

    private IEnumerator ChangeVolumeDown()
    {
        while (_actualVolumeNormalized > 0.0f)
        {
            ChangeVolume();
            _actualVolumeNormalized -= _incrementDecrimentVolume;
            yield return null;
        }

        _audioSurce.Stop();
    }

    private void ChangeVolume()
    {
        _audioSurce.volume = Mathf.Lerp(_minVolume, _maxVolume, _actualVolumeNormalized);
    }
}





