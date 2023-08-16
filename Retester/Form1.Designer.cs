namespace Retester
{
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox_DMC_input = new TextBox();
            button_retest = new Button();
            textBox_SP = new TextBox();
            textBox_OP = new TextBox();
            textBox_SOP = new TextBox();
            textBox_comment = new TextBox();
            label_SP = new Label();
            label_title = new Label();
            label_OP = new Label();
            label_SOP = new Label();
            label_comment = new Label();
            label_scan = new Label();
            textBox_method_validation = new TextBox();
            contextMenuStrip = new ContextMenuStrip(components);
            toolStripMenuItem_rebus = new ToolStripMenuItem();
            textBox_tempo = new TextBox();
            label_tempo = new Label();
            label_connected = new Label();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_DMC_input
            // 
            textBox_DMC_input.Location = new Point(69, 40);
            textBox_DMC_input.Multiline = true;
            textBox_DMC_input.Name = "textBox_DMC_input";
            textBox_DMC_input.Size = new Size(396, 398);
            textBox_DMC_input.TabIndex = 0;
            // 
            // button_retest
            // 
            button_retest.BackColor = Color.DarkCyan;
            button_retest.FlatAppearance.BorderSize = 0;
            button_retest.Font = new Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button_retest.ForeColor = SystemColors.ButtonHighlight;
            button_retest.Location = new Point(678, 401);
            button_retest.Name = "button_retest";
            button_retest.Size = new Size(106, 37);
            button_retest.TabIndex = 1;
            button_retest.Text = "Retest";
            button_retest.UseVisualStyleBackColor = false;
            button_retest.Click += button_retest_Click;
            // 
            // textBox_SP
            // 
            textBox_SP.Location = new Point(663, 52);
            textBox_SP.Name = "textBox_SP";
            textBox_SP.Size = new Size(125, 27);
            textBox_SP.TabIndex = 2;
            // 
            // textBox_OP
            // 
            textBox_OP.Location = new Point(663, 115);
            textBox_OP.Name = "textBox_OP";
            textBox_OP.Size = new Size(125, 27);
            textBox_OP.TabIndex = 3;
            // 
            // textBox_SOP
            // 
            textBox_SOP.Location = new Point(663, 183);
            textBox_SOP.Name = "textBox_SOP";
            textBox_SOP.Size = new Size(125, 27);
            textBox_SOP.TabIndex = 4;
            // 
            // textBox_comment
            // 
            textBox_comment.Location = new Point(503, 263);
            textBox_comment.Name = "textBox_comment";
            textBox_comment.Size = new Size(285, 27);
            textBox_comment.TabIndex = 5;
            // 
            // label_SP
            // 
            label_SP.AutoSize = true;
            label_SP.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label_SP.ForeColor = Color.White;
            label_SP.Location = new Point(507, 54);
            label_SP.Name = "label_SP";
            label_SP.Size = new Size(132, 21);
            label_SP.TabIndex = 6;
            label_SP.Text = "Sortie par SPC";
            // 
            // label_title
            // 
            label_title.AutoSize = true;
            label_title.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label_title.ForeColor = Color.White;
            label_title.Location = new Point(485, 14);
            label_title.Name = "label_title";
            label_title.Size = new Size(310, 22);
            label_title.TabIndex = 7;
            label_title.Text = "Nouveaux paramètres des pièces";
            // 
            // label_OP
            // 
            label_OP.AutoSize = true;
            label_OP.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label_OP.ForeColor = Color.White;
            label_OP.Location = new Point(507, 121);
            label_OP.Name = "label_OP";
            label_OP.Size = new Size(115, 21);
            label_OP.TabIndex = 8;
            label_OP.Text = "Dernière OP";
            // 
            // label_SOP
            // 
            label_SOP.AutoSize = true;
            label_SOP.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label_SOP.ForeColor = Color.White;
            label_SOP.Location = new Point(507, 189);
            label_SOP.Name = "label_SOP";
            label_SOP.Size = new Size(157, 21);
            label_SOP.TabIndex = 9;
            label_SOP.Text = "Dernière sous OP";
            // 
            // label_comment
            // 
            label_comment.AutoSize = true;
            label_comment.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label_comment.ForeColor = Color.White;
            label_comment.Location = new Point(503, 239);
            label_comment.Name = "label_comment";
            label_comment.Size = new Size(233, 21);
            label_comment.TabIndex = 10;
            label_comment.Text = "Commentaire (optionnel)";
            // 
            // label_scan
            // 
            label_scan.AutoSize = true;
            label_scan.Font = new Font("Century Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label_scan.ForeColor = Color.White;
            label_scan.Location = new Point(69, 6);
            label_scan.Name = "label_scan";
            label_scan.Size = new Size(72, 30);
            label_scan.TabIndex = 11;
            label_scan.Text = "Scan";
            // 
            // textBox_method_validation
            // 
            textBox_method_validation.ForeColor = Color.Lime;
            textBox_method_validation.Location = new Point(12, 40);
            textBox_method_validation.Multiline = true;
            textBox_method_validation.Name = "textBox_method_validation";
            textBox_method_validation.Size = new Size(51, 398);
            textBox_method_validation.TabIndex = 12;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_rebus });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(118, 28);
            contextMenuStrip.Text = "Menu";
            // 
            // toolStripMenuItem_rebus
            // 
            toolStripMenuItem_rebus.Name = "toolStripMenuItem_rebus";
            toolStripMenuItem_rebus.Size = new Size(117, 24);
            toolStripMenuItem_rebus.Text = "Rebut";
            // 
            // textBox_tempo
            // 
            textBox_tempo.Location = new Point(659, 332);
            textBox_tempo.Name = "textBox_tempo";
            textBox_tempo.Size = new Size(125, 27);
            textBox_tempo.TabIndex = 13;
            // 
            // label_tempo
            // 
            label_tempo.AutoSize = true;
            label_tempo.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label_tempo.ForeColor = Color.White;
            label_tempo.Location = new Point(582, 334);
            label_tempo.Name = "label_tempo";
            label_tempo.Size = new Size(71, 21);
            label_tempo.TabIndex = 14;
            label_tempo.Text = "Tempo";
            label_tempo.Click += label_tempo_Click;
            // 
            // label_connected
            // 
            label_connected.AutoSize = true;
            label_connected.Font = new Font("Century Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label_connected.ForeColor = Color.OrangeRed;
            label_connected.Location = new Point(485, 401);
            label_connected.Name = "label_connected";
            label_connected.Size = new Size(165, 30);
            label_connected.TabIndex = 15;
            label_connected.Text = "Déconnecté";
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(796, 445);
            Controls.Add(label_connected);
            Controls.Add(label_tempo);
            Controls.Add(textBox_tempo);
            Controls.Add(textBox_method_validation);
            Controls.Add(label_scan);
            Controls.Add(label_comment);
            Controls.Add(label_SOP);
            Controls.Add(label_OP);
            Controls.Add(label_title);
            Controls.Add(label_SP);
            Controls.Add(textBox_comment);
            Controls.Add(textBox_SOP);
            Controls.Add(textBox_OP);
            Controls.Add(textBox_SP);
            Controls.Add(button_retest);
            Controls.Add(textBox_DMC_input);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Retester";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_DMC_input;
        private Button button_retest;
        private TextBox textBox_SP;
        private TextBox textBox_OP;
        private TextBox textBox_SOP;
        private TextBox textBox_comment;
        private Label label_SP;
        private Label label_title;
        private Label label_OP;
        private Label label_SOP;
        private Label label_comment;
        private Label label_scan;
        private TextBox textBox_method_validation;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem toolStripMenuItem_rebus;
        private TextBox textBox_tempo;
        private Label label_tempo;
        private Label label_connected;
    }
}