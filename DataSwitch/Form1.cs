using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesFile;

namespace DataSwitch
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        //标记选择的要素类型：点线面、注记
        private string TypeTag;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void point_CheckedChanged(object sender, EventArgs e)
        {
            List<string> AttList = new List<string>();
            CADtoShape con = new CADtoShape("D:\\Data\\工图CAD.dwg");
            TypeTag = "Point";
            if (point.Checked == true)
            {
                checkedListBox1.Items.Clear();
                AttList = con.getUniqueAttByFeaType("1");
                for(int i = 0; i < AttList.Count; i++)
                {
                    checkedListBox1.Items.Add(AttList[i]);
                }
            }
        }

        private void polyline_CheckedChanged(object sender, EventArgs e)
        {
            List<string> AttList = new List<string>();
            CADtoShape con = new CADtoShape("D:\\Data\\工图CAD.dwg");
            TypeTag = "Polyline";
            if (polyline.Checked == true)
            {
                checkedListBox1.Items.Clear();
                AttList = con.getUniqueAttByFeaType("2");
                for (int i = 0; i < AttList.Count; i++)
                {
                    checkedListBox1.Items.Add(AttList[i]);
                }
            }
        }

        private void polygon_CheckedChanged(object sender, EventArgs e)
        {
            List<string> AttList = new List<string>();
            CADtoShape con = new CADtoShape("D:\\Data\\工图CAD.dwg");
            TypeTag = "Polygon";
            if (polygon.Checked == true)
            {
                checkedListBox1.Items.Clear();
                AttList = con.getUniqueAttByFeaType("3");
                for (int i = 0; i < AttList.Count; i++)
                {
                    checkedListBox1.Items.Add(AttList[i]);
                }
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            List<string> AttList = new List<string>();
            CADtoShape con = new CADtoShape("D:\\Data\\工图CAD.dwg");
            TypeTag = "Annotation";
            if (radioButton4.Checked == true)
            {
                checkedListBox1.Items.Clear();
                AttList = con.getUniqueAttByFeaType("4");
                for (int i = 0; i < AttList.Count; i++)
                {
                    checkedListBox1.Items.Add(AttList[i]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            string path= folderBrowserDialog.SelectedPath;
            tbxPath.Text = path;
            tbxPath.Enabled = false;
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            List<string> fileList = new List<string>();
            try
            {
                CADtoShape pCADtoShp = new CADtoShape("D:\\Data\\工图CAD.dwg", tbxPath.Text, TypeTag);
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {
                    fileList.Add(checkedListBox1.CheckedItems[i].ToString());
                }
                pCADtoShp.CADLayerToFeatureClass(fileList);
                MessageBox.Show("创建成功！");
            }
            catch(Exception)
            {
                return;
            }
            tbxPath.Enabled = true;
        }
    }
}
