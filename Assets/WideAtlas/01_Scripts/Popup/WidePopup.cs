using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WidePopup : MonoBehaviour
{

    public Canvas _cavas;
    public CanvasGroup _cavasGroup;


    public Button btnClosed;
    public bool isBackButton = false;

    [HideInInspector]
    public System.Action CloseCallback = null;

    ///<summary>
    /// 팝업 매니저 관계없이 게임오브젝트 삭제
    ///</summary>
    protected virtual void OnClosed()
    {
        // Destroy(this.gameObject);

        // if (CloseCallback != null)
        // {
        //     if (isBackButton == true)
        //     {
        //         CloseCallback?.Invoke();
        //     }
        // }
    }


    ///<summary>
    /// 팝업 매니저를 이용한 팝업삭제
    ///</summary>
    protected virtual void OnPopupClose()
    {

        Destroy(this.gameObject);
    }


    void Awake()
    {
        int count = PopupManager.Instance.GetPopupCount();

        if (btnClosed != null)
        {
            btnClosed.onClick.AddListener(OnClosed);
        }

        if (gameObject.GetComponent<CanvasGroup>() == null)
        {
            gameObject.AddComponent<CanvasGroup>();
            _cavasGroup = gameObject.GetComponent<CanvasGroup>();
        }


        if (gameObject.GetComponent<Canvas>() == null)
        {
            gameObject.AddComponent<Canvas>();
            _cavas = gameObject.GetComponent<Canvas>();
        }

        _cavasGroup.alpha = 0.0f;
        _cavas.overrideSorting = true;
        _cavas.sortingOrder = (100 + (count + 1));

        StartCoroutine(IEOpenAnimation(_cavasGroup));


    }

    IEnumerator IEOpenAnimation(CanvasGroup _obj)
    {
        float fElapsedTime = 0f; /// 경과 시간 
        float fDuration = 0.25f; /// 동작 시간 
        float fUnitTime = 1.0f / fDuration; /// 1초 대비 경과시간 계산 
        while (true)
        {
            // fElapsedTime = fElapsedTime + (Time.deltaTime * fUnitTime);
            fElapsedTime += (Time.deltaTime * fUnitTime);
            float v = Mathf.Lerp(0f, 1, fElapsedTime);
            if (fElapsedTime > 1.0f)
            {
                _obj.alpha = 1.0f;
                break;
            }
            _obj.alpha = v;
            yield return Widebrain.Yield.WideYieldHelper.WaitForEndOfFrame();
        }
        OnAwake();
    }

    void Start() { OnStart(); }
    void OnEnable() { OnEnabled(); }
    void OnDisable() { OnDisabled(); }
    void OnDestroy() { OnDestroied(); }


    protected virtual void OnAwake() { }
    protected virtual void OnStart() { }
    protected virtual void OnEnabled() { }
    protected virtual void OnDisabled() { }
    protected virtual void OnDestroied() { }

    public virtual void SetData() { }
    public virtual void SetData(object data) { }
    public virtual void SetData(object[] data) { }
    public virtual void SetData(List<object> data) { }

}
