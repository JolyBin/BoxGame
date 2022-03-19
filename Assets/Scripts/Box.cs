using System.Collections;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] BoxSettings _boxSettings;
    [SerializeField] Renderer _renderer;
    [SerializeField] float _minDistance = 1f;
    [SerializeField] float _maxDistance = 20f;
    [SerializeField] GameObject _dieEffect;

    public Rigidbody Rigidbody;

    Vector3 _startPosition;
    float _distance;

    private void Update()
    {
        if(_distance <= Vector3.Distance(_startPosition, transform.position))
        {
            GameObject effect = Instantiate(_dieEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            gameObject.SetActive(false);
        }
    }

    public void SetProperty(float distance)
    {
        _startPosition = transform.position;
        _distance = Mathf.Clamp(distance, _minDistance, _maxDistance);
        int idMatirial = Random.Range(0, _boxSettings.BoxMaterials.Length);
        _renderer.material = _boxSettings.BoxMaterials[idMatirial];
    }
}
