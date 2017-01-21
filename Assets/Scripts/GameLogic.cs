using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

    /// <summary>
    /// Recupera a Instância atual da GameLogic
    /// </summary>
    /// <value>The instance.</value>
    public static GameLogic Instance {
        get {
            if (m_instance == null) {
                m_instance = GameObject.FindObjectOfType<GameLogic>();
                DontDestroyOnLoad(m_instance.gameObject);
            }

            return m_instance;
        }
    }

    /// <summary>
    /// A instância atual da GameLogic
    /// </summary>
    private static GameLogic m_instance;

    void Awake() {
        if (m_instance == null) {
            m_instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            if (this != m_instance) {
                Destroy(this.gameObject);
            }
        }
    }

    
    [Header("Scripts")]
    public GameStateManager gameStateManager;

    void Start() {
        if (gameStateManager == null) Debug.Log("Game State Manager isn't started");
    }
}
