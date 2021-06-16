using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarEnergyBarScript : MonoBehaviour
{

    public Vector3 scale;
    public GameObject EnergyBar;
    public float Energy;
    public Text Energy_Text;
    public GameObject Next_Point;
    public float WaitBeforeClose;
    public float CloseCount;
    public GameObject DoneSound;
    public GameObject FillingSound;
    public float speed = 50;

    public void OnEnable()
    {
        this.transform.localScale = new Vector3(0, 0, 0);
        StartCoroutine(ScaleUp());
        Energy = 0;
        CloseCount = 0;
        Next_Point.SetActive(false);
        DoneSound.SetActive(false);
        FillingSound.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        EnergyBar.GetComponent<Image>().fillAmount = Energy / 100;
        Energy_Text.text = "" + (int)Energy + "%";
        if (Energy < 100)
        {
            Energy += Time.deltaTime * speed;
        }

        if (Energy >= 100)
        {
            DoneSound.SetActive(true);
            FillingSound.SetActive(false);
            if (CloseCount < WaitBeforeClose)
            {
                CloseCount += 1 * Time.deltaTime;
            }
            else
            {
                StartCoroutine(ScaleDown());
                Next_Point.SetActive(true);
                CloseCount = 0;
            }


        }
    }

    public IEnumerator ScaleUp()
    {
        yield return null;
        //this.SetActive(true);
        iTween.ScaleTo(gameObject, iTween.Hash("scale", scale, "time", 0.5f));

    }

    public IEnumerator ScaleDown()
    {

        iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.zero, "time", 0.5f));
        while (this.transform.localScale.magnitude != 0)
            yield return null;
        //this.SetActive(false);
    }
}
