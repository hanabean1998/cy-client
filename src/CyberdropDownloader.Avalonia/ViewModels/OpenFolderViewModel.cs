﻿using Avalonia.Controls;
using System.Diagnostics;
using System.IO;
using ReactiveUI;
using System.Reactive;
using CyberdropDownloader.Avalonia.Views;

namespace CyberdropDownloader.Avalonia.ViewModels
{
    public class OpenFolderViewModel
    {
        private TextBox _destinationTextBox;

        public OpenFolderViewModel(Window mainWindow)
        {
            _destinationTextBox = mainWindow.Find<FolderDestination>("FolderDestination").Find<TextBox>("FolderDestinationTextBox");

            OpenFolderDestinationCommand = ReactiveCommand.Create(OpenFolder);
        }

        public ReactiveCommand<Unit, Unit> OpenFolderDestinationCommand { get; }

        private void OpenFolder()
        {
            if (!Directory.Exists(_destinationTextBox.Text))
            {
                //TODO Report to log that path isn't real
                return;
            }

            Process.Start("explorer.exe", _destinationTextBox.Text);
        }
    }
}
