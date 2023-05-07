using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Widebrain.Enums
{

    public enum eScene
    {
        NONE = -1,
        SceneBase,
        SceneSelect,
        SceneGame,
        SceneGame_Multiplay,
        SceneGame_Multiplay_Jiheum,
        SceneGame_Multiplay_Work,
        // SceneGame_ORI,

        COUNT
    }

    public enum ePopupLayer
    {
        NONE = -1,
        PopupCharacter,
        PopupMatch,
        PopupPlay,
        PopupRanking,

        COUNT
    }

    public enum ePlayer
    {
        NONE = -1,
        ePlayer_0, /// 빨강
        ePlayer_1, /// 노랑
        ePlayer_2, /// 파랑
        ePlayer_3, /// 하양
        COUNT
    }

}

