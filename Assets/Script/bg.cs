using System.Collections; // IEnumerator için gerekli
using System.Collections.Generic;
using UnityEngine;

public class bg : MonoBehaviour
{
    public bool temasEdildimi;
    public GameObject towers;

    // Start is called before the first frame update
    void Start()
    {
        temasEdildimi = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (temasEdildimi)
        {
            StartCoroutine(YukarıAta()); // Coroutine başlat
            temasEdildimi = false;
        }
    }

    IEnumerator YukarıAta()
    {
        yield return new WaitForSeconds(1.5f); // saniye bekle
        transform.position = transform.position + new Vector3(0, 20.4f, 0);
        float xPoz = Random.Range(-0.85f, 0.85f);
        towers.transform.localPosition = new Vector3(xPoz, 0, 0);
    }
}
