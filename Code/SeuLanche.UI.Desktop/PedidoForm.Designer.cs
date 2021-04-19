namespace SeuLanche.UI.Desktop
{
    partial class PedidoForm
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
            this.components = new System.ComponentModel.Container();
            this.lblTempoPedido = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPrecoPedido = new System.Windows.Forms.Label();
            this.btnConfirmarPedido = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvPromocoes = new System.Windows.Forms.DataGridView();
            this.descricaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.promocaoDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.blnLancheAddItem = new System.Windows.Forms.Button();
            this.cmbLanchesAddItem = new System.Windows.Forms.ComboBox();
            this.dgvLanches = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemoverLanche = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lancheDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIngredienteAddItem = new System.Windows.Forms.Button();
            this.cmbIngredientesAddItem = new System.Windows.Forms.ComboBox();
            this.dgvIngredientes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemoverIngredinete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ingredienteDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromocoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.promocaoDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lancheDtoBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredienteDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTempoPedido
            // 
            this.lblTempoPedido.AutoSize = true;
            this.lblTempoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempoPedido.Location = new System.Drawing.Point(386, 429);
            this.lblTempoPedido.Name = "lblTempoPedido";
            this.lblTempoPedido.Size = new System.Drawing.Size(71, 20);
            this.lblTempoPedido.TabIndex = 7;
            this.lblTempoPedido.Text = "00:00:00";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblPrecoPedido);
            this.panel1.Controls.Add(this.btnConfirmarPedido);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(10, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 422);
            this.panel1.TabIndex = 9;
            // 
            // lblPrecoPedido
            // 
            this.lblPrecoPedido.AutoSize = true;
            this.lblPrecoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecoPedido.Location = new System.Drawing.Point(369, 396);
            this.lblPrecoPedido.Name = "lblPrecoPedido";
            this.lblPrecoPedido.Size = new System.Drawing.Size(90, 25);
            this.lblPrecoPedido.TabIndex = 13;
            this.lblPrecoPedido.Text = "R$ 00,00";
            // 
            // btnConfirmarPedido
            // 
            this.btnConfirmarPedido.Location = new System.Drawing.Point(771, 386);
            this.btnConfirmarPedido.Name = "btnConfirmarPedido";
            this.btnConfirmarPedido.Size = new System.Drawing.Size(119, 30);
            this.btnConfirmarPedido.TabIndex = 12;
            this.btnConfirmarPedido.Text = "Confirmar Pedido";
            this.btnConfirmarPedido.UseVisualStyleBackColor = true;
            this.btnConfirmarPedido.Click += new System.EventHandler(this.btnConfirmarPedido_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.blnLancheAddItem);
            this.groupBox2.Controls.Add(this.cmbLanchesAddItem);
            this.groupBox2.Controls.Add(this.dgvLanches);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(9, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(896, 377);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lanches";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvPromocoes);
            this.groupBox3.Location = new System.Drawing.Point(11, 238);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(873, 128);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Promções";
            // 
            // dgvPromocoes
            // 
            this.dgvPromocoes.AutoGenerateColumns = false;
            this.dgvPromocoes.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvPromocoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromocoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descricaoDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn1});
            this.dgvPromocoes.DataSource = this.promocaoDtoBindingSource;
            this.dgvPromocoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPromocoes.Location = new System.Drawing.Point(3, 16);
            this.dgvPromocoes.Name = "dgvPromocoes";
            this.dgvPromocoes.Size = new System.Drawing.Size(867, 109);
            this.dgvPromocoes.TabIndex = 0;
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            this.descricaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            this.descricaoDataGridViewTextBoxColumn.HeaderText = "Descricao";
            this.descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            // 
            // valorDataGridViewTextBoxColumn1
            // 
            this.valorDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.valorDataGridViewTextBoxColumn1.DataPropertyName = "Valor";
            this.valorDataGridViewTextBoxColumn1.HeaderText = "Valor";
            this.valorDataGridViewTextBoxColumn1.Name = "valorDataGridViewTextBoxColumn1";
            this.valorDataGridViewTextBoxColumn1.Width = 56;
            // 
            // promocaoDtoBindingSource
            // 
            this.promocaoDtoBindingSource.DataSource = typeof(SeuLanche.ModelDto.PromocaoDto);
            // 
            // blnLancheAddItem
            // 
            this.blnLancheAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blnLancheAddItem.Location = new System.Drawing.Point(304, 18);
            this.blnLancheAddItem.Name = "blnLancheAddItem";
            this.blnLancheAddItem.Size = new System.Drawing.Size(55, 23);
            this.blnLancheAddItem.TabIndex = 14;
            this.blnLancheAddItem.Text = "+";
            this.blnLancheAddItem.UseVisualStyleBackColor = true;
            this.blnLancheAddItem.Click += new System.EventHandler(this.blnLancheAddItem_Click);
            // 
            // cmbLanchesAddItem
            // 
            this.cmbLanchesAddItem.FormattingEnabled = true;
            this.cmbLanchesAddItem.Location = new System.Drawing.Point(1, 18);
            this.cmbLanchesAddItem.Name = "cmbLanchesAddItem";
            this.cmbLanchesAddItem.Size = new System.Drawing.Size(297, 21);
            this.cmbLanchesAddItem.TabIndex = 12;
            // 
            // dgvLanches
            // 
            this.dgvLanches.AutoGenerateColumns = false;
            this.dgvLanches.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvLanches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLanches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.RemoverLanche});
            this.dgvLanches.DataSource = this.lancheDtoBindingSource;
            this.dgvLanches.Location = new System.Drawing.Point(2, 45);
            this.dgvLanches.Name = "dgvLanches";
            this.dgvLanches.Size = new System.Drawing.Size(356, 180);
            this.dgvLanches.TabIndex = 11;
            this.dgvLanches.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLanches_CellClick);
            this.dgvLanches.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLanches_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Nome";
            this.dataGridViewTextBoxColumn1.HeaderText = "Nome";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // RemoverLanche
            // 
            this.RemoverLanche.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.RemoverLanche.DividerWidth = 5;
            this.RemoverLanche.HeaderText = "Remover";
            this.RemoverLanche.Name = "RemoverLanche";
            this.RemoverLanche.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RemoverLanche.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RemoverLanche.Text = "-";
            this.RemoverLanche.Width = 80;
            // 
            // lancheDtoBindingSource
            // 
            this.lancheDtoBindingSource.DataSource = typeof(SeuLanche.ModelDto.LancheDto);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIngredienteAddItem);
            this.groupBox1.Controls.Add(this.cmbIngredientesAddItem);
            this.groupBox1.Controls.Add(this.dgvIngredientes);
            this.groupBox1.Location = new System.Drawing.Point(365, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 212);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingredientes";
            // 
            // btnIngredienteAddItem
            // 
            this.btnIngredienteAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngredienteAddItem.Location = new System.Drawing.Point(464, 19);
            this.btnIngredienteAddItem.Name = "btnIngredienteAddItem";
            this.btnIngredienteAddItem.Size = new System.Drawing.Size(55, 23);
            this.btnIngredienteAddItem.TabIndex = 17;
            this.btnIngredienteAddItem.Text = "+";
            this.btnIngredienteAddItem.UseVisualStyleBackColor = true;
            this.btnIngredienteAddItem.Click += new System.EventHandler(this.btnIngredienteAddItem_Click);
            // 
            // cmbIngredientesAddItem
            // 
            this.cmbIngredientesAddItem.FormattingEnabled = true;
            this.cmbIngredientesAddItem.Location = new System.Drawing.Point(6, 19);
            this.cmbIngredientesAddItem.Name = "cmbIngredientesAddItem";
            this.cmbIngredientesAddItem.Size = new System.Drawing.Size(452, 21);
            this.cmbIngredientesAddItem.TabIndex = 15;
            // 
            // dgvIngredientes
            // 
            this.dgvIngredientes.AutoGenerateColumns = false;
            this.dgvIngredientes.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.valorDataGridViewTextBoxColumn,
            this.RemoverIngredinete});
            this.dgvIngredientes.DataSource = this.ingredienteDtoBindingSource;
            this.dgvIngredientes.Location = new System.Drawing.Point(6, 48);
            this.dgvIngredientes.Name = "dgvIngredientes";
            this.dgvIngredientes.Size = new System.Drawing.Size(513, 158);
            this.dgvIngredientes.TabIndex = 13;
            this.dgvIngredientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngredientes_CellContentClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nome";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nome";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            this.valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.Width = 56;
            // 
            // RemoverIngredinete
            // 
            this.RemoverIngredinete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.RemoverIngredinete.HeaderText = "Remover";
            this.RemoverIngredinete.Name = "RemoverIngredinete";
            this.RemoverIngredinete.Width = 56;
            // 
            // ingredienteDtoBindingSource
            // 
            this.ingredienteDtoBindingSource.DataSource = typeof(SeuLanche.ModelDto.IngredienteDto);
            // 
            // PedidoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 458);
            this.Controls.Add(this.lblTempoPedido);
            this.Controls.Add(this.panel1);
            this.Name = "PedidoForm";
            this.Text = "Pedido";
            this.Load += new System.EventHandler(this.Pedido_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromocoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.promocaoDtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lancheDtoBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredienteDtoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTempoPedido;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button blnLancheAddItem;
        private System.Windows.Forms.DataGridView dgvLanches;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConfirmarPedido;
        private System.Windows.Forms.ComboBox cmbLanchesAddItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label lblPrecoPedido;
        private System.Windows.Forms.BindingSource lancheDtoBindingSource;
        private System.Windows.Forms.BindingSource ingredienteDtoBindingSource;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvPromocoes;
        private System.Windows.Forms.Button btnIngredienteAddItem;
        private System.Windows.Forms.ComboBox cmbIngredientesAddItem;
        private System.Windows.Forms.DataGridView dgvIngredientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn RemoverIngredinete;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource promocaoDtoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn RemoverLanche;
    }
}