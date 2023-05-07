using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YieldHelper : MonoBehaviour
{
    public Text _text;

    IEnumerator Start()
    {
        Debug.Log("########### 00 : Start WaitForEndOfFrame");
        yield return Widebrain.Yield.WideYieldHelper.WaitForEndOfFrame();

        yield return Widebrain.Yield.WideYieldHelper.WaitForSeconds(3000);

        Debug.Log("########### 11 : Start WaitForSeconds");
        yield return Widebrain.Yield.WideYieldHelper.WaitForSeconds(3000);


        yield return Widebrain.Yield.WideYieldHelper.WaitForFixedUpdate();
        Debug.Log("########### 22 : Start WaitForFixedUpdate");
        // textVersion.text = $"Version : {Application.version.ToString()}";
    }
}
