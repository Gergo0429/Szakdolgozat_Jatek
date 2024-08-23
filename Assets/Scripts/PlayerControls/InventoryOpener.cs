using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryOpener : MonoBehaviour
{
    private bool isOpen;
    private GameObject player;
    private GameObject inventoryPanel;
    private GameObject gameUICanvas;
    private GameObject interactables;

    void Start()
    {
        isOpen = false;
        inventoryPanel = transform.Find("InventoryPanel").gameObject;

        player = GameObject.Find("Player");
        gameUICanvas = GameObject.Find("GameUICanvas");
        interactables = GameObject.Find("Interactables");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOpen)
            {
                isOpen = false;
                inventoryPanel.SetActive(false);

                player.SetActive(true);
                gameUICanvas.SetActive(true);
                interactables.SetActive(true);

                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                isOpen = true;
                inventoryPanel.SetActive(true);

                SetBackground();

                player.SetActive(false);
                gameUICanvas.SetActive(false);
                interactables.SetActive(false);

                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    void SetBackground()
    {
        Texture2D screenshotTexture = ScreenCapture.CaptureScreenshotAsTexture();

        Sprite screenshotSprite = Sprite.Create(screenshotTexture, new Rect(0, 0, screenshotTexture.width, screenshotTexture.height), new Vector2(0.5f, 0.5f));

        inventoryPanel.GetComponent<Image>().sprite = screenshotSprite;
    }
}