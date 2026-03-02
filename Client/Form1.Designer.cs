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
            this.SuspendLayout();

            this.Text = "Крестики-Нолики Online";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.ClientSize = new Size(900, 520);
            this.BackColor = Color.WhiteSmoke;

            // ================= GROUPBOX 1 =================
            groupBox1 = new GroupBox();
            groupBox1.Text = "Підключення";
            groupBox1.Location = new Point(10, 10);
            groupBox1.Size = new Size(260, 200);

            Label lblNick = new Label();
            lblNick.Text = "Нікнейм:";
            lblNick.Location = new Point(15, 25);

            txt_NickName = new TextBox();
            txt_NickName.Location = new Point(15, 45);
            txt_NickName.Size = new Size(220, 23);

            Label lblIp = new Label();
            lblIp.Text = "IP:";
            lblIp.Location = new Point(15, 75);

            txt_IpServer = new TextBox();
            txt_IpServer.Location = new Point(15, 95);
            txt_IpServer.Size = new Size(220, 23);
            txt_IpServer.Text = "127.0.0.1";

            Label lblPort = new Label();
            lblPort.Text = "Порт:";
            lblPort.Location = new Point(15, 125);

            txt_ServerPort = new TextBox();
            txt_ServerPort.Location = new Point(15, 145);
            txt_ServerPort.Size = new Size(220, 23);
            txt_ServerPort.Text = "8848";

            btn_Connect = new Button();
            btn_Connect.Text = "Підключитися";
            btn_Connect.Location = new Point(15, 170);
            btn_Connect.Size = new Size(220, 30);
            btn_Connect.BackColor = Color.MediumSeaGreen;
            btn_Connect.ForeColor = Color.White;
            btn_Connect.FlatStyle = FlatStyle.Flat;
            btn_Connect.Click += btn_Connect_Click;

            groupBox1.Controls.Add(lblNick);
            groupBox1.Controls.Add(txt_NickName);
            groupBox1.Controls.Add(lblIp);
            groupBox1.Controls.Add(txt_IpServer);
            groupBox1.Controls.Add(lblPort);
            groupBox1.Controls.Add(txt_ServerPort);
            groupBox1.Controls.Add(btn_Connect);

            // ================= GROUPBOX 3 =================
            groupBox3 = new GroupBox();
            groupBox3.Text = "Лоббі";
            groupBox3.Location = new Point(10, 220);
            groupBox3.Size = new Size(260, 270);

            lst_Rooms = new ListBox();
            lst_Rooms.Location = new Point(15, 25);
            lst_Rooms.Size = new Size(220, 120);
            lst_Rooms.DoubleClick += lst_Rooms_DoubleClick;

            txt_roomName = new TextBox();
            txt_roomName.Location = new Point(15, 160);
            txt_roomName.Size = new Size(220, 23);

            btn_createRoom = new Button();
            btn_createRoom.Text = "Створити кімнату";
            btn_createRoom.Location = new Point(15, 190);
            btn_createRoom.Size = new Size(220, 30);
            btn_createRoom.BackColor = Color.DodgerBlue;
            btn_createRoom.ForeColor = Color.White;
            btn_createRoom.FlatStyle = FlatStyle.Flat;
            btn_createRoom.Click += btn_createRoom_Click;

            btn_updateRoom = new Button();
            btn_updateRoom.Text = "Оновити";
            btn_updateRoom.Location = new Point(15, 225);
            btn_updateRoom.Size = new Size(220, 30);
            btn_updateRoom.Click += btn_updateRoom_Click;

            groupBox3.Controls.Add(lst_Rooms);
            groupBox3.Controls.Add(txt_roomName);
            groupBox3.Controls.Add(btn_createRoom);
            groupBox3.Controls.Add(btn_updateRoom);

            // ================= GROUPBOX 2 =================
            groupBox2 = new GroupBox();
            groupBox2.Text = "Ігрове поле";
            groupBox2.Location = new Point(300, 50);
            groupBox2.Size = new Size(450, 400);

            int size = 100;
            int gap = 10;

            button1 = CreateGameButton(50, 40);
            button2 = CreateGameButton(50 + size + gap, 40);
            button3 = CreateGameButton(50 + (size + gap) * 2, 40);

            button4 = CreateGameButton(50, 40 + size + gap);
            button5 = CreateGameButton(50 + size + gap, 40 + size + gap);
            button6 = CreateGameButton(50 + (size + gap) * 2, 40 + size + gap);

            button7 = CreateGameButton(50, 40 + (size + gap) * 2);
            button8 = CreateGameButton(50 + size + gap, 40 + (size + gap) * 2);
            button9 = CreateGameButton(50 + (size + gap) * 2, 40 + (size + gap) * 2);

            groupBox2.Controls.AddRange(new Control[]
            {
                button1,button2,button3,
                button4,button5,button6,
                button7,button8,button9
            });

            this.Controls.Add(groupBox1);
            this.Controls.Add(groupBox2);
            this.Controls.Add(groupBox3);

            this.ResumeLayout(false);
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
    }
}
