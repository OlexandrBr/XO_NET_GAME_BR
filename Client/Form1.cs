using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Button[] gameButtons = new Button[9];
        private bool isConnected = false;

        private string NickName; // Ігровий нікнейм
        private string mySymbol; // "X" або "O"
        private int pressedIndex = -1; // Індекс останньої натиснутої кнопки
        public Form1()
        {
            InitializeComponent();
            SetupCustomLogic();
        }
        private void SetupCustomLogic()
        {
            gameButtons = new Button[9];

            int startX = 40;
            int startY = 40;
            int size = 100;
            int gap = 10;

            for (int i = 0; i < 9; i++)
            {
                int row = i / 3;
                int col = i % 3;

                Button btn = CreateGameButton(
                    startX + col * (size + gap),
                    startY + row * (size + gap)
                );

                btn.Name = $"button{i + 1}";
                btn.Tag = i;

                gameButtons[i] = btn;
                groupBox2.Controls.Add(btn);
            }

            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
        }

        private async Task SendPacket(string msg)
        {
            if (!isConnected) return;
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(msg);
                await stream.WriteAsync(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка відправки даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!groupBox2.Enabled)
            {
                MessageBox.Show("Ви не можете зробити хід зараз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Button btn = (Button)sender;

            if (!string.IsNullOrEmpty(btn.Text))
            {
                MessageBox.Show("Ця клітинка вже зайнята! Оберіть іншу!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = (int)btn.Tag;
            await SendPacket($"MOVE|{index}");
        }

        private async void btn_Connect_Click(object sender, EventArgs e)
        {
            if (isConnected) return;
            if (string.IsNullOrWhiteSpace(txt_NickName.Text)) return;
            NickName = txt_NickName.Text.Trim();
            try
            {
                isConnected = true;
                client = new TcpClient();
                await client.ConnectAsync(txt_IpServer.Text, Convert.ToInt32(txt_ServerPort.Text));
                stream = client.GetStream();
                _ = ListenForPackets();
                await SendPacket($"LOGIN|{NickName}");
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                groupBox1.Text = $"Підключено як: {NickName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка підключення: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isConnected = false;
            }
        }

        private async Task ListenForPackets()
        {
            byte[] buffer = new byte[1024];
            while (isConnected)
            {
                try
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Сервер закрив з'єднання
                    string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    this.Invoke((MethodInvoker)delegate
                    {
                        ProcessServerMessage(msg);
                    });
                }
                catch (Exception ex)
                {
                    isConnected = false;
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Помилка з'єднання: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        groupBox2.Enabled = false;
                        groupBox3.Enabled = false;
                        groupBox1.Text = "Не підключено";
                    });
                    break;
                }
            }
        }

        private void ProcessServerMessage(string msg)
        {
            string[] parts = msg.Split('|');
            string command = parts[0];
            switch (command)
            {
                case "LOBBY_LIST":
                    lst_Rooms.Items.Clear();
                    if (parts.Length > 1 && !string.IsNullOrEmpty(parts[1]))
                    {
                        var rooms = parts[1].Split(',');
                        lst_Rooms.Items.AddRange(rooms);
                    }
                    break;
                case "ROOM_CREATED":
                    MessageBox.Show($"Кімната '{parts[1]}' створена!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupBox3.Enabled = false;
                    break;
                case "GAME_START":
                    mySymbol = parts[1];
                    string opponent = parts[2];
                    StartGameUI(opponent);
                    break;
                case "UPDATE":
                    int index = int.Parse(parts[1]);
                    string symbol = parts[2];
                    UpdateBoard(index, symbol);
                    break;
                case "TURN":
                    string currentTurnNick = parts[1];
                    groupBox2.Text = (currentTurnNick == NickName) ? "Ваш хід!" : $"Хід супротивника: {currentTurnNick}";
                    break;
                case "WIN":
                    MessageBox.Show($"Гра завершена! Переміг: {parts[1]}", "Гра завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetGameUI();
                    break;
                case "DRAW":
                    MessageBox.Show("Гра завершена! Нічия!", "Гра завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetGameUI();
                    break;
                case "OPPONENT_LEFT":
                    MessageBox.Show("Ваш супротивник вийшов з гри!", "Гра завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetGameUI();
                    break;
                case "ERROR":
                    MessageBox.Show($"Помилка від сервера: {parts[1]}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "LEADERBOARD":
                    listBoxLeaderboard.Items.Clear();

                    if (parts.Length > 1 && !string.IsNullOrWhiteSpace(parts[1]))
                    {
                        string[] leaders = parts[1].Split(';');
                        listBoxLeaderboard.Items.AddRange(leaders);
                    }
                    else
                    {
                        listBoxLeaderboard.Items.Add("Поки що немає результатів");
                    }
                    break;
            }
        }

        private void ResetGameUI()
        {
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
            btn_createRoom.Enabled = true;
            groupBox2.Text = "Ігрове поле";
            foreach (var btn in gameButtons)
            {
                btn.Text = "";
                btn.BackColor = SystemColors.Control;
            }
            _ = SendPacket("REFRESH_LOBBY");
        }

        private void UpdateBoard(int index, string symbol)
        {
            if (index >= 0 && index < gameButtons.Length)
            {
                gameButtons[index].Text = symbol;
                if (symbol == "X")
                {
                    gameButtons[index].BackColor = Color.Yellow;
                }
                else
                {
                    gameButtons[index].BackColor = Color.Blue;
                }
            }
        }

        private void StartGameUI(string opponent)
        {
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
            groupBox2.Text = $"Ірове поле: Ви {NickName} символ: {mySymbol} vs {opponent} {(mySymbol == "X" ? "O" : "X")}";

            foreach (var btn in gameButtons)
            {
                btn.Text = "";
                btn.BackColor = SystemColors.Control;
            }
        }

        private async void btn_createRoom_Click(object sender, EventArgs e)
        {
            string roomName = txt_roomName.Text.Trim();
            if (string.IsNullOrWhiteSpace(roomName))
            {
                MessageBox.Show("Назва кімнати не може бути порожньою!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            await SendPacket($"CREATE_ROOM|{roomName}");
            await SendPacket("REFRESH_LOBBY");
            btn_createRoom.Enabled = false;
        }

        private async void lst_Rooms_DoubleClick(object sender, EventArgs e)
        {
            if (lst_Rooms.SelectedItems != null)
            {
                string roomName = lst_Rooms.SelectedItem.ToString();
                await SendPacket($"JOIN_ROOM|{roomName}");
            }
        }

        private async void btn_updateRoom_Click(object sender, EventArgs e)
        {
            await SendPacket("REFRESH_LOBBY");
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            listBoxLeaderboard.Items.Clear();
            await SendPacket("GET_LEADERBOARD");
        }
    }
}
