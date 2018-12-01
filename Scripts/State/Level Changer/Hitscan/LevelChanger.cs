using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;
    private int levelToLoad;

    public RaycastHit hit;
    public GameObject playerCamera;
    public GameObject playerHouseExitActionText;

    void Update () {
        if (Physics.Raycast(playerCamera.transform.position,
        playerCamera.transform.TransformDirection(Vector3.forward),
        out hit))
        {
            if (hit.distance <= 3.0 &&
                hit.collider.gameObject.tag == "LoadWoodsLevel")
            {
                playerHouseExitActionText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    FadeToLevel(2);
                }
            }
            else
            {
                playerHouseExitActionText.SetActive(false);
            }
        }
	}

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
