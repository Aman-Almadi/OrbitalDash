using UnityEngine;
using UnityEngine.EventSystems;

public class UnscaledButtonHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // Manually call the button's click event, ignoring time scale

        GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
    }
}
