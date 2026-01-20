using UnityEngine;

public class AttackBullet : MonoBehaviour
{
    public float balletSpeed = 4.0f;
    public float destroyXBoundary = 20f;

    private void FixedUpdate()
    {

        Vector2 pos = transform.position;

        pos.x += balletSpeed;
        transform.position = pos;
        float rotateZ = 50;

        this.transform.Rotate(new Vector3(0f, 0f, rotateZ) * Time.deltaTime * -10);
        if (pos.x >= destroyXBoundary)
        {
            Destroy(this.gameObject);
        }
    }
}