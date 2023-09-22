using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private SpawnZone _spawnZone;
    [SerializeField] private LayerMask _obstacles;
    [SerializeField, Range(50, 100)] private int _countCoins;
    [SerializeField, Range(1, 10)] private float _distanceBetween;
    [SerializeField, Range(1, 10)] private float _distanceToCenter;
    [SerializeField, Range(1, 10)] private float _distanceToObstacles;

    private CoinFactory _coinFactory;

    [Inject]
    private void Construct(CoinFactory coinFactory) => _coinFactory = coinFactory;

    private void Awake()
    {
        StartWork();
    }

    public void StartWork()
    {
        Spawn();
    }

    private void Spawn()
    {
        List<Vector2> spawnPositions = DefineSpawnPoints();

        if (IsEnoughPlaceForSpawn(spawnPositions) == false)
            throw new ArgumentException($"Ќедостаточно места в {_spawnZone} при заданных параметрах");

        for (int i = 0; i < _countCoins; ++i)
        {
            Coin coin = _coinFactory.Get(GetRandomCoin());
            coin.Position = GetRandomPositionFromSpawnPointList(spawnPositions);
        }
    }

    private RaycastHit2D[] CastCircleAround(Vector2 origin, float radius, LayerMask layerMask)
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(origin, radius, Vector2.zero, radius, layerMask);

        return hits;
    }

    private List<Vector2> DefineSpawnPoints()
    {
        List<Vector2> spawnPoints = new List<Vector2>();
        Vector2 startPoint = new Vector2(_spawnZone.LeftCorner.x + _distanceBetween / 2, _spawnZone.LeftCorner.y - _distanceBetween / 2);

        int countPointsX = (int)(_spawnZone.Size.x / _distanceBetween);
        int countPointsY = (int)(_spawnZone.Size.y / _distanceBetween);


        Vector2 currentPoint = startPoint;
        for (int i = 0; i < countPointsY; ++i)
        { 
            for (int j = 0; j < countPointsX; ++j)
            {
                if (IsAllowedPosition(currentPoint))
                    spawnPoints.Add(currentPoint);

                currentPoint.x += _distanceBetween;
            }
            currentPoint.y -= _distanceBetween;
            currentPoint.x = startPoint.x;
        }
        return spawnPoints;
    }


    private bool IsAllowedPosition(Vector2 position)
    {
        float distanceToCenter = (_spawnZone.Center - position).magnitude;
        if (distanceToCenter < _distanceToCenter)
            return false;

        RaycastHit2D[] hits = CastCircleAround(position, _distanceToObstacles, _obstacles);
        if (hits.Length > 0)
            return false;

        if (position.x < _spawnZone.LeftCorner.x || position.x > _spawnZone.RightCorner.x ||
            position.y > _spawnZone.LeftCorner.y || position.y < _spawnZone.RightCorner.y)
            return false;

        return true;
    }

    private bool IsEnoughPlaceForSpawn(List<Vector2> spawnPoints)
    {
        if (spawnPoints.Count < _countCoins)
            return false;

        return true;
    }

    private Vector2 GetRandomPositionFromSpawnPointList(List<Vector2> spawnPositions)
    {
        Vector2 randomSpawnPosition = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
        spawnPositions.Remove(randomSpawnPosition);

        return randomSpawnPosition;
    }

    private CoinType GetRandomCoin()
        => (CoinType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(CoinType)).Length);
}
