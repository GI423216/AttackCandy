using System.Collections.Generic;
using UnityEngine;

public class cloud_Manager : MonoBehaviour
{
    public GameObject cloudParent;
    public GameObject cloud;

    public List<GameObject> clouds;
    private float time = 0;
    float spantime;

    void Update()
    {
        if (PlayerHP.playerHP > 0)
        {
            time += Time.deltaTime;
            if (time > spantime)
            {
                CloudCreate();
                spantime = Random.Range(0.5f, 1.5f);
            }
        }
        else
        {
            for (int i = clouds.Count - 1; i >= 0; i--)
            {
                if (clouds[i] != null)
                {
                    Destroy(clouds[i]);
                }
            }
            clouds.Clear();
        }
    }

    void CloudCreate()
    {
        if (cloud == null) return;

        Vector2 cloud_loc = cloudParent.transform.position;
        cloud_loc.y += Random.Range(-2, 1);
        GameObject clody = Instantiate(cloud, cloud_loc, Quaternion.identity);
        clody.transform.position = cloud_loc;
        clody.transform.parent = cloudParent.transform;

        float randomScale = Random.Range(0.09f, 0.15f);
        clody.transform.localScale = new Vector3(randomScale, randomScale);

        clody.transform.SetParent(cloudParent.transform);
        clouds.Add(clody);
        time = 0;
    }
}