using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPool : MonoBehaviour
{
    [SerializeField] int _poolCount = 10;
    [SerializeField] bool _isAutoExpand = true;
    [SerializeField] Box _boxPrefab;

    public Pool<Box> Pool;

    private void Start()
    {
        Pool = new Pool<Box>(_boxPrefab, transform, _poolCount, _isAutoExpand);
    }
}
