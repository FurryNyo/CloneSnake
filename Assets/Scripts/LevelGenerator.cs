using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Seed Generator")]
    private int _seed;
    private List<int> _listSeed = new List<int>();
    [SerializeField] private int _minRandomRange;
    [SerializeField] private int _maxRandomRange;
    [SerializeField] private int _maxLengthPrefabs;
    [SerializeField] private int _enableCube;
    [SerializeField] private int _level;

    [Header("Prefabs List")]
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private GameObject _startPrefab;
    [SerializeField] private GameObject _finishPrefab;

    private const string Seed = "Seed";

    void Awake()
    {
        if (SaveSeed == 0)
        {
            PreSeed();
        }
        _seed = SaveSeed;
        GenSeed();
    }

    void Start()
    {
        GameObject _startLevel = Instantiate(_startPrefab, Vector3.zero, Quaternion.identity);
        Vector3 endPos = _startLevel.GetComponent<LevelPrefabSettings>().EndPin.transform.position;
        int segmentCount = 1;
        foreach (int i in _listSeed)
        {
            GameObject prefab = Instantiate(_prefabs[i], endPos, Quaternion.identity);
            LevelPrefabSettings levelPrefabSetting = prefab.GetComponent<LevelPrefabSettings>();
            endPos = levelPrefabSetting.EndPin.transform.position;
            levelPrefabSetting.PrefNum = segmentCount;
            segmentCount++;
            levelPrefabSetting.Seed = _seed;
        }
        Instantiate(_finishPrefab, endPos, Quaternion.identity);
    }

    public void GenSeed()
    {
        int _tempSeed = _seed;

        while (true)
        {
            _listSeed.Add(_tempSeed % _prefabs.Length);
            _tempSeed = _tempSeed / _prefabs.Length;
            if (_tempSeed < _prefabs.Length)
            {
                return;
            }
        }
    }

    public void PreSeed()
    {
        _seed = Random.Range(_minRandomRange, _maxRandomRange);
        SaveSeed = _seed;
    }
    public int SaveSeed
    {
        get => PlayerPrefs.GetInt(Seed, 0);
        private set
        {
            PlayerPrefs.SetInt(Seed, value);
            PlayerPrefs.Save();
        }
    }
}