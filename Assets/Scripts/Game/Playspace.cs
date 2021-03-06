using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playspace : MonoBehaviour
{
    public static int w = 17;
    public static int h = 32;
    public static Transform[,] grid = new Transform[w, h];


    #region Utils
    public static Vector2 RoundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x),
                           Mathf.Round(v.y));
    }

    public static bool InsideBorder(Vector2 pos)
    {
        return (pos.x >= 0 &&
                pos.x < 17 &&
                pos.y >= 1);
    }
    public static void deleteRow(int y)
    {
        for (int x = 0; x < w; ++x)
        {
            grid[x, y].gameObject.GetComponent<SpriteRenderer>().enabled = false;
            grid[x, y].gameObject.GetComponentInChildren<ParticleSystem>().Play();
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }


    public static void decreaseRow(int y)
    {
        for (int x = 0; x < w; ++x)
        {
            if (grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }
    public static void decreaseRowsAbove(int y)
    {
        for (int i = y; i < h; ++i)
            decreaseRow(i);
    }
    public static bool isRowFull(int y)
    {
        for (int x = 0; x < w; ++x)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }
    public static void deleteFullRows()
    {
        int scoreMulti = 0;
        int initialScore = 0;
        for (int y = 0; y < h; ++y)
        {
            if (isRowFull(y))
            {
                deleteRow(y);
                initialScore++;
                scoreMulti += initialScore + 1;
                decreaseRowsAbove(y + 1);
                --y;
            }
        }
        GameController.Instance.PlayerScore = scoreMulti * initialScore;
    }
    #endregion

}
