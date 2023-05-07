using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupRanking : WidePopup
{

    public RankUI prefab_Rank_My;
    public RankUI prefab_Rank_Other;
    public Transform layoutRank;
    public Text textRestTime;

    public Button btnBack;


    public override void SetData()
    {
        base.SetData();
    }


    protected override void OnAwake()
    {
        base.OnAwake();
        btnBack.onClick.AddListener(OnPopupClose);
    }

    protected override void OnPopupClose()
    {
        base.OnPopupClose();
    }

    protected override void OnDestroied()
    {
        base.OnDestroied();
    }

    protected override void OnStart()
    {
        base.OnStart();

        for (int i = 0; i < 100; i++)
        {
            if (i == 0)
            {
                RankUI _prefab = Instantiate(prefab_Rank_My, layoutRank) as RankUI;
                _prefab.transform.localPosition = Vector2.zero;
                _prefab.transform.localScale = Vector3.one * 0.92f;
                _prefab.SetMyRankData();
            }
            else
            {
                RankUI _prefab = Instantiate(prefab_Rank_Other, layoutRank) as RankUI;
                _prefab.transform.localPosition = Vector2.zero;
                _prefab.transform.localScale = Vector3.one * 0.92f;
                _prefab.SetMyRankData();
            }
        }
    }


}
