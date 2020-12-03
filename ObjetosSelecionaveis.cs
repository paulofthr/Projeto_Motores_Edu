using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosSelecionaveis : MonoBehaviour
{
    //Primeiramente, o jogador seleciona um objeto. Então, ele aperta no botão "correto" ou no "errado" (um check mark e um X, respectivamente) para dizer se o objeto selecionado está 
    //conformado com a dica.

    [SerializeField]
    private bool objetoCorretoFalso = false;

    [SerializeField]
    private GameObject botaoIstoCorreto, botaoIstoErrado;

    private void OnMouseDown()
    {
        LigarBotoesCorretoErrado();

        botaoIstoCorreto.GetComponent<BotaoCorretoErrado>().IniciarResposta(objetoCorretoFalso);
        botaoIstoErrado.GetComponent<BotaoCorretoErrado>().IniciarResposta(objetoCorretoFalso);
    }

    public void LigarBotoesCorretoErrado()
    {
        botaoIstoCorreto.SetActive(true);
        botaoIstoErrado.SetActive(true);
    }
}
