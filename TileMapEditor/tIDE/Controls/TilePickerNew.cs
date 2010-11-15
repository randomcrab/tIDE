﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xTile.Tiles;
using xTile;
using System.IO;

namespace TileMapEditor.Controls
{
    public partial class TilePickerNew : UserControl
    {
        #region Public Methods

        public TilePickerNew()
        {
            InitializeComponent();

            m_autoUpdate = false;
            m_watchers = new Dictionary<TileSheet, FileSystemWatcher>();
            m_selectedTileIndex = -1;

            m_selectionBrush = new SolidBrush(Color.FromArgb(128, Color.SkyBlue));

            UpdateAvailableSize();
        }

        public void UpdatePicker()
        {
            if (m_map == null)
            {
                m_comboBoxTileSheets.Items.Clear();
                return;
            }

            string selectedItem = m_comboBoxTileSheets.SelectedItem == null
                ? null : m_comboBoxTileSheets.SelectedItem.ToString();
            m_comboBoxTileSheets.Items.Clear();
            foreach (TileSheet tileSheet in m_map.TileSheets)
                m_comboBoxTileSheets.Items.Add(tileSheet.Id);
            m_comboBoxTileSheets.SelectedItem = selectedItem;

            if (m_comboBoxTileSheets.Items.Count > 0)
                m_comboBoxTileSheets.SelectedIndex = 0;

            UpdateWatchers();

            m_tilePanel.Invalidate();
        }

        public void RefreshSelectedTileSheet()
        {
            if (m_comboBoxTileSheets.SelectedIndex < 0)
                m_tileSheet = null;
            else
            {
                string tileSheetId = m_comboBoxTileSheets.SelectedItem.ToString();
                m_tileSheet = m_map.GetTileSheet(tileSheetId);
            }

            m_tilePanel.Invalidate();

            /*
            // ensure tiles within 256 wide/high and preserve aspect ratio
            System.Drawing.Size tileSize = new System.Drawing.Size(
                m_tileSheet.TileSize.Width, m_tileSheet.TileSize.Height);
            int maxDimension = Math.Max(tileSize.Width, tileSize.Height);
            if (maxDimension > 256)
            {
                tileSize.Width = (tileSize.Width * 256) / maxDimension;
                tileSize.Height = (tileSize.Height * 256) / maxDimension;
            }*/
        }

        #endregion

        #region Public Properties

        public Map Map
        {
            get { return m_map; }
            set
            {
                m_map = value;
                UpdatePicker();
            }
        }

        public TileSheet SelectedTileSheet
        {
            get { return m_tileSheet; }
            set
            {
                if (m_tileSheet == value)
                    return;

                m_comboBoxTileSheets.SelectedIndex = m_map.TileSheets.IndexOf(value);
                OnSelectTileSheet(this, EventArgs.Empty);
            }
        }

        [Category("Behavior"),
         DefaultValue(-1),
         Description("The index of the selected tile")]
        public int SelectedTileIndex
        {
            get
            {
                return m_selectedTileIndex;
            }
            set
            {
                m_selectedTileIndex = value;
                m_tilePanel.Invalidate();

                //TODO ensure tile visible
            }
        }

        [Category("Behavior"),
         DefaultValue(false),
         Description("Automatically update tile sheets when they are updated on disk")]
        public bool AutoUpdate
        {
            get
            {
                return m_autoUpdate;
            }
            set
            {
                m_autoUpdate = value;
                UpdateWatchers();
            }
        }

        [Category("Behavior"),
         DefaultValue(false),
         Description("Prevents the user from switching tile sheets")]
        public bool LockTileSheet
        {
            get
            {
                return !m_comboBoxTileSheets.Enabled;
            }
            set
            {
                m_comboBoxTileSheets.Enabled = !value;
            }
        }

        #endregion

        #region Public Events

        [Category("Behavior"), Description("Occurs when the tile is selected")]
        public event TilePickerEventHandler TileSelected;

        #endregion

        #region Private Methods

        private void UpdateAvailableSize()
        {
            //TODO: depends on order mode

            m_availableWidth = m_tilePanel.ClientSize.Width;
            if (m_verticalScrollBar.Visible)
                m_availableWidth -= m_verticalScrollBar.Width;
            m_availableWidth = Math.Max(0, m_availableWidth);

            m_availableHeight = m_tilePanel.ClientSize.Height;
            if (m_verticalScrollBar.Visible)
                m_availableHeight -= m_verticalScrollBar.Height;
        }

        private int GetTileIndex(Point panelPosition)
        {
            if (m_tileSheet == null)
                return -1;

            if (m_verticalScrollBar.Visible)
                panelPosition.Y += m_verticalScrollBar.Value;

            int slotWidth = m_tileSheet.TileSize.Width + 1;
            int slotHeight = m_tileSheet.TileSize.Height + 1;

            int tileCount = m_tileSheet.TileCount;
            int tilesAcross = Math.Max(1, (m_availableWidth + 1) / slotWidth);
            int tilesDown = 1 + (tileCount - 1) / tilesAcross;

            int tileX = panelPosition.X / slotWidth;
            int tileY = panelPosition.Y / slotHeight;

            int tileIndex = tileY * tilesAcross + tileX;

            if (tileIndex >= tileCount)
                return -1;

            return tileIndex;
        }

        private void UpdateWatchers()
        {
            foreach (FileSystemWatcher fileSystemWatcher in m_watchers.Values)
                fileSystemWatcher.EnableRaisingEvents = false;
            m_watchers.Clear();

            if (!m_autoUpdate)
                return;

            foreach (TileSheet tileSheet in m_map.TileSheets)
            {
                string folder = Path.GetDirectoryName(tileSheet.ImageSource);
                string fileName = Path.GetFileName(tileSheet.ImageSource);
                FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(folder, fileName);
                m_watchers[tileSheet] = fileSystemWatcher;
                fileSystemWatcher.Changed += this.OnTileSheetImageSourceChanged;
                fileSystemWatcher.EnableRaisingEvents = true;
            }
        }

        private void OnSelectTileSheet(object sender, EventArgs eventArgs)
        {
            RefreshSelectedTileSheet();
        }

        private void OnVerticalScroll(object sender, ScrollEventArgs scrollEventArgs)
        {
            m_tilePanel.Invalidate();
        }

        private void OnTilePanelMouseDown(object sender, MouseEventArgs mouseEventArgs)
        {
            m_leftMouseDown = true;

            m_selectedTileIndex = GetTileIndex(mouseEventArgs.Location);
            if (m_selectedTileIndex >= 0)
            {
                if (TileSelected != null)
                    TileSelected(this,
                        new TilePickerEventArgs(m_tileSheet, m_selectedTileIndex));

                m_tilePanel.Invalidate();
            }
        }

        private void OnTilePanelMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.None)
            {
                int newHoverTileIndex = GetTileIndex(mouseEventArgs.Location);

                if (m_hoverTileIndex != newHoverTileIndex)
                {
                    m_hoverTileIndex = newHoverTileIndex;
                    m_tilePanel.Invalidate();
                }
            }
            else if (mouseEventArgs.Button == MouseButtons.Left)
            {
                if (m_tileSheet != null
                    && m_selectedTileIndex >= 0 && m_selectedTileIndex < m_tileSheet.TileCount)
                {
                    DoDragDrop(m_selectedTileIndex, DragDropEffects.All);
                }
            }
        }

        private void OnTilePanelMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {
            m_leftMouseDown = false;
        }

        private void OnDragGiveFeedback(object sender, GiveFeedbackEventArgs giveFeedbackEventArgs)
        {
            giveFeedbackEventArgs.UseDefaultCursors = false;
        }

        private void OnTileSheetImageSourceChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            foreach (TileSheet tileSheet in m_map.TileSheets)
                if (tileSheet.ImageSource == fileSystemEventArgs.FullPath)
                {
                    for (int tries = 0; tries < 10; tries++)
                    {
                        try
                        {
                            System.Threading.Thread.Sleep(10);
                            TileImageCache.Instance.Refresh(tileSheet);
                            break;
                        }
                        catch
                        {
                        }
                    }
                }

            this.Invoke(new MethodInvoker(UpdatePicker));
            this.Invoke(new MethodInvoker(RefreshSelectedTileSheet));
        }

        private void OnTilePanelPaint(object sender, PaintEventArgs paintEventArgs)
        {
            Graphics graphics = paintEventArgs.Graphics;

            if (m_tileSheet == null)
                return;

            TileImageCache tileImageCache = TileImageCache.Instance;

            int slotWidth = m_tileSheet.TileSize.Width + 1;
            int slotHeight = m_tileSheet.TileSize.Height + 1;
            int tilesAcross = Math.Max(1, (m_availableWidth + 1) / slotWidth);
            int tilesDown = 1 + (m_tileSheet.TileCount - 1) / tilesAcross;
            int scrollOffsetY = -m_verticalScrollBar.Value;
            for (int tileY = 0; tileY < tilesDown; tileY++)
            {
                for (int tileX = 0; tileX < tilesAcross; tileX++)
                {
                    int tileIndex = tileY * tilesAcross + tileX;
                    if (tileIndex >= m_tileSheet.TileCount)
                        break;
                    Bitmap tileBitmap = tileImageCache.GetTileBitmap(m_tileSheet, tileIndex);
                    graphics.DrawImageUnscaled(tileBitmap,
                        tileX * slotWidth, tileY * slotHeight + scrollOffsetY);

                    if (tileIndex == m_selectedTileIndex)
                    {
                        graphics.FillRectangle(m_selectionBrush,
                            tileX * slotWidth, tileY * slotHeight + scrollOffsetY,
                            slotWidth, slotHeight);
                        graphics.DrawRectangle(Pens.DarkCyan,
                            tileX * slotWidth - 1, tileY * slotHeight + scrollOffsetY - 1,
                            slotWidth, slotHeight);
                    }

                    if (tileIndex == m_hoverTileIndex)
                    {
                        graphics.DrawRectangle(Pens.Black,
                            tileX * slotWidth - 1, tileY * slotHeight + scrollOffsetY - 1,
                            slotWidth, slotHeight);
                    }
                }
            }

            int requiredHeight = tilesDown * slotHeight - 1;

            if (requiredHeight > m_availableHeight
                && !m_verticalScrollBar.Visible)
            {
                m_verticalScrollBar.Visible = true;
                m_verticalScrollBar.Maximum = requiredHeight;
                m_verticalScrollBar.LargeChange = m_tilePanel.ClientSize.Height;
                UpdateAvailableSize();
                m_tilePanel.Invalidate();
            }
            else if (requiredHeight <= m_availableHeight
                && m_verticalScrollBar.Visible)
            {
                m_verticalScrollBar.Visible = false;
                m_verticalScrollBar.Value = 0;
                UpdateAvailableSize();
                m_tilePanel.Invalidate();
            }
        }

        #endregion

        #region Private Fields

        private Map m_map;
        private TileSheet m_tileSheet;
        private bool m_autoUpdate;
        private Dictionary<TileSheet, FileSystemWatcher> m_watchers;
        private int m_hoverTileIndex;
        private int m_selectedTileIndex;

        private int m_availableWidth;
        private int m_availableHeight;

        private Brush m_selectionBrush;

        private bool m_leftMouseDown;

        #endregion
    }
}
