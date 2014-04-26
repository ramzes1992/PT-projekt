namespace CameraCapture
{
    partial class CameraCapture
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CamImageBox = new Emgu.CV.UI.ImageBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.RedLabel = new System.Windows.Forms.Label();
            this.redRMin = new System.Windows.Forms.TextBox();
            this.redRMax = new System.Windows.Forms.TextBox();
            this.redGMin = new System.Windows.Forms.TextBox();
            this.redGMax = new System.Windows.Forms.TextBox();
            this.redBMin = new System.Windows.Forms.TextBox();
            this.redBMax = new System.Windows.Forms.TextBox();
            this.buttonRedChange = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GreenLabel = new System.Windows.Forms.Label();
            this.greenRMin = new System.Windows.Forms.TextBox();
            this.greenRMax = new System.Windows.Forms.TextBox();
            this.greenGMin = new System.Windows.Forms.TextBox();
            this.greenGMax = new System.Windows.Forms.TextBox();
            this.greenBMin = new System.Windows.Forms.TextBox();
            this.greenBMax = new System.Windows.Forms.TextBox();
            this.yellowLabel = new System.Windows.Forms.Label();
            this.yellowRMin = new System.Windows.Forms.TextBox();
            this.yellowRMax = new System.Windows.Forms.TextBox();
            this.yellowGMin = new System.Windows.Forms.TextBox();
            this.yellowGMax = new System.Windows.Forms.TextBox();
            this.yellowBMin = new System.Windows.Forms.TextBox();
            this.yellowBMax = new System.Windows.Forms.TextBox();
            this.blueLabel = new System.Windows.Forms.Label();
            this.blueRMin = new System.Windows.Forms.TextBox();
            this.blueRMax = new System.Windows.Forms.TextBox();
            this.blueGMin = new System.Windows.Forms.TextBox();
            this.blueGMax = new System.Windows.Forms.TextBox();
            this.blueBMin = new System.Windows.Forms.TextBox();
            this.blueBMax = new System.Windows.Forms.TextBox();
            this.buttonGreenChange = new System.Windows.Forms.Button();
            this.buttonYellowChange = new System.Windows.Forms.Button();
            this.buttonBlueChange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CamImageBox
            // 
            this.CamImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CamImageBox.Location = new System.Drawing.Point(0, 0);
            this.CamImageBox.Name = "CamImageBox";
            this.CamImageBox.Size = new System.Drawing.Size(640, 480);
            this.CamImageBox.TabIndex = 2;
            this.CamImageBox.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(944, 296);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = " Start!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // RedLabel
            // 
            this.RedLabel.AutoSize = true;
            this.RedLabel.Location = new System.Drawing.Point(646, 38);
            this.RedLabel.Name = "RedLabel";
            this.RedLabel.Size = new System.Drawing.Size(27, 13);
            this.RedLabel.TabIndex = 4;
            this.RedLabel.Text = "Red";
            // 
            // redRMin
            // 
            this.redRMin.Location = new System.Drawing.Point(705, 21);
            this.redRMin.Name = "redRMin";
            this.redRMin.Size = new System.Drawing.Size(62, 20);
            this.redRMin.TabIndex = 5;
            this.redRMin.Text = "128";
            // 
            // redRMax
            // 
            this.redRMax.Location = new System.Drawing.Point(705, 47);
            this.redRMax.Name = "redRMax";
            this.redRMax.Size = new System.Drawing.Size(62, 20);
            this.redRMax.TabIndex = 6;
            this.redRMax.Text = "255";
            // 
            // redGMin
            // 
            this.redGMin.Location = new System.Drawing.Point(788, 21);
            this.redGMin.Name = "redGMin";
            this.redGMin.Size = new System.Drawing.Size(62, 20);
            this.redGMin.TabIndex = 7;
            this.redGMin.Text = "0";
            // 
            // redGMax
            // 
            this.redGMax.Location = new System.Drawing.Point(788, 47);
            this.redGMax.Name = "redGMax";
            this.redGMax.Size = new System.Drawing.Size(62, 20);
            this.redGMax.TabIndex = 8;
            this.redGMax.Text = "110";
            // 
            // redBMin
            // 
            this.redBMin.Location = new System.Drawing.Point(866, 21);
            this.redBMin.Name = "redBMin";
            this.redBMin.Size = new System.Drawing.Size(62, 20);
            this.redBMin.TabIndex = 9;
            this.redBMin.Text = "0";
            // 
            // redBMax
            // 
            this.redBMax.Location = new System.Drawing.Point(866, 47);
            this.redBMax.Name = "redBMax";
            this.redBMax.Size = new System.Drawing.Size(62, 20);
            this.redBMax.TabIndex = 10;
            this.redBMax.Text = "97";
            // 
            // buttonRedChange
            // 
            this.buttonRedChange.Location = new System.Drawing.Point(934, 21);
            this.buttonRedChange.Name = "buttonRedChange";
            this.buttonRedChange.Size = new System.Drawing.Size(95, 46);
            this.buttonRedChange.TabIndex = 11;
            this.buttonRedChange.Text = "Change";
            this.buttonRedChange.UseVisualStyleBackColor = true;
            this.buttonRedChange.Click += new System.EventHandler(this.buttonRedChange_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(725, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "R";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(809, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "G";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(888, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "B";
            // 
            // GreenLabel
            // 
            this.GreenLabel.AutoSize = true;
            this.GreenLabel.Location = new System.Drawing.Point(646, 102);
            this.GreenLabel.Name = "GreenLabel";
            this.GreenLabel.Size = new System.Drawing.Size(36, 13);
            this.GreenLabel.TabIndex = 15;
            this.GreenLabel.Text = "Green";
            this.GreenLabel.Click += new System.EventHandler(this.GreenLabel_Click);
            // 
            // greenRMin
            // 
            this.greenRMin.Location = new System.Drawing.Point(705, 86);
            this.greenRMin.Name = "greenRMin";
            this.greenRMin.Size = new System.Drawing.Size(62, 20);
            this.greenRMin.TabIndex = 16;
            this.greenRMin.Text = "0";
            // 
            // greenRMax
            // 
            this.greenRMax.Location = new System.Drawing.Point(705, 112);
            this.greenRMax.Name = "greenRMax";
            this.greenRMax.Size = new System.Drawing.Size(62, 20);
            this.greenRMax.TabIndex = 17;
            this.greenRMax.Text = "102";
            // 
            // greenGMin
            // 
            this.greenGMin.Location = new System.Drawing.Point(788, 86);
            this.greenGMin.Name = "greenGMin";
            this.greenGMin.Size = new System.Drawing.Size(62, 20);
            this.greenGMin.TabIndex = 18;
            this.greenGMin.Text = "128";
            // 
            // greenGMax
            // 
            this.greenGMax.Location = new System.Drawing.Point(788, 112);
            this.greenGMax.Name = "greenGMax";
            this.greenGMax.Size = new System.Drawing.Size(62, 20);
            this.greenGMax.TabIndex = 19;
            this.greenGMax.Text = "255";
            // 
            // greenBMin
            // 
            this.greenBMin.Location = new System.Drawing.Point(866, 86);
            this.greenBMin.Name = "greenBMin";
            this.greenBMin.Size = new System.Drawing.Size(62, 20);
            this.greenBMin.TabIndex = 20;
            this.greenBMin.Text = "0";
            // 
            // greenBMax
            // 
            this.greenBMax.Location = new System.Drawing.Point(866, 112);
            this.greenBMax.Name = "greenBMax";
            this.greenBMax.Size = new System.Drawing.Size(62, 20);
            this.greenBMax.TabIndex = 21;
            this.greenBMax.Text = "119";
            this.greenBMax.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // yellowLabel
            // 
            this.yellowLabel.AutoSize = true;
            this.yellowLabel.Location = new System.Drawing.Point(646, 171);
            this.yellowLabel.Name = "yellowLabel";
            this.yellowLabel.Size = new System.Drawing.Size(38, 13);
            this.yellowLabel.TabIndex = 22;
            this.yellowLabel.Text = "Yellow";
            // 
            // yellowRMin
            // 
            this.yellowRMin.Location = new System.Drawing.Point(705, 155);
            this.yellowRMin.Name = "yellowRMin";
            this.yellowRMin.Size = new System.Drawing.Size(62, 20);
            this.yellowRMin.TabIndex = 23;
            this.yellowRMin.Text = "194";
            // 
            // yellowRMax
            // 
            this.yellowRMax.Location = new System.Drawing.Point(705, 181);
            this.yellowRMax.Name = "yellowRMax";
            this.yellowRMax.Size = new System.Drawing.Size(62, 20);
            this.yellowRMax.TabIndex = 24;
            this.yellowRMax.Text = "255";
            // 
            // yellowGMin
            // 
            this.yellowGMin.Location = new System.Drawing.Point(788, 155);
            this.yellowGMin.Name = "yellowGMin";
            this.yellowGMin.Size = new System.Drawing.Size(62, 20);
            this.yellowGMin.TabIndex = 25;
            this.yellowGMin.Text = "165";
            // 
            // yellowGMax
            // 
            this.yellowGMax.Location = new System.Drawing.Point(788, 181);
            this.yellowGMax.Name = "yellowGMax";
            this.yellowGMax.Size = new System.Drawing.Size(62, 20);
            this.yellowGMax.TabIndex = 26;
            this.yellowGMax.Text = "240";
            // 
            // yellowBMin
            // 
            this.yellowBMin.Location = new System.Drawing.Point(866, 155);
            this.yellowBMin.Name = "yellowBMin";
            this.yellowBMin.Size = new System.Drawing.Size(62, 20);
            this.yellowBMin.TabIndex = 27;
            this.yellowBMin.Text = "32";
            // 
            // yellowBMax
            // 
            this.yellowBMax.Location = new System.Drawing.Point(866, 181);
            this.yellowBMax.Name = "yellowBMax";
            this.yellowBMax.Size = new System.Drawing.Size(62, 20);
            this.yellowBMax.TabIndex = 28;
            this.yellowBMax.Text = "140";
            // 
            // blueLabel
            // 
            this.blueLabel.AutoSize = true;
            this.blueLabel.Location = new System.Drawing.Point(646, 229);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(28, 13);
            this.blueLabel.TabIndex = 29;
            this.blueLabel.Text = "Blue";
            // 
            // blueRMin
            // 
            this.blueRMin.Location = new System.Drawing.Point(705, 229);
            this.blueRMin.Name = "blueRMin";
            this.blueRMin.Size = new System.Drawing.Size(62, 20);
            this.blueRMin.TabIndex = 30;
            this.blueRMin.Text = "0";
            // 
            // blueRMax
            // 
            this.blueRMax.Location = new System.Drawing.Point(705, 255);
            this.blueRMax.Name = "blueRMax";
            this.blueRMax.Size = new System.Drawing.Size(62, 20);
            this.blueRMax.TabIndex = 31;
            this.blueRMax.Text = "65";
            // 
            // blueGMin
            // 
            this.blueGMin.Location = new System.Drawing.Point(788, 229);
            this.blueGMin.Name = "blueGMin";
            this.blueGMin.Size = new System.Drawing.Size(62, 20);
            this.blueGMin.TabIndex = 32;
            this.blueGMin.Text = "0";
            // 
            // blueGMax
            // 
            this.blueGMax.Location = new System.Drawing.Point(788, 255);
            this.blueGMax.Name = "blueGMax";
            this.blueGMax.Size = new System.Drawing.Size(62, 20);
            this.blueGMax.TabIndex = 33;
            this.blueGMax.Text = "105";
            // 
            // blueBMin
            // 
            this.blueBMin.Location = new System.Drawing.Point(866, 229);
            this.blueBMin.Name = "blueBMin";
            this.blueBMin.Size = new System.Drawing.Size(62, 20);
            this.blueBMin.TabIndex = 34;
            this.blueBMin.Text = "70";
            // 
            // blueBMax
            // 
            this.blueBMax.Location = new System.Drawing.Point(866, 255);
            this.blueBMax.Name = "blueBMax";
            this.blueBMax.Size = new System.Drawing.Size(62, 20);
            this.blueBMax.TabIndex = 35;
            this.blueBMax.Text = "255";
            // 
            // buttonGreenChange
            // 
            this.buttonGreenChange.Location = new System.Drawing.Point(934, 86);
            this.buttonGreenChange.Name = "buttonGreenChange";
            this.buttonGreenChange.Size = new System.Drawing.Size(95, 46);
            this.buttonGreenChange.TabIndex = 36;
            this.buttonGreenChange.Text = "Change";
            this.buttonGreenChange.UseVisualStyleBackColor = true;
            this.buttonGreenChange.Click += new System.EventHandler(this.buttonGreenChange_Click);
            // 
            // buttonYellowChange
            // 
            this.buttonYellowChange.Location = new System.Drawing.Point(934, 155);
            this.buttonYellowChange.Name = "buttonYellowChange";
            this.buttonYellowChange.Size = new System.Drawing.Size(95, 46);
            this.buttonYellowChange.TabIndex = 37;
            this.buttonYellowChange.Text = "Change";
            this.buttonYellowChange.UseVisualStyleBackColor = true;
            this.buttonYellowChange.Click += new System.EventHandler(this.buttonYellowChange_Click);
            // 
            // buttonBlueChange
            // 
            this.buttonBlueChange.Location = new System.Drawing.Point(934, 229);
            this.buttonBlueChange.Name = "buttonBlueChange";
            this.buttonBlueChange.Size = new System.Drawing.Size(95, 46);
            this.buttonBlueChange.TabIndex = 38;
            this.buttonBlueChange.Text = "Change";
            this.buttonBlueChange.UseVisualStyleBackColor = true;
            this.buttonBlueChange.Click += new System.EventHandler(this.buttonBlueChange_Click);
            // 
            // CameraCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 490);
            this.Controls.Add(this.buttonBlueChange);
            this.Controls.Add(this.buttonYellowChange);
            this.Controls.Add(this.buttonGreenChange);
            this.Controls.Add(this.blueBMax);
            this.Controls.Add(this.blueBMin);
            this.Controls.Add(this.blueGMax);
            this.Controls.Add(this.blueGMin);
            this.Controls.Add(this.blueRMax);
            this.Controls.Add(this.blueRMin);
            this.Controls.Add(this.blueLabel);
            this.Controls.Add(this.yellowBMax);
            this.Controls.Add(this.yellowBMin);
            this.Controls.Add(this.yellowGMax);
            this.Controls.Add(this.yellowGMin);
            this.Controls.Add(this.yellowRMax);
            this.Controls.Add(this.yellowRMin);
            this.Controls.Add(this.yellowLabel);
            this.Controls.Add(this.greenBMax);
            this.Controls.Add(this.greenBMin);
            this.Controls.Add(this.greenGMax);
            this.Controls.Add(this.greenGMin);
            this.Controls.Add(this.greenRMax);
            this.Controls.Add(this.greenRMin);
            this.Controls.Add(this.GreenLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRedChange);
            this.Controls.Add(this.redBMax);
            this.Controls.Add(this.redBMin);
            this.Controls.Add(this.redGMax);
            this.Controls.Add(this.redGMin);
            this.Controls.Add(this.redRMax);
            this.Controls.Add(this.redRMin);
            this.Controls.Add(this.RedLabel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.CamImageBox);
            this.Name = "CameraCapture";
            this.Text = "CameraCapture";
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox CamImageBox;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label RedLabel;
        private System.Windows.Forms.TextBox redRMin;
        private System.Windows.Forms.TextBox redRMax;
        private System.Windows.Forms.TextBox redGMin;
        private System.Windows.Forms.TextBox redGMax;
        private System.Windows.Forms.TextBox redBMin;
        private System.Windows.Forms.TextBox redBMax;
        private System.Windows.Forms.Button buttonRedChange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label GreenLabel;
        private System.Windows.Forms.TextBox greenRMin;
        private System.Windows.Forms.TextBox greenRMax;
        private System.Windows.Forms.TextBox greenGMin;
        private System.Windows.Forms.TextBox greenGMax;
        private System.Windows.Forms.TextBox greenBMin;
        private System.Windows.Forms.TextBox greenBMax;
        private System.Windows.Forms.Label yellowLabel;
        private System.Windows.Forms.TextBox yellowRMin;
        private System.Windows.Forms.TextBox yellowRMax;
        private System.Windows.Forms.TextBox yellowGMin;
        private System.Windows.Forms.TextBox yellowGMax;
        private System.Windows.Forms.TextBox yellowBMin;
        private System.Windows.Forms.TextBox yellowBMax;
        private System.Windows.Forms.Label blueLabel;
        private System.Windows.Forms.TextBox blueRMin;
        private System.Windows.Forms.TextBox blueRMax;
        private System.Windows.Forms.TextBox blueGMin;
        private System.Windows.Forms.TextBox blueGMax;
        private System.Windows.Forms.TextBox blueBMin;
        private System.Windows.Forms.TextBox blueBMax;
        private System.Windows.Forms.Button buttonGreenChange;
        private System.Windows.Forms.Button buttonYellowChange;
        private System.Windows.Forms.Button buttonBlueChange;
    }
}

