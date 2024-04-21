using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Counter : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_Text _startButtonText;
    [SerializeField] private Button _resetButton;

    [SerializeField] private TMP_Text _counter;

    private string _defaultCounter = "00-00-00";
    private string _start = "START";
    private string _pause = "PAUSE";
    private string _continue = "CONTINUE";
    private float _currentTime;

    private bool _isCoroutineWork;
    private bool _isTimerWork;

    private void Start()
    {
        ResetCounter();  
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartCounter);
        _resetButton.onClick.AddListener(ResetCounter);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(StartCounter);
        _resetButton.onClick.RemoveListener(ResetCounter);
    }

    private void StartCounter()
    {
        if( _isCoroutineWork == false)
        {
            _isCoroutineWork = true;
            StartCoroutine(IncreaseTimer());
        }

        if (_isTimerWork == false)
        {
            _isTimerWork = true;
            _startButtonText.text = _pause;            
        }
        else
        {
            _isTimerWork = false;
            _startButtonText.text = _continue;
        }        
    }

    private void ResetCounter()
    {
        _isCoroutineWork = false;
        _isTimerWork = false;
        _currentTime = 0;
        _startButtonText.text = _start;
        _counter.text = _defaultCounter;
        StopCoroutine(IncreaseTimer());
    }

    private IEnumerator IncreaseTimer()
    {
        int secondsInMinute = 60;
        int milisecMultiplyer = 100;

        while (true)
        {
            if (_isTimerWork == true)
            {
                _currentTime += Time.deltaTime;

                int seconds = (int)(_currentTime % secondsInMinute);
                int minutes = (int)(_currentTime / secondsInMinute);
                int millixeconds = (int)((_currentTime - seconds) * milisecMultiplyer) % milisecMultiplyer;

                string secondsText = String.Format("{00:00}", seconds);
                string minutesText = String.Format("{00:00}", minutes);
                string millixecondsText = String.Format("{00:00}", millixeconds);

                _counter.text = $"{minutesText}-{secondsText}-{millixecondsText}";
                yield return null;
            }
            yield return null;
        }
    }
}
