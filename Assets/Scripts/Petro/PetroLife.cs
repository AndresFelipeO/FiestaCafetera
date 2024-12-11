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
        private SoundManagerPetro _soundManager;
        private bool _isDead = false;
        
        void Start()
        {
            _animator = GetComponent<Animator>();
            _soundManager = FindObjectOfType<SoundManagerPetro>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("player_bullet")) return;
            TakeDamage(this.damagePlayer);
            Destroy(other.gameObject);
        }

        private void TakeDamage(int damage)
        {
            if (_isDead) return;
            health -= damage;
            if(health <= 0)
                DiePetro();
        }

        private void DiePetro()
        {
            if (_isDead) return; // Evitar múltiples llamadas
            _isDead = true; // Marca como muerto
            _soundManager.PlayDeathSound();
            _animator.SetTrigger(Death);
            if (nextPhase != null)
            {
                Invoke(nameof(NextPhase), 4f);
            }
            else
            {
                Invoke(nameof(TriggerGameOver), 4f);
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
