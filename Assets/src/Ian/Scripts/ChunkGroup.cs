/*
    Filename: ChunkInteract.cs
    Developer: Ian King
    Purpose: Store chunk array and allow for object interaction with chunks.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChunkGroup : MonoBehaviour
{
    private List<ChunkGroup> allChunks;

    private GameObject obj;
    private Vector2 pos;
    private float width;
    private float height;

    public ChunkGroup GetNextChunk(Vector2 pos){
        for(int i = 0; i < allChunks.Count; i++)
        {
            if(allChunks[i].GetPos().x > pos.x)
            {
                return allChunks[i];
            }
        }
        return null;
    }

    public ChunkGroup GetCurChunk(Vector2 pos){
        for(int i = 0; i < allChunks.Count; i++)
        {
            if(allChunks[i-1].GetPos().x < pos.x && allChunks[i].GetPos().x > pos.x)
            {
                return allChunks[i];
            }
        }
        return null;
    }

    //Constructor for a basic ChunkGroup
    public ChunkGroup(GameObject o, Vector2 p, float w, float h){
        obj = o;
        pos = p;
        width = w;
        height = h;
        Instantiate(o, p, Quaternion.identity);
        allChunks.Add(this);
    }    

    public Vector2 GetPos(){
        return pos;
    }
}