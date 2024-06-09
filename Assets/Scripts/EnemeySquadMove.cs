using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemeySquadMove : MonoBehaviour
{
    [SerializeField] private int _sideMoves; // ���������� ������� �������� �� �������� ������
    [SerializeField] private float _moveTime; // ����� ������ ��������
    [SerializeField] private float _stoppingTime; // ����� ���������
    [SerializeField] private float _moveSpeed; // �������� ��������

    [SerializeField] private Transform _playerTransform; // ������ �� ��������� ������
    [SerializeField] private float _playerDetectionDistance = 20f; // ����������, �� ������� ����� �������� ������� ��������
    [SerializeField] private float _rotationSpeed = 2f; // �������� ��������

    private int _currentSideMove;
    private bool _isMovingForward;

    private void Start()
    {
        _currentSideMove = 0;
        _isMovingForward = false;
        _playerTransform = FindObjectOfType<Character>().transform;
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            // ���� ����� ������, ��������� � ����
            if (Vector2.Distance(transform.position, _playerTransform.position) > _playerDetectionDistance)
            {
                yield return FaceTowardsPlayer(); // ������� ������� � ������
                Vector2 directionToPlayer = (_playerTransform.position - transform.position).normalized;

                while (Vector2.Distance(transform.position, _playerTransform.position) > _playerDetectionDistance)
                {
                    transform.Translate(directionToPlayer * _moveSpeed * Time.deltaTime, Space.World);
                    yield return null; // ��������� �� ���������� �����
                }
            }

            // ����� ���������� ������ ��������� ������� �������� � ��������� ������
            while (Vector2.Distance(transform.position, _playerTransform.position) <= _playerDetectionDistance)
            {
                if (_isMovingForward)
                {
                    yield return FaceTowardsPlayer(); // ������� ������� � ������
                    yield return Move(transform.right); // �������� ������
                    _isMovingForward = false;
                    _currentSideMove = 0;
                }
                else
                {
                    if (_currentSideMove < _sideMoves)
                    {
                        Vector2 sideDirection = Random.value < 0.5f ? transform.up : -transform.up; // ��������� ������� ��������
                        yield return Move(sideDirection); // ������� ��������
                        _currentSideMove++;
                    }
                    else
                    {
                        _isMovingForward = true;
                    }
                }
            }
        }
    }

    private IEnumerator Move(Vector2 direction)
    {
        float elapsedTime = 0;

        while (elapsedTime < _moveTime)
        {
            transform.Translate(direction * _moveSpeed * Time.deltaTime, Space.World); // ��������
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(_stoppingTime);
    }

    private IEnumerator FaceTowardsPlayer()
    {
        Vector2 directionToPlayer = _playerTransform.position - transform.position;
        float targetAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        while (true)
        {
            float angle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, _rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            if (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, targetAngle)) < 0.1f)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));
                yield break; // ��������� ��������, ����� �������� ������� ����
            }

            yield return null;
        }
    }
}

