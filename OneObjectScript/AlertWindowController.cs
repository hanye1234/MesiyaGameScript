using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertWindowController : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine("DisableItSelf");
    }

    IEnumerator DisableItSelf(){
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
