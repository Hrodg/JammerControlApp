using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace JammerControlApp
{
    public partial class MainForm : Form
    {
        private SerialPort serialPort;
        private string logPath = "log.txt";
        private string dataPath = "spectrum_data.csv";
        private int baudRate = 9600;

        public MainForm()
        {
            InitializeComponent();
            LoadAvailablePorts();
        }

        private void LoadAvailablePorts()
        {
            comboPort.Items.Clear();
            comboPort.Items.AddRange(SerialPort.GetPortNames());
            if (comboPort.Items.Count > 0)
                comboPort.SelectedIndex = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboPort.SelectedItem == null)
                {
                    MessageBox.Show("Выберите COM-порт.");
                    return;
                }

                serialPort = new SerialPort(comboPort.SelectedItem.ToString(), baudRate);
                serialPort.DataReceived += SerialPort_DataReceived;
                serialPort.Open();

                lblStatus.Text = "Статус: Подключено";
                Log("Подключение к " + serialPort.PortName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения: " + ex.Message);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();
                    lblStatus.Text = "Статус: Отключено";
                    Log("Отключение от порта");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при отключении: " + ex.Message);
            }
        }

        private void btnRefreshPorts_Click(object sender, EventArgs e)
        {
            comboPort.Items.Clear();
            comboPort.Items.AddRange(SerialPort.GetPortNames());
            if (comboPort.Items.Count > 0)
                comboPort.SelectedIndex = 0;
        }


        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string line = serialPort.ReadLine();
                Log("Получено: " + line);
                this.Invoke(new Action(() => ProcessData(line)));
            }
            catch (Exception ex)
            {
                Log("Ошибка при приёме данных: " + ex.Message);
            }
        }

        private void ProcessData(string line)
        {
            // Пример строки: DATA:FREQ_START=1000;FREQ_END=1500;TYPE=NOISE;SPECTRUM=1,2,3,4,...
            try
            {
                if (!line.StartsWith("DATA:"))
                    return;

                string[] parts = line.Substring(5).Split(';');
                string freqStart = parts[0].Split('=')[1];
                string freqEnd = parts[1].Split('=')[1];
                string type = parts[2].Split('=')[1];
                string[] spectrum = parts[3].Split('=')[1].Split(',');

                txtFreqStart.Text = freqStart;
                txtFreqEnd.Text = freqEnd;
                comboJammingType.SelectedItem = type;

                chartSpectrum.Series["Spectrum"].Points.Clear();
                for (int i = 0; i < spectrum.Length; i++)
                {
                    if (double.TryParse(spectrum[i], out double y))
                        chartSpectrum.Series["Spectrum"].Points.AddXY(i, y);
                }

                SaveData(freqStart, freqEnd, type, spectrum);
            }
            catch (Exception ex)
            {
                Log("Ошибка обработки строки: " + ex.Message);
            }
        }

        private void SaveData(string freqStart, string freqEnd, string type, string[] spectrum)
        {
            try
            {
                if (!File.Exists(dataPath))
                {
                    File.WriteAllText(dataPath, "FreqStart,FreqEnd,Type,Spectrum\n");
                }

                string line = $"{freqStart},{freqEnd},{type},\"{string.Join(",", spectrum)}\"";
                File.AppendAllText(dataPath, line + "\n");
            }
            catch (Exception ex)
            {
                Log("Ошибка при сохранении данных: " + ex.Message);
            }
        }

        private void Log(string message)
        {
            try
            {
                File.AppendAllText(logPath, $"{DateTime.Now}: {message}\n");
            }
            catch
            {
                // Игнорируем ошибки логирования
            }
        }
    }
}
