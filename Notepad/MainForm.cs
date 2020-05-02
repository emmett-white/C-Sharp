using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace notepad
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void OpenFileDialog1FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		}
		
		void OpenToolStripMenuItem1Click(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
			richTextBox1.Lines = File.ReadAllLines(openFileDialog1.FileName);
		}
		
		void ClearAllToolStripMenuItem1Click(object sender, EventArgs e)
		{
			richTextBox1.Clear();
		}
		
		void SaveToolStripMenuItem1Click(object sender, EventArgs e)
		{
			try {
				File.WriteAllLines(openFileDialog1.FileName, richTextBox1.Lines);
			} catch {
				//
			}
		}
		
		void SaveAsToolStripMenuItem1Click(object sender, EventArgs e)
		{
			if (richTextBox1.Text != "") {
				saveFileDialog1.Filter = "TextFiles|(*.txt)";
				saveFileDialog1.ShowDialog();
				
				File.WriteAllLines(saveFileDialog1.FileName, richTextBox1.Lines);
			} else {
				//
			}
		}
		
		void ExitToolStripMenuItem2Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}
		
		void FontToolStripMenuItem1Click(object sender, EventArgs e)
		{
			fontDialog1.ShowDialog();
			richTextBox1.Font = fontDialog1.Font;
		}
		
		void CopyToolStripMenuItemClick(object sender, EventArgs e)
		{
			richTextBox1.Copy();
		}
		
		void PasteToolStripMenuItemClick(object sender, EventArgs e)
		{
			richTextBox1.Paste();
		}
		
		void UndoToolStripMenuItemClick(object sender, EventArgs e)
		{
			richTextBox1.Undo();
		}
		
		void RedoToolStripMenuItemClick(object sender, EventArgs e)
		{
			richTextBox1.Redo();
		}
		
		void SelectAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			richTextBox1.SelectAll();
		}
		
		void ExitToolStripMenuItem3Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}
		
		void MainForm_Closing(object sender, FormClosingEventArgs e)
		{
			if (richTextBox1.Text != "") {
				DialogResult result = MessageBox.Show("Save", "Do you want to save changes?", MessageBoxButtons.YesNo);
			
				if (DialogResult.Yes == result) {
					saveFileDialog1.Filter = "TextFiles|(*.txt)";
					saveFileDialog1.ShowDialog();
					
					File.Create(saveFileDialog1.FileName);
					Thread.Sleep(400);
					
					string Name = saveFileDialog1.FileName;
					saveFileDialog1.Reset();
					saveFileDialog1.Dispose();
					
					File.WriteAllLines(Name, richTextBox1.Lines);
					Environment.Exit(0);
				} else Environment.Exit(0);
			}
		}
		
		void AboutToolStripMenuItem1Click(object sender, EventArgs e)
		{
			MessageBox.Show("This is updated notepad (2020) created by Emmett.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
