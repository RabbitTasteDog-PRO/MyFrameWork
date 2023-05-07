using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;



public class PlayerScoreUI : MonoBehaviour
{
    public SpriteAtlas atalsPlayer;

    [Header("==================== Player UI ==================== ")]
    public Image imgPlayer;
    public GameObject objIsMine;
    public Text textScore;
    bool isMine = false;

    const int PLAYER_SCORE = 10;
    int minusScore = 0;


    void Awake()
    {
        textScore.text = PLAYER_SCORE.ToString();
    }

    void Destroy()
    {

    }


    ///<summary>
    /// 플레이어 정보 Set
    ///</summary>
    public void SetPlayerUI(string sessionID)
    {
        textScore.text = PLAYER_SCORE.ToString();
        ///플레이어 정보
        //// smaple 
        /// Sprite Setting
        // imgPlayer.sprite = atalsPlayer.GetSprite(ConvertPlayer( Widebrain.Enums.ePlayer.ePlayer_0 ));

    }


    public void SetCalcPlayerScore(int score)
    {
        minusScore += score;
        // textScore.text = $"{Mathf.Max(0, PLAYER_SCORE - minusScore)}";
        textScore.text = $"{PLAYER_SCORE - minusScore}";
    }





    string ConvertPlayer(Widebrain.Enums.ePlayer _player)
    {
        string player = "player-red@2x";
        switch (_player)
        {
            case Widebrain.Enums.ePlayer.ePlayer_0: { player = "player-red@2x"; break; }
            case Widebrain.Enums.ePlayer.ePlayer_1: { player = "player-yellow@2x"; break; }
            case Widebrain.Enums.ePlayer.ePlayer_2: { player = "player-blue@2x"; break; }
            case Widebrain.Enums.ePlayer.ePlayer_3: { player = "player-white@2x"; break; }
        }

        return player;
    }

}
