using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : WideSingleton<PopupManager>
{
    public GameObject objectPopup;
    public Transform RootPopup;

    // protected override void Release(){}
    // protected override void Init(){}

    // void Awake()
    // {
    //     gameObject.SetActive(true);
    //     for (int i = 0; i < RootPopup.childCount; i++)
    //     {
    //         Destroy(RootPopup.GetChild(i));
    //     }

    // }


    public int GetPopupCount()
    {
        return RootPopup.childCount;
    }

}
