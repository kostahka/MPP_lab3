using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AssemblyBrowser;
using Microsoft.Win32;

namespace AssemblyBrowserApp
{
    public class PageView : INotifyPropertyChanged
    {
        public string OpenedFileName { get; set; } = "";
        public List<TreeNode> Data { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void StartAssembly()
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "Assemblies|*.dll;*.exe",
                Title = "Select assembly",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog().Value)
            {

                OpenedFileName = openFileDialog.FileName;
                OnPropertyChanged(nameof(OpenedFileName));

                Data = new List<TreeNode>();
                Data.Add(AssemblyBrowser.AssemblyBrowser.BrowseFile(OpenedFileName));

                OnPropertyChanged(nameof(Data));
            }
        }
    }
}
