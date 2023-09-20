using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinFactory _coinFactory;
    [SerializeField] private SpawnZone _spawnZone;
    [SerializeField] private LayerMask _ObstaclesAndCoins;
    [SerializeField, Range(1, 10)] private float _distanceBetween;
    [SerializeField, Range(1, 10)] private float _distanceToCenter;
    [SerializeField, Range(1, 10)] private float _distanceToObstacles;

    private LayerMask _layerMaskCoin = LayerMask.GetMask("Coin");
    private LayerMask _layerMaskObstacle = LayerMask.GetMask("Obstacle");
    

    public void StartWork() 
    {
        Spawn();
    }

    [ContextMenu("Spawn")]
    private void Spawn()
    {
        Coin coin = _coinFactory.Get(CoinType.Small);
        List<Collider2D> hitColliders = CastCircleAround(coin.transform, 5);
        foreach (Collider2D collider in hitColliders)
        {
            //Debug.Log(collider.transform.gameObject.name);
            if (collider.TryGetComponent(out Coin otherCoin))
                Debug.Log(otherCoin.gameObject.name);
        }

        //for (int i = 0; i < hits.Length; ++i)
        //{
        //    Debug.Log(hits[i].collider);
        //}
       
        //coin.Position

    }

    private List<Collider2D> CastCircleAround(Transform origin, float radius, LayerMask layerMask)
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(origin.position, radius, Vector2.zero, radius, layerMask);
        List<Collider2D> resultHits = new List<Collider2D>();
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform != origin)
                resultHits.Add(hit.collider);
        }

        return resultHits;
    }

    private bool IsNeedNewPosition(Transform origin)
    {
        List<Collider2D> resultHits = CastCircleAround(origin, _distanceBetween, _layerMaskCoin);
        if (resultHits.Count > 0)
            return true;

        resultHits = CastCircleAround(origin, _distanceToObstacles, _layerMaskObstacle);
        if (resultHits.Count > 0)
            return true;

        float distanceToCenter = (_spawnZone.Center - new Vector2(origin.position.x, origin.position.y)).magnitude;
        if (distanceToCenter < _distanceToCenter)
            return true;


        return false;
    }


    private Vector2 GetRandomPosition()
        => new Vector2(UnityEngine.Random.Range(_spawnZone.LeftCorner.x, _spawnZone.RightCorner.x),
                       UnityEngine.Random.Range(_spawnZone.RightCorner.y, _spawnZone.LeftCorner.y));

    private Vector2 CalculateNewPosition(Vector2 curruntPosition, List<Collider2D> colliders)
    {
        Vector2 sumCoinVector = new Vector2();
        Vector2 sumObstacleVector = new Vector2();

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out Coin otherCoin))
                sumCoinVector += otherCoin.Position;
            else
                sumObstacleVector += new Vector2(collider.transform.position.x, collider.transform.position.y);
        }

        Vector2 resultVector = curruntPosition;
        resultVector += sumCoinVector.normalized * () + sumObstacleVector;

        float distanceToCenter = (_spawnZone.Center - resultVector).magnitude;
        if (distanceToCenter < _distanceToCenter)
            resultVector

        
    }

    //private Vector2 GetRandomPosition(Vector2[] obstaclePositions)
    //{
    //    Vector2 spawnPosition;

    //    foreach (Vector2 position in otherPositions)
    //    {

    //    }
    //} 
}
