using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerSingleton : MonoBehaviour {

    private static AudioListenerSingleton instance = null;

    private void Awake() {
        if (instance && instance != null) {
            DestroyImmediate(gameObject);
                return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
