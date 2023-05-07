using UnityEngine;
using System.Collections;

public abstract class WideSingleton<T> : MonoBehaviour where T : WideSingleton<T>
{

    protected static T _instance = null;
    public static T Instance
    {
        get
        {
            /// Instance requiered for the first time, lock for it
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;
            }
            return _instance;
        }
    }
    // If no other monobehaviour request the instance in an awake function
    // executing before this one, no need to search the object.
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
        else
        {
            if (_instance != this as T)
            {
                Destroy(gameObject);
                return;
            }
        }

        DontDestroyOnLoad(this.gameObject);
    }

}

