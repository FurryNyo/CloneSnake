using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockPrefab : MonoBehaviour
{
    public int HealthBlock;
    public int Seed;
    public int PlaceNumber;
    public int HPlimit;
    [SerializeField] private TextMeshPro _hpText;

    void Start()
    {
        HealthBlock = (Seed * PlaceNumber+1) % HPlimit;
        if(HealthBlock <= 0)
        {
            HealthBlock = 1;
        }
        _hpText.text = HealthBlock.ToString();
    }
}
