using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControler : MonoBehaviour
{
    public LevelPiece[] levelPieces;
    public Transform _camera;
    public int drawDistance;

    public float pieceLength;
    public float speed;

    Queue<GameObject> activePieces = new Queue<GameObject>();
    List<int> probabilityList = new List<int>();
    int currentCamPos = 0;
    int lastCamPos = 0;

    private void Start()
    {
        BuildProbabilityList();
        for (int i = 0; i < drawDistance; i++)
        {
            SpawnNewLevelPiece();
        }
        currentCamPos = (int)(_camera.transform.position.z / pieceLength);
        lastCamPos = currentCamPos;
    }
    private void Update()
    {
        //_camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _camera.transform.position + Vector3.forward, Time.deltaTime * speed);
        currentCamPos = (int)(_camera.transform.position.z / pieceLength);
        if (currentCamPos != lastCamPos) {
            lastCamPos = currentCamPos;
            DestroyLevelPiece();
            SpawnNewLevelPiece();
        }
    }
    void SpawnNewLevelPiece()
    {

        //float chance = Random.Range(1f,14f);
        //if (chance <= 10)
        //{
            int pieceIndex = probabilityList[Random.Range(0, probabilityList.Count)];

            GameObject newLevelPiece = Instantiate
                    (levelPieces[pieceIndex].prefab, new Vector3(0f, 0f, (currentCamPos + activePieces.Count) * pieceLength),
                    transform.rotation * Quaternion.identity);
            activePieces.Enqueue(newLevelPiece);
        /*}
        
        else if( chance <=11) {
            GameObject newLevelPiece = Instantiate
                    (levelPieces[1].prefab, new Vector3(0f, 0f, (currentCamPos + activePieces.Count) * pieceLength),
                    transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            activePieces.Enqueue(newLevelPiece);
        }
        else if (chance <= 12)
        {
            GameObject newLevelPiece = Instantiate
                    (levelPieces[2].prefab, new Vector3(0f, 0f, (currentCamPos + activePieces.Count) * pieceLength),
                    transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            activePieces.Enqueue(newLevelPiece);
        }
        else if (chance <= 13)
        {
            GameObject newLevelPiece = Instantiate
                    (levelPieces[3].prefab, new Vector3(0f, 0f, (currentCamPos + activePieces.Count) * pieceLength),
                    transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            activePieces.Enqueue(newLevelPiece);
        }
        else if (chance >= 14)
        {
            GameObject newLevelPiece = Instantiate
                    (levelPieces[4].prefab, new Vector3(0f, 0f, (currentCamPos + activePieces.Count) * pieceLength),
                    transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            activePieces.Enqueue(newLevelPiece);
        }*/
    }
    void DestroyLevelPiece() {
        GameObject oldLevelPiece = activePieces.Dequeue();
        Destroy(oldLevelPiece);
    }

    void BuildProbabilityList(){
        int index = 0;
        foreach (LevelPiece piece in levelPieces){
            for(int i =0; i < piece.probability; i++){
                probabilityList.Add(index);
            }
            index++;
        }  
    } 
}
    


[System.Serializable]
public class LevelPiece {

    public string name;
    public GameObject prefab;
    public int probability = 1;
}

