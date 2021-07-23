using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject textUI;
    public Transform Player;
    [SerializeField]
    private Shop ShopOutfits;
    public string[] lines;
    public float textSpeed;
    private bool isActive = false;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        textUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            if ((this.transform.position - Player.position).sqrMagnitude < 3f)
            {
                Debug.Log("PlayerIsNear");
            }
            if (((Player.position - this.transform.position).sqrMagnitude < 3) && Input.GetKeyDown("space"))
            {
                textUI.SetActive(true);
                StartDialogue();
                isActive = true;
            }
        } 
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else
        {
            isActive = false;
            textComponent.text = string.Empty;
            textUI.SetActive(false);
            ShopOutfits.Show();
        }
    }
}
