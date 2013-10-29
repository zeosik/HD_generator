namespace pt_lab3_6
{
    partial class Form1
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
            this.serialize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.generate_status = new System.Windows.Forms.Label();
            this.workers = new System.Windows.Forms.TextBox();
            this.year = new System.Windows.Forms.Label();
            this.max_miesiecy = new System.Windows.Forms.Label();
            this.min_lekarzy = new System.Windows.Forms.Label();
            this.max_lekarzy = new System.Windows.Forms.Label();
            this.od_roku = new System.Windows.Forms.TextBox();
            this.miesiecy = new System.Windows.Forms.TextBox();
            this.lekarzy_min = new System.Windows.Forms.TextBox();
            this.lekarzy_max = new System.Windows.Forms.TextBox();
            this.zapisz = new System.Windows.Forms.Button();
            this.domyslne = new System.Windows.Forms.Button();
            this.lekiTextBox = new System.Windows.Forms.TextBox();
            this.aptekiTextBox = new System.Windows.Forms.TextBox();
            this.FaktoryTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // serialize
            // 
            this.serialize.Location = new System.Drawing.Point(67, 229);
            this.serialize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.serialize.Name = "serialize";
            this.serialize.Size = new System.Drawing.Size(100, 28);
            this.serialize.TabIndex = 17;
            this.serialize.Text = "Generuj";
            this.serialize.UseVisualStyleBackColor = true;
            this.serialize.Click += new System.EventHandler(this.Serializacja);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Pracowników:";
            // 
            // generate_status
            // 
            this.generate_status.AutoSize = true;
            this.generate_status.Location = new System.Drawing.Point(181, 235);
            this.generate_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 12);
            this.generate_status.MinimumSize = new System.Drawing.Size(76, 16);
            this.generate_status.Name = "generate_status";
            this.generate_status.Size = new System.Drawing.Size(76, 17);
            this.generate_status.TabIndex = 21;
            // 
            // workers
            // 
            this.workers.Location = new System.Drawing.Point(124, 11);
            this.workers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.workers.Name = "workers";
            this.workers.Size = new System.Drawing.Size(132, 22);
            this.workers.TabIndex = 23;
            // 
            // year
            // 
            this.year.AutoSize = true;
            this.year.Location = new System.Drawing.Point(16, 39);
            this.year.Margin = new System.Windows.Forms.Padding(4, 0, 4, 12);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(63, 17);
            this.year.TabIndex = 24;
            this.year.Text = "Od roku:";
            // 
            // max_miesiecy
            // 
            this.max_miesiecy.AutoSize = true;
            this.max_miesiecy.Location = new System.Drawing.Point(16, 68);
            this.max_miesiecy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 12);
            this.max_miesiecy.Name = "max_miesiecy";
            this.max_miesiecy.Size = new System.Drawing.Size(95, 17);
            this.max_miesiecy.TabIndex = 25;
            this.max_miesiecy.Text = "Max miesiecy:";
            // 
            // min_lekarzy
            // 
            this.min_lekarzy.AutoSize = true;
            this.min_lekarzy.Location = new System.Drawing.Point(16, 96);
            this.min_lekarzy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 12);
            this.min_lekarzy.Name = "min_lekarzy";
            this.min_lekarzy.Size = new System.Drawing.Size(83, 17);
            this.min_lekarzy.TabIndex = 26;
            this.min_lekarzy.Text = "Min lekarzy:";
            // 
            // max_lekarzy
            // 
            this.max_lekarzy.AutoSize = true;
            this.max_lekarzy.Location = new System.Drawing.Point(16, 124);
            this.max_lekarzy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 12);
            this.max_lekarzy.Name = "max_lekarzy";
            this.max_lekarzy.Size = new System.Drawing.Size(86, 17);
            this.max_lekarzy.TabIndex = 27;
            this.max_lekarzy.Text = "Max lekarzy:";
            // 
            // od_roku
            // 
            this.od_roku.Location = new System.Drawing.Point(124, 39);
            this.od_roku.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.od_roku.Name = "od_roku";
            this.od_roku.Size = new System.Drawing.Size(132, 22);
            this.od_roku.TabIndex = 28;
            // 
            // miesiecy
            // 
            this.miesiecy.Location = new System.Drawing.Point(124, 68);
            this.miesiecy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.miesiecy.Name = "miesiecy";
            this.miesiecy.Size = new System.Drawing.Size(132, 22);
            this.miesiecy.TabIndex = 29;
            // 
            // lekarzy_min
            // 
            this.lekarzy_min.Location = new System.Drawing.Point(124, 96);
            this.lekarzy_min.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lekarzy_min.Name = "lekarzy_min";
            this.lekarzy_min.Size = new System.Drawing.Size(132, 22);
            this.lekarzy_min.TabIndex = 30;
            // 
            // lekarzy_max
            // 
            this.lekarzy_max.Location = new System.Drawing.Point(124, 124);
            this.lekarzy_max.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lekarzy_max.Name = "lekarzy_max";
            this.lekarzy_max.Size = new System.Drawing.Size(132, 22);
            this.lekarzy_max.TabIndex = 31;
            // 
            // zapisz
            // 
            this.zapisz.Location = new System.Drawing.Point(157, 180);
            this.zapisz.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zapisz.Name = "zapisz";
            this.zapisz.Size = new System.Drawing.Size(100, 28);
            this.zapisz.TabIndex = 32;
            this.zapisz.Text = "Zapisz zmiany";
            this.zapisz.UseVisualStyleBackColor = true;
            this.zapisz.Click += new System.EventHandler(this.zapisz_Click);
            // 
            // domyslne
            // 
            this.domyslne.Location = new System.Drawing.Point(20, 180);
            this.domyslne.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.domyslne.Name = "domyslne";
            this.domyslne.Size = new System.Drawing.Size(100, 28);
            this.domyslne.TabIndex = 33;
            this.domyslne.Text = "domyslne";
            this.domyslne.UseVisualStyleBackColor = true;
            this.domyslne.Click += new System.EventHandler(this.SetDefaultConfiguration);
            // 
            // lekiTextBox
            // 
            this.lekiTextBox.Location = new System.Drawing.Point(124, 276);
            this.lekiTextBox.Name = "lekiTextBox";
            this.lekiTextBox.Size = new System.Drawing.Size(132, 22);
            this.lekiTextBox.TabIndex = 34;
            // 
            // aptekiTextBox
            // 
            this.aptekiTextBox.Location = new System.Drawing.Point(124, 305);
            this.aptekiTextBox.Name = "aptekiTextBox";
            this.aptekiTextBox.Size = new System.Drawing.Size(132, 22);
            this.aptekiTextBox.TabIndex = 35;
            // 
            // FaktoryTextBox
            // 
            this.FaktoryTextBox.Location = new System.Drawing.Point(124, 333);
            this.FaktoryTextBox.Name = "FaktoryTextBox";
            this.FaktoryTextBox.Size = new System.Drawing.Size(132, 22);
            this.FaktoryTextBox.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "Leki";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "Apteki";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 333);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 39;
            this.label4.Text = "Faktury";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 367);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FaktoryTextBox);
            this.Controls.Add(this.aptekiTextBox);
            this.Controls.Add(this.lekiTextBox);
            this.Controls.Add(this.domyslne);
            this.Controls.Add(this.zapisz);
            this.Controls.Add(this.lekarzy_max);
            this.Controls.Add(this.lekarzy_min);
            this.Controls.Add(this.miesiecy);
            this.Controls.Add(this.od_roku);
            this.Controls.Add(this.max_lekarzy);
            this.Controls.Add(this.min_lekarzy);
            this.Controls.Add(this.max_miesiecy);
            this.Controls.Add(this.year);
            this.Controls.Add(this.workers);
            this.Controls.Add(this.generate_status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serialize);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button serialize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label generate_status;
        private System.Windows.Forms.TextBox workers;
        private System.Windows.Forms.Label year;
        private System.Windows.Forms.Label max_miesiecy;
        private System.Windows.Forms.Label min_lekarzy;
        private System.Windows.Forms.Label max_lekarzy;
        private System.Windows.Forms.TextBox od_roku;
        private System.Windows.Forms.TextBox miesiecy;
        private System.Windows.Forms.TextBox lekarzy_min;
        private System.Windows.Forms.TextBox lekarzy_max;
        private System.Windows.Forms.Button zapisz;
        private System.Windows.Forms.Button domyslne;
        private System.Windows.Forms.TextBox lekiTextBox;
        private System.Windows.Forms.TextBox aptekiTextBox;
        private System.Windows.Forms.TextBox FaktoryTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

