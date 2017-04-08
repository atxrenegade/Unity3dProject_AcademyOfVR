using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class submarine_controller : MonoBehaviour {
    public float speed;
    public float rotationSpeed;
    public CharacterController charControl;
    public Camera myCamera;
    public Transform artHolder;

    public Transform firePosition;
    public Transform torpedoPrefab;

    public Text uiText;
    int mineAmount;
    public static submarine_controller instance;
    public Transform minePrefab;
    public float minesToSpawn = 5;

    void Start()
    {
        instance = this;
        StartCoroutine(FadeText());

        for(int i = 0; i < minesToSpawn; i++)
        {
            Vector3 spawnPoint = Vector3.zero;
            spawnPoint.y = 25;
            spawnPoint.x = Random.Range(-150, 150);
            spawnPoint.z = Random.Range(-150, 150);
            RaycastHit hit;
            if (Physics.Raycast(spawnPoint, Vector3.up * -1, out hit))
            {
                spawnPoint.y = hit.point.y + Random.Range(0, 2.5f);
                Instantiate(minePrefab, spawnPoint, Quaternion.identity);
            }

        }
    }
    public void MineDestroyed()
    {
        mineAmount = GameObject.FindGameObjectsWithTag("Destroy").Length - 1;
        uiText.text = "Destroy " + mineAmount + " mines to win!";
        if (mineAmount < 1)
        {
            uiText.text = "You win!";
        }
        StartCoroutine(FadeText());
    }

    IEnumerator FadeText()
    {
        uiText.color = Color.white;
        yield return new WaitForSeconds(1);

        while (uiText.color.a > 0.05f)
        {
            uiText.color = Color.Lerp(uiText.color, new Color(1, 1, 1, 0), Time.deltaTime);
            yield return null;
        }
        uiText.color = new Color(1, 1, 1, 0);
    }
	// Update is called once per frame
	void Update () {
        
        charControl.Move(artHolder.forward * speed * Time.deltaTime);
        artHolder.rotation = Quaternion.Slerp(artHolder.rotation,
            myCamera.transform.rotation, Time.deltaTime * rotationSpeed);

        if(GvrViewer.Instance.Triggered)
        {
            Instantiate(torpedoPrefab, firePosition.position, artHolder.rotation);
        }

	}
}
