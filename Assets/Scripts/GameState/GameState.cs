using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState {

    protected bool m_isEnabled;
    protected EGameState m_gamestate;

    public EGameState name { get { return m_gamestate; } }
    
    /// <summary>
    /// A cada tick, faça a execução
    /// </summary>
    public abstract void UpdateState();

    /// <summary>
    /// Ao iniciar o GameState faça
    /// </summary>
    public virtual void OnStartGameState() {
        m_isEnabled = true;
    }

    /// <summary>
    /// Ao trocar de GameState faça
    /// </summary>
    public virtual void OnChangeGameState() {
        m_isEnabled = false;
    }

    /// <summary>
    /// Cria um GameState
    /// </summary>
    /// <param name="idGameState"></param>
    public GameState(EGameState idGameState){
        m_gamestate = idGameState;
    }
}
