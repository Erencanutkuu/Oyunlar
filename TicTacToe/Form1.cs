using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private bool isGameOver = false; // Oyun durumu kontrolü
        private bool isPlayerTurn = true; // Oyuncu sırası mı, CPU sırası mı?

        public enum Player
        {
            X,
            O
        }

        Player currentPlayer;
        Random random = new Random();
        int playerWinCount = 0;
        int cpuWinCount = 0;
        List<Button> buttons;
        int gridSize = 3; // Varsayılan oyun alanı boyutu 3x3
        int winCondition = 3; // Varsayılan kazanma koşulu 3 sıra

        public Form1()
        {
            InitializeComponent();
            ShowGameOptions();
            InitializeGameControls();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeGameControls()
        {
            label1.Location = new Point(10, 10);
            label1.Size = new Size(100, 20);
            label1.Text = "Oyuncu Skor: 0";
            Controls.Add(label1);

            label2.Location = new Point(ClientSize.Width - 120, 10); // Sağ üst
            label2.Size = new Size(100, 20);
            label2.Text = "CPU Skor: 0";
            Controls.Add(label2);

            // Timer ayarları
            CPUTimer.Interval = 100; // CPU'nun hamlesi için zamanlayıcıyı 1 saniye aralıkla çalıştır
            CPUTimer.Tick += CPUmove;
        }

        private void ShowGameOptions()
        {
            var dialog = MessageBox.Show("Oyun alanı 3x3 mü olsun?", "Oyun Alanı Seçimi",
                MessageBoxButtons.YesNoCancel);
            if (dialog == DialogResult.Yes)
            {
                gridSize = 3;
                winCondition = 3;
            }
            else if (dialog == DialogResult.No)
            {
                var dialog2 = MessageBox.Show("Oyun alanı 4x4 mü olsun?", "Oyun Alanı Seçimi", MessageBoxButtons.YesNo);
                if (dialog2 == DialogResult.Yes)
                {
                    gridSize = 4;
                    winCondition = 4;
                }
                else
                {
                    gridSize = 5;
                    winCondition = 4;
                }
            }

            RestartGame();
        }

        private void CPUmove(object sender, EventArgs e)
        {
            if (!isPlayerTurn && !isGameOver) // Eğer oyun bitmemişse ve oyuncu sırası değilse CPU hamlesini yap
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.DarkBlue;
                buttons.RemoveAt(index);
                CheckGame();
                isPlayerTurn = true; // CPU hamlesi bitince, oyuncuya sıra ver
                CPUTimer.Stop(); // CPU'nun hamlesi bitince zamanlayıcıyı durdur
            }
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (isGameOver || button.Enabled == false || !isPlayerTurn)
                return; // Eğer oyun bitmişse veya buton zaten tıklanmışsa, işlem yapılmaz

            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.Red;
            buttons.Remove(button);
            CheckGame();
            isPlayerTurn = false; // Oyuncu hamlesi tamamlandıktan sonra CPU'ya sıra ver
            CPUTimer.Start(); // CPU'nun hamlesini başlat
        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            RestartGame(); // Yeniden boyutlandırıldığında oyun düzenini yeniden oluştur
        }

        private void CheckGame()
        {
            if (isGameOver) return; // Oyun bitmişse daha fazla kontrol yapma

            var matrix = new string[gridSize, gridSize];
            foreach (Control ctrl in Controls)
            {
                if (ctrl is Button btn && btn.Tag != null)
                {
                    var position = btn.Tag.ToString().Split(',');
                    int x = int.Parse(position[0]);
                    int y = int.Parse(position[1]);
                    matrix[x, y] = btn.Text;
                }
            }

            if (CheckWin(Player.X.ToString(), matrix))
            {
                isGameOver = true;
                MessageBox.Show("Oyuncu kazandı");
                playerWinCount++;
                label1.Text = "Oyuncu Skor: " + playerWinCount;
                RestartGame();
                return;
            }
            else if (CheckWin(Player.O.ToString(), matrix))
            {
                isGameOver = true;
                MessageBox.Show("CPU kazandı");
                cpuWinCount++;
                label2.Text = "CPU Skor: " + cpuWinCount;
                RestartGame();
                return;
            }

            // Beraberlik kontrolü
            if (buttons.All(b => b.Enabled == false))
            {
                isGameOver = true;
                MessageBox.Show("Beraberlik!");
                RestartGame();
            }
        }

        private bool CheckWin(string player, string[,] board)
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    // Satır, sütun ve çapraz kazanma kontrolleri
                    if (CheckLine(player, board, i, j, 1, 0) || // Yatay
                        CheckLine(player, board, i, j, 0, 1) || // Dikey
                        CheckLine(player, board, i, j, 1, 1) || // Çapraz sağ aşağı
                        CheckLine(player, board, i, j, 1, -1)) // Çapraz sağ yukarı
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckLine(string player, string[,] board, int x, int y, int dx, int dy)
        {
            int count = 0;
            for (int i = 0; i < winCondition; i++)
            {
                int nx = x + i * dx;
                int ny = y + i * dy;
                if (nx >= 0 && ny >= 0 && nx < gridSize && ny < gridSize && board[nx, ny] == player)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count == winCondition;
        }

        private Button restartButton;

        private void RestartGame()
        {
            isGameOver = false; // Yeni oyun için bayrağı sıfırla
            buttons = new List<Button>();

            var controlsToRemove = Controls.OfType<Button>().Where(b => b != restartButton).ToList();
            foreach (var btn in controlsToRemove)
            {
                Controls.Remove(btn);
            }

            int margin = 20; // Izgaranın ekrandan boşluk bırakacağı mesafe
            int buttonSize = Math.Min((ClientSize.Width - 2 * margin) / gridSize,
                (ClientSize.Height - 2 * margin) / (gridSize + 1)); // Yeniden Başla için ek satır

            int gridWidth = gridSize * buttonSize;
            int gridHeight = gridSize * buttonSize;

            int startX = (ClientSize.Width - gridWidth) / 2;
            int startY = (ClientSize.Height - gridHeight) / 2;

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(startX + (buttonSize * i), startY + (buttonSize * j)),
                        Text = "",
                        Tag = $"{i},{j}"
                    };
                    btn.Click += PlayerClickButton;
                    buttons.Add(btn);
                    Controls.Add(btn);
                }
            }

            // Yeniden Başla butonunu oluştur veya güncelle
            if (restartButton == null)
            {
                restartButton = new Button
                {
                    Text = "Yeniden Başla",
                    Size = new Size(150, 40),
                    BackColor = Color.Green, // Yeşil arka plan
                    ForeColor = Color.Black, // Siyah yazı rengi
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat
                };
                restartButton.FlatAppearance.BorderSize = 2; // Beyaz kenarlık kalınlığı
                restartButton.FlatAppearance.BorderColor = Color.Wheat; // Beyaz kenarlık rengi
                restartButton.Click += RestartGame;
                Controls.Add(restartButton);
            }

            // Yeniden Başla butonunun konumunu ayarla
            restartButton.Location = new Point((ClientSize.Width - restartButton.Width) / 2, startY + gridHeight + 10);

            // Skor etiketlerini yeniden ekle
            label1.Location = new Point(10, 10);
            label2.Location = new Point(ClientSize.Width - label2.Width - 10, 10);
            Controls.Add(label1);
            Controls.Add(label2);
        }
    }
}
