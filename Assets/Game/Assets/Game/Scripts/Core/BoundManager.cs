using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundManager : MonoBehaviour
{
    public static BoundManager instance;

    public Transform leftBound;
    public Transform rightBound;
    public Transform topBound;
    public Transform bottomBound;

    public int boundDiff = 1;
    public int boundSize;

    public Vector2 size;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        size.x = Random.Range(1, 4f);
        size.y = Random.Range(1, 4f);

        size *= boundSize + boundDiff * Game.difficulty;

        UpdateBounds(size);
    }

    public void UpdateBounds(Vector2 newSize)
    {
        leftBound.localScale = new Vector3(1, newSize.y, 1);
        rightBound.localScale = new Vector3(1, newSize.y, 1);
        topBound.localScale = new Vector3(newSize.x, 1, 1);
        bottomBound.localScale = new Vector3(newSize.x, 1, 1);

        leftBound.localPosition = new Vector3(-newSize.x / 2, 0, 0);
        rightBound.localPosition = new Vector3(newSize.x / 2, 0, 0);
        topBound.localPosition = new Vector3(0, newSize.y / 2, 0);
        bottomBound.localPosition = new Vector3(0, -newSize.y / 2, 0);
    }

}
