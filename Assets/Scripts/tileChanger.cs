using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tileChanger : MonoBehaviour
{
    public Button[] tileBtn;
    void Start()
    {
        //pick the count of the tile being clicked and call the colortile function
        for (int i=0; i<tileBtn.Length; i++)
        {
            int x = i;
            tileBtn[x].onClick.AddListener(()=>colorTile(x));
        }
    }

    private void colorTile(int index)
    {
        tileBtn[index].image.color = Color.blue;
        StartCoroutine(colorChange(index));//coroutine called to color remaining tiles
    }
    IEnumerator colorChange(int curTile)
    {
        for (int i = 0; i < tileBtn.Length; i++)
        {
            if(i!=curTile)//change the tile color if it is not the one that was clicked
            {
                yield return new WaitForSeconds(1);
                tileBtn[i].image.color = Color.blue;
            }
        }
        SceneManager.LoadScene("scene2");
        yield return null;
    }
    
}
