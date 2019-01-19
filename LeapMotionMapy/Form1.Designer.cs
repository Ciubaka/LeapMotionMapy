namespace LeapMotionMapy
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.txtLong = new System.Windows.Forms.TextBox();
            this.btnLoadIntoMap = new System.Windows.Forms.Button();
            this.btnGetRoute = new System.Windows.Forms.Button();
            this.txtPrzyklad = new System.Windows.Forms.TextBox();
            this.lblDistance = new System.Windows.Forms.Label();
            this.btnAddPoly = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.mapZoomik = new System.Windows.Forms.Label();
            this.numberofDetectedHands = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1122, 953);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(1035, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 108);
            this.label1.TabIndex = 1;
            this.label1.Text = "Szerokość geograficzna";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(1035, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 101);
            this.label2.TabIndex = 2;
            this.label2.Text = "Długość geograficzna";
            // 
            // map
            // 
            this.map.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemmory = 5;
            this.map.Location = new System.Drawing.Point(0, 0);
            this.map.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 18;
            this.map.MinZoom = 2;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(1013, 953);
            this.map.TabIndex = 4;
            this.map.Zoom = 0D;
            this.map.MouseClick += new System.Windows.Forms.MouseEventHandler(this.map_MouseClick);
            // 
            // txtLat
            // 
            this.txtLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtLat.Location = new System.Drawing.Point(1295, 30);
            this.txtLat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(184, 44);
            this.txtLat.TabIndex = 5;
            // 
            // txtLong
            // 
            this.txtLong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtLong.Location = new System.Drawing.Point(1295, 138);
            this.txtLong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLong.Name = "txtLong";
            this.txtLong.Size = new System.Drawing.Size(184, 44);
            this.txtLong.TabIndex = 6;
            // 
            // btnLoadIntoMap
            // 
            this.btnLoadIntoMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadIntoMap.Location = new System.Drawing.Point(1042, 246);
            this.btnLoadIntoMap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoadIntoMap.Name = "btnLoadIntoMap";
            this.btnLoadIntoMap.Size = new System.Drawing.Size(197, 84);
            this.btnLoadIntoMap.TabIndex = 7;
            this.btnLoadIntoMap.Text = "Załaduj mapę";
            this.btnLoadIntoMap.UseVisualStyleBackColor = true;
            this.btnLoadIntoMap.Click += new System.EventHandler(this.btnLoadIntoMap_Click_1);
            // 
            // btnGetRoute
            // 
            this.btnGetRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetRoute.Location = new System.Drawing.Point(1042, 364);
            this.btnGetRoute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetRoute.Name = "btnGetRoute";
            this.btnGetRoute.Size = new System.Drawing.Size(197, 84);
            this.btnGetRoute.TabIndex = 8;
            this.btnGetRoute.Text = "Wyznacz trase";
            this.btnGetRoute.UseVisualStyleBackColor = true;
            this.btnGetRoute.Click += new System.EventHandler(this.btnGetRoute_Click);
            // 
            // txtPrzyklad
            // 
            this.txtPrzyklad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrzyklad.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPrzyklad.Location = new System.Drawing.Point(1054, 474);
            this.txtPrzyklad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrzyklad.Name = "txtPrzyklad";
            this.txtPrzyklad.Size = new System.Drawing.Size(184, 44);
            this.txtPrzyklad.TabIndex = 10;
            // 
            // lblDistance
            // 
            this.lblDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDistance.Location = new System.Drawing.Point(1288, 370);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(195, 78);
            this.lblDistance.TabIndex = 11;
            this.lblDistance.Text = "Dystans";
            // 
            // btnAddPoly
            // 
            this.btnAddPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPoly.Location = new System.Drawing.Point(1282, 246);
            this.btnAddPoly.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddPoly.Name = "btnAddPoly";
            this.btnAddPoly.Size = new System.Drawing.Size(197, 84);
            this.btnAddPoly.TabIndex = 12;
            this.btnAddPoly.Text = "Zaznacz pole";
            this.btnAddPoly.UseVisualStyleBackColor = true;
            this.btnAddPoly.Click += new System.EventHandler(this.btnAddPoly_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAll.Location = new System.Drawing.Point(1295, 474);
            this.btnRemoveAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(197, 84);
            this.btnRemoveAll.TabIndex = 13;
            this.btnRemoveAll.Text = "Wyczysc wszystko";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // mapZoomik
            // 
            this.mapZoomik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mapZoomik.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mapZoomik.Location = new System.Drawing.Point(1035, 615);
            this.mapZoomik.Name = "mapZoomik";
            this.mapZoomik.Size = new System.Drawing.Size(214, 84);
            this.mapZoomik.TabIndex = 14;
            this.mapZoomik.Text = "Zoom:";
            // 
            // numberofDetectedHands
            // 
            this.numberofDetectedHands.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numberofDetectedHands.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numberofDetectedHands.Location = new System.Drawing.Point(1297, 615);
            this.numberofDetectedHands.Name = "numberofDetectedHands";
            this.numberofDetectedHands.Size = new System.Drawing.Size(195, 112);
            this.numberofDetectedHands.TabIndex = 15;
            this.numberofDetectedHands.Text = "Liczba wykrytych rąk:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(1042, 775);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(450, 165);
            this.txtAddress.TabIndex = 16;
            this.txtAddress.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 953);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.numberofDetectedHands);
            this.Controls.Add(this.mapZoomik);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnAddPoly);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.txtPrzyklad);
            this.Controls.Add(this.btnGetRoute);
            this.Controls.Add(this.btnLoadIntoMap);
            this.Controls.Add(this.txtLong);
            this.Controls.Add(this.txtLat);
            this.Controls.Add(this.map);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitter1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "LeapMotionMapy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private GMap.NET.WindowsForms.GMapControl map;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.TextBox txtLong;
        private System.Windows.Forms.Button btnLoadIntoMap;
        private System.Windows.Forms.Button btnGetRoute;
        private System.Windows.Forms.TextBox txtPrzyklad;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Button btnAddPoly;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Label mapZoomik;
        private System.Windows.Forms.Label numberofDetectedHands;
        private System.Windows.Forms.RichTextBox txtAddress;

        #endregion

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

    }
}

