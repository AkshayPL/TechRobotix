using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class uiDrop : MonoBehaviour, IDropHandler
{
    public static int count = 0; //to keep a count of successful drag and drop
    public GameObject explosion; //burst effect prefab
   
    public void OnDrop (PointerEventData eventData)
    {
        if (uiDrag.obj.name == this.gameObject.name) //checking for correct matches
        {
            count += 1; //increment count after successful matches
            StartCoroutine(burst()); // calling the burst effect animation
            Destroy(this.gameObject);
            Destroy(uiDrag.obj);
        }
    }
    IEnumerator burst()
    {
        //instantiating the burst effect based on the tile position where match happened
        var explode = Instantiate(explosion, this.transform.position, this.transform.localRotation);
        explode.transform.SetParent(this.transform.parent);
        //destroy the prefab after 2 seconds
        Destroy(explode, 2f);
        if (count == 4) // when all the tiles are matched call new 
        {
            Debug.Log("destroyed");
            StartCoroutine(loadBundle());
        }
        yield return null;
    }
    IEnumerator loadBundle()
    {
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "finish"));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
           yield return null;
        }
        Sprite newSprite = myLoadedAssetBundle.LoadAsset<Sprite>("ab");
        GameObject newGO = new GameObject();
        newGO.transform.SetParent(GameObject.Find("Canvas").transform);
        newGO.GetComponent<Transform>().localPosition = Vector3.zero;
       Image newImg = newGO.AddComponent<Image>();
        newImg.rectTransform.sizeDelta = new Vector2(1311, 1059);
        newImg.sprite = newSprite;
        myLoadedAssetBundle.Unload(false);
        yield return null;
    }
}
