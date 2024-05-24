
namespace Project_Bartus_top
{
    partial class Form
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
            this.Delete_element = new System.Windows.Forms.Button();
            this.Find_element = new System.Windows.Forms.Button();
            this.Add_file = new System.Windows.Forms.Button();
            this.Replace_value = new System.Windows.Forms.Button();
            this.Add_atribute = new System.Windows.Forms.Button();
            this.Delete_table = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Find_atributes = new System.Windows.Forms.Button();
            this.Wypisz = new System.Windows.Forms.Button();
            this.Save_to_file = new System.Windows.Forms.Button();
            this.Add_element_by_name = new System.Windows.Forms.Button();
            this.data_streamer = new System.Windows.Forms.RichTextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.Number = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Delete_element
            // 
            this.Delete_element.Location = new System.Drawing.Point(426, 162);
            this.Delete_element.Margin = new System.Windows.Forms.Padding(2);
            this.Delete_element.Name = "Delete_element";
            this.Delete_element.Size = new System.Drawing.Size(86, 31);
            this.Delete_element.TabIndex = 0;
            this.Delete_element.Text = "Delete element";
            this.Delete_element.UseVisualStyleBackColor = true;
            this.Delete_element.Click += new System.EventHandler(this.Delete_element_Click);
            // 
            // Find_element
            // 
            this.Find_element.Location = new System.Drawing.Point(589, 162);
            this.Find_element.Margin = new System.Windows.Forms.Padding(2);
            this.Find_element.Name = "Find_element";
            this.Find_element.Size = new System.Drawing.Size(86, 31);
            this.Find_element.TabIndex = 1;
            this.Find_element.Text = "Find element";
            this.Find_element.UseVisualStyleBackColor = true;
            // 
            // Add_file
            // 
            this.Add_file.Location = new System.Drawing.Point(426, 209);
            this.Add_file.Margin = new System.Windows.Forms.Padding(2);
            this.Add_file.Name = "Add_file";
            this.Add_file.Size = new System.Drawing.Size(86, 28);
            this.Add_file.TabIndex = 2;
            this.Add_file.Text = "Add From File";
            this.Add_file.UseVisualStyleBackColor = true;
            // 
            // Replace_value
            // 
            this.Replace_value.Location = new System.Drawing.Point(589, 209);
            this.Replace_value.Margin = new System.Windows.Forms.Padding(2);
            this.Replace_value.Name = "Replace_value";
            this.Replace_value.Size = new System.Drawing.Size(86, 28);
            this.Replace_value.TabIndex = 3;
            this.Replace_value.Text = "Replace value";
            this.Replace_value.UseVisualStyleBackColor = true;
            // 
            // Add_atribute
            // 
            this.Add_atribute.Location = new System.Drawing.Point(426, 251);
            this.Add_atribute.Margin = new System.Windows.Forms.Padding(2);
            this.Add_atribute.Name = "Add_atribute";
            this.Add_atribute.Size = new System.Drawing.Size(86, 42);
            this.Add_atribute.TabIndex = 4;
            this.Add_atribute.Text = "Add element to first";
            this.Add_atribute.UseVisualStyleBackColor = true;
            // 
            // Delete_table
            // 
            this.Delete_table.Location = new System.Drawing.Point(589, 307);
            this.Delete_table.Margin = new System.Windows.Forms.Padding(2);
            this.Delete_table.Name = "Delete_table";
            this.Delete_table.Size = new System.Drawing.Size(86, 30);
            this.Delete_table.TabIndex = 5;
            this.Delete_table.Text = "Delete table";
            this.Delete_table.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(387, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "File name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(471, 20);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 20);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(471, 57);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(76, 20);
            this.textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(471, 92);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(76, 20);
            this.textBox3.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Element Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Value";
            // 
            // Find_atributes
            // 
            this.Find_atributes.Location = new System.Drawing.Point(426, 307);
            this.Find_atributes.Margin = new System.Windows.Forms.Padding(2);
            this.Find_atributes.Name = "Find_atributes";
            this.Find_atributes.Size = new System.Drawing.Size(86, 28);
            this.Find_atributes.TabIndex = 12;
            this.Find_atributes.Text = "Find atributes";
            this.Find_atributes.UseVisualStyleBackColor = true;
            // 
            // Wypisz
            // 
            this.Wypisz.Location = new System.Drawing.Point(589, 358);
            this.Wypisz.Margin = new System.Windows.Forms.Padding(2);
            this.Wypisz.Name = "Wypisz";
            this.Wypisz.Size = new System.Drawing.Size(86, 35);
            this.Wypisz.TabIndex = 13;
            this.Wypisz.Text = "Show xml";
            this.Wypisz.UseVisualStyleBackColor = true;
            // 
            // Save_to_file
            // 
            this.Save_to_file.Location = new System.Drawing.Point(426, 358);
            this.Save_to_file.Margin = new System.Windows.Forms.Padding(2);
            this.Save_to_file.Name = "Save_to_file";
            this.Save_to_file.Size = new System.Drawing.Size(86, 35);
            this.Save_to_file.TabIndex = 14;
            this.Save_to_file.Text = "Save to file";
            this.Save_to_file.UseVisualStyleBackColor = true;
            // 
            // Add_element_by_name
            // 
            this.Add_element_by_name.Location = new System.Drawing.Point(589, 251);
            this.Add_element_by_name.Margin = new System.Windows.Forms.Padding(2);
            this.Add_element_by_name.Name = "Add_element_by_name";
            this.Add_element_by_name.Size = new System.Drawing.Size(86, 42);
            this.Add_element_by_name.TabIndex = 15;
            this.Add_element_by_name.Text = "Add element by name";
            this.Add_element_by_name.UseVisualStyleBackColor = true;
            // 
            // data_streamer
            // 
            this.data_streamer.Location = new System.Drawing.Point(13, 20);
            this.data_streamer.Margin = new System.Windows.Forms.Padding(2);
            this.data_streamer.Name = "data_streamer";
            this.data_streamer.Size = new System.Drawing.Size(343, 368);
            this.data_streamer.TabIndex = 16;
            this.data_streamer.Text = "";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(652, 20);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(76, 20);
            this.textBox4.TabIndex = 17;
            // 
            // Number
            // 
            this.Number.AutoSize = true;
            this.Number.Location = new System.Drawing.Point(572, 23);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(44, 13);
            this.Number.TabIndex = 18;
            this.Number.Text = "Number";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 434);
            this.Controls.Add(this.Number);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.data_streamer);
            this.Controls.Add(this.Add_element_by_name);
            this.Controls.Add(this.Save_to_file);
            this.Controls.Add(this.Wypisz);
            this.Controls.Add(this.Find_atributes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Delete_table);
            this.Controls.Add(this.Add_atribute);
            this.Controls.Add(this.Replace_value);
            this.Controls.Add(this.Add_file);
            this.Controls.Add(this.Find_element);
            this.Controls.Add(this.Delete_element);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form";
            this.Text = "XML Database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Delete_element;
        private System.Windows.Forms.Button Find_element;
        private System.Windows.Forms.Button Add_file;
        private System.Windows.Forms.Button Replace_value;
        private System.Windows.Forms.Button Add_atribute;
        private System.Windows.Forms.Button Delete_table;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Find_atributes;
        private System.Windows.Forms.Button Wypisz;
        private System.Windows.Forms.Button Save_to_file;
        private System.Windows.Forms.Button Add_element_by_name;
        private System.Windows.Forms.RichTextBox data_streamer;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label Number;
    }
}

