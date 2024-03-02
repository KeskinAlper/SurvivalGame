using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class uiitem : MonoBehaviour, IDragHandler
{
    public int index;
    public InventoryUI ui;
    public Canvas canvas;
    public float minx;
    public float maxx;
    public float miny;
    public float maxy;
    public GameObject invuiobj;
    RectTransform recttrans;
    private void Start()
    {
        recttrans = gameObject.GetComponent<RectTransform>();
        RectTransform rectrans = invuiobj.GetComponent<RectTransform>();
        minx = recttrans.rect.width/2  - rectrans.rect.width/2;
        maxx =  rectrans.rect.width/2 - recttrans.rect.width/2;
        miny = recttrans.rect.height/2 - rectrans.rect.height/2;
        maxy = rectrans.rect.height/2 - recttrans.rect.height/2;
    }
    void Update()
    {
        var pos = transform.localPosition;
        pos.x = Mathf.Clamp(transform.localPosition.x, minx, maxx);
        pos.y = Mathf.Clamp(transform.localPosition.y, miny, maxy);
        transform.localPosition = pos;

    }

    public void OnDrag(PointerEventData data)
    {
        recttrans.anchoredPosition += data.delta / canvas.scaleFactor;
    }
}
