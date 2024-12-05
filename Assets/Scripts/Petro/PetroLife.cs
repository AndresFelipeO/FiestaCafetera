using UnityEngine;
using UnityEngine.SceneManagement;

namespace Petro
{
    public class PetroLife : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad;
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
            if (nextPhase != null)
            {
                nextPhase.SetActive(true);
                Destroy(gameObject);
            }
            else
                Invoke(nameof(TriggerGameOver), 2f);
        }
        private void TriggerGameOver()
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
