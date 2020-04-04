namespace Login
{
    partial class Buscar_Clientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Buscar_Clientes));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView_BuscarCliente = new System.Windows.Forms.DataGridView();
            this.btnSalir_pantBuscarClientes = new System.Windows.Forms.Button();
            this.btnBuscar_pantBuscarClientes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_BuscarCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 268);
            this.panel1.TabIndex = 3;
            // 
            // dataGridView_BuscarCliente
            // 
            this.dataGridView_BuscarCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_BuscarCliente.Location = new System.Drawing.Point(266, 108);
            this.dataGridView_BuscarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_BuscarCliente.Name = "dataGridView_BuscarCliente";
            this.dataGridView_BuscarCliente.RowHeadersWidth = 51;
            this.dataGridView_BuscarCliente.RowTemplate.Height = 24;
            this.dataGridView_BuscarCliente.Size = new System.Drawing.Size(390, 149);
            this.dataGridView_BuscarCliente.TabIndex = 50;
            // 
            // btnSalir_pantBuscarClientes
            // 
            this.btnSalir_pantBuscarClientes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir_pantBuscarClientes.BackgroundImage")));
            this.btnSalir_pantBuscarClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSalir_pantBuscarClientes.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir_pantBuscarClientes.ForeColor = System.Drawing.Color.Black;
            this.btnSalir_pantBuscarClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir_pantBuscarClientes.Location = new System.Drawing.Point(708, 10);
            this.btnSalir_pantBuscarClientes.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir_pantBuscarClientes.Name = "btnSalir_pantBuscarClientes";
            this.btnSalir_pantBuscarClientes.Size = new System.Drawing.Size(33, 35);
            this.btnSalir_pantBuscarClientes.TabIndex = 49;
            this.btnSalir_pantBuscarClientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir_pantBuscarClientes.UseVisualStyleBackColor = true;
            this.btnSalir_pantBuscarClientes.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnBuscar_pantBuscarClientes
            // 
            this.btnBuscar_pantBuscarClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBuscar_pantBuscarClientes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar_pantBuscarClientes.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar_pantBuscarClientes.Location = new System.Drawing.Point(386, 76);
            this.btnBuscar_pantBuscarClientes.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar_pantBuscarClientes.Name = "btnBuscar_pantBuscarClientes";
            this.btnBuscar_pantBuscarClientes.Size = new System.Drawing.Size(158, 28);
            this.btnBuscar_pantBuscarClientes.TabIndex = 48;
            this.btnBuscar_pantBuscarClientes.Text = "BUSCAR";
            this.btnBuscar_pantBuscarClientes.UseVisualStyleBackColor = false;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(313, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 47;
            this.label1.Text = "ID CLIENTE:";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(378, 52);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(236, 13);
            this.textBox2.TabIndex = 46;
            this.textBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(313, 70);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(302, 1);
            this.panel3.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(341, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 39);
            this.label2.TabIndex = 44;
            this.label2.Text = "BUSCAR CLIENTES";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(660, 140);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 46);
            this.button1.TabIndex = 51;
            this.button1.Text = "ELIMINAR CLIENTE";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Buscar_Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(752, 268);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_BuscarCliente);
            this.Controls.Add(this.btnSalir_pantBuscarClientes);
            this.Controls.Add(this.btnBuscar_pantBuscarClientes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Buscar_Clientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Buscar_Clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_BuscarCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_BuscarCliente;
        private System.Windows.Forms.Button btnSalir_pantBuscarClientes;
        private System.Windows.Forms.Button btnBuscar_pantBuscarClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}