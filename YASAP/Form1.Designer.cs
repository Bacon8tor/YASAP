
namespace YASAP
{
    partial class Form1
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
            this.msm = new MetroFramework.Components.MetroStyleManager(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.main_tabControl = new MetroFramework.Controls.MetroTabControl();
            this.simConnect_tab = new MetroFramework.Controls.MetroTabPage();
            this.simConnect_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.simConnectInfo_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.fsConnect_btn = new MetroFramework.Controls.MetroButton();
            this.simVar_ComboBox = new MetroFramework.Controls.MetroComboBox();
            this.simVarUnits_combo = new MetroFramework.Controls.MetroComboBox();
            this.simVarDataType_combo = new MetroFramework.Controls.MetroComboBox();
            this.simVarAdd_button = new MetroFramework.Controls.MetroButton();
            this.registerVars_button = new MetroFramework.Controls.MetroButton();
            this.vJoy_tab = new MetroFramework.Controls.MetroTabPage();
            this.vJoyInfo_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.vJoyAcquire_btn = new MetroFramework.Controls.MetroButton();
            this.arduino_tab = new MetroFramework.Controls.MetroTabPage();
            this.arduinoConnect_fp = new System.Windows.Forms.FlowLayoutPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.searchArduino_button = new MetroFramework.Controls.MetroButton();
            this.firmataComPort_label = new MetroFramework.Controls.MetroLabel();
            this.firmataBaud_label = new MetroFramework.Controls.MetroLabel();
            this.firmataFirmware_label = new MetroFramework.Controls.MetroLabel();
            this.firmataVersion_label = new MetroFramework.Controls.MetroLabel();
            this.ardBoard_label = new MetroFramework.Controls.MetroLabel();
            this.settings_tab = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.style_comboBox = new MetroFramework.Controls.MetroComboBox();
            this.style_label = new MetroFramework.Controls.MetroLabel();
            this.theme_comboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusSimConnect_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusvJoy_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusArduino_label = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.msm)).BeginInit();
            this.main_tabControl.SuspendLayout();
            this.simConnect_tab.SuspendLayout();
            this.simConnectInfo_panel.SuspendLayout();
            this.vJoy_tab.SuspendLayout();
            this.vJoyInfo_panel.SuspendLayout();
            this.arduino_tab.SuspendLayout();
            this.arduinoConnect_fp.SuspendLayout();
            this.settings_tab.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msm
            // 
            this.msm.Owner = this;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // main_tabControl
            // 
            this.main_tabControl.Controls.Add(this.simConnect_tab);
            this.main_tabControl.Controls.Add(this.vJoy_tab);
            this.main_tabControl.Controls.Add(this.arduino_tab);
            this.main_tabControl.Controls.Add(this.settings_tab);
            this.main_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tabControl.Location = new System.Drawing.Point(20, 60);
            this.main_tabControl.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.main_tabControl.Name = "main_tabControl";
            this.main_tabControl.SelectedIndex = 0;
            this.main_tabControl.Size = new System.Drawing.Size(803, 459);
            this.main_tabControl.TabIndex = 0;
            this.main_tabControl.UseSelectable = true;
            // 
            // simConnect_tab
            // 
            this.simConnect_tab.Controls.Add(this.simConnect_panel);
            this.simConnect_tab.Controls.Add(this.simConnectInfo_panel);
            this.simConnect_tab.HorizontalScrollbarBarColor = false;
            this.simConnect_tab.HorizontalScrollbarHighlightOnWheel = false;
            this.simConnect_tab.HorizontalScrollbarSize = 0;
            this.simConnect_tab.Location = new System.Drawing.Point(4, 38);
            this.simConnect_tab.Name = "simConnect_tab";
            this.simConnect_tab.Size = new System.Drawing.Size(795, 417);
            this.simConnect_tab.TabIndex = 1;
            this.simConnect_tab.Text = "SimConnect";
            this.simConnect_tab.VerticalScrollbarBarColor = false;
            this.simConnect_tab.VerticalScrollbarHighlightOnWheel = false;
            this.simConnect_tab.VerticalScrollbarSize = 0;
            // 
            // simConnect_panel
            // 
            this.simConnect_panel.BackColor = System.Drawing.Color.Transparent;
            this.simConnect_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simConnect_panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.simConnect_panel.Location = new System.Drawing.Point(203, 0);
            this.simConnect_panel.Name = "simConnect_panel";
            this.simConnect_panel.Size = new System.Drawing.Size(592, 417);
            this.simConnect_panel.TabIndex = 5;
            // 
            // simConnectInfo_panel
            // 
            this.simConnectInfo_panel.BackColor = System.Drawing.Color.Transparent;
            this.simConnectInfo_panel.Controls.Add(this.fsConnect_btn);
            this.simConnectInfo_panel.Controls.Add(this.simVar_ComboBox);
            this.simConnectInfo_panel.Controls.Add(this.simVarUnits_combo);
            this.simConnectInfo_panel.Controls.Add(this.simVarDataType_combo);
            this.simConnectInfo_panel.Controls.Add(this.simVarAdd_button);
            this.simConnectInfo_panel.Controls.Add(this.registerVars_button);
            this.simConnectInfo_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.simConnectInfo_panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.simConnectInfo_panel.Location = new System.Drawing.Point(0, 0);
            this.simConnectInfo_panel.Name = "simConnectInfo_panel";
            this.simConnectInfo_panel.Size = new System.Drawing.Size(203, 417);
            this.simConnectInfo_panel.TabIndex = 4;
            // 
            // fsConnect_btn
            // 
            this.fsConnect_btn.Location = new System.Drawing.Point(3, 3);
            this.fsConnect_btn.Name = "fsConnect_btn";
            this.fsConnect_btn.Size = new System.Drawing.Size(194, 38);
            this.fsConnect_btn.TabIndex = 2;
            this.fsConnect_btn.Text = "Connect to MSFS";
            this.fsConnect_btn.UseSelectable = true;
            this.fsConnect_btn.Click += new System.EventHandler(this.fsConnect_btn_Click);
            // 
            // simVar_ComboBox
            // 
            this.simVar_ComboBox.FormattingEnabled = true;
            this.simVar_ComboBox.ItemHeight = 23;
            this.simVar_ComboBox.Location = new System.Drawing.Point(3, 47);
            this.simVar_ComboBox.Name = "simVar_ComboBox";
            this.simVar_ComboBox.Size = new System.Drawing.Size(194, 29);
            this.simVar_ComboBox.TabIndex = 3;
            this.simVar_ComboBox.UseSelectable = true;
            this.simVar_ComboBox.Visible = false;
            // 
            // simVarUnits_combo
            // 
            this.simVarUnits_combo.FormattingEnabled = true;
            this.simVarUnits_combo.ItemHeight = 23;
            this.simVarUnits_combo.Location = new System.Drawing.Point(3, 82);
            this.simVarUnits_combo.Name = "simVarUnits_combo";
            this.simVarUnits_combo.Size = new System.Drawing.Size(194, 29);
            this.simVarUnits_combo.TabIndex = 6;
            this.simVarUnits_combo.UseSelectable = true;
            this.simVarUnits_combo.Visible = false;
            // 
            // simVarDataType_combo
            // 
            this.simVarDataType_combo.FormattingEnabled = true;
            this.simVarDataType_combo.ItemHeight = 23;
            this.simVarDataType_combo.Location = new System.Drawing.Point(3, 117);
            this.simVarDataType_combo.Name = "simVarDataType_combo";
            this.simVarDataType_combo.Size = new System.Drawing.Size(194, 29);
            this.simVarDataType_combo.TabIndex = 5;
            this.simVarDataType_combo.UseSelectable = true;
            this.simVarDataType_combo.Visible = false;
            // 
            // simVarAdd_button
            // 
            this.simVarAdd_button.Location = new System.Drawing.Point(3, 152);
            this.simVarAdd_button.Name = "simVarAdd_button";
            this.simVarAdd_button.Size = new System.Drawing.Size(194, 23);
            this.simVarAdd_button.TabIndex = 4;
            this.simVarAdd_button.Text = "add Sim Variable";
            this.simVarAdd_button.UseSelectable = true;
            this.simVarAdd_button.Visible = false;
            this.simVarAdd_button.Click += new System.EventHandler(this.simVarAdd_button_Click);
            // 
            // registerVars_button
            // 
            this.registerVars_button.Location = new System.Drawing.Point(3, 181);
            this.registerVars_button.Name = "registerVars_button";
            this.registerVars_button.Size = new System.Drawing.Size(194, 23);
            this.registerVars_button.TabIndex = 7;
            this.registerVars_button.Text = "Register Vars with Sim";
            this.registerVars_button.UseSelectable = true;
            this.registerVars_button.Visible = false;
            this.registerVars_button.Click += new System.EventHandler(this.registerVars_button_Click);
            // 
            // vJoy_tab
            // 
            this.vJoy_tab.Controls.Add(this.vJoyInfo_panel);
            this.vJoy_tab.HorizontalScrollbarBarColor = true;
            this.vJoy_tab.HorizontalScrollbarHighlightOnWheel = false;
            this.vJoy_tab.HorizontalScrollbarSize = 10;
            this.vJoy_tab.Location = new System.Drawing.Point(4, 38);
            this.vJoy_tab.Name = "vJoy_tab";
            this.vJoy_tab.Size = new System.Drawing.Size(795, 417);
            this.vJoy_tab.TabIndex = 2;
            this.vJoy_tab.Text = "vJoy";
            this.vJoy_tab.VerticalScrollbarBarColor = true;
            this.vJoy_tab.VerticalScrollbarHighlightOnWheel = false;
            this.vJoy_tab.VerticalScrollbarSize = 10;
            // 
            // vJoyInfo_panel
            // 
            this.vJoyInfo_panel.BackColor = System.Drawing.Color.Transparent;
            this.vJoyInfo_panel.Controls.Add(this.metroLabel1);
            this.vJoyInfo_panel.Controls.Add(this.vJoyAcquire_btn);
            this.vJoyInfo_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.vJoyInfo_panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.vJoyInfo_panel.Location = new System.Drawing.Point(0, 0);
            this.vJoyInfo_panel.Name = "vJoyInfo_panel";
            this.vJoyInfo_panel.Size = new System.Drawing.Size(200, 417);
            this.vJoyInfo_panel.TabIndex = 4;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(60, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "vJoy Info";
            // 
            // vJoyAcquire_btn
            // 
            this.vJoyAcquire_btn.Location = new System.Drawing.Point(3, 22);
            this.vJoyAcquire_btn.Name = "vJoyAcquire_btn";
            this.vJoyAcquire_btn.Size = new System.Drawing.Size(115, 23);
            this.vJoyAcquire_btn.TabIndex = 2;
            this.vJoyAcquire_btn.Text = "Acquire vJoy Device";
            this.vJoyAcquire_btn.UseSelectable = true;
            this.vJoyAcquire_btn.Click += new System.EventHandler(this.vJoyAcquire_btn_Click);
            // 
            // arduino_tab
            // 
            this.arduino_tab.Controls.Add(this.arduinoConnect_fp);
            this.arduino_tab.HorizontalScrollbarBarColor = true;
            this.arduino_tab.HorizontalScrollbarHighlightOnWheel = false;
            this.arduino_tab.HorizontalScrollbarSize = 10;
            this.arduino_tab.Location = new System.Drawing.Point(4, 38);
            this.arduino_tab.Name = "arduino_tab";
            this.arduino_tab.Size = new System.Drawing.Size(795, 417);
            this.arduino_tab.TabIndex = 3;
            this.arduino_tab.Text = "Arduino";
            this.arduino_tab.VerticalScrollbarBarColor = true;
            this.arduino_tab.VerticalScrollbarHighlightOnWheel = false;
            this.arduino_tab.VerticalScrollbarSize = 10;
            // 
            // arduinoConnect_fp
            // 
            this.arduinoConnect_fp.BackColor = System.Drawing.Color.Transparent;
            this.arduinoConnect_fp.Controls.Add(this.metroLabel2);
            this.arduinoConnect_fp.Controls.Add(this.searchArduino_button);
            this.arduinoConnect_fp.Controls.Add(this.firmataComPort_label);
            this.arduinoConnect_fp.Controls.Add(this.firmataBaud_label);
            this.arduinoConnect_fp.Controls.Add(this.firmataFirmware_label);
            this.arduinoConnect_fp.Controls.Add(this.firmataVersion_label);
            this.arduinoConnect_fp.Controls.Add(this.ardBoard_label);
            this.arduinoConnect_fp.Dock = System.Windows.Forms.DockStyle.Left;
            this.arduinoConnect_fp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.arduinoConnect_fp.Location = new System.Drawing.Point(0, 0);
            this.arduinoConnect_fp.Name = "arduinoConnect_fp";
            this.arduinoConnect_fp.Size = new System.Drawing.Size(200, 417);
            this.arduinoConnect_fp.TabIndex = 5;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(3, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(80, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Firmata Info";
            // 
            // searchArduino_button
            // 
            this.searchArduino_button.Location = new System.Drawing.Point(3, 22);
            this.searchArduino_button.Name = "searchArduino_button";
            this.searchArduino_button.Size = new System.Drawing.Size(115, 23);
            this.searchArduino_button.TabIndex = 2;
            this.searchArduino_button.Text = "Search for Arduino";
            this.searchArduino_button.UseSelectable = true;
            this.searchArduino_button.Click += new System.EventHandler(this.searchArduino_button_Click);
            // 
            // firmataComPort_label
            // 
            this.firmataComPort_label.AutoSize = true;
            this.firmataComPort_label.Location = new System.Drawing.Point(3, 48);
            this.firmataComPort_label.Name = "firmataComPort_label";
            this.firmataComPort_label.Size = new System.Drawing.Size(46, 19);
            this.firmataComPort_label.TabIndex = 4;
            this.firmataComPort_label.Text = "COM1";
            this.firmataComPort_label.Visible = false;
            // 
            // firmataBaud_label
            // 
            this.firmataBaud_label.AutoSize = true;
            this.firmataBaud_label.Location = new System.Drawing.Point(3, 67);
            this.firmataBaud_label.Name = "firmataBaud_label";
            this.firmataBaud_label.Size = new System.Drawing.Size(72, 19);
            this.firmataBaud_label.TabIndex = 7;
            this.firmataBaud_label.Text = "BaudRate: ";
            this.firmataBaud_label.Visible = false;
            // 
            // firmataFirmware_label
            // 
            this.firmataFirmware_label.AutoSize = true;
            this.firmataFirmware_label.Location = new System.Drawing.Point(3, 86);
            this.firmataFirmware_label.Name = "firmataFirmware_label";
            this.firmataFirmware_label.Size = new System.Drawing.Size(71, 19);
            this.firmataFirmware_label.TabIndex = 5;
            this.firmataFirmware_label.Text = "Firmware: ";
            this.firmataFirmware_label.Visible = false;
            // 
            // firmataVersion_label
            // 
            this.firmataVersion_label.AutoSize = true;
            this.firmataVersion_label.Location = new System.Drawing.Point(3, 105);
            this.firmataVersion_label.Name = "firmataVersion_label";
            this.firmataVersion_label.Size = new System.Drawing.Size(58, 19);
            this.firmataVersion_label.TabIndex = 6;
            this.firmataVersion_label.Text = "Version: ";
            this.firmataVersion_label.Visible = false;
            // 
            // ardBoard_label
            // 
            this.ardBoard_label.AutoSize = true;
            this.ardBoard_label.Location = new System.Drawing.Point(3, 124);
            this.ardBoard_label.Name = "ardBoard_label";
            this.ardBoard_label.Size = new System.Drawing.Size(48, 19);
            this.ardBoard_label.TabIndex = 8;
            this.ardBoard_label.Text = "Board:";
            this.ardBoard_label.Visible = false;
            // 
            // settings_tab
            // 
            this.settings_tab.Controls.Add(this.metroPanel1);
            this.settings_tab.HorizontalScrollbarBarColor = true;
            this.settings_tab.HorizontalScrollbarHighlightOnWheel = false;
            this.settings_tab.HorizontalScrollbarSize = 10;
            this.settings_tab.Location = new System.Drawing.Point(4, 38);
            this.settings_tab.Name = "settings_tab";
            this.settings_tab.Size = new System.Drawing.Size(795, 417);
            this.settings_tab.TabIndex = 4;
            this.settings_tab.Text = "Settings";
            this.settings_tab.VerticalScrollbarBarColor = true;
            this.settings_tab.VerticalScrollbarHighlightOnWheel = false;
            this.settings_tab.VerticalScrollbarSize = 10;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.style_comboBox);
            this.metroPanel1.Controls.Add(this.style_label);
            this.metroPanel1.Controls.Add(this.theme_comboBox);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(200, 417);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // style_comboBox
            // 
            this.style_comboBox.FormattingEnabled = true;
            this.style_comboBox.ItemHeight = 23;
            this.style_comboBox.Location = new System.Drawing.Point(3, 87);
            this.style_comboBox.Name = "style_comboBox";
            this.style_comboBox.Size = new System.Drawing.Size(194, 29);
            this.style_comboBox.TabIndex = 5;
            this.style_comboBox.UseSelectable = true;
            this.style_comboBox.SelectedIndexChanged += new System.EventHandler(this.style_comboBox_SelectedIndexChanged);
            // 
            // style_label
            // 
            this.style_label.AutoSize = true;
            this.style_label.Location = new System.Drawing.Point(3, 65);
            this.style_label.Name = "style_label";
            this.style_label.Size = new System.Drawing.Size(36, 19);
            this.style_label.TabIndex = 4;
            this.style_label.Text = "Style";
            // 
            // theme_comboBox
            // 
            this.theme_comboBox.FormattingEnabled = true;
            this.theme_comboBox.ItemHeight = 23;
            this.theme_comboBox.Location = new System.Drawing.Point(3, 33);
            this.theme_comboBox.Name = "theme_comboBox";
            this.theme_comboBox.Size = new System.Drawing.Size(194, 29);
            this.theme_comboBox.TabIndex = 3;
            this.theme_comboBox.UseSelectable = true;
            this.theme_comboBox.SelectedIndexChanged += new System.EventHandler(this.theme_comboBox_SelectedIndexChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(3, 11);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(53, 19);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Theme ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusSimConnect_label,
            this.statusvJoy_label,
            this.toolStripStatusLabel1,
            this.statusArduino_label});
            this.statusStrip1.Location = new System.Drawing.Point(20, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(803, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusSimConnect_label
            // 
            this.statusSimConnect_label.Name = "statusSimConnect_label";
            this.statusSimConnect_label.Size = new System.Drawing.Size(142, 17);
            this.statusSimConnect_label.Text = "Simulator Not Connected";
            // 
            // statusvJoy_label
            // 
            this.statusvJoy_label.Name = "statusvJoy_label";
            this.statusvJoy_label.Size = new System.Drawing.Size(104, 17);
            this.statusvJoy_label.Text = "vJoy Not Acquired";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // statusArduino_label
            // 
            this.statusArduino_label.Name = "statusArduino_label";
            this.statusArduino_label.Size = new System.Drawing.Size(134, 17);
            this.statusArduino_label.Text = "Arduino Not Connected";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 541);
            this.Controls.Add(this.main_tabControl);
            this.Controls.Add(this.statusStrip1);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(20, 60, 20, 0);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "YASAP";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.msm)).EndInit();
            this.main_tabControl.ResumeLayout(false);
            this.simConnect_tab.ResumeLayout(false);
            this.simConnectInfo_panel.ResumeLayout(false);
            this.vJoy_tab.ResumeLayout(false);
            this.vJoyInfo_panel.ResumeLayout(false);
            this.vJoyInfo_panel.PerformLayout();
            this.arduino_tab.ResumeLayout(false);
            this.arduinoConnect_fp.ResumeLayout(false);
            this.arduinoConnect_fp.PerformLayout();
            this.settings_tab.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager msm;
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroTabControl main_tabControl;
        private MetroFramework.Controls.MetroTabPage simConnect_tab;
        private MetroFramework.Controls.MetroButton fsConnect_btn;
        private MetroFramework.Controls.MetroTabPage vJoy_tab;
        private MetroFramework.Controls.MetroButton vJoyAcquire_btn;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.FlowLayoutPanel vJoyInfo_panel;
        private MetroFramework.Controls.MetroTabPage arduino_tab;
        private System.Windows.Forms.FlowLayoutPanel arduinoConnect_fp;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton searchArduino_button;
        private MetroFramework.Controls.MetroLabel firmataComPort_label;
        private MetroFramework.Controls.MetroLabel firmataFirmware_label;
        private MetroFramework.Controls.MetroLabel firmataVersion_label;
        private MetroFramework.Controls.MetroLabel firmataBaud_label;
        private MetroFramework.Controls.MetroLabel ardBoard_label;
        private System.Windows.Forms.FlowLayoutPanel simConnect_panel;
        private System.Windows.Forms.FlowLayoutPanel simConnectInfo_panel;
        private MetroFramework.Controls.MetroTabPage settings_tab;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroComboBox style_comboBox;
        private MetroFramework.Controls.MetroLabel style_label;
        private MetroFramework.Controls.MetroComboBox theme_comboBox;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusSimConnect_label;
        private System.Windows.Forms.ToolStripStatusLabel statusvJoy_label;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusArduino_label;
        private MetroFramework.Controls.MetroComboBox simVar_ComboBox;
        private MetroFramework.Controls.MetroButton simVarAdd_button;
        private MetroFramework.Controls.MetroComboBox simVarDataType_combo;
        private MetroFramework.Controls.MetroComboBox simVarUnits_combo;
        private MetroFramework.Controls.MetroButton registerVars_button;
    }
}