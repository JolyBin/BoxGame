using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public float Velocity = 10f;
    float _previousVelocity = 10f;

    public float SpawnPeriod = 1f;
    float _previousSpawnPeriod = 1f;

    public float DestroyDistance = 10f;
    float _previousDestroyDistance = 1f;


    public void SetVelocity(string value)
    {
        float resultParse;
        if(float.TryParse(value, out resultParse))
        {
            _previousVelocity = Velocity;
            Velocity = resultParse;
        }
        else
        {
            Velocity = _previousVelocity;
        }
    }

    public void SetSpawnPeriod(string value)
    {
        float resultParse;
        if (float.TryParse(value, out resultParse))
        {
            _previousSpawnPeriod = SpawnPeriod;
            SpawnPeriod = resultParse;
        }
        else
        {
            SpawnPeriod = _previousSpawnPeriod;
        }
    }

    public void SetDestroyDistance(string value)
    {
        float resultParse;
        if (float.TryParse(value, out resultParse))
        {
            _previousDestroyDistance = DestroyDistance;
            DestroyDistance = resultParse;
        }
        else
        {
            DestroyDistance = _previousDestroyDistance;
        }
    }
}
