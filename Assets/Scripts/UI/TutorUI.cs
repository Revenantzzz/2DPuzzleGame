using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TutorUI : MonoBehaviour
{
    [SerializeField] GameObject TextHasAxe;
    [SerializeField] GameObject TextNotHasAxe;
    [SerializeField] InteractButton interactButton;

    List<IPickableObject> PickableObjects => PlayerController.Instance.PickedObjectList;
    private void Start()
    {
        Initialize();
    }
    private void Initialize()
    {
        TextHasAxe.SetActive(false);
        this.gameObject.SetActive(true);
    }
    private void Update()
    {
        ChangeWhenHasAxe();
    }
    private void ChangeWhenHasAxe()
    {
        
        foreach(IPickableObject obj in PickableObjects)
        {
            if(obj is PickableAxe)
            {
                interactButton.EnableImage();
                TextNotHasAxe.SetActive(false);
                TextHasAxe.SetActive(true);
            }
        }      
    }
}
