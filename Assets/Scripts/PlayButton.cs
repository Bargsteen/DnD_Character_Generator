using UnityEngine;

public class PlayButton : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed!");
        }
        
    }

    public void OnPlayButtonClicked()
    {
        Debug.Log("Play Button clicked!");
    }
}
