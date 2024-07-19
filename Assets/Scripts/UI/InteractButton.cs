using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    [SerializeField] Image axeImage;
    [SerializeField] TextMeshProUGUI pickText;
    private void Start()
    {
        axeImage.gameObject.SetActive(false);
        pickText.gameObject.SetActive(true);
    }
    private void Update()
    {
        EnableImage();
    }
    private void EnableImage()
    {
        if(axeImage == null)
        {
            return;
        }
        if(!axeImage.gameObject.activeSelf && PlayerController.Instance.HasAxe)
        {
            axeImage.gameObject.SetActive(true);
            pickText.gameObject.SetActive(false);
        }
    }
}
