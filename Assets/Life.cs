using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [SerializeField, Header("HP‰æ‘œ")]
    private Image image;
    int beforHP;
    private int hp = PlayerHP.playerHP;
    public Image[] h_img;
    int b;
    private void Start()
    {
        PlayerHP.playerHP = 5;
        LifeCount();
    }
    void Update()
    {
        HPicon();
    }
    private void LifeCount()
    {
        hp = PlayerHP.playerHP;

        if (hp != b)
        {
            for (int i = 0; i < hp; i++)
            {
                Instantiate(image, transform);
            }
            b = hp;
        }
    }
    private void HPicon()
    {
        Image[] icon = transform.GetComponentsInChildren<Image>();
        if (beforHP == PlayerHP.playerHP)
        {
            return;
        }
        else
        {
            for (int i = 0; i < icon.Length; i++)
            {
                icon[i].gameObject.SetActive(i < PlayerHP.playerHP);
            }
        }
    }
}