using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Description: Interface created for any state machine
//Created: (2025/03/18) Rodrigo Duran Daniel

public interface IStateManager<Controller> where Controller : class
{

    #region State Methods

    /// <summary>
    /// Gerencia as acoes ao entrar no estado, recebe como parametro o ultimo estado para casos de estados que irao realizar uma acao e voltar pro ultimo estado
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="lastState"></param>
    public void EnterState(Controller controller, IStateManager<Controller> lastState);

    /// <summary>
    /// Define como o personagem se comporta no estado atual
    /// </summary>
    /// <param name="controller"></param>
    public void UpdateState(Controller controller);

    /// <summary>
    /// Gerencia as movimentacoes do personagem no estado atual
    /// </summary>
    /// <param name="controller"></param>
    public void FixedUpdateState(Controller controller);

    /// <summary>
    /// Define como o jogador se comporta ao sair do estado atual
    /// </summary>
    /// <param name="controller"></param>
    public void ExitState(Controller controller);

    /// <summary>
    /// Gerencia os inputs do player, para troca de estados
    /// </summary>
    /// <param name="controller"></param>
    public void HandleInput(Controller controller);

    #endregion

}
