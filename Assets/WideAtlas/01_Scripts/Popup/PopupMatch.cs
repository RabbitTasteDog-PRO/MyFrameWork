using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopupMatch : WidePopup
{
    public Image[] imgPlayer;
    public Image[] imgNotJoinedPlayer;
    public Text textMatchMessage;

    public Button btnBack;

    bool isMatch = false;
    bool isBack = false;
    string textMatchStart = "MATCHING...";
    string textMatchEnd = "MATCHING COMPLETE";

    const int COUNT_DOWN = 1;

    // WideRFC_DTH _rfc;

    Coroutine corutineMatch = null;

    private bool startMatch = false;
    public bool StartMatch
    {
        get => startMatch;

        set
        {
            startMatch = value;

            // 매치 시작하게 되면
            if (startMatch)
            {
                corutineMatch = StartCoroutine(MatchProcess());
            }
            else
            {
                // 매치 끝날 때 (ex : 매칭 취소, 매칭 완료)
                // ServerView.Instance.popupMatch = null;
                // if (corutineMatch != null)
                //     StopCoroutine(corutineMatch);
                // corutineMatch = null;
            }
        }
    }

    protected override void OnAwake()
    {
        base.OnAwake();
        // _rfc = ServerView.Instance.GetComponent<WideRFC_DTH>();
        // _rfc = ServerView.Instance.GetComponent<WideRFCFunction>();
        
        textMatchMessage.text = textMatchStart;
        btnBack.onClick.AddListener(OnClickBack);
    }

    protected override void OnDestroied()
    {
        base.OnDestroied();

        if (isMatch == true)
        {
            Debug.LogError($"########### PopupMatch isMatch : {isMatch}");
            // _rfc.SendMatchEndGameStart(ServerView.Instance.sessionId, isMatch);
        }

        if (isBack == true)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(Widebrain.Enums.eScene.SceneSelect.ToString());
        }

    }

    protected override void OnStart()
    {
        base.OnStart();

        // ServerView.Instance.popupMatch = this;
        // ServerView.Instance.JoinOrCreate();


        // _rfc.init
        // _rfc.initAddFunction();

        //StartCoroutine(IEDestroy());
    }

    
    void OnClickBack()
    {
        isBack = true;

        Destroy(this.gameObject);
    }

    ///<summary>
    /// 매치 로직 구현
    ///</summary>
    public IEnumerator MatchProcess()
    {
        // 호스트라면 본인 데이터 추가
        // if (ServerView.Instance.IsHost)
        // {
        //     NetworkManager.Instance.SetUserData(NetworkManager.Instance.myUserData, true);
        // }
        // else
        // {
        //     // 호스트가 아니라면 내 유저 정보를 호스트에게 보내기
        //     RFCParameter RFCparam = new RFCParameter
        //     {
        //         strParam = NetworkManager.Instance.GetMyUserDataToString(),
        //         boolParam = true
        //     };
        //     WideRFCController.Instance.SendRFC("RPCSendUserDataToHost", RFCparam);
        // }
        

        // while (startMatch)
        // {
        //     if (ServerView.Instance.IsHost)
        //     {


        //         if (Input.GetKeyDown(KeyCode.F1))
        //         {
        //             RFCParameter RFCparam = null;
        //             WideRFCController.Instance.SendRFC("RPCGameStart", RFCparam);
        //             StartCoroutine(GameStart());

        //         }
        //     }

            yield return null;
        // }
    }

    public IEnumerator GameStart()
    {
        // 본인 playerscript 할당
        // foreach (var item in NetworkManager.Instance.players)
        // {
        //     if (item.GetPlayerView().isMine)
        //     {
        //         item.SetGame(NetworkManager.Instance.players.FindIndex(x => x == item));
        //         //item.actor
        //     }
        // }

        // TO-DO : 타이밍 맞추기
        // textMatchMessage.text = textMatchEnd;
        // yield return Constants.wait1Seconds;
        // yield return Constants.wait1Seconds;
        // yield return Constants.wait1Seconds;
        isMatch = true;
        Destroy(this.gameObject);

        yield return null;
    }

    public void SetPlayerImageInMatch()
    { 
        // for (int i = 0; i < NetworkManager.Instance.userDataList.Count; i++)
        // {
        //     int temp = i;
        //     imgPlayer[temp].color = SetCharacterColor((int)NetworkManager.Instance.userDataList[temp].playerColor);
        //     imgNotJoinedPlayer[temp].gameObject.SetActive(false);
        // }

        // for (int i = 0; i < 4 - NetworkManager.Instance.userDataList.Count; i++)
        // {
        //     int temp = i;
        //     imgNotJoinedPlayer[3- temp].gameObject.SetActive(true);
        // }

        // // 이미지 세팅까지 완료한 후 방이 꽉 찼었다는 표시가 있으면 게임 시작!
        // if (NetworkManager.Instance.isFull)
        // {
        //     RFCParameter RFCparam = null;
        //     WideRFCController.Instance.SendRFC("RPCGameStart", RFCparam);
        //     StartCoroutine(GameStart());
        // }

    }

    // Color32 SetCharacterColor(int index)
    // {
    //     Color32 pickedColor = Constants.CH_WHITE;
    //     switch (index)
    //     {
    //         case 0: { pickedColor = Constants.CH_RED; break; }
    //         case 1: { pickedColor = Constants.CH_YELLOW; break; }
    //         case 2: { pickedColor = Constants.CH_BLUE; break; }
    //         case 3: { pickedColor = Constants.CH_WHITE; break; }
    //     }
    //     return pickedColor;
    // }

    /// <summary>
    /// 호스트 매치 로직 구현
    /// </summary>
    /// <returns></returns>
    IEnumerator CilentMatchProcess()
    {

        yield return null;
    }

    IEnumerator IEDestroy()
    {
        yield return null; 
        // int time = 0;
        // while (true)
        // {
        //     if (time > COUNT_DOWN) { break; }

        //     switch (time)
        //     {
        //         case 0: { imgPlayer[0].color = Constants.CH_RED; break; }
        //         case 1: { imgPlayer[1].color = Constants.CH_YELLOW; break; }
        //         case 2: { imgPlayer[2].color = Constants.CH_BLUE; break; }
        //         case 3: { imgPlayer[3].color = Constants.CH_WHITE; break; }
        //     }

        //     yield return Widebrain.Yield.WideYieldHelper.WaitForSeconds(1000);
        //     time++;
        // }
        // textMatchMessage.text = textMatchEnd;
        // yield return Widebrain.Yield.WideYieldHelper.WaitForSeconds(3000);
        // isMatch = true;
        // Destroy(this.gameObject);
    }
}
