using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingCoor : MonoBehaviour
{
    private SpriteRenderer _target;
    [SerializeField] private float _duration;
    [SerializeField] private Color _targetColor;
    private Color _startColor;
    private float _runningTime;
    private bool _hasChanged;
    
    private void Start()
    {
        _target = GetComponent<SpriteRenderer>();
        _startColor = _target.color;
        _hasChanged = false;
    }

    private void Update()
    {        
        float normalizeRunningTime;

        if (_hasChanged == false)
        {
            _runningTime += Time.deltaTime;

            if (_runningTime >= _duration)
                _hasChanged = true;
        }
        else
        {
            _runningTime -= Time.deltaTime;

            if (_runningTime <= 0)
                _hasChanged = false;
        }

        normalizeRunningTime = _runningTime / _duration;

        _target.color = Color.Lerp(_startColor, _targetColor, normalizeRunningTime);
    }
}
