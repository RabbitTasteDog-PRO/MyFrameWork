using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopupResult : WidePopup
{

    public ResultUI prefabResult;
    public Button btnOk;


    protected override void OnAwake()
    {
        base.OnAwake();
        btnOk.onClick.AddListener(OnClickMoveScene);
    }

    protected override void OnStart()
    {
        base.OnStart();

        // / 결과 시 방 제거

    }

    protected override void OnDestroied()
    {
        base.OnDestroied();
        // Message.Send<Widebrain.Common.ActionMoveSelect>(new Widebrain.Common.ActionMoveSelect { select = true });

        UnityEngine.SceneManagement.SceneManager.LoadScene(Widebrain.Enums.eScene.SceneSelect.ToString());

    }

    public void OnClickMoveScene()
    {
        Debug.Log("############### OnClickMoveScene");
        Destroy(this.gameObject);
    }
}
