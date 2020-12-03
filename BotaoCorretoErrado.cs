using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoCorretoErrado : MonoBehaviour
{
    [SerializeField]
    private bool corretoErrado = true;              //O botão correto manda true, o botão errado manda false

    private bool objetoSelecionadoCorreto = false;  //Se o objeto selecionado for o objeto correto, true, senão, false

    private GameManager meuManager;

    void Awake()
    {
        meuManager = GameObject.Find("Canvas").GetComponent<GameManager>();
    }

    public void IniciarResposta(bool selecao)
    {
        objetoSelecionadoCorreto = selecao;
    }

    public void EnviarResposta()
    {
        meuManager.ReceberResposta(corretoErrado, objetoSelecionadoCorreto);
    }
}
