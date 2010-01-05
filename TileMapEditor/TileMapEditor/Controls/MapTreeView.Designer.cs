﻿using Tiling;

namespace TileMapEditor.Control
{
    partial class MapTreeView
    {
        private System.Windows.Forms.TreeView m_treeView;
        private System.Windows.Forms.ImageList m_imageList;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label m_labelCaption;
            System.Windows.Forms.Panel m_treePanel;
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Layers");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Tile Sheets");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Map", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapTreeView));
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            this.m_treeView = new System.Windows.Forms.TreeView();
            this.m_imageList = new System.Windows.Forms.ImageList(this.components);
            this.m_layersContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_layerNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_layerPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerVisibilityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerBringForwardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerSendBackwardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mapContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_mapPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_tileSheetNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            m_labelCaption = new System.Windows.Forms.Label();
            m_treePanel = new System.Windows.Forms.Panel();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            m_treePanel.SuspendLayout();
            this.m_layersContextMenuStrip.SuspendLayout();
            this.m_layerContextMenuStrip.SuspendLayout();
            this.m_mapContextMenuStrip.SuspendLayout();
            this.m_tileSheetsContextMenuStrip.SuspendLayout();
            this.m_tileSheetContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_labelCaption
            // 
            m_labelCaption.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            m_labelCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            m_labelCaption.Dock = System.Windows.Forms.DockStyle.Top;
            m_labelCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            m_labelCaption.Location = new System.Drawing.Point(0, 0);
            m_labelCaption.Name = "m_labelCaption";
            m_labelCaption.Padding = new System.Windows.Forms.Padding(2);
            m_labelCaption.Size = new System.Drawing.Size(150, 20);
            m_labelCaption.TabIndex = 1;
            m_labelCaption.Text = "Map Explorer";
            m_labelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_treePanel
            // 
            m_treePanel.Controls.Add(this.m_treeView);
            m_treePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            m_treePanel.Location = new System.Drawing.Point(0, 20);
            m_treePanel.Name = "m_treePanel";
            m_treePanel.Size = new System.Drawing.Size(150, 130);
            m_treePanel.TabIndex = 2;
            // 
            // m_treeView
            // 
            this.m_treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_treeView.ImageIndex = 0;
            this.m_treeView.ImageList = this.m_imageList;
            this.m_treeView.Location = new System.Drawing.Point(0, 0);
            this.m_treeView.Name = "m_treeView";
            treeNode1.ImageKey = "LayerFolder.png";
            treeNode1.Name = "Layers";
            treeNode1.SelectedImageKey = "LayerFolder.png";
            treeNode1.Text = "Layers";
            treeNode2.ImageKey = "TileSheetFolder.png";
            treeNode2.Name = "TileSheets";
            treeNode2.SelectedImageKey = "TileSheetFolder.png";
            treeNode2.Text = "Tile Sheets";
            treeNode3.ImageKey = "Map.png";
            treeNode3.Name = "Map";
            treeNode3.SelectedImageKey = "Map.png";
            treeNode3.Text = "Map";
            this.m_treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.m_treeView.SelectedImageIndex = 0;
            this.m_treeView.Size = new System.Drawing.Size(150, 130);
            this.m_treeView.TabIndex = 0;
            this.m_treeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseClick);
            this.m_treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnAfterSelect);
            this.m_treeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.OnBeforeSelect);
            // 
            // m_imageList
            // 
            this.m_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imageList.ImageStream")));
            this.m_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imageList.Images.SetKeyName(0, "Map.png");
            this.m_imageList.Images.SetKeyName(1, "LayerFolder.png");
            this.m_imageList.Images.SetKeyName(2, "LayerVisible.png");
            this.m_imageList.Images.SetKeyName(3, "LayerInvisible.png");
            this.m_imageList.Images.SetKeyName(4, "TileSheetFolder.png");
            this.m_imageList.Images.SetKeyName(5, "TileSheet.png");
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(151, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // m_layersContextMenuStrip
            // 
            this.m_layersContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_layerNewMenuItem});
            this.m_layersContextMenuStrip.Name = "m_contextMenuLayers";
            this.m_layersContextMenuStrip.Size = new System.Drawing.Size(108, 26);
            // 
            // m_layerNewMenuItem
            // 
            this.m_layerNewMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerNew;
            this.m_layerNewMenuItem.Name = "m_layerNewMenuItem";
            this.m_layerNewMenuItem.Size = new System.Drawing.Size(107, 22);
            this.m_layerNewMenuItem.Text = "New...";
            this.m_layerNewMenuItem.Click += new System.EventHandler(this.OnLayerNew);
            // 
            // m_layerContextMenuStrip
            // 
            this.m_layerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_layerPropertiesMenuItem,
            this.m_layerVisibilityMenuItem,
            toolStripMenuItem1,
            this.m_layerBringForwardMenuItem,
            this.m_layerSendBackwardMenuItem,
            toolStripSeparator2,
            this.m_layerDeleteMenuItem});
            this.m_layerContextMenuStrip.Name = "m_contextMenuLayer";
            this.m_layerContextMenuStrip.Size = new System.Drawing.Size(155, 126);
            this.m_layerContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.OnContextMenuLayerOpening);
            // 
            // m_layerPropertiesMenuItem
            // 
            this.m_layerPropertiesMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerProperties;
            this.m_layerPropertiesMenuItem.Name = "m_layerPropertiesMenuItem";
            this.m_layerPropertiesMenuItem.Size = new System.Drawing.Size(154, 22);
            this.m_layerPropertiesMenuItem.Text = "Properties";
            this.m_layerPropertiesMenuItem.Click += new System.EventHandler(this.OnLayerProperties);
            // 
            // m_layerVisibilityMenuItem
            // 
            this.m_layerVisibilityMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerInvisible;
            this.m_layerVisibilityMenuItem.Name = "m_layerVisibilityMenuItem";
            this.m_layerVisibilityMenuItem.Size = new System.Drawing.Size(154, 22);
            this.m_layerVisibilityMenuItem.Text = "Make Invisible";
            this.m_layerVisibilityMenuItem.Click += new System.EventHandler(this.OnLayerVisibility);
            // 
            // m_layerBringForwardMenuItem
            // 
            this.m_layerBringForwardMenuItem.Enabled = false;
            this.m_layerBringForwardMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerBringForward;
            this.m_layerBringForwardMenuItem.Name = "m_layerBringForwardMenuItem";
            this.m_layerBringForwardMenuItem.Size = new System.Drawing.Size(154, 22);
            this.m_layerBringForwardMenuItem.Text = "Bring Forward";
            this.m_layerBringForwardMenuItem.Click += new System.EventHandler(this.OnLayerBringForward);
            // 
            // m_layerSendBackwardMenuItem
            // 
            this.m_layerSendBackwardMenuItem.Enabled = false;
            this.m_layerSendBackwardMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerSendBackward;
            this.m_layerSendBackwardMenuItem.Name = "m_layerSendBackwardMenuItem";
            this.m_layerSendBackwardMenuItem.Size = new System.Drawing.Size(154, 22);
            this.m_layerSendBackwardMenuItem.Text = "Send Backward";
            this.m_layerSendBackwardMenuItem.Click += new System.EventHandler(this.OnLayerSendBackward);
            // 
            // m_layerDeleteMenuItem
            // 
            this.m_layerDeleteMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerDelete;
            this.m_layerDeleteMenuItem.Name = "m_layerDeleteMenuItem";
            this.m_layerDeleteMenuItem.Size = new System.Drawing.Size(154, 22);
            this.m_layerDeleteMenuItem.Text = "Delete";
            this.m_layerDeleteMenuItem.Click += new System.EventHandler(this.OnLayerDelete);
            // 
            // m_mapContextMenuStrip
            // 
            this.m_mapContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mapPropertiesMenuItem});
            this.m_mapContextMenuStrip.Name = "m_contextMenuMap";
            this.m_mapContextMenuStrip.Size = new System.Drawing.Size(137, 26);
            // 
            // m_mapPropertiesMenuItem
            // 
            this.m_mapPropertiesMenuItem.Image = global::TileMapEditor.Properties.Resources.MapProperties;
            this.m_mapPropertiesMenuItem.Name = "m_mapPropertiesMenuItem";
            this.m_mapPropertiesMenuItem.Size = new System.Drawing.Size(136, 22);
            this.m_mapPropertiesMenuItem.Text = "Properties...";
            this.m_mapPropertiesMenuItem.Click += new System.EventHandler(this.OnMapProperties);
            // 
            // m_tileSheetsContextMenuStrip
            // 
            this.m_tileSheetsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tileSheetNewMenuItem});
            this.m_tileSheetsContextMenuStrip.Name = "m_tileSheetsContextMenuStrip";
            this.m_tileSheetsContextMenuStrip.Size = new System.Drawing.Size(108, 26);
            // 
            // m_tileSheetNewMenuItem
            // 
            this.m_tileSheetNewMenuItem.Image = global::TileMapEditor.Properties.Resources.TileSheetNew;
            this.m_tileSheetNewMenuItem.Name = "m_tileSheetNewMenuItem";
            this.m_tileSheetNewMenuItem.Size = new System.Drawing.Size(107, 22);
            this.m_tileSheetNewMenuItem.Text = "New...";
            this.m_tileSheetNewMenuItem.Click += new System.EventHandler(this.OnTileSheetNew);
            // 
            // m_tileSheetContextMenuStrip
            // 
            this.m_tileSheetContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem,
            toolStripSeparator1,
            this.deleteToolStripMenuItem});
            this.m_tileSheetContextMenuStrip.Name = "m_tileSheetContextMenuStrip";
            this.m_tileSheetContextMenuStrip.Size = new System.Drawing.Size(137, 54);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Image = global::TileMapEditor.Properties.Resources.TileSheetProperties;
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.propertiesToolStripMenuItem.Text = "Properties...";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.OnTileSheetProperties);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::TileMapEditor.Properties.Resources.TileSheetDelete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.OnTileSheetDelete);
            // 
            // MapTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(m_treePanel);
            this.Controls.Add(m_labelCaption);
            this.Name = "MapTreeView";
            m_treePanel.ResumeLayout(false);
            this.m_layersContextMenuStrip.ResumeLayout(false);
            this.m_layerContextMenuStrip.ResumeLayout(false);
            this.m_mapContextMenuStrip.ResumeLayout(false);
            this.m_tileSheetsContextMenuStrip.ResumeLayout(false);
            this.m_tileSheetContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip m_layersContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_layerNewMenuItem;
        private System.Windows.Forms.ContextMenuStrip m_layerContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_layerPropertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerBringForwardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerSendBackwardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerDeleteMenuItem;
        private System.Windows.Forms.ContextMenuStrip m_mapContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_mapPropertiesMenuItem;
        private System.Windows.Forms.ContextMenuStrip m_tileSheetsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetNewMenuItem;
        private System.Windows.Forms.ContextMenuStrip m_tileSheetContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerVisibilityMenuItem;


        #region Public Methods

        #endregion
    }
}