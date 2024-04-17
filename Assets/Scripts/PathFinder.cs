using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner EnemySpawner;
    WaveConfigSO WaveConfig;
    List<Transform> WayPoints;
    int WayPointsIndex = 0;

	private void Awake()
	{
		EnemySpawner = FindAnyObjectByType<EnemySpawner>();
	}
	void Start()
    {
        WaveConfig = EnemySpawner.GetCurrentWave();
        WayPoints = WaveConfig.GetWavePoints();
        transform.position = WayPoints[WayPointsIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

	void FollowPath()
	{
		if(WayPointsIndex < WayPoints.Count )
        {
            Vector3 TargetPosition = WayPoints[WayPointsIndex].position;
            float delta = WaveConfig.GetMovementSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, TargetPosition, delta);
            if(transform.position == TargetPosition)
            {
                WayPointsIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
