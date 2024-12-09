using UnityEngine;
using UnityEngine.SceneManagement;

namespace Petro
{
    public class PetroLife : MonoBehaviour
    {
        private static readonly int Death = Animator.StringToHash("Dead");
        [SerializeField] private string sceneToLoad;
        public int health=100;
        public int damagePlayer=10;
        public GameObject nextPhase;
        private Animator _animator;
        
        void Start()
        {
            _animator = GetComponent<Animator>();
        }

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
            _animator.SetTrigger(Death);
            if (nextPhase != null)
            {
                Invoke(nameof(NextPhase), 3f);
            }
            else
            {
                Invoke(nameof(TriggerGameOver), 2f);
            }
        }

        private void NextPhase()
        {
            nextPhase.SetActive(true);
            Destroy(gameObject);
        }
        private void TriggerGameOver()
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
