using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupReady : WidePopup
{

    public GameObject objReady;
    public GameObject objStart;

    bool isStart = false;

    protected override void OnAwake()
    {
        base.OnAwake();

        objReady.SetActive(true);
        objStart.SetActive(false);
    }

    protected override void OnDestroied()
    {
        base.OnDestroied();
        if (isStart == true)
        {
        }
    }

    protected override void OnStart()
    {
        base.OnStart();

        StartCoroutine(IEReady());
    }


    IEnumerator IEReady()
    {
        yield return Widebrain.Yield.WideYieldHelper.WaitForSeconds(3000);
        objReady.SetActive(false);
        objStart.SetActive(true);
        yield return Widebrain.Yield.WideYieldHelper.WaitForSeconds(2000);
        isStart = true;
        Destroy(this.gameObject);
        // OnDestroied();

    }
}
