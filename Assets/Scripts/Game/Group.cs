using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Group : MonoBehaviour
{
    public List<Color> PotentialColours;
    private float lastFall;
    PlayerInput inputSystem;
    GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameController.Instance;
        if (!IsValidGridPos())
        {
            controller.GameOverMessage();
            Destroy(gameObject);
        }

        inputSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerInput>();
        AssignControls();
        AttachToButtons();
        SetColour();
    }

    private void SetColour()
    {
        Color randomColour = PotentialColours[Random.Range(0, PotentialColours.Count)];
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (var graphic in sprites)
        {
            graphic.color = randomColour;
        }
    }

    private void AssignControls()
    {
        //This doesn't work on mobile
        inputSystem.actions.FindAction("MoveLeft").performed += MoveLeft;
        inputSystem.actions.FindAction("MoveRight").performed += MoveRight;
        inputSystem.actions.FindAction("Rotate").performed += Rotate;
        inputSystem.actions.FindAction("MoveDown").performed += MoveDown;
    }

    void AttachToButtons() 
    {
        controller.LeftButton.onClick.AddListener(MoveLeft);
        controller.RightButton.onClick.AddListener(MoveRight);
        controller.DownButton.onClick.AddListener(MoveDown);
        controller.RotateButton.onClick.AddListener(Rotate);
    }
    void RemoveFromButtons()
    {
        controller.LeftButton.onClick.RemoveAllListeners();
        controller.RightButton.onClick.RemoveAllListeners();
        controller.DownButton.onClick.RemoveAllListeners();
        controller.RotateButton.onClick.RemoveAllListeners();
    }

    void RemoveControls() 
    {
        inputSystem.actions.FindAction("MoveLeft").performed -= MoveLeft;
        inputSystem.actions.FindAction("MoveRight").performed -= MoveRight;
        inputSystem.actions.FindAction("Rotate").performed -= Rotate;
        inputSystem.actions.FindAction("MoveDown").performed -= MoveDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastFall >= 1)
        {
            transform.position += new Vector3(0, -1, 0);
            if (IsValidGridPos())
            {
                UpdateGrid();
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                Playspace.deleteFullRows();
                RemoveControls();
                RemoveFromButtons();
                GameController.Instance.Spawner.SpawnObject();
                enabled = false;
            }
            lastFall = Time.time;
        }
    }
    bool IsValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Playspace.RoundVec2(child.position);

            // Not inside Border?
            if (!Playspace.InsideBorder(v))
                return false;
            // Block in grid cell (and not part of same group)?
            if (Playspace.grid[(int)v.x, (int)v.y] != null &&
                Playspace.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }

    void UpdateGrid()
    {
        // Remove old children from grid
        for (int y = 0; y < Playspace.h; ++y)
            for (int x = 0; x < Playspace.w; ++x)
                if (Playspace.grid[x, y] != null)
                    if (Playspace.grid[x, y].parent == transform)
                        Playspace.grid[x, y] = null;

        // Add new children to grid
        foreach (Transform child in transform)
        {
            Vector2 v = Playspace.RoundVec2(child.position);
            Playspace.grid[(int)v.x, (int)v.y] = child;
        }
    }

    #region Input system based controls
    public void MoveLeft(InputAction.CallbackContext context) 
    {
        if (!context.performed)
        {
            return;
        }
        transform.position += new Vector3(-1, 0, 0);

        if (IsValidGridPos())
        {
            UpdateGrid();
        }
        else
        {
            transform.position += new Vector3(1, 0, 0);
        }
    }
    public void MoveRight(InputAction.CallbackContext context) 
    {
        if (!context.performed)
        {
            return;
        }
        transform.position += new Vector3(1, 0, 0);

        if (IsValidGridPos())
        {
            UpdateGrid();
        }
        else
        {
            transform.position += new Vector3(-1, 0, 0);
        }
    }
    public void Rotate(InputAction.CallbackContext context) 
    {
        if (!context.performed)
        {
            return;
        }
        transform.Rotate(0, 0, -90);
        if (IsValidGridPos())
        {
            UpdateGrid();
        }
        else
            transform.Rotate(0, 0, 90);
    }
    public void MoveDown(InputAction.CallbackContext context) 
    {
        if (!context.performed)
        {
            return;
        }
        transform.position += new Vector3(0, -1, 0);
        if (IsValidGridPos())
        {
            // It's valid. Update grid.
            UpdateGrid();
        }
        else
        {
            transform.position += new Vector3(0, 1, 0);
            Playspace.deleteFullRows();
            RemoveControls();
            RemoveFromButtons();
            GameController.Instance.Spawner.SpawnObject();
            enabled = false;
        }

        lastFall = Time.time;
    }
    #endregion
    #region Button based controls
    public void MoveLeft()
    {
        transform.position += new Vector3(-1, 0, 0);

        if (IsValidGridPos())
        {
            UpdateGrid();
        }
        else
        {
            transform.position += new Vector3(1, 0, 0);
        }
    }
    public void MoveRight()
    {
        transform.position += new Vector3(1, 0, 0);

        if (IsValidGridPos())
        {
            UpdateGrid();
        }
        else
        {
            transform.position += new Vector3(-1, 0, 0);
        }
    }
    public void Rotate()
    {
        transform.Rotate(0, 0, -90);
        if (IsValidGridPos())
        {
            UpdateGrid();
        }
        else
            transform.Rotate(0, 0, 90);
    }
    public void MoveDown()
    {
        transform.position += new Vector3(0, -1, 0);
        if (IsValidGridPos())
        {
            // It's valid. Update grid.
            UpdateGrid();
        }
        else
        {
            transform.position += new Vector3(0, 1, 0);
            Playspace.deleteFullRows();
            RemoveControls();
            RemoveFromButtons();
            GameController.Instance.Spawner.SpawnObject();
            enabled = false;
        }

        lastFall = Time.time;
    }
    #endregion

}
