using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Control Properties")]
    [SerializeField] float _sencentivety = 25f;
    [SerializeField] float _maxPosition = 4f;
    [Header("Spawn Properties")]
    [SerializeField] float _minSpawnPeriod = 0.1f;
    [SerializeField] float _maxSpawnPeriod = 5f;
    [SerializeField] float _minVelocity = 3f;
    [SerializeField] float _maxVelocity = 20f;
    [SerializeField] UIController _uiController;
    [SerializeField] float _maxAngularVelocity = 100f;
    [SerializeField] GameObject _boxPrefab;
    [SerializeField] BoxPool _boxPool;


    float _yPosition;
    float _oldMouseY;

    [ContextMenu("StartSpawn")]
    public void StartSpawn()
    {
        StopAllCoroutines();
        StartCoroutine(CreateBox());
        
        
    }

    [ContextMenu("StopSpawn")]
    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _oldMouseY = Input.mousePosition.y;
        }

        if(Input.GetMouseButton(0))
        {
            float delta = Input.mousePosition.y - _oldMouseY;
            _oldMouseY = Input.mousePosition.y;
            _yPosition += delta * _sencentivety / Screen.height;
            _yPosition = Mathf.Clamp(_yPosition, -_maxPosition, _maxPosition);
            transform.position = new Vector3(transform.position.x, _yPosition, transform.position.z);
        }
    }

    IEnumerator CreateBox()
    {
        while (true)
        {
            Box newBox = _boxPool.Pool.GetFreeElement();
            newBox.transform.position = transform.position;
            newBox.SetProperty(_uiController.DestroyDistance);
            float clampVelocity = Mathf.Clamp(_uiController.Velocity, _minVelocity, _maxVelocity);
            newBox.Rigidbody.velocity = transform.forward * clampVelocity;
            newBox.Rigidbody.angularVelocity = new Vector3(
                Random.Range(-_maxAngularVelocity, _maxAngularVelocity),
                Random.Range(-_maxAngularVelocity, _maxAngularVelocity),
                Random.Range(-_maxAngularVelocity, _maxAngularVelocity));
            float clampSpawnPeriod = Mathf.Clamp(_uiController.SpawnPeriod, _minSpawnPeriod, _maxSpawnPeriod); ;
            yield return new WaitForSeconds(clampSpawnPeriod);
        }
    }
}
