using UnityEngine;

public class EnemeySpowner : MonoBehaviour
{
    [SerializeField] private GameObject _squadToSpown;
    [SerializeField] private Transform _player;
    [SerializeField] private Vector2 _zoneMin;
    [SerializeField] private Vector2 _zoneMax;
    [SerializeField] private Vector2 _excludedZoneMin;
    [SerializeField] private Vector2 _excludedZoneMax;
    [SerializeField] private float _spowmZoneSize;

    private void Start()
    {
        _player = FindObjectOfType<Character>().transform;
        SetSpownArea();
    }

    public void SetSpownArea()
    {
        _excludedZoneMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        _excludedZoneMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        _zoneMax = _excludedZoneMax * _spowmZoneSize;
        _zoneMin = _excludedZoneMin * _spowmZoneSize;
    }
    public void FindPlaceToSpawn(GameObject objectToSpown)
    {
        _squadToSpown = objectToSpown;
        Vector2 spawnPosition = GetValidPosition(5);

        if (spawnPosition != Vector2.zero)
        {
            _squadToSpown.transform.position = spawnPosition;
            RotateTowardsPlayer(_squadToSpown);
        }
        else
        {
            Debug.LogWarning("Failed to find a valid position for the object.");
        }
    }

    private Vector2 GetValidPosition(float radius)
    {
        int attempts = 100;
        for (int i = 0; i < attempts; i++)
        {
            Vector2 position = GetRandomPosition();
            if (IsAreaClear(position, radius))
            {
                return position;
            }
        }
        return Vector2.zero;
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 position;
        do
        {
            position = new Vector2(
                Random.Range(_zoneMin.x, _zoneMax.x),
                Random.Range(_zoneMin.y, _zoneMax.y)
            );
        } while (position.x > _excludedZoneMin.x && position.x < _excludedZoneMax.x &&
                 position.y > _excludedZoneMin.y && position.y < _excludedZoneMax.y);
        return position;
    }

    private bool IsAreaClear(Vector2 position, float radius)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius);

        return colliders.Length == 0;
    }

    private void RotateTowardsPlayer(GameObject squad)
    {
        Vector2 direction = _player.position - squad.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        squad.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
