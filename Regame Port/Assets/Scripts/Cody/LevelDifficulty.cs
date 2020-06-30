using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDifficulty : MonoBehaviour
{
    public GameObject target;
    public GameObject objectToThrow;
    public float AdjustableTargetPercent = 1f;
    public float AdjustableObjectPercent = 1f;
    
    public void MoveTarget(Vector3 newPos)
    {
        target.transform.position = newPos;
    }

    public void AdjustTargetSize(float reductionPercent)
    {
        target.transform.localScale = Vector3.one * reductionPercent;
    }

    public void AdjustObjectSize(float reductionPercent)
    {
        objectToThrow.transform.localScale = Vector3.one * reductionPercent;
    }
}
