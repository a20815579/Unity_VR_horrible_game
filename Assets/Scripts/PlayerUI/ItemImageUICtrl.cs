using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemImageUICtrl : MonoBehaviour
{
    public Item[] items;
    [SerializeField]
    int[] action_idx;
    [SerializeField]
    int current_idx;

    public Image itemImage;
    public Text itemName;

    public static ItemImageUICtrl self;
    private void Awake()
    {
        self = this;
    }
   
    public void ShowItemImage()
    {
        Debug.Log("showImage");
        itemName.enabled = true;
        itemImage.enabled = true;
        itemName.text = items[current_idx].itemName;
        itemImage.sprite = items[current_idx].itemImg;
    }

    public void HideItemImage()
    {
        itemName.enabled = false;
        itemImage.enabled = false;
    }
}
