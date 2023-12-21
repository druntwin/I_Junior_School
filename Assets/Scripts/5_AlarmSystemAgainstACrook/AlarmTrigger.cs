using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField][Range(0.01f, 0.5f)] private float _volumeUpChangeSpeed = 0.1f;
    [SerializeField][Range(0.01f, 0.5f)] private float _volumeDownChangeSpeed = 0.2f;
    [SerializeField][Range(0.01f, 0.2f)] private float _volumeStep = 0.1f;

    private AudioSource _audioSource;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    private void OnEnable()
    {
        _door.DoorOpened += OnAlarm;
    }

    private void OnDisable()
    {
        _door.DoorOpened -= OnAlarm;
    }

    private void OnAlarm()
    {
        StartCoroutine(SetVolume());
    }

    IEnumerator SetVolume()
    {
        float volumeChangeSpeed;
        var waitSomeTime = new WaitForSeconds(_volumeDownChangeSpeed);

        if (_door.IsDoorTiggered)
        {
            volumeChangeSpeed = _volumeUpChangeSpeed;

            _audioSource.Play();

            while (_audioSource.volume < _maxVolume)
            {
                _audioSource.volume += _volumeStep;

                yield return waitSomeTime;
            }

            _audioSource.volume = _maxVolume;
        }
        else
        {
            volumeChangeSpeed = _volumeDownChangeSpeed;

            while (_audioSource.volume > _minVolume)
            {
                _audioSource.volume -= _volumeStep;

                yield return waitSomeTime;
            }

            _audioSource.volume = _minVolume;
            _audioSource.Stop();
        }
    }
}
