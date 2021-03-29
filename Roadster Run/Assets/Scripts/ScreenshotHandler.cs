using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
    private static ScreenshotHandler instance;
    public Camera myCamera;
    private bool photoable;
    public int width;
    public int height;

    private void Awake() {

        instance = this;
        //myCamera = gameObject.GetComponent<Camera>();
    }

    public void takeScreenshot() {
        TakeScreenshot_Instance(width,height);
    }

    private void OnPostRender() {
        if (photoable == true) {
            photoable = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/RoadsterPic.png",byteArray);
            Debug.Log("Saved Saved Image");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
    }

    private void takeImage(int width, int height) {

        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        photoable = true;
    }

    public static void TakeScreenshot_Instance(int width, int height) {
        instance.takeImage(width, height);
    }
}
