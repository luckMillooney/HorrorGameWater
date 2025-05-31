using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MenuButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TMP_Text currentText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        currentText.color = new Color(0.67f, 0.67f, 0.67f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        currentText.color = new Color(1f, 1f, 1f);
    }
}
