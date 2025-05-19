using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragMap : MonoBehaviour, IDragHandler, IScrollHandler
{
    public Canvas canvas;
    private RectTransform rect_transform;
    private Vector3 initial_scale;

    // Start is called before the first frame update
    void Start()
    {
        rect_transform = GetComponent<RectTransform>();
    }

    void Awake(){
        initial_scale = transform.localScale;
    }

    // Update is called once per frame
    void IDragHandler.OnDrag(PointerEventData event_data)
    {
        rect_transform.anchoredPosition += event_data.delta * 2;
    }

    void IScrollHandler.OnScroll(PointerEventData event_data)
    {
        var delta = Vector3.one * event_data.scrollDelta.y * 0.1F;
        transform.localScale += delta;
    }
}
