using UnityEngine;

namespace Petro
{
    public class PetroLife : MonoBehaviour
    {
        public int health=100;
        public int damagePlayer=10;
        public GameObject nextPhase;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("player_bullet")) return;
            TakeDamage(this.damagePlayer);
            Destroy(other.gameObject);
        }

        private void TakeDamage(int damage)
        {
            health -= damage;
            if(health <= 0)
                DiePetro();
        }

        private void DiePetro()
        {
            Destroy(gameObject);
            if(nextPhase != null)
                nextPhase.SetActive(true);
        }
    }
}
