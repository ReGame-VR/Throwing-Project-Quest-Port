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

    [Header("Bools for levels. [Read Only]")]
    public bool one = false;
    public bool two = false;
    public bool three = false;
    public bool four = false;
    public bool five = false;

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
        Instantiate(obstaclePrefab, obstacleLocation);
    }

    public void MoveObstacle()
    {
        obstaclePrefab.transform.position = Vector3.Lerp(startPos.position, endPos.position, (Mathf.Sin(obstacleSpeed * Time.time) + 1.0f) / 2.0f);
    }

    public void LevelOne()
    {
        //level one which is current target adjustment based off of height.
        //getting calibrated target position for a reference for other levels.
        calibratedTargetPos = target.transform.position;
    }

    public void LevelTwo()
    {
        MoveTarget();
    }

    public void LevelThree()
    {
        ResetTargetPosition();
        ResetTargetSize();

        AdjustTargetSize(.50f);
    }

    public void LevelFour()
    {
        //Reset positions and size for reference
        ResetTargetPosition();
        ResetTargetSize();

        MoveTarget();
        AdjustTargetSize(.50f);
    }

    public void LevelFive()
    {
        ResetTargetPosition();
        ResetTargetSize();

        MoveTarget();
        AdjustTargetSize(.50f);
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
}
