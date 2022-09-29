using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameplay : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private GameController _gameController;
    [SerializeField] private SnakeTail _snakeTail;

    [Header("Health Snake")]
    [SerializeField] private int _startSnakeHP;
    [SerializeField] private TextMeshPro _HPText;
    public int CurentHP;

    [Header("Sounds")]
    [SerializeField] private AudioSource _blockBreakingSound;
    [SerializeField] private AudioSource _appleEatingSound;
    [SerializeField] private AudioSource _backGroundMusic;

    [Header("Level Index")]
    private const string LevelIndexKey = "LevelIndex";
    
    void Start()
    {
        CurentHP = _startSnakeHP;
        for (int i = CurentHP; i > 0; i--)
        {
            _snakeTail.AddBodyPart();
        }
    }

    void Update()
    {
        _HPText.text = CurentHP.ToString();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<BlockPrefab>(out BlockPrefab blockPrefab))
        {
            _blockBreakingSound.Play();
            LossHP(blockPrefab.HealthBlock);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.TryGetComponent<ApplePrefab>(out ApplePrefab applePrefab))
        {
            _appleEatingSound.Play();
            AddHP(applePrefab.HealthApple);
            Destroy(collision.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {
            _gameController.OnPlayerWin();
            LevelIndex++;
        }
    }

    public void AddHP(int x)
    {
        CurentHP = CurentHP + x;
        for (int i = x; i > 0; i--)
        {
            _snakeTail.AddBodyPart();
        }
    }

    public void LossHP(int x)
    {
        CurentHP = CurentHP - x;
        if (CurentHP <= 0)
        {
            _gameController.OnPlayerLoss();
        }

        for (int i = x; i > 0; i--)
        {
            _snakeTail.RemoveBodyPart();
        }
    }
    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
}
