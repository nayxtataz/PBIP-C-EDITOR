using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using PBEncDec.src.core;

namespace PBEncDec;

public class MainForm : Form
{
	private IContainer components = null;

	private RichTextBox rtbValue;

	private Button btnOpen;

	private Button btnLoad;

	private Button btnSave;

	private TextBox tbPath;

	private RichTextBox testtext;

	private LinkLabel linkLabel1;

	public MainForm()
	{
		InitializeComponent();
	}

	private void btnOpen_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			tbPath.Text = openFileDialog.FileName;
		}
		btnLoad_Click(sender, e);
	}

	private void btnLoad_Click(object sender, EventArgs e)
	{
		if (tbPath.Text == null)
		{
			return;
		}
		string path = tbPath.Text;
		try
		{
			if (!File.Exists(path))
			{
				MessageBox.Show("Select the file!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			byte[] array = File.ReadAllBytes(path);
			string text = "";
			for (int i = 0; i < array.Length; i++)
			{
				text = text + array[i] + " ";
			}
			RichTextBox richTextBox = testtext;
			richTextBox.Text = richTextBox.Text + text + "\n\n";
			string text2 = "";
			Crypt.decrypt2(array, array.Length, 7);
			for (int i = 0; i < array.Length; i++)
			{
				text2 = text2 + array[i] + " ";
			}
			testtext.Text += text2;
			rtbValue.Text = Encoding.UTF8.GetString(array);
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error: " + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		if (tbPath.Text != null)
		{
			string text = tbPath.Text;
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(rtbValue.Text);
				Crypt.encrypt2(bytes, bytes.Length, 7);
				rtbValue.Text = Encoding.UTF8.GetString(bytes);
				File.WriteAllBytes(text, bytes);
				MessageBox.Show("File : " + text + " Saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rtbValue = new System.Windows.Forms.RichTextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.testtext = new System.Windows.Forms.RichTextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // rtbValue
            // 
            this.rtbValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbValue.Location = new System.Drawing.Point(12, 38);
            this.rtbValue.Name = "rtbValue";
            this.rtbValue.Size = new System.Drawing.Size(666, 400);
            this.rtbValue.TabIndex = 0;
            this.rtbValue.Text = "";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(738, 10);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(25, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(684, 68);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(79, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(684, 39);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.Location = new System.Drawing.Point(12, 12);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(720, 20);
            this.tbPath.TabIndex = 4;
            this.tbPath.Text = "lwsi_En.sif";
            // 
            // testtext
            // 
            this.testtext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testtext.Location = new System.Drawing.Point(877, 207);
            this.testtext.Name = "testtext";
            this.testtext.Size = new System.Drawing.Size(666, 397);
            this.testtext.TabIndex = 5;
            this.testtext.Text = "";
            this.testtext.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(706, 425);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "nayxtatadev";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 447);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.testtext);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.rtbValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IP Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

	}
}
