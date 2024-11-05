using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefabs;

    [Header("Enemies")]
    public List<GameObject> Enemies;

    [Header("References")]
    public Transform StartPoint;

    [Header("Animations")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;


    private GameObject _CurrentPlayer;

    public void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawPlayer();
    }

    private void SpawPlayer()
    {
        _CurrentPlayer = Instantiate(playerPrefabs);
        _CurrentPlayer.transform.position = StartPoint.transform.position;
        _CurrentPlayer.transform.DOScale(0, duration).SetEase(ease).From();
    }
}
