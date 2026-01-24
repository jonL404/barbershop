namespace BARBEARIA
{
    partial class telaCancelamentoServico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.labelProfissional = new System.Windows.Forms.Label();
            this.comboBoxProfissionais = new System.Windows.Forms.ComboBox();
            this.labelData = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.listBoxAgendamentos = new System.Windows.Forms.ListBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonFechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelProfissional
            // 
            this.labelProfissional.AutoSize = true;
            this.labelProfissional.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.labelProfissional.Location = new System.Drawing.Point(30, 30);
            this.labelProfissional.Name = "labelProfissional";
            this.labelProfissional.Size = new System.Drawing.Size(86, 18);
            this.labelProfissional.TabIndex = 0;
            this.labelProfissional.Text = "Profissional";
            // 
            // comboBoxProfissionais
            // 
            this.comboBoxProfissionais.FormattingEnabled = true;
            this.comboBoxProfissionais.Items.AddRange(new object[] {
            "Miguel",
            "Lacerda",
            "Alex",
            "Fábio"});
            this.comboBoxProfissionais.Location = new System.Drawing.Point(33, 55);
            this.comboBoxProfissionais.Name = "comboBoxProfissionais";
            this.comboBoxProfissionais.Size = new System.Drawing.Size(160, 21);
            this.comboBoxProfissionais.TabIndex = 1;
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.labelData.Location = new System.Drawing.Point(220, 30);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(39, 18);
            this.labelData.TabIndex = 2;
            this.labelData.Text = "Data";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(223, 55);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(450, 50);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(110, 27);
            this.buttonBuscar.TabIndex = 4;
            this.buttonBuscar.Text = "Buscar Agendamentos";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // listBoxAgendamentos
            // 
            this.listBoxAgendamentos.FormattingEnabled = true;
            this.listBoxAgendamentos.Location = new System.Drawing.Point(33, 100);
            this.listBoxAgendamentos.Name = "listBoxAgendamentos";
            this.listBoxAgendamentos.Size = new System.Drawing.Size(527, 238);
            this.listBoxAgendamentos.TabIndex = 5;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.DarkRed;
            this.buttonCancelar.ForeColor = System.Drawing.Color.White;
            this.buttonCancelar.Location = new System.Drawing.Point(33, 355);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(160, 35);
            this.buttonCancelar.TabIndex = 6;
            this.buttonCancelar.Text = "Cancelar Selecionado";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonFechar
            // 
            this.buttonFechar.Location = new System.Drawing.Point(400, 355);
            this.buttonFechar.Name = "buttonFechar";
            this.buttonFechar.Size = new System.Drawing.Size(160, 35);
            this.buttonFechar.TabIndex = 7;
            this.buttonFechar.Text = "Fechar";
            this.buttonFechar.UseVisualStyleBackColor = true;
            this.buttonFechar.Click += new System.EventHandler(this.buttonFechar_Click);
            // 
            // telaCancelamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 420);
            this.Controls.Add(this.buttonFechar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.listBoxAgendamentos);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.comboBoxProfissionais);
            this.Controls.Add(this.labelProfissional);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "telaCancelamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelamento de Serviços";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProfissional;
        private System.Windows.Forms.ComboBox comboBoxProfissionais;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.ListBox listBoxAgendamentos;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonFechar;
    }
}