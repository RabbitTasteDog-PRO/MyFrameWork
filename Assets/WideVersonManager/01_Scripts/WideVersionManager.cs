
#if UNITY_EDITOR == true
using UnityEditor;
using UnityEditor.Callbacks;
#endif
using UnityEngine;

namespace Widebrain.VersionController
{
#if UNITY_EDITOR == true
    public class WideVersionManager : MonoBehaviour
    {
        private static bool AutoIncrease = true;

        /// ture, false 로 자동빌드 체크
        private const string AutoIncreaseMenuName = "WideBuild/Auto Increase Build Version";

        [PostProcessBuild(1)] // PostProcessBuild - 빌드 후 실행되는 콜백 함수
        public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
        {
            if (AutoIncrease) EditVersion(0, 0, 1);
        }

        /// <summary>
        /// 자동 버전 업
        /// </summary>
        [MenuItem(AutoIncreaseMenuName, false, 1)]
        private static void SetAutoIncrease()
        {
            AutoIncrease = !AutoIncrease;
            EditorPrefs.SetBool(AutoIncreaseMenuName, AutoIncrease);
            Debug.Log("Auto Increase : " + AutoIncrease);
        }

        [MenuItem(AutoIncreaseMenuName, true)]
        private static bool SetAutoIncreaseValidate()
        {
            Menu.SetChecked(AutoIncreaseMenuName, AutoIncrease);
            return true;
        }

        /// <summary>
        /// 버전 수정
        /// </summary>
        static void EditVersion(int majorIncr, int minorIncr, int buildIncr)
        {
            string[] lines = PlayerSettings.bundleVersion.Split('.');

            int MajorVersion = int.Parse(lines[0]) + majorIncr;
            int MinorVersion = int.Parse(lines[1]) + minorIncr;
            int Build = int.Parse(lines[2]) + buildIncr;

            PlayerSettings.bundleVersion = MajorVersion.ToString("0") + "." +
                                           MinorVersion.ToString("0") + "." +
                                           Build.ToString("0");
            PlayerSettings.Android.bundleVersionCode =
                 MajorVersion * 10000 + MinorVersion * 1000 + Build;
            CheckCurrentVersion();
        }

        ///<summary>
        /// 현재 버전 체크
        ///</summary>
        [MenuItem("WideBuild/Check Current Version", false, 2)]
        private static void CheckCurrentVersion()
        {
            Debug.Log("Build v" + PlayerSettings.bundleVersion +
                 " (" + PlayerSettings.Android.bundleVersionCode + ")"); //현재 버전 표시
        }

        ///<summary>
        /// Major 버전 업
        ///</summary>
        [MenuItem("WideBuild/Increase Major Version", false, 51)]
        private static void IncreaseMajor()
        {
            string[] lines = PlayerSettings.bundleVersion.Split('.');
            EditVersion(1, -int.Parse(lines[1]), -int.Parse(lines[2]));
        }

        ///<summary>
        /// Minor 버전 업
        ///</summary>
        [MenuItem("WideBuild/Increase Minor Version", false, 52)]
        private static void IncreaseMinor()
        {
            string[] lines = PlayerSettings.bundleVersion.Split('.');
            EditVersion(0, 1, -int.Parse(lines[2]));
        }

        ///<summary>
        /// 버전 초기화
        ///</summary>
        [MenuItem("WideBuild/Version Init", false, 52)]
        private static void CheckVersionLength()
        {
            string[] lines = PlayerSettings.bundleVersion.Split('.');
            int MajorVersion = 0;
            int MinorVersion = 0;
            int Build = 0;

            PlayerSettings.bundleVersion = MajorVersion.ToString("0") + "." +
                                           MinorVersion.ToString("0") + "." +
                                           Build.ToString("0");

            PlayerSettings.Android.bundleVersionCode =
                MajorVersion * 10000 + MinorVersion * 1000 + Build;

            CheckCurrentVersion();

        }

    }
#endif
}