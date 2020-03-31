using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class uiDrag : MonoBehaviour , IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static GameObject obj;
    public void OnBeginDrag(PointerEventData eventData)
    {
       obj =  Instantiate(this.gameObject, this.transform); //showing a replica of the tile beimg dragged
       obj.name = this.gameObject.name; // renaming it to the name of the original tile for comparison with dropped tile
    }
    public void OnDrag(PointerEventData eventData)
    {
        obj.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
      Destroy(obj);
    }
}
