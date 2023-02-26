#if UNITY_EDITOR
using CodeBase.HexLib;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Core.Grid
{
    internal class GridEditorWindow : OdinMenuEditorWindow
    {
        private readonly SimpleTreeMenuEditor<TileData> _editor;

        private static ILayout _layout;
        private static Tile _model;
        private static HexGrid _hexGrid;
        private int SpriteRendererSorting;

        internal GridEditorWindow() =>
          _editor = new SimpleTreeMenuEditor<TileData>("Assets/Presets/Tiles", this);

        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = _editor.BuildMenuTree(header: "Tiles");
            tree.Add("Delete", GreadEditorDeleteOption.Instance);
            return tree;
        }


        protected override void OnBeginDrawEditors()
        {
            SirenixEditorGUI.BeginHorizontalToolbar(MenuTree.Config.SearchToolbarHeight);
            {
                SpriteRendererSorting = SirenixEditorFields.IntField("Sprite order", SpriteRendererSorting);
                _editor.OnBeginDrawEditors(MenuTree);
            }
            SirenixEditorGUI.EndHorizontalToolbar();
        }

        protected override void OnEnable()
        {
            _layout = new Layout(OrentationType.Flat, new Vector2(1, .75f), Vector2.zero);
            _model = AssetDatabase.LoadAssetAtPath<Tile>("Assets/Presets/Tiles/DefaultTile.prefab");
            _hexGrid = FindObjectOfType<HexGrid>();

            SceneView.duringSceneGui += OnSceneViewClick;
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            SceneView.duringSceneGui -= OnSceneViewClick;
            base.OnDisable();
        }

        [MenuItem("Tools/GridEditor")]
        private static void ShowWindow()
        {
            var window = GetWindow<GridEditorWindow>();
            window.titleContent = new GUIContent("Grid Editor");
            window.Show();
        }

        private void OnSceneViewClick(SceneView sceneView)
        {
            if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
            {
                if (_hexGrid == null)
                    _hexGrid = FindObjectOfType<HexGrid>() ?? throw new ArgumentNullException("Please place the object with the typeof(HexGrid) component on this scene");
                Vector2 mousePosition = Event.current.mousePosition;
                Camera sceneCamera = sceneView.camera;
                Vector3 worldPosition = sceneCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, sceneCamera.pixelHeight - mousePosition.y, sceneCamera.nearClipPlane));

                var hexCoord = _layout.PixelToHex(worldPosition);
                var tileData = GetSelected<object>();

                if (tileData is TileData tile)
                    PlaceTile(hexCoord, tile);
                else if (tileData is GreadEditorDeleteOption)
                    DeletTile(hexCoord);
            }
        }

        private void DeletTile(Hex hexCoord)
        {
            foreach (var tile in _hexGrid.GetTiles(hexCoord))
                DestroyImmediate(((Tile)tile).gameObject);
        }

        private void PlaceTile(Hex hexCoord, TileData tileData)
        {
            var tileCenter = _layout.HexToPixel(hexCoord);

            var tile = Instantiate(_model, tileCenter, Quaternion.identity);
            tile.Init(tileData, hexCoord, SpriteRendererSorting);
            tile.transform.parent = _hexGrid.transform;
        }

        private T GetSelected<T>() where T : class =>
            MenuTree.Selection.FirstOrDefault().Value as T;
    }

    internal class test
    { 
    }
}
#endif