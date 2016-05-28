﻿using System.IO;
using SharpShell.SharpPreviewHandler;
using System;
using MarkdownSharp;

namespace MarkDownPreview
{
    /// <summary>
    /// Displays content of a file as MarkDown
    /// </summary>
    /// <seealso cref="SharpShell.SharpPreviewHandler.PreviewHandlerControl" />
    public partial class MarkDownHandlerPreviewControl : PreviewHandlerControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkDownHandlerPreviewControl"/> class.
        /// </summary>
        public MarkDownHandlerPreviewControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Performs the preview, transforming the content of <paramref name="selectedFilePath"/> into MarkDown and display it in a Browser control (in the preview pane)
        /// </summary>
        /// <param name="selectedFilePath">The selected file path.</param>
        public void DoPreview(string selectedFilePath)
        {
            try
            {
                var content = File.ReadAllText(selectedFilePath);

                // Create new markdown instance
                var mark = new Markdown();

                // Run parser
                string text = mark.Transform(content);

                //Insert the html into the browser
                webBrowser.DocumentText = $"<html><head></head><body>{text}</body></html>";
            }
            catch (Exception ex)
            {
                //  Maybe we could show something to the user in the preview
                //  window, but for now we'll just ignore any exceptions.
                webBrowser.DocumentText = ex.ToString();
            }
        }
    }
}
