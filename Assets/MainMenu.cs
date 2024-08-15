using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Oyun oynamaya başlamak için bu fonksiyon çağrılır.
    public void PlayGame()
    {
        // Mevcut sahnenin build index'ine 1 ekleyerek bir sonraki sahneye geçer.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Oyundan çıkmak için bu fonksiyon çağrılır.
    public void QuitGame()
    {
        // Uygulamayı kapatır. Bu, Unity editöründe çalışmaz, yalnızca derlenmiş uygulamalarda çalışır.
        Application.Quit();

        // Unity editöründe çalışırken çıkışı test etmek için aşağıdaki satırı kullanabilirsiniz:
        // UnityEditor.EditorApplication.isPlaying = false;
    }

    // Ana menüye dönmek için bu fonksiyon çağrılır.
    public void HomeGame()
    {
        // İlk sahneye (ana menü sahnesi) geçer. Genellikle bu sahne build index 0'dır.
        SceneManager.LoadScene(0);
    }
}
