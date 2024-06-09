using System.Collections.Generic;
using UnityEngine;

public class EnemeyFormation : MonoBehaviour
{
    [SerializeField] float _spacing;

    public List<Vector2> GenerateFormationPositions(Vector2 startPosition, FormationType formationType, int count)
    {
        List<Vector2> positions = new List<Vector2>();

        switch (formationType)
        {
            case FormationType.Triangle:
                positions = GenerateTriangleFormation(transform.position, count);
                break;
            case FormationType.Square:
                positions = GenerateSquareFormation(transform.position, count);
                break;
        }
        return positions;
    }

    private List<Vector2> GenerateTriangleFormation(Vector2 startPosition, int count)
    {
        List<Vector2> positions = new List<Vector2>();
        int rows = Mathf.CeilToInt((Mathf.Sqrt(8 * count + 1) - 1) / 2);

        int currentCount = 0;
        for (int row = 0; row < rows; row++)
        {
            int rowCount = row + 1;
            for (int col = 0; col < rowCount; col++)
            {
                if (currentCount >= count)
                    return positions;

                float xOffset = col * _spacing;
                float yOffset = row * _spacing -(col * _spacing / 2);
                positions.Add(new Vector2(startPosition.x + xOffset, startPosition.y + yOffset));
                currentCount++;
            }
        }
        return positions;
    }

    private List<Vector2> GenerateSquareFormation(Vector2 startPosition, int count)
    {
        List<Vector2> positions = new List<Vector2>();
        int side = Mathf.CeilToInt(Mathf.Sqrt(count));

        int currentCount = 0;
        for (int row = 0; row < side; row++)
        {
            for (int col = 0; col < side; col++)
            {
                if (currentCount >= count)
                    return positions;

                float xOffset = col * _spacing;
                float yOffset = -row * _spacing;
                positions.Add(new Vector2(startPosition.x + xOffset, startPosition.y + yOffset));
                currentCount++;
            }
        }
        return positions;

    }
}
