using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Threading.Tasks;
using Widebrain.Yield;



public class WideRestAPIManager : WideSingleton<WideRestAPIManager>
{

    [Header("API URL")]
    // public const string API_URL = "http://20.196.214.93:4000"; /// <== 운영용
    public const string API_URL = "http://20.249.82.250:4004"; /// <== 테스트용


    [Header("Game Id")]
    public const string GAMEID_ROCK_PAPER_SCISSOR = "638f388b1ffb4368bffa0cfc"; // <= 가위바위보 게임 아이디 test용 


    void Awake()
    {
        Application.targetFrameRate = 40;
    }

    /********************************************************************************************************************/


    public IEnumerator IERequestGetByByte(string url, Action<byte[]> complite = null)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {

            var operation = www.SendWebRequest();

            string[] pages = url.Split('/');
            int page = pages.Length - 1;

            while (!operation.isDone)
                yield return WideYieldHelper.WaitForEndOfFrame();

            if (www.error == null)
            {
                try
                {
                    if (complite != null && complite.GetInvocationList().Length > 0)
                    {
                        complite?.Invoke(www.downloadHandler.data);
                        www.Dispose();
                        yield break;
                    }
                }
                catch (System.Exception e)
                {
                    Debug.LogError("################ IERequestGet Error : " + e.ToString());
                    www.Dispose();
                    yield break;
                }
            }
            else
            {
                Debug.LogError("################ IERequestGet Error : " + www.error.ToString());
                www.Dispose();
                yield break;
            }


        }
    }

    public IEnumerator IERequestPostByByte(string url, string json, Action<byte[]> onComplete = null, Action<string> onError = null)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(url, json))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            www.uploadHandler = new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                onError?.Invoke(www.error);
                www.Dispose();
                yield break;
            }
            else
            {
                onComplete?.Invoke(www.downloadHandler.data);
                Debug.Log("################ Form upload complete!");
                www.Dispose();
                yield break;
            }
        }
    }

    public IEnumerator IERequestGetByString(string url, Action<string> complite = null)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {

            var operation = www.SendWebRequest();

            string[] pages = url.Split('/');
            int page = pages.Length - 1;

            while (!operation.isDone)
                yield return WideYieldHelper.WaitForEndOfFrame();

            if (www.error == null)
            {
                try
                {
                    if (complite != null && complite.GetInvocationList().Length > 0)
                    {
                        complite(www.downloadHandler.text);
                        www.Dispose();
                        yield break;
                    }
                }
                catch (ArgumentException e)
                {
                    Debug.LogError("################ IERequestGet Error : " + e.ToString());
                    www.Dispose();
                    yield break;
                }
            }
            else
            {
                Debug.LogError("################ IERequestGet Error : " + www.error.ToString());
                www.Dispose();
                yield break;
            }


        }
    }


    //Http Post Async To Bytes
    public IEnumerator IERequestPostByString(string url, string json, Action<string> onComplete = null, Action<string> onError = null)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(url, json))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            www.uploadHandler = new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                onError?.Invoke(www.error);
                Debug.LogError("################### www.error : " + www.error.ToString());
                www.Dispose();
                yield break;
            }
            else
            {
                onComplete?.Invoke(www.downloadHandler.text);
                Debug.Log("Form upload complete!");
                www.Dispose();
                yield break;
            }


        }
    }



    /********************************************************************************************************************/


    ////Http Get Async To Bytes
    public static async Task<string> GetAsyncToStrings(string url, Action<string> onError = null)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            var operation = www.SendWebRequest();
            while (!operation.isDone)
            {
                await Task.Yield();
            }
            if (www.error == null)
            {
                try
                {
                    return www.downloadHandler.text;
                }
                catch (ArgumentException e)
                {
#if UNITY_EDITOR
                    Debug.LogError("################# e.Message : " + e.Message);
#endif
                    return null;
                }
            }
            else
            {
#if UNITY_EDITOR
                // Widebrain.DebugHelper.WideDebugHelper.Instance.DebugLog(www.error);
                Debug.LogError("################# e.error : " + www.error.ToString());
#endif
                onError?.Invoke(www.error);
                return null;
            }
        }
    }

    ////Http Post Async To Bytes
    public static async Task<byte[]> PostAsyncToBytes(string url, string json, Action<string> onError = null)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(url, json))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            www.uploadHandler = new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            var operation = www.SendWebRequest();

            while (!operation.isDone)
                await Task.Yield();

            if (www.error == null)
            {
                try
                {
                    return www.downloadHandler.data;
                }
                catch (ArgumentException e)
                {
#if UNITY_EDITOR
                    // Widebrain.DebugHelper.WideDebugHelper.Instance.DebugLog(e.Message);
                    Debug.LogError("################## e.Message : " + e.Message);
#endif
                    return null;
                }
            }
            else
            {
#if UNITY_EDITOR
                // Widebrain.DebugHelper.WideDebugHelper.Instance.DebugLog(www.error);
                Debug.LogError("################# e.error : " + www.error.ToString());
#endif
                onError?.Invoke(www.error);
                return null;
            }

            www.Dispose();
        }
    }




    /****************************************************************************************************************/
    //// Unity 기본
    //// get
    // public static IEnumerator WWWRequest(string url, System.Action<byte[]> onComplete)
    // {
    //     using (UnityWebRequest www = UnityWebRequest.Get(url))
    //     {
    //         var operation = www.SendWebRequest();

    //         while (!operation.isDone)
    //             yield return new WaitForEndOfFrame();

    //         if (www.error == null)
    //         {
    //             try
    //             {
    //                 byte[] _data = www.downloadHandler.data;
    //                 if (_data != null)
    //                 {
    //                     onComplete?.Invoke(_data);
    //                 }

    //             }
    //             catch (System.ArgumentException e)
    //             {
    //                 Widebrain.DebugHelper.WideDebugHelper.Instance.DebugError(e.Message);
    //             }
    //         }
    //         else
    //         {
    //             Widebrain.DebugHelper.WideDebugHelper.Instance.DebugError(www.error);
    //         }
    //     }
    // }

    /// send
    // public IEnumerator IEPostAPI()
    // {
    //     WWWForm form = new WWWForm();
    //     form.AddField("myField", "myData");

    //     using (UnityWebRequest www = UnityWebRequest.Post("https://www.my-server.com/myform", form))
    //     {
    //         yield return www.SendWebRequest();

    //         if (www.result != UnityWebRequest.Result.Success)
    //         {
    //             Widebrain.DebugHelper.WideDebugHelper.Instance.DebugLog(www.error);
    //         }
    //         else
    //         {
    //             Widebrain.DebugHelper.WideDebugHelper.Instance.DebugLog("Form upload complete!");
    //         }
    //     }
    // }
}

