using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class ResultUI : MonoBehaviour
{
    public SpriteAtlas atlas;


    public Image background;

    public Image imgPlayer;

    public Text textRank;
    public Text textPlyerNickName;
    public Text textScore;
    public Text textPercent;


    //// isMine
    Color32 colorMine = new Color32(242, 70, 176, 255);
    /// 
    Color32 colorOther = new Color32(52, 52, 69, 255);


    public void SetResultUI(bool isMine, int randk, string nickName, int score)
    {

    }



    string ConverRandk(int rank)
    {
        string strRank = "";
        switch (rank)
        {
            case 1: { strRank = "1ST"; break; }
            case 2: { strRank = "2ND"; break; }
            case 3: { strRank = "3RD"; break; }
            case 4: { strRank = "4TH"; break; }
        }

        return strRank;
    }
}
