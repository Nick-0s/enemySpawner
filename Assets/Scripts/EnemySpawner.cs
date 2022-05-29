using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _spawnPoints;

    private bool _isWorking;
    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
            _points[i] = _spawnPoints.GetChild(i);

        _isWorking = true;
        Coroutine spawn = StartCoroutine(Spawn());
    }

    private void OnMouseDown()
    {
        _isWorking = false;
    }

    private IEnumerator Spawn()
    {
        var waitForTwoSeconds = new WaitForSeconds(2f);
        int pointIndex = 0;

        while(_isWorking)
        {
            Enemy newEnemy = Instantiate(_enemy, _points[pointIndex].position, Quaternion.identity);
            pointIndex = (++pointIndex) % _spawnPoints.childCount;

            yield return waitForTwoSeconds;
        }
    }
}
