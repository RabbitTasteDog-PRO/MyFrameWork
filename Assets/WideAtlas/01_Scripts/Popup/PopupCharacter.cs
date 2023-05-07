using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupCharacter : WidePopup
{

    public static System.Action<bool> ACTION_INTRO;

    public Button btnRanking;
    public Button btnPlay;

    public Button btnBack;


    int chracterIndex = 0;
    bool isPlay = false;
    bool isBack = false;


    protected override void OnAwake()
    {
        base.OnAwake();

        btnBack.gameObject.SetActive(false);

        btnBack.onClick.AddListener(OnClickBack);


        btnPlay.onClick.AddListener(OnClickPlay);
        btnRanking.onClick.AddListener(OnClickRanking);
    }

    protected override void OnDestroied()
    {
        base.OnDestroied();

        if (isPlay == true)
        {
            // UnityEngine.SceneManagement.SceneManager.LoadScene(Widebrain.Enums.eScene.SceneGame_Multiplay_Jiheum.ToString());
            // UnityEngine.SceneManagement.SceneManager.LoadScene(Widebrain.Enums.eScene.SceneGame_Multiplay.ToString());
            // UnityEngine.SceneManagement.SceneManager.LoadScene(Widebrain.Enums.eScene.SceneGame_Multiplay_Work.ToString());
            
        }

        // Message.RemoveListener<Widebrain.Common.DataUserCharacter>(SetChracterIndex);
    }

    protected override void OnStart()
    {
        base.OnStart();
    }

    void OnClickBack()
    {
        Destroy(this.gameObject);
    }


    // void SetChracterIndex(Widebrain.Common.DataUserCharacter _data)
    // {
    //     if (_data != null)
    //     {
    //         ServerView.Instance.CHARACTER_INDEX = _data.chracter;
    //         Widebrain.DebugHelper.WideDebugHelper.Instance.DebugError("################ chracter index : " + _data.chracter);
    //     }
    // }


    void OnClickPlay()
    {
        isPlay = true;
        Destroy(this.gameObject);
    }



    void OnClickRanking()
    {
        SceneBase.Instance.AddPopup(SceneBase.Instance.popupRoot, Widebrain.Enums.ePopupLayer.PopupRanking);
        // SceneBase.Instance.AddPopup(SceneBase.Instance.popupRoot, Widebrain.Enums.ePopupLayer.PopupResult);
    }
}
