using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TutorUI : MonoBehaviour
{
    [SerializeField] GameObject TextHasAxe;
    [SerializeField] GameObject TextNotHasAxe;
    [SerializeField] GameObject PlayerIcon;

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
        if(!PlayerController.Instance.HasAxe)
        {
            return;
        }
        TextNotHasAxe.SetActive(false);
        TextHasAxe.SetActive(true);
    }
}
