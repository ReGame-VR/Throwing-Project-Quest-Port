using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDifficulty : MonoBehaviour
{
    public GameObject target;
    public GameObject objectToThrow;
    public float AdjustableTargetPercent = 1f;
    public float AdjustableObjectPercent = 1f;
    public enum Level {one, two , three, four, five};
    
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

    //Temporary code for setting levels. Confirmation of level diffculty by friday. 
    public void LevelSelection(Level level)
    {
        switch (level)
        {
            case Level.one:
                /*
                 * Current game mode where target is adjusted based off the players height.
                 */
                break;
            case Level.two:
                /*
                 * Target is further by 1X
                 */
                break;
            case Level.three:
                /*
                 * Target is smaller by 1X
                 */
                break;
            case Level.four:
                /*
                 * Object to throw smaller by 1X
                 */
                break;
            case Level.five:
                /*
                 * Target is further away by 1X
                 */
                break;
            default:
                break;

            /*
             * Current levels document shows 5 more levels. Will add after friday call with Danielle.  
             */
        }
    }
}
