using System;
using UnityEditor;
using UnityEngine;


namespace NodeEditor.EditorExtension
{
    public class GraphEditorWindow : EditorWindow
    {
        private Rect win1;
        private Rect win2;
        
        [MenuItem("Tools/Graph Editor")]
        public static void OpenWindow()
        {
            var window = GetWindow<GraphEditorWindow>("Graph Editor");
            window.Show();
            window.Initialize();
        }

        private void Initialize()
        {
            win1 = new Rect(10, 10, 100, 50);
            win2 = new Rect(50, 10, 100, 50);
        }
        //main render loop
        private void OnGUI()
        {
            DrawNodeCurve(win1, win2);
            BeginWindows();
            win1 = GUI.Window(1, win1, DrawNodeWindow, "Window 1");   // Updates the Rect's when these are dragged
            win2 = GUI.Window(2, win2, DrawNodeWindow, "Window 2");
            EndWindows();
        }

        private void DrawNodeWindow(int id)
        {
            GUI.DragWindow();
        }

        private void DrawNodeCurve(Rect start, Rect end)
        {
            Vector3 startPos = new Vector3(start.x + start.width, start.y + start.height / 2, 0);
            Vector3 endPos = new Vector3(end.x, end.y + end.height / 2, 0);
            Vector3 startTan = startPos + Vector3.right * 50;
            Vector3 endTan = endPos + Vector3.left * 50;
            Color shadowCol = new Color(0, 0, 0, 0.06f);
            for (int i = 0; i < 3; i++) // Draw a shadow
                Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);
            Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.grey, null, 3);
        }
    }
}
