/*
    Filename: ChunkInteract.cs
    Developer: Ian King
    Purpose: Store chunk array and allow for object interaction with chunks.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    private List<Chunk> allChunks;

    public Chunk GetNextChunk(Vector2 pos){
        for(int i = 0; i < allChunks.Count; i++)
        {
            if(allChunks[i].GetPos().x > pos.x)
            {
                return allChunks[i];
            }
        }
        return null;
    }

    GameObject obj;
    Vector2 startPos;
    float width;
    float height;

    public Chunk(GameObject o, Vector2 p, float w, float h){
        obj = o;
        startPos = p;
        width = w;
        height = h;
    }    

    private Vector2 GetPos(){
        return startPos;
    }
}