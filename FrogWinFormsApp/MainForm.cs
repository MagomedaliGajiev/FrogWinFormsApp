namespace FrogWinFormsApp
{
    public partial class MainForm : Form
    {
        private int startLocationXEmptyPictureBox = 440;
        public MainForm()
        {
            InitializeComponent();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Swap((PictureBox)sender);
            if (EndGame())
            {
                if (CanBeBetter(Convert.ToInt32(scoreLabel.Text)))
                {
                    MessageBox.Show("�� ���������� �� ����������� ���������� �����");
                }
                else
                {
                    var result = MessageBox.Show("����� �����. ������ ����������� ��� ���?", "����� ����", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                }
            }

        }

        private void Swap(PictureBox clickedPictureBox)
        {
            var distance = Math.Abs(clickedPictureBox.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Size.Width;

            if (distance > 2)
            {
                MessageBox.Show("��� ������!");
            }
            else
            {
                var location = clickedPictureBox.Location;
                clickedPictureBox.Location = emptyPictureBox.Location;
                emptyPictureBox.Location = location;
                scoreLabel.Text = (Convert.ToInt32(scoreLabel.Text) + 1).ToString();
            }
        }

        private bool EndGame()
        {

            if (leftPictureBox1.Location.X > emptyPictureBox.Location.X &&
                leftPictureBox2.Location.X > emptyPictureBox.Location.X &&
                leftPictureBox3.Location.X > emptyPictureBox.Location.X &&
                leftPictureBox4.Location.X > emptyPictureBox.Location.X &&
                emptyPictureBox.Location.X == startLocationXEmptyPictureBox
                )
            {
                leftPictureBox1.Enabled = false;
                leftPictureBox2.Enabled = false;
                leftPictureBox3.Enabled = false;
                leftPictureBox4.Enabled = false;

                rightPictureBox1.Enabled = false;
                rightPictureBox2.Enabled = false;
                rightPictureBox3.Enabled = false;
                rightPictureBox4.Enabled = false;

                return true;
            }
            return false;
        }

        private bool CanBeBetter(int moves)
        {
            var minMoves = 24;
            return moves == minMoves;
        }

        private void rulesButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"���� ���� � ����������� �������, ������� ������� �����, � ����� �����, " +
                $"� ��������� - � ������ ����� �� ����������� ���������� ��������������." +
                $"\r\n\r\n������� ����� �� ������, ���� �� ��������� ����� ��� ����� 1 �������");
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
