using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class LevelManager : MonoBehaviour
    {
        public void BotonStart()
        {
            SceneManager.LoadScene(1);
        }
        public void BotonOpcion()
        {
    
            Debug.Log("Opciones ajustadas");
        }
        public void BotonSalir()
        {
            Debug.Log("Salir del juego");
            Application.Quit();
        }

        public void RetryButton()
        {
            SceneManager.LoadScene(2);
        }
    }
}
