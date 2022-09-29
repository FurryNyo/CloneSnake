using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ApplePrefab : MonoBehaviour
{
    public int HealthApple;
    public int Seed;
    public int PlaceNumber;
    public int HPlimit;
    [SerializeField] private TextMeshPro _hpText;

    void Start()
    {
        HealthApple = (Seed * PlaceNumber + 1) % HPlimit;
        if (HealthApple <= 0)
        {
            HealthApple = 1;
        }
        _hpText.text = HealthApple.ToString();
    }
}