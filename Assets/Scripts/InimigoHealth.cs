using UnityEngine;

public class InimigoHealth : MonoBehaviour
{
    public int vidaMaxima = 100;
    int vidaAtual;

    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void ReceberDano(int dano)
    {
        vidaAtual -= dano;

        // Opcional: Adicionar animação de "Dano" aqui
        Debug.Log("Inimigo recebeu dano! Vida restante: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        // Opcional: Adicionar animação de morte ou efeitos de partículas
        Debug.Log("Inimigo Morreu!");
        
        // Remove o inimigo da cena
        Destroy(gameObject);
    }
}