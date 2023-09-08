using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovementController : MonoBehaviour
{
    private Snake _snake;
    private float _waitTime;
    [SerializeField] private GameObject _snakePartSprite;
    private List<GameObject> _snakeParts;
    private Direction _directionTemp = Direction.Right;

    void Start()
    {
        _waitTime = FindObjectOfType<Configuration>().WaitTime;
        _snake = FindObjectOfType<SnakeHolder>().Snake;
        _snakeParts = new List<GameObject>();
        StartCoroutine(nameof(WaitForTick));
    }

    IEnumerator WaitForTick()
    {
        yield return new WaitForSeconds(_waitTime);
        _snake.ChangeDirection(_directionTemp);
        _snake.MoveSnake();
        DrawSnake();
        StartCoroutine(nameof(WaitForTick));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _directionTemp = Direction.Up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _directionTemp = Direction.Down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _directionTemp = Direction.Left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _directionTemp = Direction.Right;
        }
    }

    private void DrawSnake()
    {
        while (_snakeParts.Count != 0)
        {
            Destroy(_snakeParts[0]);
            _snakeParts.RemoveAt(0);
        }

        foreach (var item in _snake)
        {
            var go = Instantiate(_snakePartSprite);
            go.transform.position = new Vector3(item.X, item.Y, 0f);
            _snakeParts.Add(go);
        }
    }
}
