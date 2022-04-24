using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace NodeEditor.EditorExtension
{
    public class GraphEditorWindow : EditorWindow
    {
        private Rect win1;
        private Rect win2;
        private Texture2D connectionCircleTex;

        private List<NodeGUI> nodeList;
        
        [MenuItem("Tools/Graph Editor")]
        public static void OpenWindow()
        {
            var window = GetWindow<GraphEditorWindow>("Graph Editor");
            window.Show();
            window.Initialize();
        }

        private void Initialize()
        {
            win1 = new Rect(10, 10, 100, 70);
            win2 = new Rect(200, 10, 100, 70);

            nodeList = new List<NodeGUI>();
            nodeList.Add(new NodeGUI(1,win1,"Win1") );
            nodeList.Add(new NodeGUI(2,win2,"Win2") );
            nodeList[0].SetConnection(nodeList[1]);
        }

        private void Awake()
        {
            LoadTextures();
        }

        private void LoadTextures()
        {
            connectionCircleTex = EditorGUIUtility.Load("Assets/dot.png") as Texture2D;
            if (connectionCircleTex != null)
            {
                Debug.Log("Load done");
            }
        }
        //main render loop
        private void OnGUI()
        {
            //DrawNodeCurve(win1, win2);
            BeginWindows();
            for (int i = 0; i < nodeList.Count; i++)
            {
                nodeList[i].DrawNode();
            }
            // var newRect = new Rect(win1.x + win1.width, win1.y+win1.height/2-20/2, 20, 20);
            // GUI.DrawTexture(newRect,connectionCircleTex);// Updates the Rect's when these are dragged
            EndWindows();
        }
        
        
    }
}
