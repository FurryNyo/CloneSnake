using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    [Header("SnakePrefabs")]
    [SerializeField] private GameObject _snakeBodyPref;

    [Header("Snake Head Position")]
    [SerializeField] private GameObject _snakeHead;

    [Header("Snake Builder")]
    [SerializeField] private float _distansBeteenBody;
    [SerializeField] private float _snakeBodySpeed;

    [Header("Hiden Variable")]
    private List<GameObject> _snakeBodyParts = new List<GameObject>();

    void Start()
    {
        _snakeBodyParts.Insert(0, _snakeHead);
    }

    void Update()
    {
        for(int i = 1; i < _snakeBodyParts.Count; i++)
        {
            Vector3 dir = _snakeBodyParts[i-1].transform.position - _snakeBodyParts[i].transform.position;
            if (dir.sqrMagnitude > _distansBeteenBody * _distansBeteenBody)
            {
                float step = _snakeBodySpeed * Time.deltaTime;
                _snakeBodyParts[i].transform.position = Vector3.MoveTowards(_snakeBodyParts[i].transform.position, _snakeBodyParts[i - 1].transform.position, step);
                _snakeBodyParts[i].transform.LookAt(_snakeBodyParts[i - 1].transform);
            }
        }
    }

    public void AddBodyPart()
    {
        GameObject bodyParts = Instantiate(_snakeBodyPref);
        _snakeBodyParts.Add(bodyParts);
    }

    public void RemoveBodyPart()
    {
        Destroy(_snakeBodyParts[_snakeBodyParts.Count - 1]);
        _snakeBodyParts.RemoveAt(_snakeBodyParts.Count - 1);
    }
}
