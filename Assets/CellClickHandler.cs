using UnityEngine;
using UnityEngine.EventSystems;

public class CellClickHandler : MonoBehaviour, IPointerClickHandler
{
    private ConnectFourManager manager;
    private int columnIndex;

    public void Initialize(ConnectFourManager mgr, int col)
    {
        manager = mgr;
        columnIndex = col;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (manager != null)
            {
                manager.SelectColumn(columnIndex);
            }
        }
    }
}