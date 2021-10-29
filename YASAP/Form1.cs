using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vJoyInterfaceWrap;
using Solid.Arduino;
using Solid.Arduino.Firmata;
using CTrue.FsConnect;
using System.Runtime.InteropServices;
using MetroFramework;
using MetroFramework.Controls;
using System.Reflection;
using CTrue.FsConnect.Managers;
using System.IO;
using System.Drawing.Text;
using System.Threading;

namespace YASAP
{

    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        private vJoy Joystick = new vJoy();
        private bool vJoyAcq = false;
        private List<uint> sticksAcquired = new List<uint>();

        private ArduinoSession ard_sess;
        private IFirmataProtocol ard_firm;
        private ISerialConnection ard_conn;
        private BoardCapability ard_board;
        private bool firmAcq = false;
        private BoardInfo bInfo;
        FsConnect fsConnect;
        bool simState = false;
        bool isMSFSRunning = false;
        int planeInfoDefinitionId;
        PlaneInfoResponse responses;
        bool labelsmade = false;
        List<SimVar> definition = new List<SimVar>();
        RadioManager radioManager;
        WorldManager worldManager;
        AutopilotManager autopilotManager;
        System.Windows.Forms.Timer managerTimer;
        PrivateFontCollection pfc;
        
        public enum Requests
        {
            PlaneInfoRequest = 0
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct PlaneInfoResponse
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public String Title;
 
            
        }

        public Form1()
        {
            InitializeComponent();
            this.StyleManager = msm;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            fillComboBoxes();
            loadFonts();
            
        }

        #region Arduino

        private void ConnectArduino()
        {
            if (!firmAcq)
            {
                try
                {
                     ard_conn = EnhancedSerialConnection.Find();// "Hello?", "Arduino!");
                   
                }
                catch (System.IO.IOException ex)
                {
                    Debug.WriteLine(ex.Message);

                }
            } else { DisconnectArduino(); return; }
            if(ard_conn == null)
            {
                Debug.WriteLine("No Connection Found");
            }else
            {

                Debug.WriteLine($"Found Arduino on {ard_conn.PortName}");
                
                searchArduino_button.Text = "Disconnect";
                firmAcq = true;
                ard_sess = new ArduinoSession(ard_conn);
                ard_firm = (IFirmataProtocol)ard_sess;
                ard_board = ard_firm.GetBoardCapability();
                ard_sess.MessageReceived += Ard_sess_MessageReceived;
                ard_sess.DigitalStateReceived += Ard_sess_DigitalStateReceived;
                ard_sess.AnalogStateReceived += Ard_sess_AnalogStateReceived;
                ard_sess.I2CReplyReceived += Ard_sess_I2CReplyReceived;
                updateLabelText(firmataComPort_label,$"COM port: {ard_conn.PortName}");
                updateLabelText(firmataBaud_label, $"BaudRate: {ard_conn.BaudRate.ToString()}");
                updateLabelText(firmataFirmware_label, $"Firmware Name: {ard_firm.GetFirmware().Name}");
                updateLabelText(firmataVersion_label, $"Version: {ard_firm.GetFirmware().MajorVersion}.{ard_firm.GetFirmware().MinorVersion}");
                statusArduino_label.Text = $"Arduino Connected port: {ard_conn.PortName}";
                statusArduino_label.ForeColor = Color.Green;
                //Get proc type
                ard_sess.SendStringData("%");
                //Count pins 
                CountPins();
            }
        }
        
        private void CountPins()
        {
            bInfo = new BoardInfo();
            bInfo.totalPins = ard_board.Pins.Length;
            string msg = $"Total Pins : {bInfo.totalPins}";
            foreach(var pin in ard_board.Pins)
            {
                if (pin.Analog)
                {
                    bInfo.analogPins.Add(pin);
                    
                }
                if (pin.DigitalInput && pin.DigitalOutput)
                {
                   bInfo.digitalPins.Add(pin);
                }
                if(pin.Encoder)
                {
                    bInfo.encoderPins.Add(pin);
                }
                if(pin.Pwm)
                {
                    bInfo.pwmPins.Add(pin);
                }
                if(pin.I2C)
                {
                    bInfo.i2cPins.Add(pin);
                }
                if(pin.InputPullup)
                {
                    bInfo.pullupPins.Add(pin);
                }
                if(pin.OneWire)
                {
                    bInfo.oneWirePins.Add(pin);
                }
                if (pin.Serial)
                {
                    bInfo.serialPins.Add(pin);
                }
                if (pin.Servo)
                {
                    bInfo.servoPins.Add(pin);
                }
                if (pin.StepperControl)
                {
                    bInfo.stepperPins.Add(pin);
                }

            }
            msg += $"\nAnalog Pins: {bInfo.analogPins.Count}";
            msg += $"\nDigital Pins: {bInfo.digitalPins.Count}";
            msg += $"\nEncoder Pins: {bInfo.encoderPins.Count}";
            msg += $"\nPWM Pins: {bInfo.pwmPins.Count}";
            msg += $"\nI2C Pins: {bInfo.i2cPins.Count}";
            msg += $"\nPullup Pins: {bInfo.pullupPins.Count}";
            msg += $"\nOneWire Pins: {bInfo.oneWirePins.Count}";
            msg += $"\nSerial Pins: {bInfo.serialPins.Count}";
            msg += $"\nServo Pins: {bInfo.servoPins.Count}";
            msg += $"\nStepper Pins: {bInfo.stepperPins.Count}";
            Debug.WriteLine(msg);
            MetroLabel ml = new MetroLabel();
            ml.Text = msg;
            ml.StyleManager = msm;
            ml.AutoSize = true;
            
            arduinoConnect_fp.Controls.Add(ml);
            
        }
        private void DisconnectArduino()
        {
            if (ard_conn.IsOpen)
            {
                ard_conn.Dispose();
                ard_sess.Dispose();
                ard_firm = null;
                searchArduino_button.Text = "Search for Arduino";
                firmAcq = false;
                ardBoard_label.Visible = false;
                firmataBaud_label.Visible = false;
                firmataComPort_label.Visible = false;
                firmataFirmware_label.Visible = false;
                firmataVersion_label.Visible = false;
               
            }
        }

        // Firmata Events 
        private void Ard_sess_I2CReplyReceived(object sender, Solid.Arduino.I2C.I2CEventArgs eventArgs)
        {
            Debug.WriteLine("I2C Reply-Addr: {0}, Reg: {1}, Data: {2}", eventArgs.Value.Address, eventArgs.Value.Register, eventArgs.Value.Data);
        }

        private void Ard_sess_AnalogStateReceived(object sender, FirmataEventArgs<AnalogState> eventArgs)
        {
            Debug.WriteLine("Analog level of pin {0}: {1}", eventArgs.Value.Channel, eventArgs.Value.Level);
        }

        private void Ard_sess_DigitalStateReceived(object sender, FirmataEventArgs<DigitalPortState> eventArgs)
        {
           Debug.WriteLine("Digital level of port {0}: {1}", eventArgs.Value.Port, eventArgs.Value.IsSet(6) ? 'X' : 'O');
        }

        private void Ard_sess_MessageReceived(object sender, FirmataMessageEventArgs eventArgs)
        {
            string o; 
            switch(eventArgs.Value.Type)
            {
                case MessageType.StringData:
                        o = ((StringData)eventArgs.Value.Value).Text;
                    switch (o[0])
                    {
                        case '%':
                            o.Trim('%');
                            string i = o.Substring(1);
                            Debug.WriteLine($"Board Type: {i}");
                            SetboardName(i,arduinoConnect_fp);
                            break;
                    }
                        break;
                case MessageType.FirmwareResponse:
                    o = "Firmware Received";
                    Debug.WriteLine("Message {0} received: {1}", eventArgs.Value.Type, o);
                    break;

                default:
                    o = "?";
                    Debug.WriteLine("Message {0} received: {1}", eventArgs.Value.Type, o);
                    break;
            }
            
        }
        delegate void SetBoardCallback( string text, FlowLayoutPanel fp);

        private void SetboardName(string text,FlowLayoutPanel fp)
        {
            if (fp.InvokeRequired)
            {
                // Debug.WriteLine("Set text");
                SetBoardCallback d = new SetBoardCallback(SetboardName);
                this.Invoke(d, new object[] { text , fp});
            }
            else
            {

                updateLabelText(ardBoard_label, $"Chip: {text}");
                

            }
        }
        #endregion

        #region vJoy

        private void CheckvJoyDriver()
        {
            if (!Joystick.vJoyEnabled())
            {
                Debug.WriteLine("vJoy driver not enabled: Failed Getting vJoy attributes.");
                return;
            } else
            {
                Debug.WriteLine("Vendor: {0}\nProduct :{1}\nVersion Number:{2}", Joystick.GetvJoyManufacturerString(), Joystick.GetvJoyProductString(), Joystick.GetvJoySerialNumberString());
                
            }

            //Test if Drivers Match
            UInt32 DllVer = 0, DrvVer = 0;
            bool match = Joystick.DriverMatch(ref DllVer, ref DrvVer);
            if (match)
            {
                Debug.WriteLine("Version of Driver Matches DLL Version ({0:X})", DllVer);
                AcquirevJoy();
            }
            else
                Debug.WriteLine("Version of Driver ({0:X}) does NOT match DLL Version ({1:X})", DrvVer, DllVer);

        }
        
        private void AcquirevJoy(uint id = 1)
        {
            VjdStat status = Joystick.GetVJDStatus(id);

            switch (status)
            {
                case VjdStat.VJD_STAT_OWN:
                    Debug.WriteLine("vJoy Device {0} is already owned by this feeder", id);
                    GetvJoyCapabilities();
                    
                    break;
                case VjdStat.VJD_STAT_FREE:
                    Debug.WriteLine("vJoy Device {0} is free", id);
                    GetvJoyCapabilities();
                    break;
                case VjdStat.VJD_STAT_BUSY:
                    Debug.WriteLine("vJoy Device {0} is already owned by another feeder\nCannot continue", id);
                    return;
                case VjdStat.VJD_STAT_MISS:
                    Debug.WriteLine("vJoy Device {0} is not installed or disabled\nCannot continue", id);
                    return;
                default:
                    Debug.WriteLine("vJoy Device {0} general error\nCannot continue", id);
                    return;
            }
            if ((status == VjdStat.VJD_STAT_OWN) || ((status == VjdStat.VJD_STAT_FREE) && (!Joystick.AcquireVJD(id))))
            {
                Debug.WriteLine("Failed to acquire vJoy device number {0}.", id);
                return;
            }
            else
            {
                Debug.WriteLine("Acquired: vJoy device number {0}.", id);
                statusvJoy_label.Text = String.Format("Acquired: vJoy device number {0}.", id);
                statusvJoy_label.ForeColor = Color.Green;
                sticksAcquired.Add(id);
                vJoyAcq = true;
                ChangeBtnText("Release vJoy", vJoyAcquire_btn);
            }
        }

        private void GetvJoyCapabilities(uint id = 1)
        {
            bool AxisX = Joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_X);
            bool AxisY = Joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_Y);
            bool AxisZ = Joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_Z);
            bool AxisRX = Joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_RX);
            bool AxisRZ = Joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_RZ);
            bool AxisGAS = Joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_ACCELERATOR);
            bool AxisBRK = Joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_BRAKE);
            bool AxisTHR = Joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_THROTTLE);
            // Get the number of buttons and POV Hat switchessupported by this vJoy device
            int nButtons = Joystick.GetVJDButtonNumber(id);
            int ContPovNumber = Joystick.GetVJDContPovNumber(id);
            int DiscPovNumber = Joystick.GetVJDDiscPovNumber(id);

            //Make Labels 
            addLabel(String.Format("vJoy Device {0} capabilities:", id), vJoyInfo_panel);
            addLabel(String.Format("Number of buttons: {0}", nButtons), vJoyInfo_panel);
            addLabel(String.Format("Number of Continuous POVs: {0}", ContPovNumber), vJoyInfo_panel);
            addLabel(String.Format("Number of Descrete POVs: {0})", DiscPovNumber), vJoyInfo_panel);
            addLabel(String.Format("Number of buttons: {0}", nButtons), vJoyInfo_panel);
            addLabel(String.Format("Axis X: {0}", AxisX ? "Yes" : "No"), vJoyInfo_panel);
            addLabel(String.Format("Axis Y: {0}", AxisX ? "Yes" : "No"), vJoyInfo_panel);
            addLabel(String.Format("Axis Z: {0}", AxisX ? "Yes" : "No"), vJoyInfo_panel);
            addLabel(String.Format("Axis Rx: {0}", AxisRX ? "Yes" : "No"), vJoyInfo_panel);
            addLabel(String.Format("Axis Rz: {0}", AxisRZ ? "Yes" : "No"), vJoyInfo_panel);
            addLabel(String.Format("Axis Accelerator: {0}", AxisGAS ? "Yes" : "No"), vJoyInfo_panel);
            addLabel(String.Format("Axis Brake: {0}", AxisBRK ? "Yes" : "No"), vJoyInfo_panel);

            // Print results
            Debug.WriteLine("\nvJoy Device {0} capabilities:", id);
            Debug.WriteLine("Number of buttons\t\t{0}", nButtons);
            Debug.WriteLine("Number of Continuous POVs\t{0}", ContPovNumber);
            Debug.WriteLine("Number of Descrete POVs\t\t{0}", DiscPovNumber);
            Debug.WriteLine("Axis X\t\t{0}", AxisX ? "Yes" : "No");
            Debug.WriteLine("Axis Y\t\t{0}", AxisX ? "Yes" : "No");
            Debug.WriteLine("Axis Z\t\t{0}", AxisX ? "Yes" : "No");
            Debug.WriteLine("Axis Rx\t\t{0}", AxisRX ? "Yes" : "No");
            Debug.WriteLine("Axis Rz\t\t{0}", AxisRZ ? "Yes" : "No");
        }
        
        private void vJoyDisconnect(uint id = 1)
        {
            Joystick.RelinquishVJD(id);
            statusvJoy_label.Text = "vJoy Not Connected";
            statusvJoy_label.ForeColor = Color.Black;
        }
        #endregion

        #region SimConnect  

        private void ConnectFS()
        {
            fsConnect = new FsConnect();
            fsConnect.SimConnectFileLocation = SimConnectFileLocation.Local;
            Process[] processes = Process.GetProcessesByName("FlightSimulator");
            if (processes.Length == 0)
            {

                Debug.WriteLine("Not running");
                isMSFSRunning = false;
               
            }
            else
            {
                Debug.WriteLine("Running");
                isMSFSRunning = true;
                try
                {
                    fsConnect.Connect("Test");

                }
                catch (Exception ex)
                {
                    //Debug.WriteLine(ex.ErrorCode.ToString());
                    Debug.WriteLine(ex.Message);
                    return;
                }
                fsConnect.FsDataReceived += FsConnect_FsDataReceived;
                //planeInfoDefinitionId = fsConnect.RegisterDataDefinition<PlaneInfoResponse>();
                fsConnect.SimStateChanged += FsConnect_SimStateChanged;
                fsConnect.AircraftLoaded += FsConnect_AircraftLoaded;
                fsConnect.Crashed += FsConnect_Crashed;
                fsConnect.FlightLoaded += FsConnect_FlightLoaded;
                timer1.Enabled = true;
                fsConnect_btn.Text = "Disconnect";
                statusSimConnect_label.Text = "Simulator Connected";
                statusSimConnect_label.ForeColor = Color.Green;
                GetSimVars();
                radioManager = new RadioManager(fsConnect);
                worldManager = new WorldManager(fsConnect);
                autopilotManager = new AutopilotManager(fsConnect);

                simManager_mainTab.Visible = true;
                time_time.ShowUpDown = true;
                time_time.Format = DateTimePickerFormat.Time;
              

            }
   
        }



        private void LoadManagers()
        {

            nav1Act_label.Text = String.Format("{0:0.00}", radioManager.Nav1ActiveFrequency);
            nav1Stby_label.Text = String.Format("{0:0.00}",radioManager.Nav1StandbyFrequency); 
            nav2Act_label.Text = String.Format("{0:0.00}", radioManager.Nav2ActiveFrequency); 
            nav2Stby_label.Text = String.Format("{0:0.00}", radioManager.Nav2StandbyFrequency);
            com1Act_label.Text = String.Format("{0:0.000}", radioManager.Com1ActiveFrequency);
            com1Stby_label.Text = String.Format("{0:0.000}", radioManager.Com1StandbyFrequency);
            com2Act_label.Text = String.Format("{0:0.000}", radioManager.Com2ActiveFrequency);
            com2Stby_label.Text = String.Format("{0:0.000}", radioManager.Com2StandbyFrequency);

        }

        private void RegisterDefinitions()
        {
           // definition.Add(new SimVar("Title", null, Microsoft.FlightSimulator.SimConnect.SIMCONNECT_DATATYPE.STRING256));
            fsConnect.RegisterDataDefinition<PlaneInfoResponse>(Requests.PlaneInfoRequest, definition);
        }

        private void AddDefinitionToData(FsSimVar var)
        {
            
        }

        private void FsConnect_FlightLoaded(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FsConnect_Crashed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FsConnect_AircraftLoaded(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DisconnectFS()
        {
            if(fsConnect != null)
            {
                fsConnect.Disconnect();
                timer1.Enabled = false;
                timer1.Interval = 250;
                fsConnect = null;
                fsConnect_btn.Text = "Connect";
                statusSimConnect_label.Text = "Simulator Not Connected";
                statusSimConnect_label.ForeColor = Color.Black;
                simManager_mainTab.Visible = false;
            }
        }

        private void GetSimVars()
        {
            foreach (var t in Enum.GetValues(typeof(FsSimVar)))
            {
                simVar_ComboBox.Items.Add(t);
                //Debug.WriteLine(t.ToString());
            }
            simVar_ComboBox.Visible = true;
            simVar_ComboBox.SelectedIndex = 0;

            foreach (var t in Enum.GetValues(typeof(FsUnit)))
            {
                simVarUnits_combo.Items.Add(t);
                //Debug.WriteLine(t.ToString());
            }
            simVarUnits_combo.Visible = true;
            simVarUnits_combo.SelectedIndex = 0;


            foreach (var s in Enum.GetValues(typeof(Microsoft.FlightSimulator.SimConnect.SIMCONNECT_DATATYPE)))
            {
                simVarDataType_combo.Items.Add(s);
                simVarDataType_combo.Visible = true;
                simVarDataType_combo.SelectedIndex = 0;
            }

            simVarAdd_button.Visible = true;
            registerVars_button.Visible = true;
        }

        private void simVarAdd_button_Click(object sender, EventArgs e)
        {
            
            definition.Add(new SimVar((FsSimVar)simVar_ComboBox.SelectedItem, (FsUnit)simVarUnits_combo.SelectedItem, (Microsoft.FlightSimulator.SimConnect.SIMCONNECT_DATATYPE)simVarDataType_combo.SelectedItem));
        }


        private void registerVars_button_Click(object sender, EventArgs e)
        {
            RegisterDefinitions();
        }
        private void FsConnect_SimStateChanged(object sender, SimStateChangedEventArgs e)
        {
            simState = e.Running;
            if(!isMSFSRunning && !simState)
            {
                DisconnectFS();
            } else
            {
                //do nothing
            }
            //Debug.WriteLine(e.Running.ToString());
        }

        private void FsConnect_FsDataReceived(object sender, FsDataReceivedEventArgs e)
        {
            
           // simConnectDebug_label.Visible = true;
           // simConnectDebug_label.Text = "";

            if (e.Data == null || e.Data.Count == 0) return;

            if (e.RequestId == (uint)Requests.PlaneInfoRequest)
            {
                PlaneInfoResponse r = (PlaneInfoResponse)e.Data.FirstOrDefault();
                responses = r;
              //  Debug.WriteLine($"{r.PlaneLatitude:F4} {r.PlaneLongitude:F4} {r.PlaneAltitude:F1}ft {r.PlaneHeadingDegreesTrue:F1}deg {r.AirspeedTrueInMeterPerSecond:F0}m/s {r.AirspeedTrueInKnot:F0}kt  {r.BrakeIndicator.ToString()}");

                foreach (FieldInfo n in typeof(PlaneInfoResponse).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                {

                    SetText(n.Name,n.GetValue(responses).ToString());
                }
                
                
            }
            
        }

        delegate void SetTextCallback(string name, string text);

        private void SetText(string name, string text)
        {

            if (simConnect_panel.InvokeRequired)
            {
               // Debug.WriteLine("Set text");
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { name, text });
            }
            else
            {

               // Debug.WriteLine("Text set");
                // this.metroTextBox1.AppendText(text + Environment.NewLine);
                //MetroLabel label = flowLayoutPanel1.Controls.Find(name, true).FirstOrDefault() as MetroLabel;
                Control[] tbxs = simConnect_panel.Controls.Find(name, true);
                if(tbxs != null && tbxs.Length > 0)
                {
                    tbxs[0].Text = name + ": " + text;
                }else
                {
                    addLabel(text, name, simConnect_panel);
                }


            }
        }
       
        #endregion

        #region FORM

        private void loadFonts()
        {
            //Create your private font collection object.
            PrivateFontCollection pfc = new PrivateFontCollection();

            //Select your font from the resources.
            //My font here is "Digireu.ttf"
            int fontLength = Properties.Resources.DS_DIGII.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.DS_DIGII;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);

           nav1Act_label.Font = new Font(pfc.Families[0], nav1Act_label.Font.Size);
            nav1Stby_label.Font = new Font(pfc.Families[0], nav1Act_label.Font.Size);
            nav2Act_label.Font = new Font(pfc.Families[0], nav1Act_label.Font.Size);
            nav2Stby_label.Font = new Font(pfc.Families[0], nav1Act_label.Font.Size);

            com1Act_label.Font = new Font(pfc.Families[0], nav1Act_label.Font.Size);
            com1Stby_label.Font = new Font(pfc.Families[0], nav1Act_label.Font.Size);
            com2Act_label.Font = new Font(pfc.Families[0], nav1Act_label.Font.Size);
            com2Stby_label.Font = new Font(pfc.Families[0], nav1Act_label.Font.Size);
        }
    
        private void ChangeBtnText(string text,MetroButton btn)
        {
            btn.Text = text;
        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                fsConnect.RequestData((int)Requests.PlaneInfoRequest, planeInfoDefinitionId);
                radioManager.Update();
               // autopilotManager.Update();
                LoadManagers();
            } catch (TimeoutException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void fsConnect_btn_Click(object sender, EventArgs e)
        {
            if(fsConnect == null && !simState)
            {
                ConnectFS();

            }else
            {
                DisconnectFS();
                simState = false;
                fsConnect_btn.Text = "Connect to MSFS";
            }
        }

        private void vJoyAcquire_btn_Click(object sender, EventArgs e)
        {
            if (!vJoyAcq)
            {
                CheckvJoyDriver();
            } else
            {
                foreach (uint id in sticksAcquired)
                {
                    Joystick.RelinquishVJD(id);
                    vJoyDisconnect(id);
                }
                vJoyAcq = false;
                ChangeBtnText("Acquire vJoy Device", vJoyAcquire_btn);

            }
        }

        private void addLabel(string text,MetroPanel mp,DockStyle ds = DockStyle.None)
        {
            MetroLabel lb = new MetroLabel();
            lb.Text = text;
            lb.AutoSize = true;
            lb.Dock = ds;
            lb.StyleManager = msm;

            mp.Controls.Add(lb);
        }
        private void addLabel(string text, FlowLayoutPanel mp, DockStyle ds = DockStyle.None)
        {
            MetroLabel lb = new MetroLabel();
            lb.Text = text;
            lb.AutoSize = true;
            lb.Dock = ds;
            lb.StyleManager = msm;

            mp.Controls.Add(lb);
        }
        private void addLabel(string text, string name, FlowLayoutPanel mp, DockStyle ds = DockStyle.None)
        {
            MetroLabel lb = new MetroLabel();
            lb.Text = text;
            lb.AutoSize = true;
            lb.Dock = ds;
            lb.StyleManager = msm;
            lb.Name = name;

            mp.Controls.Add(lb);
        }
        private void addLabel(string text, string name, MetroPanel mp, DockStyle ds = DockStyle.None)
        {
            MetroLabel lb = new MetroLabel();
            lb.Text = text;
            lb.AutoSize = true;
            lb.Dock = ds;
            lb.StyleManager = msm;
            lb.Name = name;

            mp.Controls.Add(lb);
        }
        private void updateLabelText(MetroLabel label, string text, bool visibility = true)
        {
            label.Text = text;
            label.Visible = visibility;
        }
        private void searchArduino_button_Click(object sender, EventArgs e)
        {
            
                ConnectArduino();
    
        }

        #endregion

        #region UI
        private void fillComboBoxes()
        {
            //Fill them combo box
           
            foreach(var t in Enum.GetValues(typeof(MetroThemeStyle)))
            {
                //Debug.WriteLine(t.ToString());
                theme_comboBox.Items.Add(t);
                
            }
            theme_comboBox.SelectedItem = MetroThemeStyle.Default;

            //fill style combobox
            
            foreach(var r in Enum.GetValues(typeof(MetroColorStyle)))
            {
                style_comboBox.Items.Add(r);
            }
            style_comboBox.SelectedItem = MetroColorStyle.Default;

        }
        private void changeTheme(MetroThemeStyle theme)
        {
            msm.Theme = theme;
        }
        private void changeStyle(MetroColorStyle style)
        {
            msm.Style = style;
        }
        private void theme_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeTheme((MetroThemeStyle)theme_comboBox.SelectedItem);
        }

        private void style_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeStyle((MetroColorStyle)style_comboBox.SelectedItem);
        }

        #endregion

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (worldManager != null)
            {
                DateTime myTime = new DateTime();
                
                myTime = worldDateTime_date.Value.Date + time_time.Value.TimeOfDay;
                myTime.ToLocalTime();
                worldManager.SetTime(myTime);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            radioManager.Nav1Swap();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            radioManager.Nav2Swap();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            radioManager.Com1Swap();

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            radioManager.Com2Swap();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {

            radioManager.SetNav1StandbyFrequency(radioManager.Nav1StandbyFrequency + 0.05);
        }

        private void nav1Dn_btn_Click(object sender, EventArgs e)
        {
            radioManager.SetNav1StandbyFrequency(radioManager.Nav1StandbyFrequency - 0.05);
        }

        private void nav2UP_btn_Click(object sender, EventArgs e)
        {
            radioManager.SetNav2StandbyFrequency(radioManager.Nav2StandbyFrequency + 0.05);
        }

        private void nav2Dn_btn_Click(object sender, EventArgs e)
        {
            radioManager.SetNav2StandbyFrequency(radioManager.Nav2StandbyFrequency - 0.05);
        }

        private void com1UP_btn_Click(object sender, EventArgs e)
        {
            radioManager.SetCom1StandbyFrequency(radioManager.Com1StandbyFrequency + 0.005);
        }

        private void com1Dn_btn_Click(object sender, EventArgs e)
        {
            radioManager.SetCom1StandbyFrequency(radioManager.Com1StandbyFrequency - 0.005);
        }

        private void com2Up_btn_Click(object sender, EventArgs e)
        {
            radioManager.SetCom2StandbyFrequency(radioManager.Com2StandbyFrequency + 0.005);
        }

        private void Com2Dn_btn_Click(object sender, EventArgs e)
        {
            radioManager.SetCom2StandbyFrequency(radioManager.Com2StandbyFrequency - 0.005);
        }
    }


    public class BoardInfo
    {
        public int totalPins;
        public List<PinCapability> analogPins = new List<PinCapability>();
        public List<PinCapability> digitalPins = new List<PinCapability>();
        public List<PinCapability> pwmPins = new List<PinCapability>();
        public List<PinCapability> encoderPins = new List<PinCapability>();
        public List<PinCapability> i2cPins = new List<PinCapability>();
        public List<PinCapability> pullupPins = new List<PinCapability>();
        public List<PinCapability> oneWirePins = new List<PinCapability>();
        public List<PinCapability> serialPins = new List<PinCapability>();
        public List<PinCapability> servoPins = new List<PinCapability>();
        public List<PinCapability> stepperPins = new List<PinCapability>();

    }
}
