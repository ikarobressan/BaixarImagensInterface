﻿using System;
using System.Windows.Forms;

namespace Diego
{
    partial class Form_Baixar : Form, ISelecionar
    {
        private string _arquivo;
        private string _destino;

        public Form_Baixar()
        {
            InitializeComponent();   
        }
  
        public void button_selecionar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog abrirTxt = new OpenFileDialog())
            {
                abrirTxt.Title = "Selecione a lista de imagens";
                abrirTxt.CheckFileExists = true;
                abrirTxt.CheckPathExists = true;
                abrirTxt.DefaultExt = "txt";
                abrirTxt.Filter = "txt files (*.txt)|*.txt";
                abrirTxt.ReadOnlyChecked = true;

                if (abrirTxt.ShowDialog() == DialogResult.OK)
                    MessageBox.Show($"O arquivo {abrirTxt.FileName} foi selecionado.");
                else
                    MessageBox.Show("Alguma coisa deu errado.");

                _arquivo = abrirTxt.FileName;
            }
        }

        public void button_destino_Click(object sender, EventArgs e)
        {
            using (var abrirDestino = new FolderBrowserDialog())
            {
                if (abrirDestino.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(abrirDestino.SelectedPath))
                    MessageBox.Show($"O arquivo {abrirDestino.SelectedPath} foi selecionado.");
                else
                    MessageBox.Show("Alguma coisa deu errado.");

                _destino = abrirDestino.SelectedPath;
            }
        }

        public void button_baixar_Click(object sender, EventArgs e)
        {
            BaixarImagens download = new BaixarImagens();
            download.Baixar(_arquivo, _destino);
        }
    }
}
