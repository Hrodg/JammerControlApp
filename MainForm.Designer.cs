// Add the required namespace reference for System.Windows.Forms.DataVisualization.Charting  
using System.Windows.Forms.DataVisualization.Charting;
namespace JammerControlApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnrefreshPorts;
        private System.Windows.Forms.TextBox txtFreqStart;
        private System.Windows.Forms.TextBox txtFreqEnd;
        private System.Windows.Forms.ComboBox comboJammingType;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSpectrum;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.comboPort = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnrefreshPorts = new System.Windows.Forms.Button();
            this.txtFreqStart = new System.Windows.Forms.TextBox();
            this.txtFreqEnd = new System.Windows.Forms.TextBox();
            this.comboJammingType = new System.Windows.Forms.ComboBox();
            this.chartSpectrum = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblStatus = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.chartSpectrum)).BeginInit();
            this.SuspendLayout();

            // comboPort
            this.comboPort.FormattingEnabled = true;
            this.comboPort.Location = new System.Drawing.Point(20, 20);
            this.comboPort.Name = "comboPort";
            this.comboPort.Size = new System.Drawing.Size(100, 21);

            // btnConnect
            this.btnConnect.Location = new System.Drawing.Point(130, 20);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(110, 23);
            this.btnConnect.Text = "Подключиться";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);

            // btnDisconnect
            this.btnDisconnect.Location = new System.Drawing.Point(250, 20);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(110, 23);
            this.btnDisconnect.Text = "Отключиться";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);

            // btnrefreshPorts
            this.btnrefreshPorts.Location = new System.Drawing.Point(370, 20);
            this.btnrefreshPorts.Name = "btnrefreshPorts";
            this.btnrefreshPorts.Size = new System.Drawing.Size(110, 23);
            this.btnrefreshPorts.Text = "Обновить";
            this.btnrefreshPorts.UseVisualStyleBackColor = true;
            this.btnrefreshPorts.Click += new System.EventHandler(this.btnRefreshPorts_Click);

            // txtFreqStart
            this.txtFreqStart.Location = new System.Drawing.Point(20, 60);
            this.txtFreqStart.Name = "txtFreqStart";
            this.txtFreqStart.Size = new System.Drawing.Size(80, 20);

            // txtFreqEnd
            this.txtFreqEnd.Location = new System.Drawing.Point(110, 60);
            this.txtFreqEnd.Name = "txtFreqEnd";
            this.txtFreqEnd.Size = new System.Drawing.Size(80, 20);

            // comboJammingType
            this.comboJammingType.FormattingEnabled = true;
            this.comboJammingType.Items.AddRange(new object[] {
                "Noise", "Pulse", "Sweep"
            });
            this.comboJammingType.Location = new System.Drawing.Point(200, 60);
            this.comboJammingType.Name = "comboJammingType";
            this.comboJammingType.Size = new System.Drawing.Size(120, 21);

            // chartSpectrum
            chartArea.Name = "ChartArea1";
            this.chartSpectrum.ChartAreas.Add(chartArea);
            this.chartSpectrum.Location = new System.Drawing.Point(20, 100);
            this.chartSpectrum.Name = "chartSpectrum";
            series.ChartArea = "ChartArea1";
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series.Name = "Spectrum";
            this.chartSpectrum.Series.Add(series);
            this.chartSpectrum.Size = new System.Drawing.Size(600, 300);

            // lblStatus
            this.lblStatus.Location = new System.Drawing.Point(20, 420);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(600, 23);
            this.lblStatus.Text = "Статус: Отключено";

            // MainForm
            this.ClientSize = new System.Drawing.Size(650, 460);
            this.Controls.Add(this.comboPort);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnrefreshPorts);
            this.Controls.Add(this.txtFreqStart);
            this.Controls.Add(this.txtFreqEnd);
            this.Controls.Add(this.comboJammingType);
            this.Controls.Add(this.chartSpectrum);
            this.Controls.Add(this.lblStatus);
            this.Name = "MainForm";
            this.Text = "Генератор Помех - Управление";

            ((System.ComponentModel.ISupportInitialize)(this.chartSpectrum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

