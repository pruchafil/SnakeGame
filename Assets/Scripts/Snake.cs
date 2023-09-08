using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : IEnumerable<SnakePart>
{
    private List<SnakePart> _snakeParts;
	private Direction _direction;
	private Dictionary<Direction, Vector2> _directions = new Dictionary<Direction, Vector2>()
	{
		{ Direction.Up, Vector2.up },
		{ Direction.Down, Vector2.down },
		{ Direction.Right, Vector2.right },
		{ Direction.Left, Vector2.left },
	};

	public SnakePart this[int index]
	{
		get { return _snakeParts[index]; }
	}

	public Snake()
	{
        _snakeParts = new List<SnakePart>()
		{
			new SnakePart() { X = 1, Y = 0 },
			new SnakePart() { X = 0, Y = 0 }
		};
		_direction = Direction.Right;
    }

	public int Count => _snakeParts.Count;

	public void CreateNewSnakePart()
	{
		_snakeParts.Add(new SnakePart
		{
			X = -999,
			Y = -999
		});
	}

	public void MoveSnake()
	{
		for (int i = _snakeParts.Count - 1; i >= 1; i--)
		{
			_snakeParts[i].X = _snakeParts[i - 1].X;
			_snakeParts[i].Y = _snakeParts[i - 1].Y;
        }

        var vec = _directions[_direction];
		_snakeParts[0].X += (int)vec.x;
		_snakeParts[0].Y += (int)vec.y;
	}

	public void ChangeDirection(Direction direction)
	{
		if (Mathf.Max((int)direction , (int)_direction) % Mathf.Min((int)direction, (int)_direction) == 0) // do not move in the opposite way
		{
			return;
		}

		_direction = direction;
	}

    public IEnumerator<SnakePart> GetEnumerator()
    {
		foreach (var item in _snakeParts)
		{
			yield return item;
		}
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
		return this.GetEnumerator();
    }
}