using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;


/// Package Manager Add
/// 2d Sprite
/// 2d SpriteShape
/// PlayerSetting => Eidtor => Sprite Atlas V1 - Always Enabled 

//// Create Atlas
//// Asset => Create => 2D => Sprite Atlas

public class WideAtlas : MonoBehaviour
{

    Image _image;
    SpriteAtlas _atlas;

    void OnClickPopup(Widebrain.Enums.ePopupLayer _popup)
    {
        Debug.Log("############### _popup : " + _popup);
        AddPopup(PopupManager.Instance.RootPopup, _popup);
    }

    void StpriteSetting()
    {
        _image.sprite = Resources.Load<Sprite>("phat");
        _image.sprite = _atlas.GetSprite("imgName");
    }


    /*************************************************************************************************************************************/
    //// ADD Popup
    public void AddPopup(Transform _root, Widebrain.Enums.ePopupLayer layer)
    {
        WidePopup data = Instantiate(Resources.Load<WidePopup>("Prefab/Popup/" + layer.ToString()), _root) as WidePopup;
        data.transform.localScale = Vector3.one;
        data.transform.localPosition = Vector2.zero;
        data.gameObject.SetActive(true);
    }

    //// ADD Popup
    public void AddPopup(Transform _root, Widebrain.Enums.ePopupLayer layer, object _data)
    {
        WidePopup data = Instantiate(Resources.Load<WidePopup>("Prefab/Popup/" + layer.ToString()), _root) as WidePopup;
        data.transform.localScale = Vector3.one;
        data.transform.localPosition = Vector2.zero;
        data.SetData(_data);
        data.gameObject.SetActive(true);
    }

    //// ADD Popup
    public void AddPopup(Transform _root, Widebrain.Enums.ePopupLayer layer, object[] _data)
    {
        WidePopup data = Instantiate(Resources.Load<WidePopup>("Prefab/Popup/" + layer.ToString()), _root) as WidePopup;
        data.transform.localScale = Vector3.one;
        data.transform.localPosition = Vector2.zero;
        data.SetData(_data);
        data.gameObject.SetActive(true);
    }

    //// ADD Popup
    public void AddPopup(Transform _root, Widebrain.Enums.ePopupLayer layer, List<object> _data)
    {
        WidePopup data = Instantiate(Resources.Load<WidePopup>("Prefab/Popup/" + layer.ToString()), _root) as WidePopup;
        data.transform.localScale = Vector3.one;
        data.transform.localPosition = Vector2.zero;
        data.SetData(_data);
        data.gameObject.SetActive(true);
    }
}
