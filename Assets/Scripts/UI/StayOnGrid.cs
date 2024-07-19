using UnityEngine;

public class StayOnGrid : MonoBehaviour
{
    private void Start()
    {
        PostionOnGrid();
    }
    private void PostionOnGrid()
    {
        transform.position = new Vector3(ModifyValue(transform.position.x), ModifyValue(transform.position.y),0);
        
    }
    private float ModifyValue(float value)
    {
        float num = Mathf.Floor(value);
        return (num + 0.5f);
    }
}
