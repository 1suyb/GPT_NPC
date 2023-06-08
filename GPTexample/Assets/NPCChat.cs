using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCChat : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI chatText;
    [SerializeField] GameObject backGround;
    void Start()
    {
        chatText = this.GetComponent<TextMeshProUGUI>();
    }

    public void setChat(string response)
    {
        Debug.Log(response);
        chatText.text = response;
        StartCoroutine("diminishChat");
    }
    IEnumerator diminishChat()
    {
        backGround.SetActive(true);
        chatText.enabled = true;
        yield return new WaitForSeconds(3f);
        chatText.enabled = false;
        backGround.SetActive(false);

    }
}
