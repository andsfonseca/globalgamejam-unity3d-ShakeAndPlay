using UnityEngine;

public class GameStateManager : MonoBehaviour{

    private GameState m_currentGameState;
    private GameState m_lastGameState;

	public GameObject menu;
	public GameObject options;
	public GameObject gameover;
	public GameObject game;

    /// <summary>
    /// Retorna Enumerator do GameState Atual
    /// </summary>
    public EGameState current {
        get {
            return m_currentGameState.name;
        }
    }

    /// <summary>
    /// Retorna o Enumerator do GameState Anterior
    /// </summary>
    public EGameState last {
        get {
            return m_lastGameState.name;
        }
    }

    /// <summary>
    /// Retorna Enumerator do GameState Atual
    /// </summary>
    public GameState currentGS {
        get {
            return m_currentGameState;
        }
    }

    /// <summary>
    /// Retorna o Enumerator do GameState Anterior
    /// </summary>
    public GameState lastGS {
        get {
            return m_lastGameState;
        }
    }


    /// <summary>
    /// Altera o GameState Atual para o próximo GameState
    /// </summary>
    /// <param name="gs"></param>
    public void SwitchGameState(GameState gs) {
        if (m_currentGameState != null) m_lastGameState = m_currentGameState;
        if (m_currentGameState != null) m_currentGameState.OnChangeGameState();
        m_currentGameState = gs;
        m_currentGameState.OnStartGameState();
    }

    /// <summary>
    /// A cada tick faça
    /// </summary>
    void Update() {
        if (m_currentGameState != null) m_currentGameState.UpdateState();
    }

    /// <summary>
    /// Ao criar o Objeto
    /// </summary>
    void Awake() {
        DontDestroyOnLoad(this);
    }

	void muda(){
		//SwitchGameState(new GameOverGamestate);
	}
    
}






   