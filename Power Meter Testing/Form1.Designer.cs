using System;

namespace Power_Meter_Testing
{
    public partial class frmTester
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
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTester));
            this.tabNotes = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.grpInstruct = new System.Windows.Forms.GroupBox();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.ThorlabsLogo = new System.Windows.Forms.PictureBox();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBaseD1 = new System.Windows.Forms.TextBox();
            this.txtBaseD2 = new System.Windows.Forms.TextBox();
            this.txtBaseRatio = new System.Windows.Forms.TextBox();
            this.txtSampD1 = new System.Windows.Forms.TextBox();
            this.txtSampD2 = new System.Windows.Forms.TextBox();
            this.txtSampRatio = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtSampPerc = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lblDet1 = new System.Windows.Forms.Label();
            this.lblSampleAvg = new System.Windows.Forms.Label();
            this.lblDet2 = new System.Windows.Forms.Label();
            this.lblBaseAvg = new System.Windows.Forms.Label();
            this.lblD1D2 = new System.Windows.Forms.Label();
            this.lblPerc = new System.Windows.Forms.Label();
            this.grpInputs = new System.Windows.Forms.GroupBox();
            this.cmdRefFile = new System.Windows.Forms.Button();
            this.txtTargetOD = new System.Windows.Forms.TextBox();
            this.txtWavelength = new System.Windows.Forms.TextBox();
            this.lblWavelength = new System.Windows.Forms.Label();
            this.lblNm = new System.Windows.Forms.Label();
            this.lblTargetOD = new System.Windows.Forms.Label();
            this.lblNegTol = new System.Windows.Forms.Label();
            this.txtPosTol = new System.Windows.Forms.TextBox();
            this.txtNegTol = new System.Windows.Forms.TextBox();
            this.lvlPosTol = new System.Windows.Forms.Label();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FailNotice = new System.Windows.Forms.Button();
            this.PassNotice = new System.Windows.Forms.Button();
            this.txtResultOD = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblNegResultUncert = new System.Windows.Forms.Label();
            this.lblResultOD = new System.Windows.Forms.Label();
            this.lblPosResultUncert = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.grpProgControl = new System.Windows.Forms.GroupBox();
            this.lblClearForms = new System.Windows.Forms.Label();
            this.cmdClearForms = new System.Windows.Forms.Button();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdViewFile = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblTestNum = new System.Windows.Forms.Label();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.lblDeviceStatus = new System.Windows.Forms.Label();
            this.txtTestNum = new System.Windows.Forms.TextBox();
            this.txtExportStatus = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblExportStatus = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTimedMeas = new System.Windows.Forms.TextBox();
            this.lblIntSet = new System.Windows.Forms.Label();
            this.lblPerSec = new System.Windows.Forms.Label();
            this.lblApprox = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTimeEst = new System.Windows.Forms.TextBox();
            this.lblStepAvg = new System.Windows.Forms.Label();
            this.chkIntSet = new System.Windows.Forms.CheckBox();
            this.txtTimeSetCheck = new System.Windows.Forms.TextBox();
            this.lblCountExplain = new System.Windows.Forms.Label();
            this.lblIntWarn = new System.Windows.Forms.Label();
            this.lblSampleCountSet = new System.Windows.Forms.Label();
            this.lblBaseCountSet = new System.Windows.Forms.Label();
            this.txtIntSetCheck = new System.Windows.Forms.TextBox();
            this.txtBaseCountNum = new System.Windows.Forms.TextBox();
            this.txtIntSet = new System.Windows.Forms.TextBox();
            this.txtSampCountNum = new System.Windows.Forms.TextBox();
            this.chkTimedMeas = new System.Windows.Forms.CheckBox();
            this.lblSampleCountNum = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblBaseCountNum = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtD1Name = new System.Windows.Forms.TextBox();
            this.lblD1Name = new System.Windows.Forms.Label();
            this.lblD2Name = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtD2Name = new System.Windows.Forms.TextBox();
            this.txtFlippperSerial = new System.Windows.Forms.TextBox();
            this.lblFlipperSerial = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLogLoc = new System.Windows.Forms.TextBox();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.lblFolder = new System.Windows.Forms.Label();
            this.cmdViewLog = new System.Windows.Forms.Button();
            this.cmdChooseLog = new System.Windows.Forms.Button();
            this.cmdViewFolder = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lblPathInfo = new System.Windows.Forms.Label();
            this.lblLogLoc = new System.Windows.Forms.Label();
            this.cmdChooseFolder = new System.Windows.Forms.Button();
            this.tabMotion = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdChangePosition = new System.Windows.Forms.Button();
            this.txtCurrentPosition = new System.Windows.Forms.TextBox();
            this.lblCurrentPosition = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdExit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabNotes.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.grpInstruct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThorlabsLogo)).BeginInit();
            this.grpData.SuspendLayout();
            this.grpInputs.SuspendLayout();
            this.grpResults.SuspendLayout();
            this.grpProgControl.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabMotion.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabNotes
            // 
            this.tabNotes.Controls.Add(this.tabMain);
            this.tabNotes.Controls.Add(this.tabSettings);
            this.tabNotes.Controls.Add(this.tabMotion);
            this.tabNotes.Controls.Add(this.tabPage1);
            this.tabNotes.Location = new System.Drawing.Point(1, -3);
            this.tabNotes.Name = "tabNotes";
            this.tabNotes.SelectedIndex = 0;
            this.tabNotes.Size = new System.Drawing.Size(589, 494);
            this.tabNotes.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.grpInstruct);
            this.tabMain.Controls.Add(this.ThorlabsLogo);
            this.tabMain.Controls.Add(this.grpData);
            this.tabMain.Controls.Add(this.grpInputs);
            this.tabMain.Controls.Add(this.grpResults);
            this.tabMain.Controls.Add(this.grpProgControl);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(581, 468);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // grpInstruct
            // 
            this.grpInstruct.Controls.Add(this.lblInstructions);
            this.grpInstruct.Location = new System.Drawing.Point(370, 3);
            this.grpInstruct.Name = "grpInstruct";
            this.grpInstruct.Size = new System.Drawing.Size(198, 140);
            this.grpInstruct.TabIndex = 149;
            this.grpInstruct.TabStop = false;
            this.grpInstruct.Text = "Instructions";
            // 
            // lblInstructions
            // 
            this.lblInstructions.Location = new System.Drawing.Point(9, 16);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(185, 93);
            this.lblInstructions.TabIndex = 0;
            this.lblInstructions.Text = "Place instructions here when you actually have any";
            // 
            // ThorlabsLogo
            // 
            this.ThorlabsLogo.Image = ((System.Drawing.Image)(resources.GetObject("ThorlabsLogo.Image")));
            this.ThorlabsLogo.Location = new System.Drawing.Point(501, 365);
            this.ThorlabsLogo.Name = "ThorlabsLogo";
            this.ThorlabsLogo.Size = new System.Drawing.Size(67, 94);
            this.ThorlabsLogo.TabIndex = 148;
            this.ThorlabsLogo.TabStop = false;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.label15);
            this.grpData.Controls.Add(this.txtBaseD1);
            this.grpData.Controls.Add(this.txtBaseD2);
            this.grpData.Controls.Add(this.txtBaseRatio);
            this.grpData.Controls.Add(this.txtSampD1);
            this.grpData.Controls.Add(this.txtSampD2);
            this.grpData.Controls.Add(this.txtSampRatio);
            this.grpData.Controls.Add(this.Label4);
            this.grpData.Controls.Add(this.txtSampPerc);
            this.grpData.Controls.Add(this.Label6);
            this.grpData.Controls.Add(this.Label2);
            this.grpData.Controls.Add(this.Label3);
            this.grpData.Controls.Add(this.lblDet1);
            this.grpData.Controls.Add(this.lblSampleAvg);
            this.grpData.Controls.Add(this.lblDet2);
            this.grpData.Controls.Add(this.lblBaseAvg);
            this.grpData.Controls.Add(this.lblD1D2);
            this.grpData.Controls.Add(this.lblPerc);
            this.grpData.Location = new System.Drawing.Point(7, 221);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(561, 119);
            this.grpData.TabIndex = 147;
            this.grpData.TabStop = false;
            this.grpData.Text = "Program Data";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(491, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 13);
            this.label15.TabIndex = 124;
            this.label15.Text = "%";
            // 
            // txtBaseD1
            // 
            this.txtBaseD1.Enabled = false;
            this.txtBaseD1.Location = new System.Drawing.Point(107, 29);
            this.txtBaseD1.Name = "txtBaseD1";
            this.txtBaseD1.Size = new System.Drawing.Size(100, 20);
            this.txtBaseD1.TabIndex = 99;
            this.txtBaseD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBaseD1.TextChanged += new System.EventHandler(this.txtBaseD1_TextChanged);
            // 
            // txtBaseD2
            // 
            this.txtBaseD2.Enabled = false;
            this.txtBaseD2.Location = new System.Drawing.Point(236, 29);
            this.txtBaseD2.Name = "txtBaseD2";
            this.txtBaseD2.Size = new System.Drawing.Size(113, 20);
            this.txtBaseD2.TabIndex = 100;
            this.txtBaseD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBaseRatio
            // 
            this.txtBaseRatio.Enabled = false;
            this.txtBaseRatio.Location = new System.Drawing.Point(377, 30);
            this.txtBaseRatio.Name = "txtBaseRatio";
            this.txtBaseRatio.Size = new System.Drawing.Size(113, 20);
            this.txtBaseRatio.TabIndex = 101;
            this.txtBaseRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSampD1
            // 
            this.txtSampD1.Enabled = false;
            this.txtSampD1.Location = new System.Drawing.Point(107, 55);
            this.txtSampD1.Name = "txtSampD1";
            this.txtSampD1.Size = new System.Drawing.Size(100, 20);
            this.txtSampD1.TabIndex = 103;
            this.txtSampD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSampD2
            // 
            this.txtSampD2.Enabled = false;
            this.txtSampD2.Location = new System.Drawing.Point(236, 55);
            this.txtSampD2.Name = "txtSampD2";
            this.txtSampD2.Size = new System.Drawing.Size(113, 20);
            this.txtSampD2.TabIndex = 104;
            this.txtSampD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSampRatio
            // 
            this.txtSampRatio.Enabled = false;
            this.txtSampRatio.Location = new System.Drawing.Point(377, 55);
            this.txtSampRatio.Name = "txtSampRatio";
            this.txtSampRatio.Size = new System.Drawing.Size(113, 20);
            this.txtSampRatio.TabIndex = 105;
            this.txtSampRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(349, 59);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(26, 13);
            this.Label4.TabIndex = 123;
            this.Label4.Text = "mW";
            // 
            // txtSampPerc
            // 
            this.txtSampPerc.Enabled = false;
            this.txtSampPerc.Location = new System.Drawing.Point(377, 81);
            this.txtSampPerc.Name = "txtSampPerc";
            this.txtSampPerc.Size = new System.Drawing.Size(113, 20);
            this.txtSampPerc.TabIndex = 106;
            this.txtSampPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(349, 33);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(26, 13);
            this.Label6.TabIndex = 121;
            this.Label6.Text = "mW";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(207, 59);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(26, 13);
            this.Label2.TabIndex = 120;
            this.Label2.Text = "mW";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(207, 33);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(26, 13);
            this.Label3.TabIndex = 118;
            this.Label3.Text = "mW";
            // 
            // lblDet1
            // 
            this.lblDet1.AutoSize = true;
            this.lblDet1.Location = new System.Drawing.Point(98, 11);
            this.lblDet1.Name = "lblDet1";
            this.lblDet1.Size = new System.Drawing.Size(119, 13);
            this.lblDet1.TabIndex = 111;
            this.lblDet1.Text = "Detector 1 (Reference):";
            // 
            // lblSampleAvg
            // 
            this.lblSampleAvg.AutoSize = true;
            this.lblSampleAvg.Location = new System.Drawing.Point(17, 58);
            this.lblSampleAvg.Name = "lblSampleAvg";
            this.lblSampleAvg.Size = new System.Drawing.Size(88, 13);
            this.lblSampleAvg.TabIndex = 117;
            this.lblSampleAvg.Text = "Sample Average:";
            // 
            // lblDet2
            // 
            this.lblDet2.AutoSize = true;
            this.lblDet2.Location = new System.Drawing.Point(240, 11);
            this.lblDet2.Name = "lblDet2";
            this.lblDet2.Size = new System.Drawing.Size(104, 13);
            this.lblDet2.TabIndex = 112;
            this.lblDet2.Text = "Detector 2 (Sample):";
            // 
            // lblBaseAvg
            // 
            this.lblBaseAvg.AutoSize = true;
            this.lblBaseAvg.Location = new System.Drawing.Point(12, 32);
            this.lblBaseAvg.Name = "lblBaseAvg";
            this.lblBaseAvg.Size = new System.Drawing.Size(93, 13);
            this.lblBaseAvg.TabIndex = 116;
            this.lblBaseAvg.Text = "Baseline Average:";
            // 
            // lblD1D2
            // 
            this.lblD1D2.AutoSize = true;
            this.lblD1D2.Location = new System.Drawing.Point(411, 11);
            this.lblD1D2.Name = "lblD1D2";
            this.lblD1D2.Size = new System.Drawing.Size(43, 13);
            this.lblD1D2.TabIndex = 113;
            this.lblD1D2.Text = "D2/D1:";
            // 
            // lblPerc
            // 
            this.lblPerc.Location = new System.Drawing.Point(233, 78);
            this.lblPerc.Name = "lblPerc";
            this.lblPerc.Size = new System.Drawing.Size(116, 31);
            this.lblPerc.TabIndex = 114;
            this.lblPerc.Text = "Sample Percentage of Baseline:";
            this.lblPerc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grpInputs
            // 
            this.grpInputs.Controls.Add(this.cmdRefFile);
            this.grpInputs.Controls.Add(this.txtTargetOD);
            this.grpInputs.Controls.Add(this.txtWavelength);
            this.grpInputs.Controls.Add(this.lblWavelength);
            this.grpInputs.Controls.Add(this.lblNm);
            this.grpInputs.Controls.Add(this.lblTargetOD);
            this.grpInputs.Controls.Add(this.lblNegTol);
            this.grpInputs.Controls.Add(this.txtPosTol);
            this.grpInputs.Controls.Add(this.txtNegTol);
            this.grpInputs.Controls.Add(this.lvlPosTol);
            this.grpInputs.Location = new System.Drawing.Point(7, 149);
            this.grpInputs.Name = "grpInputs";
            this.grpInputs.Size = new System.Drawing.Size(561, 66);
            this.grpInputs.TabIndex = 146;
            this.grpInputs.TabStop = false;
            this.grpInputs.Text = "Program Inputs";
            // 
            // cmdRefFile
            // 
            this.cmdRefFile.Location = new System.Drawing.Point(431, 33);
            this.cmdRefFile.Name = "cmdRefFile";
            this.cmdRefFile.Size = new System.Drawing.Size(118, 23);
            this.cmdRefFile.TabIndex = 135;
            this.cmdRefFile.Text = "Raw Data Reference";
            this.cmdRefFile.UseVisualStyleBackColor = true;
            this.cmdRefFile.Click += new System.EventHandler(this.cmdRefFile_Click);
            // 
            // txtTargetOD
            // 
            this.txtTargetOD.Location = new System.Drawing.Point(105, 35);
            this.txtTargetOD.Name = "txtTargetOD";
            this.txtTargetOD.Size = new System.Drawing.Size(107, 20);
            this.txtTargetOD.TabIndex = 129;
            this.txtTargetOD.Text = "1.0";
            this.txtTargetOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetOD.TextChanged += new System.EventHandler(this.txtTargetOD_TextChanged);
            this.txtTargetOD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTargetOD_KeyPress);
            // 
            // txtWavelength
            // 
            this.txtWavelength.Location = new System.Drawing.Point(12, 35);
            this.txtWavelength.Name = "txtWavelength";
            this.txtWavelength.Size = new System.Drawing.Size(67, 20);
            this.txtWavelength.TabIndex = 88;
            this.txtWavelength.Text = "980";
            this.txtWavelength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWavelength.TextChanged += new System.EventHandler(this.txtWavelength_TextChanged);
            this.txtWavelength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWavelength_KeyPress);
            // 
            // lblWavelength
            // 
            this.lblWavelength.AutoSize = true;
            this.lblWavelength.Location = new System.Drawing.Point(9, 19);
            this.lblWavelength.Name = "lblWavelength";
            this.lblWavelength.Size = new System.Drawing.Size(92, 13);
            this.lblWavelength.TabIndex = 89;
            this.lblWavelength.Text = "Test Wavelength:";
            // 
            // lblNm
            // 
            this.lblNm.AutoSize = true;
            this.lblNm.Location = new System.Drawing.Point(80, 38);
            this.lblNm.Name = "lblNm";
            this.lblNm.Size = new System.Drawing.Size(21, 13);
            this.lblNm.TabIndex = 90;
            this.lblNm.Text = "nm";
            // 
            // lblTargetOD
            // 
            this.lblTargetOD.AutoSize = true;
            this.lblTargetOD.Location = new System.Drawing.Point(102, 19);
            this.lblTargetOD.Name = "lblTargetOD";
            this.lblTargetOD.Size = new System.Drawing.Size(115, 13);
            this.lblTargetOD.TabIndex = 130;
            this.lblTargetOD.Text = "Target Optical Density:";
            // 
            // lblNegTol
            // 
            this.lblNegTol.AutoSize = true;
            this.lblNegTol.Location = new System.Drawing.Point(321, 19);
            this.lblNegTol.Name = "lblNegTol";
            this.lblNegTol.Size = new System.Drawing.Size(104, 13);
            this.lblNegTol.TabIndex = 134;
            this.lblNegTol.Text = "Negative Tolerance:";
            // 
            // txtPosTol
            // 
            this.txtPosTol.Location = new System.Drawing.Point(221, 35);
            this.txtPosTol.Name = "txtPosTol";
            this.txtPosTol.Size = new System.Drawing.Size(95, 20);
            this.txtPosTol.TabIndex = 131;
            this.txtPosTol.Text = "0.1";
            this.txtPosTol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPosTol.TextChanged += new System.EventHandler(this.txtPosTol_TextChanged);
            this.txtPosTol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPosTol_KeyPress);
            // 
            // txtNegTol
            // 
            this.txtNegTol.Location = new System.Drawing.Point(324, 35);
            this.txtNegTol.Name = "txtNegTol";
            this.txtNegTol.Size = new System.Drawing.Size(101, 20);
            this.txtNegTol.TabIndex = 133;
            this.txtNegTol.Text = "0.1";
            this.txtNegTol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNegTol.TextChanged += new System.EventHandler(this.txtNegTol_TextChanged);
            this.txtNegTol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNegTol_KeyPress);
            // 
            // lvlPosTol
            // 
            this.lvlPosTol.AutoSize = true;
            this.lvlPosTol.Location = new System.Drawing.Point(218, 19);
            this.lvlPosTol.Name = "lvlPosTol";
            this.lvlPosTol.Size = new System.Drawing.Size(98, 13);
            this.lvlPosTol.TabIndex = 132;
            this.lvlPosTol.Text = "Positive Tolerance:";
            // 
            // grpResults
            // 
            this.grpResults.Controls.Add(this.label1);
            this.grpResults.Controls.Add(this.FailNotice);
            this.grpResults.Controls.Add(this.PassNotice);
            this.grpResults.Controls.Add(this.txtResultOD);
            this.grpResults.Controls.Add(this.textBox3);
            this.grpResults.Controls.Add(this.lblNegResultUncert);
            this.grpResults.Controls.Add(this.lblResultOD);
            this.grpResults.Controls.Add(this.lblPosResultUncert);
            this.grpResults.Controls.Add(this.textBox2);
            this.grpResults.Location = new System.Drawing.Point(7, 346);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(480, 112);
            this.grpResults.TabIndex = 145;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Results";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 13);
            this.label1.TabIndex = 150;
            this.label1.Text = "These uncertainty measurements are NOT standard deviation.";
            // 
            // FailNotice
            // 
            this.FailNotice.Enabled = false;
            this.FailNotice.Location = new System.Drawing.Point(335, 61);
            this.FailNotice.Name = "FailNotice";
            this.FailNotice.Size = new System.Drawing.Size(128, 23);
            this.FailNotice.TabIndex = 149;
            this.FailNotice.Text = "Fail";
            this.FailNotice.UseVisualStyleBackColor = true;
            // 
            // PassNotice
            // 
            this.PassNotice.Enabled = false;
            this.PassNotice.Location = new System.Drawing.Point(335, 28);
            this.PassNotice.Name = "PassNotice";
            this.PassNotice.Size = new System.Drawing.Size(128, 23);
            this.PassNotice.TabIndex = 148;
            this.PassNotice.Text = "Pass";
            this.PassNotice.UseVisualStyleBackColor = true;
            // 
            // txtResultOD
            // 
            this.txtResultOD.Enabled = false;
            this.txtResultOD.Location = new System.Drawing.Point(6, 49);
            this.txtResultOD.Name = "txtResultOD";
            this.txtResultOD.Size = new System.Drawing.Size(91, 20);
            this.txtResultOD.TabIndex = 140;
            this.txtResultOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(103, 49);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(101, 20);
            this.textBox3.TabIndex = 142;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNegResultUncert
            // 
            this.lblNegResultUncert.AutoSize = true;
            this.lblNegResultUncert.Location = new System.Drawing.Point(207, 33);
            this.lblNegResultUncert.Name = "lblNegResultUncert";
            this.lblNegResultUncert.Size = new System.Drawing.Size(110, 13);
            this.lblNegResultUncert.TabIndex = 139;
            this.lblNegResultUncert.Text = "Negative Uncertainty:";
            // 
            // lblResultOD
            // 
            this.lblResultOD.AutoSize = true;
            this.lblResultOD.Location = new System.Drawing.Point(6, 33);
            this.lblResultOD.Name = "lblResultOD";
            this.lblResultOD.Size = new System.Drawing.Size(81, 13);
            this.lblResultOD.TabIndex = 137;
            this.lblResultOD.Text = "Optical Density:";
            // 
            // lblPosResultUncert
            // 
            this.lblPosResultUncert.AutoSize = true;
            this.lblPosResultUncert.Location = new System.Drawing.Point(100, 33);
            this.lblPosResultUncert.Name = "lblPosResultUncert";
            this.lblPosResultUncert.Size = new System.Drawing.Size(104, 13);
            this.lblPosResultUncert.TabIndex = 138;
            this.lblPosResultUncert.Text = "Positive Uncertainty:";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(210, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(107, 20);
            this.textBox2.TabIndex = 141;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpProgControl
            // 
            this.grpProgControl.Controls.Add(this.lblClearForms);
            this.grpProgControl.Controls.Add(this.cmdClearForms);
            this.grpProgControl.Controls.Add(this.cmdStart);
            this.grpProgControl.Controls.Add(this.cmdViewFile);
            this.grpProgControl.Controls.Add(this.lblDate);
            this.grpProgControl.Controls.Add(this.txtFilePath);
            this.grpProgControl.Controls.Add(this.lblTestNum);
            this.grpProgControl.Controls.Add(this.lblFilePath);
            this.grpProgControl.Controls.Add(this.lblDeviceStatus);
            this.grpProgControl.Controls.Add(this.txtTestNum);
            this.grpProgControl.Controls.Add(this.txtExportStatus);
            this.grpProgControl.Controls.Add(this.txtDate);
            this.grpProgControl.Controls.Add(this.txtStatus);
            this.grpProgControl.Controls.Add(this.lblExportStatus);
            this.grpProgControl.Location = new System.Drawing.Point(7, 3);
            this.grpProgControl.Name = "grpProgControl";
            this.grpProgControl.Size = new System.Drawing.Size(357, 140);
            this.grpProgControl.TabIndex = 144;
            this.grpProgControl.TabStop = false;
            this.grpProgControl.Text = "Program Control and Status";
            // 
            // lblClearForms
            // 
            this.lblClearForms.Location = new System.Drawing.Point(231, 49);
            this.lblClearForms.Name = "lblClearForms";
            this.lblClearForms.Size = new System.Drawing.Size(126, 54);
            this.lblClearForms.TabIndex = 149;
            this.lblClearForms.Text = "Clear Forms button will clear all forms below this group. Everything in this box " +
    "will remain.";
            // 
            // cmdClearForms
            // 
            this.cmdClearForms.Location = new System.Drawing.Point(247, 23);
            this.cmdClearForms.Name = "cmdClearForms";
            this.cmdClearForms.Size = new System.Drawing.Size(75, 23);
            this.cmdClearForms.TabIndex = 148;
            this.cmdClearForms.Text = "Clear Forms";
            this.cmdClearForms.UseVisualStyleBackColor = true;
            this.cmdClearForms.Click += new System.EventHandler(this.cmdClearForms_Click);
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(9, 23);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 87;
            this.cmdStart.Text = "Start Test";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdViewFile
            // 
            this.cmdViewFile.Location = new System.Drawing.Point(232, 110);
            this.cmdViewFile.Name = "cmdViewFile";
            this.cmdViewFile.Size = new System.Drawing.Size(112, 23);
            this.cmdViewFile.TabIndex = 129;
            this.cmdViewFile.Text = "View File";
            this.cmdViewFile.UseVisualStyleBackColor = true;
            this.cmdViewFile.Click += new System.EventHandler(this.cmdViewFile_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(115, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 98;
            this.lblDate.Text = "Date:";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Enabled = false;
            this.txtFilePath.Location = new System.Drawing.Point(118, 112);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(100, 20);
            this.txtFilePath.TabIndex = 95;
            // 
            // lblTestNum
            // 
            this.lblTestNum.AutoSize = true;
            this.lblTestNum.Location = new System.Drawing.Point(115, 53);
            this.lblTestNum.Name = "lblTestNum";
            this.lblTestNum.Size = new System.Drawing.Size(64, 13);
            this.lblTestNum.TabIndex = 97;
            this.lblTestNum.Text = "Last Test #:";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(115, 96);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(110, 13);
            this.lblFilePath.TabIndex = 96;
            this.lblFilePath.Text = "File Path of Last Test:";
            // 
            // lblDeviceStatus
            // 
            this.lblDeviceStatus.AutoSize = true;
            this.lblDeviceStatus.Location = new System.Drawing.Point(6, 52);
            this.lblDeviceStatus.Name = "lblDeviceStatus";
            this.lblDeviceStatus.Size = new System.Drawing.Size(77, 13);
            this.lblDeviceStatus.TabIndex = 91;
            this.lblDeviceStatus.Text = "Device Status:";
            // 
            // txtTestNum
            // 
            this.txtTestNum.Enabled = false;
            this.txtTestNum.Location = new System.Drawing.Point(118, 69);
            this.txtTestNum.Name = "txtTestNum";
            this.txtTestNum.Size = new System.Drawing.Size(100, 20);
            this.txtTestNum.TabIndex = 94;
            this.txtTestNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtExportStatus
            // 
            this.txtExportStatus.Enabled = false;
            this.txtExportStatus.Location = new System.Drawing.Point(9, 112);
            this.txtExportStatus.Name = "txtExportStatus";
            this.txtExportStatus.Size = new System.Drawing.Size(93, 20);
            this.txtExportStatus.TabIndex = 125;
            this.txtExportStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDate
            // 
            this.txtDate.AllowDrop = true;
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(118, 31);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 93;
            this.txtDate.Text = "3/8/2018";
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus
            // 
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(9, 68);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(94, 20);
            this.txtStatus.TabIndex = 92;
            this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // lblExportStatus
            // 
            this.lblExportStatus.AutoSize = true;
            this.lblExportStatus.Location = new System.Drawing.Point(6, 96);
            this.lblExportStatus.Name = "lblExportStatus";
            this.lblExportStatus.Size = new System.Drawing.Size(99, 13);
            this.lblExportStatus.TabIndex = 124;
            this.lblExportStatus.Text = "Data Export Status:";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupBox3);
            this.tabSettings.Controls.Add(this.groupBox2);
            this.tabSettings.Controls.Add(this.groupBox1);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(581, 468);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.txtTimedMeas);
            this.groupBox3.Controls.Add(this.lblIntSet);
            this.groupBox3.Controls.Add(this.lblPerSec);
            this.groupBox3.Controls.Add(this.lblApprox);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtTimeEst);
            this.groupBox3.Controls.Add(this.lblStepAvg);
            this.groupBox3.Controls.Add(this.chkIntSet);
            this.groupBox3.Controls.Add(this.txtTimeSetCheck);
            this.groupBox3.Controls.Add(this.lblCountExplain);
            this.groupBox3.Controls.Add(this.lblIntWarn);
            this.groupBox3.Controls.Add(this.lblSampleCountSet);
            this.groupBox3.Controls.Add(this.lblBaseCountSet);
            this.groupBox3.Controls.Add(this.txtIntSetCheck);
            this.groupBox3.Controls.Add(this.txtBaseCountNum);
            this.groupBox3.Controls.Add(this.txtIntSet);
            this.groupBox3.Controls.Add(this.txtSampCountNum);
            this.groupBox3.Controls.Add(this.chkTimedMeas);
            this.groupBox3.Controls.Add(this.lblSampleCountNum);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.lblBaseCountNum);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(0, 243);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(578, 222);
            this.groupBox3.TabIndex = 153;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Measurement Settings";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(222, 134);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(332, 32);
            this.label16.TabIndex = 152;
            this.label16.Text = "See \"Notes\" tab for helpful guidelines regarding device measurement settings.";
            // 
            // txtTimedMeas
            // 
            this.txtTimedMeas.Location = new System.Drawing.Point(10, 34);
            this.txtTimedMeas.Name = "txtTimedMeas";
            this.txtTimedMeas.Size = new System.Drawing.Size(100, 20);
            this.txtTimedMeas.TabIndex = 9;
            this.txtTimedMeas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTimedMeas.TextChanged += new System.EventHandler(this.txtTimedMeas_TextChanged);
            this.txtTimedMeas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimedMeas_KeyPress);
            // 
            // lblIntSet
            // 
            this.lblIntSet.AutoSize = true;
            this.lblIntSet.Location = new System.Drawing.Point(7, 18);
            this.lblIntSet.Name = "lblIntSet";
            this.lblIntSet.Size = new System.Drawing.Size(148, 13);
            this.lblIntSet.TabIndex = 6;
            this.lblIntSet.Text = "Measurement Interval Setting:";
            // 
            // lblPerSec
            // 
            this.lblPerSec.AutoSize = true;
            this.lblPerSec.Location = new System.Drawing.Point(110, 37);
            this.lblPerSec.Name = "lblPerSec";
            this.lblPerSec.Size = new System.Drawing.Size(60, 13);
            this.lblPerSec.TabIndex = 12;
            this.lblPerSec.Text = "per second";
            // 
            // lblApprox
            // 
            this.lblApprox.AutoSize = true;
            this.lblApprox.Location = new System.Drawing.Point(283, 201);
            this.lblApprox.Name = "lblApprox";
            this.lblApprox.Size = new System.Drawing.Size(190, 13);
            this.lblApprox.TabIndex = 139;
            this.lblApprox.Text = "Approximate Time of Test (in seconds):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(357, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(219, 13);
            this.label12.TabIndex = 146;
            this.label12.Text = "Program runs at 30 samples/second natively.";
            // 
            // txtTimeEst
            // 
            this.txtTimeEst.Enabled = false;
            this.txtTimeEst.Location = new System.Drawing.Point(479, 198);
            this.txtTimeEst.Name = "txtTimeEst";
            this.txtTimeEst.Size = new System.Drawing.Size(100, 20);
            this.txtTimeEst.TabIndex = 138;
            this.txtTimeEst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblStepAvg
            // 
            this.lblStepAvg.AutoSize = true;
            this.lblStepAvg.Location = new System.Drawing.Point(8, 118);
            this.lblStepAvg.Name = "lblStepAvg";
            this.lblStepAvg.Size = new System.Drawing.Size(119, 13);
            this.lblStepAvg.TabIndex = 151;
            this.lblStepAvg.Text = "Step Averaging Setting:";
            // 
            // chkIntSet
            // 
            this.chkIntSet.AutoSize = true;
            this.chkIntSet.Location = new System.Drawing.Point(10, 160);
            this.chkIntSet.Name = "chkIntSet";
            this.chkIntSet.Size = new System.Drawing.Size(56, 17);
            this.chkIntSet.TabIndex = 15;
            this.chkIntSet.Text = "Active";
            this.chkIntSet.UseVisualStyleBackColor = true;
            this.chkIntSet.CheckedChanged += new System.EventHandler(this.chkIntSet_CheckedChanged);
            // 
            // txtTimeSetCheck
            // 
            this.txtTimeSetCheck.Enabled = false;
            this.txtTimeSetCheck.Location = new System.Drawing.Point(72, 57);
            this.txtTimeSetCheck.Name = "txtTimeSetCheck";
            this.txtTimeSetCheck.Size = new System.Drawing.Size(38, 20);
            this.txtTimeSetCheck.TabIndex = 148;
            this.txtTimeSetCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCountExplain
            // 
            this.lblCountExplain.Location = new System.Drawing.Point(222, 94);
            this.lblCountExplain.Name = "lblCountExplain";
            this.lblCountExplain.Size = new System.Drawing.Size(348, 29);
            this.lblCountExplain.TabIndex = 129;
            this.lblCountExplain.Text = "The number entered in the above boxes will determine how many counts the program " +
    "tests for in each measurement.";
            // 
            // lblIntWarn
            // 
            this.lblIntWarn.Location = new System.Drawing.Point(7, 80);
            this.lblIntWarn.Name = "lblIntWarn";
            this.lblIntWarn.Size = new System.Drawing.Size(169, 28);
            this.lblIntWarn.TabIndex = 16;
            this.lblIntWarn.Text = "Notice: If not active, program will run as fast as possible.";
            // 
            // lblSampleCountSet
            // 
            this.lblSampleCountSet.AutoSize = true;
            this.lblSampleCountSet.Location = new System.Drawing.Point(286, 74);
            this.lblSampleCountSet.Name = "lblSampleCountSet";
            this.lblSampleCountSet.Size = new System.Drawing.Size(262, 13);
            this.lblSampleCountSet.TabIndex = 19;
            this.lblSampleCountSet.Text = "Enter # of data points to take for sample measurement";
            // 
            // lblBaseCountSet
            // 
            this.lblBaseCountSet.AutoSize = true;
            this.lblBaseCountSet.Location = new System.Drawing.Point(286, 35);
            this.lblBaseCountSet.Name = "lblBaseCountSet";
            this.lblBaseCountSet.Size = new System.Drawing.Size(268, 13);
            this.lblBaseCountSet.TabIndex = 18;
            this.lblBaseCountSet.Text = "Enter # of data points to take for baseline measurement";
            // 
            // txtIntSetCheck
            // 
            this.txtIntSetCheck.Enabled = false;
            this.txtIntSetCheck.Location = new System.Drawing.Point(72, 158);
            this.txtIntSetCheck.Name = "txtIntSetCheck";
            this.txtIntSetCheck.Size = new System.Drawing.Size(38, 20);
            this.txtIntSetCheck.TabIndex = 147;
            this.txtIntSetCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBaseCountNum
            // 
            this.txtBaseCountNum.Location = new System.Drawing.Point(225, 32);
            this.txtBaseCountNum.Name = "txtBaseCountNum";
            this.txtBaseCountNum.Size = new System.Drawing.Size(55, 20);
            this.txtBaseCountNum.TabIndex = 11;
            this.txtBaseCountNum.Text = "100";
            this.txtBaseCountNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBaseCountNum.TextChanged += new System.EventHandler(this.txtBaseCountNum_TextChanged);
            this.txtBaseCountNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBaseCountNum_KeyPress);
            // 
            // txtIntSet
            // 
            this.txtIntSet.Location = new System.Drawing.Point(10, 134);
            this.txtIntSet.Name = "txtIntSet";
            this.txtIntSet.Size = new System.Drawing.Size(100, 20);
            this.txtIntSet.TabIndex = 135;
            this.txtIntSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIntSet.TextChanged += new System.EventHandler(this.txtIntSet_TextChanged);
            this.txtIntSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIntSet_KeyPress);
            // 
            // txtSampCountNum
            // 
            this.txtSampCountNum.Location = new System.Drawing.Point(225, 71);
            this.txtSampCountNum.Name = "txtSampCountNum";
            this.txtSampCountNum.Size = new System.Drawing.Size(55, 20);
            this.txtSampCountNum.TabIndex = 10;
            this.txtSampCountNum.Text = "100";
            this.txtSampCountNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSampCountNum.TextChanged += new System.EventHandler(this.txtSampCountNum_TextChanged);
            this.txtSampCountNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSampCountNum_KeyPress);
            // 
            // chkTimedMeas
            // 
            this.chkTimedMeas.AutoSize = true;
            this.chkTimedMeas.Location = new System.Drawing.Point(10, 60);
            this.chkTimedMeas.Name = "chkTimedMeas";
            this.chkTimedMeas.Size = new System.Drawing.Size(56, 17);
            this.chkTimedMeas.TabIndex = 136;
            this.chkTimedMeas.Text = "Active";
            this.chkTimedMeas.UseVisualStyleBackColor = true;
            this.chkTimedMeas.CheckedChanged += new System.EventHandler(this.chkTimedMeas_CheckedChanged);
            // 
            // lblSampleCountNum
            // 
            this.lblSampleCountNum.AutoSize = true;
            this.lblSampleCountNum.Location = new System.Drawing.Point(222, 55);
            this.lblSampleCountNum.Name = "lblSampleCountNum";
            this.lblSampleCountNum.Size = new System.Drawing.Size(183, 13);
            this.lblSampleCountNum.TabIndex = 8;
            this.lblSampleCountNum.Text = "Sample Measurement Count Number:";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(7, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(219, 40);
            this.label10.TabIndex = 140;
            this.label10.Text = "WARNING: If step averaging is active, the number of data points taken must be div" +
    "isible by the # of steps in the interval.";
            // 
            // lblBaseCountNum
            // 
            this.lblBaseCountNum.AutoSize = true;
            this.lblBaseCountNum.Location = new System.Drawing.Point(222, 18);
            this.lblBaseCountNum.Name = "lblBaseCountNum";
            this.lblBaseCountNum.Size = new System.Drawing.Size(188, 13);
            this.lblBaseCountNum.TabIndex = 7;
            this.lblBaseCountNum.Text = "Baseline Measurement Count Number:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(111, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 137;
            this.label9.Text = "samples per average";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtD1Name);
            this.groupBox2.Controls.Add(this.lblD1Name);
            this.groupBox2.Controls.Add(this.lblD2Name);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtD2Name);
            this.groupBox2.Controls.Add(this.txtFlippperSerial);
            this.groupBox2.Controls.Add(this.lblFlipperSerial);
            this.groupBox2.Location = new System.Drawing.Point(3, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(572, 115);
            this.groupBox2.TabIndex = 146;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hardware Settings";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(2, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(385, 17);
            this.label8.TabIndex = 151;
            this.label8.Text = "See PM100USB documentation for help determining power sensor names.";
            // 
            // txtD1Name
            // 
            this.txtD1Name.Location = new System.Drawing.Point(5, 32);
            this.txtD1Name.Name = "txtD1Name";
            this.txtD1Name.Size = new System.Drawing.Size(294, 20);
            this.txtD1Name.TabIndex = 2;
            this.txtD1Name.Text = "USB0::0x1313::0x8072::P2001836::INSTR";
            this.txtD1Name.TextChanged += new System.EventHandler(this.txtD1Name_TextChanged);
            // 
            // lblD1Name
            // 
            this.lblD1Name.AutoSize = true;
            this.lblD1Name.Location = new System.Drawing.Point(2, 16);
            this.lblD1Name.Name = "lblD1Name";
            this.lblD1Name.Size = new System.Drawing.Size(91, 13);
            this.lblD1Name.TabIndex = 5;
            this.lblD1Name.Text = "Detector 1 Name:";
            // 
            // lblD2Name
            // 
            this.lblD2Name.AutoSize = true;
            this.lblD2Name.Location = new System.Drawing.Point(2, 57);
            this.lblD2Name.Name = "lblD2Name";
            this.lblD2Name.Size = new System.Drawing.Size(91, 13);
            this.lblD2Name.TabIndex = 4;
            this.lblD2Name.Text = "Detector 2 Name:";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(427, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(144, 59);
            this.label14.TabIndex = 150;
            this.label14.Text = "This can be found on the filter flipper device. Must be updated if the device is " +
    "changed out.";
            // 
            // txtD2Name
            // 
            this.txtD2Name.Location = new System.Drawing.Point(5, 73);
            this.txtD2Name.Name = "txtD2Name";
            this.txtD2Name.Size = new System.Drawing.Size(294, 20);
            this.txtD2Name.TabIndex = 1;
            this.txtD2Name.Text = "USB0::0x1313::0x8072::P2007370::INSTR";
            this.txtD2Name.TextChanged += new System.EventHandler(this.txtD2Name_TextChanged);
            // 
            // txtFlippperSerial
            // 
            this.txtFlippperSerial.Location = new System.Drawing.Point(316, 32);
            this.txtFlippperSerial.Name = "txtFlippperSerial";
            this.txtFlippperSerial.Size = new System.Drawing.Size(100, 20);
            this.txtFlippperSerial.TabIndex = 132;
            this.txtFlippperSerial.Text = "37000305";
            // 
            // lblFlipperSerial
            // 
            this.lblFlipperSerial.AutoSize = true;
            this.lblFlipperSerial.Location = new System.Drawing.Point(314, 16);
            this.lblFlipperSerial.Name = "lblFlipperSerial";
            this.lblFlipperSerial.Size = new System.Drawing.Size(102, 13);
            this.lblFlipperSerial.TabIndex = 133;
            this.lblFlipperSerial.Text = "Filter Flipper Serial #";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLogLoc);
            this.groupBox1.Controls.Add(this.txtFolder);
            this.groupBox1.Controls.Add(this.lblFolder);
            this.groupBox1.Controls.Add(this.cmdViewLog);
            this.groupBox1.Controls.Add(this.cmdChooseLog);
            this.groupBox1.Controls.Add(this.cmdViewFolder);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblPathInfo);
            this.groupBox1.Controls.Add(this.lblLogLoc);
            this.groupBox1.Controls.Add(this.cmdChooseFolder);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 122);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Location Settings";
            // 
            // txtLogLoc
            // 
            this.txtLogLoc.Location = new System.Drawing.Point(5, 87);
            this.txtLogLoc.Name = "txtLogLoc";
            this.txtLogLoc.Size = new System.Drawing.Size(295, 20);
            this.txtLogLoc.TabIndex = 141;
            this.txtLogLoc.Text = "C:\\Users\\gmarth\\Desktop\\Log File.xlsx";
            this.txtLogLoc.TextChanged += new System.EventHandler(this.txtLogLoc_TextChanged);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(7, 30);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(294, 20);
            this.txtFolder.TabIndex = 0;
            this.txtFolder.Text = "\\\\thorlabs.local\\NWT\\OpticsBU\\Users\\Gabe Marth\\Test Logs";
            this.txtFolder.TextChanged += new System.EventHandler(this.txtFolder_TextChanged);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(4, 14);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(159, 13);
            this.lblFolder.TabIndex = 3;
            this.lblFolder.Text = "Folder where records are saved:";
            // 
            // cmdViewLog
            // 
            this.cmdViewLog.Location = new System.Drawing.Point(408, 84);
            this.cmdViewLog.Name = "cmdViewLog";
            this.cmdViewLog.Size = new System.Drawing.Size(101, 23);
            this.cmdViewLog.TabIndex = 145;
            this.cmdViewLog.Text = "View File";
            this.cmdViewLog.UseVisualStyleBackColor = true;
            this.cmdViewLog.Click += new System.EventHandler(this.cmdViewLog_Click);
            // 
            // cmdChooseLog
            // 
            this.cmdChooseLog.Location = new System.Drawing.Point(306, 84);
            this.cmdChooseLog.Name = "cmdChooseLog";
            this.cmdChooseLog.Size = new System.Drawing.Size(96, 23);
            this.cmdChooseLog.TabIndex = 144;
            this.cmdChooseLog.Text = "Choose File";
            this.cmdChooseLog.UseVisualStyleBackColor = true;
            this.cmdChooseLog.Click += new System.EventHandler(this.cmdChooseLog_Click);
            // 
            // cmdViewFolder
            // 
            this.cmdViewFolder.Location = new System.Drawing.Point(409, 27);
            this.cmdViewFolder.Name = "cmdViewFolder";
            this.cmdViewFolder.Size = new System.Drawing.Size(101, 23);
            this.cmdViewFolder.TabIndex = 17;
            this.cmdViewFolder.Text = "View Folder";
            this.cmdViewFolder.UseVisualStyleBackColor = true;
            this.cmdViewFolder.Click += new System.EventHandler(this.cmdViewFolder_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(299, 13);
            this.label11.TabIndex = 143;
            this.label11.Text = "Needed for program operation. It is inadvisable to change this.";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // lblPathInfo
            // 
            this.lblPathInfo.AutoSize = true;
            this.lblPathInfo.Location = new System.Drawing.Point(4, 53);
            this.lblPathInfo.Name = "lblPathInfo";
            this.lblPathInfo.Size = new System.Drawing.Size(370, 13);
            this.lblPathInfo.TabIndex = 20;
            this.lblPathInfo.Text = "You can adjust what folder the test logs are saved in with the above text box.";
            // 
            // lblLogLoc
            // 
            this.lblLogLoc.AutoSize = true;
            this.lblLogLoc.Location = new System.Drawing.Point(4, 71);
            this.lblLogLoc.Name = "lblLogLoc";
            this.lblLogLoc.Size = new System.Drawing.Size(96, 13);
            this.lblLogLoc.TabIndex = 142;
            this.lblLogLoc.Text = "Location of log file:";
            this.lblLogLoc.Click += new System.EventHandler(this.lblLogLoc_Click);
            // 
            // cmdChooseFolder
            // 
            this.cmdChooseFolder.Location = new System.Drawing.Point(307, 27);
            this.cmdChooseFolder.Name = "cmdChooseFolder";
            this.cmdChooseFolder.Size = new System.Drawing.Size(96, 23);
            this.cmdChooseFolder.TabIndex = 129;
            this.cmdChooseFolder.Text = "Choose Folder";
            this.cmdChooseFolder.UseVisualStyleBackColor = true;
            this.cmdChooseFolder.Click += new System.EventHandler(this.cmdChooseFolder_Click);
            // 
            // tabMotion
            // 
            this.tabMotion.Controls.Add(this.label5);
            this.tabMotion.Controls.Add(this.label7);
            this.tabMotion.Controls.Add(this.cmdChangePosition);
            this.tabMotion.Controls.Add(this.txtCurrentPosition);
            this.tabMotion.Controls.Add(this.lblCurrentPosition);
            this.tabMotion.Location = new System.Drawing.Point(4, 22);
            this.tabMotion.Name = "tabMotion";
            this.tabMotion.Size = new System.Drawing.Size(581, 468);
            this.tabMotion.TabIndex = 2;
            this.tabMotion.Text = "Motion Control";
            this.tabMotion.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(116, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 52);
            this.label5.TabIndex = 4;
            this.label5.Text = "Position can also be changed by pressing the white dot on top of the filter flipp" +
    "er. That is the recommended method for changing flipper position.";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(7, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 56);
            this.label7.TabIndex = 3;
            this.label7.Text = "Current position represents the position of the sample carrier.";
            // 
            // cmdChangePosition
            // 
            this.cmdChangePosition.Location = new System.Drawing.Point(10, 45);
            this.cmdChangePosition.Name = "cmdChangePosition";
            this.cmdChangePosition.Size = new System.Drawing.Size(100, 23);
            this.cmdChangePosition.TabIndex = 2;
            this.cmdChangePosition.Text = "Change Position";
            this.cmdChangePosition.UseVisualStyleBackColor = true;
            this.cmdChangePosition.Click += new System.EventHandler(this.cmdChangePosition_Click);
            // 
            // txtCurrentPosition
            // 
            this.txtCurrentPosition.Location = new System.Drawing.Point(10, 19);
            this.txtCurrentPosition.Name = "txtCurrentPosition";
            this.txtCurrentPosition.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentPosition.TabIndex = 1;
            // 
            // lblCurrentPosition
            // 
            this.lblCurrentPosition.AutoSize = true;
            this.lblCurrentPosition.Location = new System.Drawing.Point(7, 3);
            this.lblCurrentPosition.Name = "lblCurrentPosition";
            this.lblCurrentPosition.Size = new System.Drawing.Size(84, 13);
            this.lblCurrentPosition.TabIndex = 0;
            this.lblCurrentPosition.Text = "Current Position:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(581, 468);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Notes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 155;
            this.button1.Text = "Test Button";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(13, 302);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(510, 46);
            this.label23.TabIndex = 154;
            this.label23.Text = resources.GetString("label23.Text");
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(16, 260);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(507, 42);
            this.label22.TabIndex = 153;
            this.label22.Text = resources.GetString("label22.Text");
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(13, 213);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(510, 47);
            this.label21.TabIndex = 152;
            this.label21.Text = resources.GetString("label21.Text");
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 196);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(486, 13);
            this.label20.TabIndex = 151;
            this.label20.Text = "- The power sensors are silicon based, so the useful measurement range is approxi" +
    "mately 400-1100nm";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(10, 159);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(510, 33);
            this.label19.TabIndex = 150;
            this.label19.Text = resources.GetString("label19.Text");
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(10, 102);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(513, 57);
            this.label18.TabIndex = 149;
            this.label18.Text = resources.GetString("label18.Text");
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(10, 73);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(510, 29);
            this.label17.TabIndex = 148;
            this.label17.Text = "- The power meters can max out at 3000 samples/second, but will not realistically" +
    " achieve this because of computation time associated with this program.\r\n";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(219, 13);
            this.label13.TabIndex = 147;
            this.label13.Text = "Program runs at 30 samples/second natively.";
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(515, 497);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 23);
            this.cmdExit.TabIndex = 128;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(131, 366);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 156;
            this.button2.Text = "Current Meas";
            this.button2.UseVisualStyleBackColor = true;
            //this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 523);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.tabNotes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTester";
            this.Text = "ND Filter Tester";
            this.tabNotes.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.grpInstruct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ThorlabsLogo)).EndInit();
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.grpInputs.ResumeLayout(false);
            this.grpInputs.PerformLayout();
            this.grpResults.ResumeLayout(false);
            this.grpResults.PerformLayout();
            this.grpProgControl.ResumeLayout(false);
            this.grpProgControl.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabMotion.ResumeLayout(false);
            this.tabMotion.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabNotes;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabSettings;
        internal System.Windows.Forms.TextBox txtExportStatus;
        internal System.Windows.Forms.Label lblExportStatus;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label lblSampleAvg;
        internal System.Windows.Forms.Label lblBaseAvg;
        internal System.Windows.Forms.Label lblPerc;
        internal System.Windows.Forms.Label lblD1D2;
        internal System.Windows.Forms.Label lblDet2;
        internal System.Windows.Forms.Label lblDet1;
        internal System.Windows.Forms.TextBox txtSampPerc;
        internal System.Windows.Forms.TextBox txtSampRatio;
        internal System.Windows.Forms.TextBox txtSampD2;
        internal System.Windows.Forms.TextBox txtSampD1;
        internal System.Windows.Forms.TextBox txtBaseRatio;
        internal System.Windows.Forms.TextBox txtBaseD2;
        internal System.Windows.Forms.TextBox txtBaseD1;
        internal System.Windows.Forms.Label lblDate;
        internal System.Windows.Forms.Label lblTestNum;
        internal System.Windows.Forms.Label lblFilePath;
        internal System.Windows.Forms.TextBox txtFilePath;
        internal System.Windows.Forms.TextBox txtTestNum;
        internal System.Windows.Forms.TextBox txtDate;
        internal System.Windows.Forms.TextBox txtStatus;
        internal System.Windows.Forms.Label lblDeviceStatus;
        internal System.Windows.Forms.Label lblNm;
        internal System.Windows.Forms.Label lblWavelength;
        internal System.Windows.Forms.TextBox txtWavelength;
        internal System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.TabPage tabMotion;
        private System.Windows.Forms.Label lblD1Name;
        private System.Windows.Forms.Label lblD2Name;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox txtD1Name;
        private System.Windows.Forms.TextBox txtD2Name;
        private System.Windows.Forms.Label lblIntWarn;
        private System.Windows.Forms.CheckBox chkIntSet;
        private System.Windows.Forms.Label lblPerSec;
        private System.Windows.Forms.TextBox txtBaseCountNum;
        private System.Windows.Forms.TextBox txtSampCountNum;
        private System.Windows.Forms.TextBox txtTimedMeas;
        private System.Windows.Forms.Label lblSampleCountNum;
        private System.Windows.Forms.Label lblBaseCountNum;
        private System.Windows.Forms.Label lblIntSet;
        private System.Windows.Forms.Button cmdChangePosition;
        private System.Windows.Forms.TextBox txtCurrentPosition;
        private System.Windows.Forms.Label lblCurrentPosition;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdViewFile;
        private System.Windows.Forms.Button cmdViewFolder;
        private System.Windows.Forms.Label lblTargetOD;
        private System.Windows.Forms.TextBox txtTargetOD;
        private System.Windows.Forms.Label lblNegTol;
        private System.Windows.Forms.TextBox txtNegTol;
        private System.Windows.Forms.Label lvlPosTol;
        private System.Windows.Forms.TextBox txtPosTol;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtResultOD;
        private System.Windows.Forms.Label lblNegResultUncert;
        private System.Windows.Forms.Label lblPosResultUncert;
        private System.Windows.Forms.Label lblResultOD;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.GroupBox grpProgControl;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.GroupBox grpInputs;
        private System.Windows.Forms.Label lblClearForms;
        private System.Windows.Forms.Button cmdClearForms;
        private System.Windows.Forms.Button FailNotice;
        private System.Windows.Forms.Button PassNotice;
        private System.Windows.Forms.PictureBox ThorlabsLogo;
        private System.Windows.Forms.GroupBox grpInstruct;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblSampleCountSet;
        private System.Windows.Forms.Label lblBaseCountSet;
        private System.Windows.Forms.Label lblPathInfo;
        private System.Windows.Forms.Button cmdChooseFolder;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblCountExplain;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label lblFlipperSerial;
        private System.Windows.Forms.TextBox txtFlippperSerial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkTimedMeas;
        private System.Windows.Forms.TextBox txtIntSet;
        private System.Windows.Forms.Label lblApprox;
        private System.Windows.Forms.TextBox txtTimeEst;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblLogLoc;
        private System.Windows.Forms.TextBox txtLogLoc;
        private System.Windows.Forms.Button cmdViewLog;
        private System.Windows.Forms.Button cmdChooseLog;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIntSetCheck;
        private System.Windows.Forms.TextBox txtTimeSetCheck;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button cmdRefFile;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblStepAvg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

