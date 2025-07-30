using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private float moveSpeedX = 1f;
    void Update()
    {
        Vector3 moveVector = new Vector3(moveSpeedX, 0,0);
        transform.position += moveVector * Time.deltaTime;
    }
}
