using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro; // Required for TextMeshPro UI

public class ConnectFourManager : MonoBehaviour
{
    [Header("Grid Settings")]
    public int rows = 6;
    public int columns = 7;

    [Header("Prefabs")]
    public GameObject redDiscPrefab;
    public GameObject yellowDiscPrefab;

    [Header("UI Reference")]
    public Transform boardPanel;
    public TextMeshProUGUI winText; // Reference to the onscreen text

    private int[,] grid;
    private int currentPlayer = 1; // 1 = Red, 2 = Yellow
    private bool isGameOver = false;

    private void Start()
    {
        grid = new int[rows, columns];
        SetupCellClickHandlers();
        UpdateTurnUI();
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            RestartGame();
        }
    }

    private void SetupCellClickHandlers()
{
    if (boardPanel == null) return;

    for (int i = 0; i < boardPanel.childCount; i++)
    {
        Transform cellTransform = boardPanel.GetChild(i);

        // Remove lingering text objects automatically
        foreach (Transform child in cellTransform)
        {
            if (child.GetComponent<TextMeshProUGUI>() != null || child.GetComponent<Text>() != null)
            {
                Destroy(child.gameObject);
            }
        }

        Button btn = cellTransform.GetComponent<Button>();
        if (btn != null)
        {
            Destroy(btn);
        }

        CellClickHandler clickHandler = cellTransform.GetComponent<CellClickHandler>();
        if (clickHandler == null)
        {
            clickHandler = cellTransform.gameObject.AddComponent<CellClickHandler>();
        }

        int colIndex = i % columns;
        clickHandler.Initialize(this, colIndex);
    }
}

    public void SelectColumn(int col)
    {
        if (isGameOver) return;

        for (int r = rows - 1; r >= 0; r--)
        {
            if (grid[r, col] == 0)
            {
                grid[r, col] = currentPlayer;
                SpawnDisc(r, col, currentPlayer);

                if (CheckWin(r, col))
                {
                    string winner = (currentPlayer == 1) ? "Red" : "Yellow";
                    
                    if (winText != null)
                    {
                        winText.text = winner.ToUpper() + " WINS!\nPress 'R' to Restart";
                        winText.color = (currentPlayer == 1) ? Color.red : Color.yellow;
                    }

                    isGameOver = true;
                    return;
                }

                // Switch turn and update status text
                currentPlayer = (currentPlayer == 1) ? 2 : 1;
                UpdateTurnUI();
                return;
            }
        }
    }

    private void UpdateTurnUI()
    {
        if (winText != null && !isGameOver)
        {
            string turnName = (currentPlayer == 1) ? "Red" : "Yellow";
            winText.text = turnName + "'s Turn";
            winText.color = (currentPlayer == 1) ? Color.red : Color.yellow;
        }
    }

    private void SpawnDisc(int row, int col, int player)
    {
        int visualRow = (rows - 1) - row;
        int cellIndex = visualRow * columns + col;

        if (boardPanel == null || cellIndex >= boardPanel.childCount) return;

        Transform cellTransform = boardPanel.GetChild(cellIndex);
        GameObject prefabToSpawn = (player == 1) ? redDiscPrefab : yellowDiscPrefab;

        if (prefabToSpawn != null && cellTransform != null)
        {
            GameObject disc = Instantiate(prefabToSpawn, cellTransform, false);

            Image discImage = disc.GetComponent<Image>();
            if (discImage != null)
            {
                discImage.raycastTarget = false;
            }

            RectTransform rect = disc.GetComponent<RectTransform>();
            if (rect != null)
            {
                rect.anchorMin = Vector2.zero;
                rect.anchorMax = Vector2.one;
                rect.offsetMin = Vector2.zero;
                rect.offsetMax = Vector2.zero;
                rect.localScale = Vector3.one;
            }
        }
    }

    private bool CheckWin(int r, int c)
    {
        int player = grid[r, c];

        if (CountDirection(r, c, 0, 1, player) + CountDirection(r, c, 0, -1, player) >= 3) return true;
        if (CountDirection(r, c, 1, 0, player) + CountDirection(r, c, -1, 0, player) >= 3) return true;
        if (CountDirection(r, c, 1, 1, player) + CountDirection(r, c, -1, -1, player) >= 3) return true;
        if (CountDirection(r, c, -1, 1, player) + CountDirection(r, c, 1, -1, player) >= 3) return true;

        return false;
    }

    private int CountDirection(int row, int col, int rowDir, int colDir, int player)
    {
        int count = 0;
        int r = row + rowDir;
        int c = col + colDir;

        while (r >= 0 && r < rows && c >= 0 && c < columns && grid[r, c] == player)
        {
            count++;
            r += rowDir;
            c += colDir;
        }

        return count;
    }

    public void RestartGame()
    {
        grid = new int[rows, columns];
        currentPlayer = 1;
        isGameOver = false;

        for (int i = 0; i < boardPanel.childCount; i++)
        {
            Transform cell = boardPanel.GetChild(i);
            foreach (Transform child in cell)
            {
                Destroy(child.gameObject);
            }
        }

        UpdateTurnUI();
    }
}