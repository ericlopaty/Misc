using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TIFFUtility
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                tbFileName.Text = openFileDialog.FileName;
        }    

        private void btnSplitPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                tbSplitPath.Text = folderBrowserDialog.SelectedPath;
        }

        private void btnReadProperties_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(R2KToolbox.TIFFTools.GetTIFFPageCount(tbFileName.Text).ToString());

        //    try
        //    {
        //        System.Drawing.Bitmap image = new System.Drawing.Bitmap(tbFileName.Text);
        //        System.Drawing.Imaging.PropertyItem[] properties = image.PropertyItems;
        //        PropertyItem currentItem = null;
        //        object objValue = null;
        //        lbProperties.Items.Clear();
        //        for (int i = 0; i < properties.GetLength(0); i++)
        //        {
        //            currentItem = properties[i];
        //            objValue = ReadPropertyValue(currentItem.Type, currentItem.Value);
        //            lbProperties.Items.Add(string.Format("{0} = {1}", currentItem.Id, objValue.ToString()));
        //        }
        //        image = null;
        //        properties = null;
        //    }
        //    catch (Exception x)
        //    {
        //        MessageBox.Show(string.Format("ERROR: {0}", x.Message));
        //    }
        }

        //private object ReadPropertyValue(short pItemType, byte[] pitemValue)
        //{
        //    // Read all the properties of the file. 
        //    object objValue = null;
        //    System.Text.Encoding asciiEnc = System.Text.Encoding.ASCII;
        //    // Read the values based on the type of the propery 
        //    switch (pItemType)
        //    {
        //        case 2: // Value is a null-terminated ASCII string.  
        //            objValue = asciiEnc.GetString(pitemValue);
        //            break;
        //        case 3: // Value is an array of unsigned short (16-bit) integers. 
        //            objValue = System.BitConverter.ToUInt16(pitemValue, 0);
        //            break;
        //        case 4: // Value is an array of unsigned long (32-bit) integers. 
        //            objValue = System.BitConverter.ToUInt32(pitemValue, 0);
        //            break;
        //        default:
        //            break;
        //    }
        //    return objValue;
        //}

        private void btnSplit_Click(object sender, EventArgs e)
        {
            R2KToolbox.TIFFTools.SplitPages(tbFileName.Text, tbSplitPath.Text, "fubar");

            //try
            //{
            //    Split(tbFileName.Text, tbSplitPath.Text);
            //}
            //catch (Exception x)
            //{
            //    MessageBox.Show(string.Format("ERROR: {0}", x.Message));
            //}
            //MessageBox.Show("Completed");
        }

        //private void Split(string inputFile, string outputPath)
        //{
        //    Image tiffImage = Image.FromFile(inputFile);
        //    Guid objGuid = tiffImage.FrameDimensionsList[0];
        //    FrameDimension dimension = new FrameDimension(objGuid);
        //    int pages = tiffImage.GetFrameCount(dimension);
        //    ImageCodecInfo encodeInfo = null;
        //    ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
        //    for (int j = 0; j < imageEncoders.Length; j++)
        //    {
        //        if (imageEncoders[j].MimeType == "image/tiff")
        //        {
        //            encodeInfo = imageEncoders[j];
        //            break;
        //        }
        //    }
        //    foreach (Guid guid in tiffImage.FrameDimensionsList)
        //    {
        //        for (int index = 0; index < pages; index++)
        //        {
        //            FrameDimension currentFrame = new FrameDimension(guid);
        //            tiffImage.SelectActiveFrame(currentFrame, index);
        //            string outputFile = string.Format("{0}{1}.TIF", Path.GetFileNameWithoutExtension(inputFile), index);
        //            tiffImage.Save(Path.Combine(outputPath, outputFile), encodeInfo, null);
        //        }
        //    }
        //}
    }
}


