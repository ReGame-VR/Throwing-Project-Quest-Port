using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelDifficulty : MonoBehaviour
{
    [Header("Target")]
    public GameObject target;
    public Vector3 calibratedTargetPos;
    [Header("Throwable Object")]
    public GameObject objectToThrow;
    [Header("Obstacle")]
    public GameObject obstaclePrefab;
    [Header("Obstacle Spawn Position")]
    public Transform obstacleLocation;
    public Transform startPos;
    public Transform endPos;
    [Header("Adjustable Values")]
    public float AdjustableTargetPercent = 2.0f;
    public float AdjustableObjectPercent = 1f;
    public float obstacleSpeed = 1.0f;
    public GlobalControl globalControl;
    public bool hasRecievedBaseline = false;
    private GameObject _obstacle;


    private void Update()
    {
        if (globalControl.hasCalibrated && !hasRecievedBaseline)
        {
            calibratedTargetPos = target.transform.position;
            hasRecievedBaseline = true;
        }
    }

    public void MoveTarget()
    {
        target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z * AdjustableTargetPercent);
    }

    public void AdjustTargetSize(float reductionPercent)
    {
        target.transform.localScale = Vector3.one * reductionPercent;
    }

    public void AdjustObjectSize(float reductionPercent)
    {
        objectToThrow.transform.localScale = Vector3.one * reductionPercent;
    }

    public void SpawnObstacle()
    {
        _obstacle = Instantiate(obstaclePrefab, obstacleLocation);
    }

    public void DestroyObstacle()
    {
        if(_obstacle != null)
        {
            Destroy(_obstacle);
        }
    }

    public void MoveObstacle()
    {
        obstaclePrefab.transform.position = Vector3.Lerp(startPos.position, endPos.position, (Mathf.Sin(obstacleSpeed * Time.time) + 1.0f) / 2.0f);
    }

    public void LevelOne()
    {
        ResetTargetPosition();
        ResetTargetSize();
    }

    public void LevelTwo()
    {
        ResetTargetPosition();
        ResetTargetSize();

        MoveTarget();
    }

    public void LevelThree()
    {
        ResetTargetPosition();
        ResetTargetSize();

        AdjustTargetSize(AdjustableObjectPercent);
    }

    public void LevelFour()
    {
        //Reset positions and size for reference
        ResetTargetPosition();
        ResetTargetSize();

        MoveTarget();
        AdjustTargetSize(AdjustableObjectPercent);
    }

    public void LevelFive()
    {
        ResetTargetPosition();
        ResetTargetSize();

        MoveTarget();
        AdjustTargetSize(AdjustableObjectPercent);
        SpawnObstacle();
    }

    //Used to reset target reference
    public void ResetTargetPosition()
    {
        target.transform.position = calibratedTargetPos;
    }

    public void ResetTargetSize()
    {
        target.transform.localScale = Vector3.one * 1f;
    }

    public void FullReset()
    {
        ResetTargetPosition();
        ResetTargetSize();
        DestroyObstacle();
    }
}
