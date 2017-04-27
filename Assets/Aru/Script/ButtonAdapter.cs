using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAdapter : MonoBehaviour
{

    public Button[] Buttons;
 

    private GameObject firstSelected = null;

    private void Awake()
    {
        foreach (var b in this.Buttons)
        {
            var trigger = b.gameObject.AddComponent<EventTrigger>();

            // IPointerDownHandler
            EventTrigger.Entry entryDown = new EventTrigger.Entry();
            entryDown.eventID = EventTriggerType.PointerDown;
            entryDown.callback.AddListener((eventData) => { OnTouchDown(eventData as PointerEventData); });
            trigger.triggers.Add(entryDown);
        }
    }

    public void OnTouchDown(PointerEventData eventData)
    {
        if (this.firstSelected == null)
        {
            this.firstSelected = eventData.selectedObject;
            // 他を無効化
            foreach (var other in this.Buttons)
            {
                if (other.gameObject.Equals(eventData.selectedObject))
                {
                    continue;
                }
                other.interactable = false;
            }
        }
    }

    //public void Reset()
    //{
    //    foreach (var other in this.Buttons)
    //    {
    //        other.interactable = true;
    //    }
    //    this.firstSelected = null;
    //}
}