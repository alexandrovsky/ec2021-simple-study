using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public enum InputMethod {
        Keys,
        Mouse,
    }

    public int score;
    public int collectedItems;
    public float speed = 3;
    public InputMethod inputMethod;

    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddScore(int points)
	{
        score += points;
        scoreText.text = $"Score: {score}";
        collectedItems += 1;

    }

    float KeysInput() {
        return Input.GetAxis("Horizontal");
    }

    float MouseInput()
    {
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        return (pos.x - 0.5f) * 2;
    }

    // Update is called once per frame
    void Update()
    {
        float dir = 0;
        if(inputMethod == InputMethod.Keys) {
            dir = KeysInput();
		} else {
            dir = MouseInput();

        }
        //print(dir);
        transform.Translate(Vector3.right * speed * dir * Time.deltaTime);
        Vector3 pos = transform.position;

        float minX = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        float maxX = Camera.main.ViewportToWorldPoint(Vector3.right).x;
        pos.x = Mathf.Clamp(pos.x, minX,maxX);

        transform.position = pos;
    }
}
