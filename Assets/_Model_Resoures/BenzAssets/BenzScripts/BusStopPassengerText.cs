using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusStopPassengerText : MonoBehaviour
{
    //public Image PassengerStatusBG;
    public SpriteRenderer PassengerStatusBG;
    //public Text StatusText;
    public Text PassengerText;

    [Space]
    public int MaxPassenger = 8;
    public float pickUpDelay = 0.5f;

    int passengers;
    float counter;
    int remainingPassenger;

    [Space]
    public string availableText = "ว่าง";
    public string fullText = "เต็ม";
    public string placeText = "ที่";

    [Space]
    public Color availableColor = Color.white;
    public Color fullColor = Color.white;

    // Use this for initialization
    void Awake()
    {
        passengers = 0;
        PassengerText.text = availableText + " " + MaxPassenger.ToString() + " " + placeText;
        PassengerStatusBG.color = availableColor;
    }

    void Update()
    {
        if (remainingPassenger != 0)
        {
            counter += Time.deltaTime;
            if (counter >= pickUpDelay)
            {
                counter = 0;
                if (remainingPassenger > 0)
                {
                    AddPassenger(1);
                    remainingPassenger--;
                }
                else if (remainingPassenger < 0)
                {
                    RemovePassenger(1);
                    remainingPassenger++;
                }
            }
        }
    }

    public void AddPassenger(int value)
    {
        if (value == 0)
            return;

        passengers += Mathf.Abs(value);
        if (passengers > MaxPassenger)
        {
            passengers = MaxPassenger;
            //StatusText.text = "เต็ม";
        }

        if (passengers == MaxPassenger)
        {
            PassengerStatusBG.color = fullColor;
            PassengerText.text = fullText;
        }
        else
        {
            PassengerStatusBG.color = availableColor;
            PassengerText.text = availableText + " " + (MaxPassenger - passengers).ToString() + " " + placeText;
        }
    }

    public void RemovePassenger(int value)
    {
        if (value == 0)
            return;

        passengers -= Mathf.Abs(value);
        //StatusText.text = "ว่าง";
        if (passengers < 0)
        {
            passengers = 0;
        }

        PassengerStatusBG.color = availableColor;
        PassengerText.text = availableText + " " + (MaxPassenger - passengers).ToString() + " " + placeText;
    }

    public void AddPassengerOverTime(int value)
    {
        remainingPassenger = Mathf.Abs(value);
    }

    public void RemovePassengerOverTime(int value)
    {
        remainingPassenger = -Mathf.Abs(value);
    }

    public void SetTime(float value)
    {
        pickUpDelay = Mathf.Abs(value);
    }
}
