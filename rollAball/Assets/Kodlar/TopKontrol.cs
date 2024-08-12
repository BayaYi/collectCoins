using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    Rigidbody fizik;
    public int hiz;
    int sayac = 0;
    int obstacleCount = 0;
    public Text sayacText;
    public Text oyunBittiText;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Engel");
        obstacleCount = obstacles.Length;
        Debug.Log("Toplam Engel Sayýsý: " + obstacleCount);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yatay = Input.GetAxisRaw("Horizontal");
        float dikey = Input.GetAxisRaw("Vertical");

        Vector3 vec = new Vector3(yatay, 0, dikey);

        fizik.AddForce(vec*hiz);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Engel")
        {
            other.gameObject.SetActive(false);
            sayac++;
            sayacText.text = "Puan = " + sayac;
            if (sayac >= obstacleCount) 
            {
                oyunBittiText.text = "OYUN BÝTTÝ";
                fizik.isKinematic = true;
            }                
        }
    }
}
