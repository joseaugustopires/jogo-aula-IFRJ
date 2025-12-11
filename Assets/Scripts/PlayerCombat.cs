using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform pontoDeAtaque; // Onde o ataque acontece
    public float raioDoAtaque = 0.5f; // Tamanho do ataque
    public LayerMask layerInimigo; // Para saber o que é inimigo
    public int danoAtaque = 20;

    void Update()
    {
        // Altere "Fire1" para a tecla que preferir (ex: KeyCode.Z ou botão do mouse)
        if (Input.GetButtonDown("Fire1")) 
        {
            Atacar();
        }
    }

    void Atacar()
    {
        // 1. Tocar animação de ataque (se tiver)
        // animator.SetTrigger("Atacar"); 

        // 2. Detectar inimigos na área de alcance
        Collider2D[] inimigosAtingidos = Physics2D.OverlapCircleAll(pontoDeAtaque.position, raioDoAtaque, layerInimigo);

        // 3. Causar dano neles
        foreach (Collider2D inimigo in inimigosAtingidos)
        {
            // Tenta pegar o script de vida do inimigo
            InimigoHealth scriptInimigo = inimigo.GetComponent<InimigoHealth>();
            
            if (scriptInimigo != null)
            {
                scriptInimigo.ReceberDano(danoAtaque);
            }
        }
    }

    // Isso desenha uma bolinha vermelha na cena para você ver o alcance do ataque (apenas no editor)
    void OnDrawGizmosSelected()
    {
        if (pontoDeAtaque == null)
            return;

        Gizmos.DrawWireSphere(pontoDeAtaque.position, raioDoAtaque);
    }
}