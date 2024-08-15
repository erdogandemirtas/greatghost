using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GhostScript : MonoBehaviour
{
    public float hiz;  // Hayaletin hareket hızı
    public int puan;  // Oyuncunun puanı
    public GameObject canvas;  // Oyun sonu ekranı
    public GameObject canvas1;  // Oyun içi ekran
    public AudioClip[] sesDosyalari;  // Ses dosyaları: 0 = puan alma sesi, 1 = oyun sonu sesi
    public Text rekor;  // Rekor puanı gösteren UI Text
    public Text puanText;  // Güncel puanı gösteren UI Text

    void Start()
    {
        // Başlangıçta oyun sonu ekranını kapat, oyun içi ekranı aç
        canvas.SetActive(false);
        canvas1.SetActive(true);
        puan = 0;  // Puanı sıfırla
        Time.timeScale = 1;  // Zamanı normal hızına ayarla
    }

    void Update()
    {
        // Hayaleti yukarı doğru hareket ettir
        transform.Translate(Vector3.up * hiz * Time.deltaTime);
    }

    void OnTriggerExit2D(Collider2D temas)
    {
        // Tetikleyici ile temas sona erdiğinde
        if (temas.gameObject.tag == "Tetik")
        {
            // Temas edilen nesnenin temasEdildimi özelliğini true yap
            temas.gameObject.transform.parent.root.gameObject.GetComponent<bg>().temasEdildimi = true;
            puan++;  // Puanı artır
            GetComponent<AudioSource>().PlayOneShot(sesDosyalari[0], 1);  // Puan alma sesini çal
        }
    }

    void OnCollisionEnter2D(Collision2D temas)
    {
        // Engel ile çarpışma durumunda
        if (temas.gameObject.tag == "Engel")
        {
            OyunSonu();  // Oyun sonu işlemlerini başlat
        }
    }

    void OyunSonu()
    {
        // Oyunu durdur
        Time.timeScale = 0;
        // Oyun sonu sesini çal
        GetComponent<AudioSource>().PlayOneShot(sesDosyalari[1], 1);
        // Oyun sonu ekranını aç, oyun içi ekranı kapat
        canvas.SetActive(true);
        canvas1.SetActive(false);

        // Eğer mevcut puan rekoru geçtiyse yeni rekoru kaydet
        if (puan > PlayerPrefs.GetInt("Rekor"))
        {
            PlayerPrefs.SetInt("Rekor", puan);
        }

        // Güncel puanı ve rekoru UI'da göster
        puanText.text = puan.ToString();
        rekor.text = PlayerPrefs.GetInt("Rekor").ToString();
    }

    public void TekrarButon()
    {
        // 1. sahneyi yeniden yükleyerek oyunu baştan başlat
        SceneManager.LoadScene(1);
    }
}
