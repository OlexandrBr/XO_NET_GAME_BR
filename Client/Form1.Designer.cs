using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;

        private TextBox txt_NickName;
        private TextBox txt_IpServer;
        private TextBox txt_ServerPort;
        private TextBox txt_roomName;

        private Button btn_Connect;
        private Button btn_createRoom;
        private Button btn_updateRoom;

        private ListBox lst_Rooms;

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            lblNick = new Label();
            txt_NickName = new TextBox();
            lblIp = new Label();
            txt_IpServer = new TextBox();
            lblPort = new Label();
            txt_ServerPort = new TextBox();
            btn_Connect = new Button();
            groupBox3 = new GroupBox();
            lst_Rooms = new ListBox();
            txt_roomName = new TextBox();
            btn_createRoom = new Button();
            btn_updateRoom = new Button();
            groupBox2 = new GroupBox();
            listBoxLeaderboard = new ListBox();
            button10 = new Button();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblNick);
            groupBox1.Controls.Add(txt_NickName);
            groupBox1.Controls.Add(lblIp);
            groupBox1.Controls.Add(txt_IpServer);
            groupBox1.Controls.Add(lblPort);
            groupBox1.Controls.Add(txt_ServerPort);
            groupBox1.Controls.Add(btn_Connect);
            groupBox1.Location = new Point(10, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(260, 200);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Підключення";
            // 
            // lblNick
            // 
            lblNick.Location = new Point(15, 25);
            lblNick.Name = "lblNick";
            lblNick.Size = new Size(100, 23);
            lblNick.TabIndex = 0;
            lblNick.Text = "Нікнейм:";
            // 
            // txt_NickName
            // 
            txt_NickName.Location = new Point(15, 45);
            txt_NickName.Name = "txt_NickName";
            txt_NickName.Size = new Size(220, 39);
            txt_NickName.TabIndex = 1;
            // 
            // lblIp
            // 
            lblIp.Location = new Point(15, 75);
            lblIp.Name = "lblIp";
            lblIp.Size = new Size(100, 23);
            lblIp.TabIndex = 2;
            lblIp.Text = "IP:";
            // 
            // txt_IpServer
            // 
            txt_IpServer.Location = new Point(15, 95);
            txt_IpServer.Name = "txt_IpServer";
            txt_IpServer.Size = new Size(220, 39);
            txt_IpServer.TabIndex = 3;
            txt_IpServer.Text = "127.0.0.1";
            // 
            // lblPort
            // 
            lblPort.Location = new Point(15, 125);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(100, 23);
            lblPort.TabIndex = 4;
            lblPort.Text = "Порт:";
            // 
            // txt_ServerPort
            // 
            txt_ServerPort.Location = new Point(15, 145);
            txt_ServerPort.Name = "txt_ServerPort";
            txt_ServerPort.Size = new Size(220, 39);
            txt_ServerPort.TabIndex = 5;
            txt_ServerPort.Text = "8848";
            // 
            // btn_Connect
            // 
            btn_Connect.BackColor = Color.MediumSeaGreen;
            btn_Connect.FlatStyle = FlatStyle.Flat;
            btn_Connect.ForeColor = Color.White;
            btn_Connect.Location = new Point(15, 170);
            btn_Connect.Name = "btn_Connect";
            btn_Connect.Size = new Size(220, 30);
            btn_Connect.TabIndex = 6;
            btn_Connect.Text = "Підключитися";
            btn_Connect.UseVisualStyleBackColor = false;
            btn_Connect.Click += btn_Connect_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lst_Rooms);
            groupBox3.Controls.Add(txt_roomName);
            groupBox3.Controls.Add(btn_createRoom);
            groupBox3.Controls.Add(btn_updateRoom);
            groupBox3.Location = new Point(10, 220);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(260, 270);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Лоббі";
            // 
            // lst_Rooms
            // 
            lst_Rooms.Location = new Point(15, 25);
            lst_Rooms.Name = "lst_Rooms";
            lst_Rooms.Size = new Size(220, 100);
            lst_Rooms.TabIndex = 0;
            lst_Rooms.DoubleClick += lst_Rooms_DoubleClick;
            // 
            // txt_roomName
            // 
            txt_roomName.Location = new Point(15, 160);
            txt_roomName.Name = "txt_roomName";
            txt_roomName.Size = new Size(220, 39);
            txt_roomName.TabIndex = 1;
            // 
            // btn_createRoom
            // 
            btn_createRoom.BackColor = Color.DodgerBlue;
            btn_createRoom.FlatStyle = FlatStyle.Flat;
            btn_createRoom.ForeColor = Color.White;
            btn_createRoom.Location = new Point(15, 190);
            btn_createRoom.Name = "btn_createRoom";
            btn_createRoom.Size = new Size(220, 30);
            btn_createRoom.TabIndex = 2;
            btn_createRoom.Text = "Створити кімнату";
            btn_createRoom.UseVisualStyleBackColor = false;
            btn_createRoom.Click += btn_createRoom_Click;
            // 
            // btn_updateRoom
            // 
            btn_updateRoom.Location = new Point(15, 225);
            btn_updateRoom.Name = "btn_updateRoom";
            btn_updateRoom.Size = new Size(220, 30);
            btn_updateRoom.TabIndex = 3;
            btn_updateRoom.Text = "Оновити";
            btn_updateRoom.Click += btn_updateRoom_Click;
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(300, 50);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(450, 400);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ігрове поле";
            // 
            // listBoxLeaderboard
            // 
            listBoxLeaderboard.FormattingEnabled = true;
            listBoxLeaderboard.Location = new Point(1008, 116);
            listBoxLeaderboard.Name = "listBoxLeaderboard";
            listBoxLeaderboard.Size = new Size(419, 324);
            listBoxLeaderboard.TabIndex = 3;
            // 
            // button10
            // 
            button10.Location = new Point(1085, 48);
            button10.Name = "button10";
            button10.Size = new Size(268, 46);
            button10.TabIndex = 4;
            button10.Text = "Таблиця лідерів";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // Form1
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1512, 520);
            Controls.Add(button10);
            Controls.Add(listBoxLeaderboard);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Крестики-Нолики Online";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        private Button CreateGameButton(int x, int y)
        {
            Button btn = new Button();
            btn.Location = new Point(x, y);
            btn.Size = new Size(100, 100);
            btn.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.Click += button1_Click;
            return btn;
        }
        private Label lblNick;
        private Label lblIp;
        private Label lblPort;
        private ListBox listBoxLeaderboard;
        private Button button10;
    }
}
