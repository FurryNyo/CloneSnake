using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Unity.Collections;
using UnityEngine;

public class LevelPrefabSettings : MonoBehaviour
{
    [Header("Pin List for LevelGenerator")]
    public Transform StartPin;
    public Transform EndPin;

    [Header("Spawn point")]
    [SerializeField] private Transform[] _spawnBlockPoint;
    [SerializeField] private Transform[] _spawnApplePoint;

    [Header("Preafab for Spawn")]
    [SerializeField] private GameObject Block;
    [SerializeField] private GameObject Apple;

    public int PrefNum;
    public int Seed;
    private int Counter;
    [SerializeField, Range(1, 100)] private int _hpLimit;
    void Start()
    {
        Counter = 0;
        foreach (Transform sbp in _spawnBlockPoint)
        {
            if ((Seed * PrefNum) % (2 + Array.IndexOf(_spawnBlockPoint, sbp)) == 0)
            {                
                GameObject cube = Instantiate(Block, sbp.transform.position, Quaternion.identity);
                BlockPrefab BlockPrefab = cube.GetComponent<BlockPrefab>();
                BlockPrefab.Seed = Seed;
                BlockPrefab.PlaceNumber = Counter + PrefNum;
                BlockPrefab.HPlimit = _hpLimit;
                Counter++;
            }
        }

        Counter = 0;
        foreach (Transform sap in _spawnApplePoint)
        {
            if ((Seed * PrefNum) % (2 + Array.IndexOf(_spawnBlockPoint, sap)) == 0)
            {
                GameObject apple = Instantiate(Apple, sap.transform.position, Quaternion.identity);
                ApplePrefab ApplePrefab = apple.GetComponent<ApplePrefab>();
                ApplePrefab.Seed = Seed;
                ApplePrefab.PlaceNumber = Counter + PrefNum;
                ApplePrefab.HPlimit = _hpLimit;
                Counter++;
            }
        }
    }
}
