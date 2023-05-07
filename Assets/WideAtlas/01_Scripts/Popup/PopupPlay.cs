using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;

public class PopupPlay : WidePopup
{
    const int MAX_PLAYER = 4;


    public Transform layoutPlayer;
    public PlayerScoreUI profabPlayer;

    public Text textTimer;
    public ProceduralImage imgTimer;


    Color32 white = new Color32(77, 77, 90, 255);
    Color32 red = new Color32(246, 45, 88, 255);
    // Color32 red = new Color(255, 0, 0, 255);

    List<PlayerScoreUI> listScore;

    bool isGameEnd = false;

    public override void SetData(object data)
    {
        if (data != null)
        {
            base.SetData(data);

            textTimer.text = 60.ToString();

            for (int i = 0; i < layoutPlayer.transform.childCount; i++)
            {
                Destroy(layoutPlayer.transform.GetChild(i));
            }

        }
    }

    protected override void OnAwake()
    {
        base.OnAwake();

    }

    protected override void OnDestroied()
    {
        base.OnDestroied();

    }

    protected override void OnStart()
    {
        base.OnStart();

        // ServerTransformController.Instance.idToGo[x]
        CreatePlayerScoreUI();

    }

    void FixedUpdate()
    {

    }

    void CreatePlayerScoreUI()
    {
        if (listScore == null)
        {
            listScore = new List<PlayerScoreUI>();
        }

        // if (NetworkManager.Instance.players.Count < MAX_PLAYER)
        // {
            for (int i = 0; i < MAX_PLAYER; i++)
            {
                PlayerScoreUI _player = Instantiate(profabPlayer, layoutPlayer) as PlayerScoreUI;
                _player.transform.localPosition = Vector2.zero;
                _player.transform.localScale = Vector3.one;
                string _strData = i.ToString();//NetworkManager.Instance.players.Count > i ? NetworkManager.Instance.players[i].GetPlayerView().sessionId : $"BOT_{i}";
                _player.name = _strData;
                _player.SetPlayerUI(_strData);
                listScore.Add(_player);
            }
        // }
        // else
        // {
        //     for (int i = 0; i < NetworkManager.Instance.players.Count; i++)
        //     {
        //         PlayerScoreUI _player = Instantiate(profabPlayer, layoutPlayer) as PlayerScoreUI;
        //         _player.transform.localPosition = Vector2.zero;
        //         _player.transform.localScale = Vector3.one;
        //         string seesionID = NetworkManager.Instance.players[i].GetPlayerView().sessionId;
        //         _player.name = seesionID;
        //         _player.SetPlayerUI(seesionID);
        //         listScore.Add(_player);
        //     }
        // }
    }

    IEnumerator IETimer()
    {
        float _COUNT = 60.0f;

        float count = _COUNT;
        float time = 0.0f;
        yield return Widebrain.Yield.WideYieldHelper.WaitForSeconds(1000);

        float fElapsedTime = 0f; /// 경과 시간 
        float fDuration = _COUNT; /// 동작 시간 
        float fUnitTime = 1.0f / fDuration; /// 1초 대비 경과시간 계산 
        while (true)
        {
            fElapsedTime += (Time.deltaTime * fUnitTime);
            Color32 c = Color32.Lerp(white, red, fElapsedTime);
            if (time > count)
            {
                imgTimer.color = red;
                yield return Widebrain.Yield.WideYieldHelper.WaitForSeconds(2000);

                isGameEnd = true;
                Destroy(this.gameObject);

                break;
            }
            imgTimer.color = c;
            yield return Widebrain.Yield.WideYieldHelper.WaitForEndOfFrame();
            time += Time.deltaTime;
            textTimer.text = (Mathf.RoundToInt((count - time))).ToString();

            // Widebrain.DebugHelper.WideDebugHelper.Instance.DebugError("############### fElapsedTime : " + Mathf.RoundToInt((count - time)));
        }
    }



    bool isCheck = false;
    ///<summary>
    /// 플레이어 스코어 계산
    ///</summary>
    // public void SetPlayerScore(Widebrain.Common.SyncPlayerHammerTrigger _data)
    // {
    //     if (_data != null)
    //     {
    //         Debug.LogError($"################### 플레이어 스코어 계산 check : {isCheck}");
    //         if (isCheck == false)
    //         {
    //             isCheck = true;
    //             // Invoke("InvokeIsCheck", 3.0f);
    //             //// 스윙부터 아이들까지 애니메이션 동작시간 1.25f
    //             Invoke("InvokeIsCheck", 1.5f);
    //             Debug.Log($"<color=red> player Tag </color> : {_data.tag}");
    //             int number = int.Parse(_data.tag.Replace("Player_", ""));
    //             listScore[number].SetCalcPlayerScore(1);
    //         }
    //     }
    // }

    void InvokeIsCheck()
    {
        isCheck = false;
    }


}
