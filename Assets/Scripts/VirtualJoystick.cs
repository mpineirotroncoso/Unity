using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform background; // Fondo del joystick
    public RectTransform handle; // Botón que se mueve
    private Vector2 inputVector = Vector2.zero;

    public Vector2 GetInput() => inputVector;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(background, eventData.position, eventData.pressEventCamera, out pos);
        pos /= background.sizeDelta / 2;

        inputVector = (pos.magnitude > 1.0f) ? pos.normalized : pos;
        handle.anchoredPosition = new Vector2(inputVector.x * (background.sizeDelta.x / 2), inputVector.y * (background.sizeDelta.y / 2));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
