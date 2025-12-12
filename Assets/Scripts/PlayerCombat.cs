using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Configurações")]
    public Animator animator; // Referência para o Animator
    public Transform pontoDeAtaque;
    public float raioDoAtaque = 0.5f;
    public LayerMask layerInimigo;
    public int danoAtaque = 20;

    [Header("Tempo de Ataque")]
    public float taxaDeAtaque = 2f; // Quantos ataques por segundo
    float proximoAtaqueTempo = 0f;

    void Update()
    {
        // Verifica se já passou tempo suficiente para atacar de novo
        if (Time.time >= proximoAtaqueTempo)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Atacar();
                // Define quando poderá atacar novamente (Ex: agora + 0.5 segundos)
                proximoAtaqueTempo = Time.time + 1f / taxaDeAtaque;
            }
        }
    }

    void Atacar()
    {
        // 1. Toca a animação baseada no Trigger que criamos
        animator.SetTrigger("Atacar");

        // 2. Detecta inimigos
        Collider2D[] inimigosAtingidos = Physics2D.OverlapCircleAll(pontoDeAtaque.position, raioDoAtaque, layerInimigo);

        // 3. Aplica dano
        foreach (Collider2D inimigo in inimigosAtingidos)
        {
            // Tenta pegar o script no próprio objeto ou nos pais/filhos
            InimigoHealth scriptInimigo = inimigo.GetComponent<InimigoHealth>();
            
            if (scriptInimigo != null)
            {
                scriptInimigo.ReceberDano(danoAtaque);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (pontoDeAtaque == null) return;
        Gizmos.DrawWireSphere(pontoDeAtaque.position, raioDoAtaque);
    }
}