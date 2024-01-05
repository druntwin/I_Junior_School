using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthView : MonoBehaviour
{
    [SerializeField] private float _smoothDecreasingDuretion = 0.5f;
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Color _damageHealthColor;
    [SerializeField] private AnimationCurve _colorBehavior;
    [SerializeField] private Animator _healthAnimator;
    [SerializeField] private AnimationClip _heartPulseAnimation;

    private Color _originalHealthColor;

    private void Start()
    {
        _originalHealthColor = _healthText.color;
        _healthText.text = _health.MaxHealth.ToString("");
    }

    private void OnEnable()
    {
        _health.Changed += TakeDamage;
    }

    private void OnDisable()
    {
        _health.Changed -= TakeDamage;
    }

    private void TakeDamage(float currentHealth)
    {
        _healthAnimator.Play(_heartPulseAnimation.name);
        StartCoroutine(DecreaseHealtSmothly(currentHealth));
    }

    private IEnumerator DecreaseHealtSmothly(float target)
    {
        float elapsedTime = 0;
        float previousValue = float.Parse(_healthText.text);

        while(elapsedTime < _smoothDecreasingDuretion)
        {
            elapsedTime += Time.deltaTime;
            float normolizedPosition = elapsedTime / _smoothDecreasingDuretion;
            float intermediateValue = Mathf.Lerp(previousValue, target, normolizedPosition);
            _healthText.text = ((int)intermediateValue).ToString("");

            _healthText.color = Color.Lerp(_originalHealthColor, _damageHealthColor, _colorBehavior.Evaluate(normolizedPosition));
            yield return null;
        }
    }
}
