using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// 코루틴 사용시 new 사용으로 인한 
// 메모리 과사용을 잡기위한 
// Yield 클래스
namespace Widebrain.Yield
{
    public static class WideYieldHelper
    {
        private static readonly WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame();
        private static readonly WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();
        private static readonly Dictionary<int, WaitForSeconds> waitForSeconds = new Dictionary<int, WaitForSeconds>();

        ///<summary>
        /// 밀리세컨드 사용
        ///</summary>
        public static WaitForSeconds WaitForSeconds(int miliSec)
        {
            WaitForSeconds wfs = null;
            if (!waitForSeconds.TryGetValue(miliSec, out wfs))
            {
                wfs = new WaitForSeconds(miliSec * 0.001f);
                waitForSeconds.Add(miliSec, wfs);
            }
            return wfs;
        }

        ///<summary>
        /// WaitforEndOfFrame
        ///</summary>
        public static WaitForEndOfFrame WaitForEndOfFrame()
        {
            return _waitForEndOfFrame;
        }

        ///<summary>
        /// WaitForFixedUpdate
        ///</summary>
        public static WaitForFixedUpdate WaitForFixedUpdate()
        {
            return _waitForFixedUpdate;
        }


    }

}

