using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelViewer : MonoBehaviour
{
    public Text Name_UI;
    public float RotationSpeed = 5;
    public GameObject[] Models;
    public string[] Model_Names;
    GameObject CurrentModel;
    int modelIndex;

	// Use this for initialization
	void Start ()
    {
        modelIndex = 0;
        if (Models != null && Models.Length > 0)
        {
            // Hide All Model
            for (int i = 1; i < Models.Length; i++)
            {
                Models[i].SetActive(false);
            }

            // Show First Model
            ChangeModel(modelIndex);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!CurrentModel || Models.Length < 1)
            return;

        CurrentModel.transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            modelIndex--;
            if (modelIndex < 0)
                modelIndex = Models.Length - 1;

            ChangeModel(modelIndex);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            modelIndex++;
            if (modelIndex >= Models.Length)
                modelIndex = 0;

            ChangeModel(modelIndex);
        }
    }

    void ChangeModel(int index)
    {
        Quaternion rotation = Quaternion.identity;
        if (CurrentModel)
        {
            CurrentModel.SetActive(false);
            rotation = CurrentModel.transform.localRotation;
        }

        CurrentModel = Models[index];
        CurrentModel.SetActive(true);
        CurrentModel.transform.localRotation = rotation;

        if (Name_UI)
        {
            if(index < Model_Names.Length)
                Name_UI.text = Model_Names[index];
            else
                Name_UI.text = CurrentModel.name;
        }
    }
}
