using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockWindSlash : MonoBehaviour
{
    [SerializeField] GameObject canvasUI;
    bool used;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.Instance.unlocked_WindSlash)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !used)
        {
            used = true;
            StartCoroutine(ShowUI());
        }
    }

    IEnumerator ShowUI()
    {
        canvasUI.SetActive(true);
        yield return new WaitForSeconds(3f);

        PlayerController.Instance.unlocked_WindSlash = true;
        SaveData.Instance.Save_PlayerData();
        canvasUI.SetActive(false);
        Destroy(gameObject);
    }
}
