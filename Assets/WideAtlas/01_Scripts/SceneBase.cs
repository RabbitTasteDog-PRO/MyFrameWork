using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBase : MonoBehaviour
{


    // public Transform trCenterPosition;

    public PopupManager popupManager;
    public Transform popupRoot;


    public AudioSource audioBGMSource;
    public AudioSource audioSFXSource;



    public bool isFirst = false;

    // public ServerView _server;


    ///싱글톤 객체
    private static SceneBase _instance = null;
    public static SceneBase Instance
    {
        get
        {
            if (_instance == null)
            {
                ///싱글톤 객체를 찾아서 넣는다.
                _instance = (SceneBase)FindObjectOfType(typeof(SceneBase));

                ///없다면 생성한다.
                if (_instance == null)
                {
                    string goName = typeof(SceneBase).ToString();
                    GameObject go = GameObject.Find(goName);
                    if (go == null)
                    {
                        go = new GameObject();
                        go.name = goName;
                    }
                    _instance = go.AddComponent<SceneBase>();
                }
            }
            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        popupRoot = popupManager.RootPopup;

        UnityEngine.SceneManagement.SceneManager.LoadScene(Widebrain.Enums.eScene.SceneSelect.ToString());
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

    /*************************************************************************************************************************************/
    //// Sound
    public void PlayBGM(string bgm)
    {
        if (audioBGMSource.isPlaying == true)
        {
            audioBGMSource.Stop();
        }
        audioBGMSource.clip = Resources.Load<AudioClip>("Sound/BGM/" + bgm);
        audioBGMSource.loop = true;
        audioBGMSource.Play();

    }

    public void PlaySFX(string sfx)
    {
        //if (UserInfoManager.Instance.GetSavePlaySound() == true)
        //{
        //    AudioClip _clip = Resources.Load<AudioClip>("Sound/SFX/" + sfx);
        //    audioSFXSource.PlayOneShot(_clip);
        //}
        AudioClip _clip = Resources.Load<AudioClip>("Sound/SFX/" + sfx);
        audioSFXSource.PlayOneShot(_clip);
    }

    /*************************************************************************************************************************************/



}
