using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;

    private GameObject fundoDica;
    private GameObject textoDica;
    private GameObject botaoAbrirDica;
    private GameObject botaoFecharDica;
    private GameObject botaoIstoCorreto;
    private GameObject botaoIstoErrado;
    private GameObject botaoRetornarMenu;
    private GameObject botaoSairAplicacao;

    public int numeroFases = 6;
    private int faseAtual = 1;
    private int acertos = 0;

    private string[] textosDicas = new string[] {
        "O Estatuto da Criança e do Adolescente (lei Nº 8.069, de 13 de julho de 1990), diz:\n\n“[...] A criança e o adolescente têm direito à educação, [...] assegurando-se-lhes: [...] igualdade de condições para o acesso e permanência na escola, [...]”",
        "A Lei de Diretrizes e Bases da Educação Nacional (lei Nº 9.394, de 20 de dezembro de 1996), diz:\n\n“[...] Os docentes incumbir-se-ão de: [...] colaborar com as atividades de articulação da escola com as famílias e a comunidade. [...]”",
        "O Estatuto da Criança e do Adolescente (lei Nº 8.069, de 13 de julho de 1990), diz que:\n\n“[...] é dever do Estado assegurar à criança e ao adolescente: [...] oferta de ensino noturno regular, adequado às condições do adolescente trabalhador;[...]",
        "O Estatuto da Criança e do Adolescente (lei Nº 8.069, de 13 de julho de 1990), diz:\n\n“[...] Os dirigentes de estabelecimentos de ensino fundamental comunicarão ao Conselho Tutelar os casos de: [...] maus-tratos envolvendo seus alunos;[...]”",
        "O Estatuto da Criança e do Adolescente (lei Nº 8.069, de 13 de julho de 1990), diz:\n\n“[...] No processo educacional respeitar-se-ão os valores culturais, artísticos e históricos próprios do contexto social da criança e do adolescente[...]”",
        "A Lei de Diretrizes e Bases da Educação Nacional (lei Nº 9.394, de 20 de dezembro de 1996), diz:\n\n“[...] Os docentes incumbir-se-ão de: [...] ministrar os dias letivos e horas-aula estabelecidos, [...]”"
    };

    private bool[] gabaritoBool = new bool[] {
        false,
        true,
        true,
        true,
        false,
        false};

    void Awake()
    {
        fundoDica = GameObject.Find("Fundo Dica");
        textoDica = GameObject.Find("Texto Dica");
        botaoAbrirDica = GameObject.Find("Botao Abrir Dica");
        botaoFecharDica = GameObject.Find("Botao Fechar Dica");
        botaoIstoCorreto = GameObject.Find("Botao Isto Correto");
        botaoIstoErrado = GameObject.Find("Botao Isto Errado");
        botaoRetornarMenu = GameObject.Find("Botao Retornar Menu");
        botaoSairAplicacao = GameObject.Find("Botao Sair Aplicacao");

        botaoRetornarMenu.SetActive(false);
        botaoSairAplicacao.SetActive(false);

        botaoIstoCorreto.SetActive(false);
        botaoIstoErrado.SetActive(false);

        AbrirDica();
    }

    public void AbrirDica()
    {
        fundoDica.SetActive(true);
        DefinirTextoDica(faseAtual);
        botaoAbrirDica.SetActive(false);

        botaoIstoCorreto.SetActive(false);
        botaoIstoErrado.SetActive(false);
    }

    public void FecharDica()
    {
        botaoAbrirDica.SetActive(true);
        fundoDica.SetActive(false);
    }

    public void DefinirTextoDica(int numeroDaFase)
    {
        textoDica.GetComponent<Text>().text = textosDicas[faseAtual-1];
    }

    public void ReceberResposta(bool resposta, bool objetoSelecionado)
    {
        if(resposta == gabaritoBool[faseAtual-1] && objetoSelecionado == true)
        {
            acertos++;
        }

        ProximaFase();
    }

    public void ProximaFase()
    {
        if(faseAtual < numeroFases)
        {
            mainCamera.transform.position += new Vector3(20, 0, 0);
            faseAtual++;
            AbrirDica();
        }
        else
        {
            //Tela de pontuação
            fundoDica.SetActive(true);
            botaoIstoCorreto.SetActive(false);
            botaoIstoErrado.SetActive(false);
            botaoFecharDica.SetActive(false);
            botaoAbrirDica.SetActive(false);

            botaoRetornarMenu.SetActive(true);
            botaoSairAplicacao.SetActive(true);

            textoDica.GetComponent<Text>().text = "Concluído! Você teve " +acertos.ToString() +" acertos em " +numeroFases.ToString() +" questões.";
        }
    }

    public void RetornarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SairAplicacao()
    {
        Application.Quit();
    }
}
