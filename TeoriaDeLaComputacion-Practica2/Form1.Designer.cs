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
    private void InitializeComponent() {
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        txtInput = new System.Windows.Forms.TextBox();
        btnValidar = new System.Windows.Forms.Button();
        btnLimpiar = new System.Windows.Forms.Button();
        txtSalida = new System.Windows.Forms.TextBox();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(108, 52);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(252, 51);
        label1.TabIndex = 0;
        label1.Text = "Analisis lexico";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.Location = new System.Drawing.Point(45, 132);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(270, 25);
        label2.TabIndex = 1;
        label2.Text = "Ingresar Argumento a Analizar";
        // 
        // txtInput
        // 
        txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        txtInput.Location = new System.Drawing.Point(45, 185);
        txtInput.Name = "txtInput";
        txtInput.Size = new System.Drawing.Size(405, 29);
        txtInput.TabIndex = 2;
        // 
        // btnValidar
        // 
        btnValidar.BackColor = System.Drawing.Color.PaleGreen;
        btnValidar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        btnValidar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        btnValidar.Location = new System.Drawing.Point(108, 242);
        btnValidar.Name = "btnValidar";
        btnValidar.Size = new System.Drawing.Size(128, 50);
        btnValidar.TabIndex = 3;
        btnValidar.Text = "Validar";
        btnValidar.UseVisualStyleBackColor = false;
        btnValidar.Click += btnValidar_Click;
        // 
        // btnLimpiar
        // 
        btnLimpiar.BackColor = System.Drawing.Color.LemonChiffon;
        btnLimpiar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        btnLimpiar.Location = new System.Drawing.Point(265, 242);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new System.Drawing.Size(125, 50);
        btnLimpiar.TabIndex = 4;
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.UseVisualStyleBackColor = false;
        btnLimpiar.Click += btnLimpiar_Click;
        // 
        // txtSalida
        // 
        txtSalida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtSalida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtSalida.Enabled = false;
        txtSalida.Location = new System.Drawing.Point(45, 321);
        txtSalida.Multiline = true;
        txtSalida.Name = "txtSalida";
        txtSalida.ReadOnly = true;
        txtSalida.Size = new System.Drawing.Size(405, 99);
        txtSalida.TabIndex = 5;
        txtSalida.TextChanged += txtSalida_TextChanged;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(514, 471);
        Controls.Add(txtSalida);
        Controls.Add(btnLimpiar);
        Controls.Add(btnValidar);
        Controls.Add(txtInput);
        Controls.Add(label2);
        Controls.Add(label1);
        FormScreenCaptureMode = System.Windows.Forms.ScreenCaptureMode.HideWindow;
        Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
    private System.Windows.Forms.Button btnLimpiar;
    public TextBox txtSalida;
}