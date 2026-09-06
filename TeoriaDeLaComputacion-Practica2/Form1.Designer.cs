namespace TeoriaDeLaComputacion_Practica2;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        label1 = new Label();
        label2 = new Label();
        txtInput = new TextBox();
        btnValidar = new Button();
        btnLimpiar = new Button();
        txtSalida = new TextBox();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.Location = new Point(108, 56);
        label1.Name = "label1";
        label1.Size = new Size(313, 62);
        label1.TabIndex = 0;
        label1.Text = "Analisis lexico";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label2.Location = new Point(45, 138);
        label2.Name = "label2";
        label2.Size = new Size(325, 31);
        label2.TabIndex = 1;
        label2.Text = "Ingresar Argumento a Analizar";
        // 
        // txtInput
        // 
        txtInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtInput.BorderStyle = BorderStyle.FixedSingle;
        txtInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtInput.Location = new Point(45, 185);
        txtInput.Name = "txtInput";
        txtInput.Size = new Size(405, 34);
        txtInput.TabIndex = 2;
        // 
        // btnValidar
        // 
        btnValidar.BackColor = Color.PaleGreen;
        btnValidar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        btnValidar.ForeColor = SystemColors.ActiveCaptionText;
        btnValidar.Location = new Point(108, 242);
        btnValidar.Name = "btnValidar";
        btnValidar.Size = new Size(128, 50);
        btnValidar.TabIndex = 3;
        btnValidar.Text = "Validar";
        btnValidar.UseVisualStyleBackColor = false;
        btnValidar.Click += btnValidar_Click;
        // 
        // btnLimpiar
        // 
        btnLimpiar.BackColor = Color.LemonChiffon;
        btnLimpiar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        btnLimpiar.Location = new Point(265, 242);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(125, 50);
        btnLimpiar.TabIndex = 4;
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.UseVisualStyleBackColor = false;
        // 
        // txtSalida
        // 
        txtSalida.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtSalida.BorderStyle = BorderStyle.FixedSingle;
        txtSalida.Enabled = false;
        txtSalida.Location = new Point(45, 321);
        txtSalida.Multiline = true;
        txtSalida.Name = "txtSalida";
        txtSalida.ReadOnly = true;
        txtSalida.Size = new Size(405, 99);
        txtSalida.TabIndex = 5;
        txtSalida.TextChanged += txtSalida_TextChanged;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(514, 471);
        Controls.Add(txtSalida);
        Controls.Add(btnLimpiar);
        Controls.Add(btnValidar);
        Controls.Add(txtInput);
        Controls.Add(label2);
        Controls.Add(label1);
        FormScreenCaptureMode = ScreenCaptureMode.HideWindow;
        Margin = new Padding(3, 4, 3, 4);
        Name = "Form1";
        Text = "Analisis Lexico";
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Label label2;
    private TextBox txtInput;
    private Button btnValidar;
    private Button btnLimpiar;
    public TextBox txtSalida;
}