using System.Runtime.InteropServices;

namespace PCaffeine;

public partial class MainForm : Form
{
    [DllImport("kernel32.dll")]
    private static extern uint SetThreadExecutionState(uint esFlags);

    private const uint EsContinuous = 0x80000000;
    private const uint EsSystemRequired = 0x00000001;

    public MainForm()
    {
        InitializeComponent();

        // PCのスリープを防止
        SetThreadExecutionState(
            EsContinuous |
            EsSystemRequired
        );

        // ウィンドウ設定
        Text = "PCaffeine";
        ClientSize = new Size(360, 180);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        // タイトル
        var titleLabel = new Label();
        titleLabel.Text = "☕ PCaffeine";
        titleLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold);
        titleLabel.AutoSize = true;
        titleLabel.Left = 25;
        titleLabel.Top = 20;

        // 状態表示
        var statusLabel = new Label();
        statusLabel.Text = "PC is caffeinated.\nSleep prevention is active.";
        statusLabel.Font = new Font("Segoe UI", 10);
        statusLabel.AutoSize = true;
        statusLabel.Left = 28;
        statusLabel.Top = 70;

        // 終了ボタン
        var exitButton = new Button();
        exitButton.Text = "Exit";
        exitButton.Width = 80;
        exitButton.Height = 30;
        exitButton.Left = 250;
        exitButton.Top = 125;

        exitButton.Click += (_, _) =>
        {
            Close();
        };

        Controls.Add(titleLabel);
        Controls.Add(statusLabel);
        Controls.Add(exitButton);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        // スリープ防止を解除
        SetThreadExecutionState(EsContinuous);

        base.OnFormClosed(e);
    }
}