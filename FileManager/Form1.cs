using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.IO.File;

namespace FileManager
{
    public partial class Form1 : Form
    {
        private bool lv_left = false, lv_right = false;
        private Thread th;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DriveInfo[] allDisks = DriveInfo.GetDrives();
            foreach (var d in allDisks)
            {
                if (d.IsReady)
                {
                    cb_Disks.Items.Add(d.Name);
                    cb_Disk2.Items.Add(d.Name);
                }
            }
            lbl_freeMemoryDisk2.Visible = false;
            lbl_FreeMemory.Visible = false; 
        }

        private void cb_Disks_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriveInfo SelectedDisk = new DriveInfo(cb_Disks.Text);
            lbl_FreeMemory.Visible = true;
            //Свободна пам'ять
            int DiskFreeMemoryGB = (int) (((SelectedDisk.TotalFreeSpace / 1024) / 1024) / 1024);
            double DiskFreeMemoryMB = ((SelectedDisk.TotalFreeSpace - DiskFreeMemoryGB) / 1024) / 1024;
            string ConvertNumbs = DiskFreeMemoryGB + "," + DiskFreeMemoryMB;
            double ResultDiskFreeMemoryGB = Convert.ToDouble(ConvertNumbs);

            //Повна пам'ять діска
            int DiskFullMemoryGB = (int) (((SelectedDisk.TotalSize / 1024) / 1024) / 1024);
            double DiskFullMemoryMB = ((SelectedDisk.TotalSize - DiskFullMemoryGB) / 1024) / 1024;
            string Convertnumbs = DiskFullMemoryGB + "," + DiskFullMemoryMB;
            double ResultDiskFullMemory = Convert.ToDouble(Convertnumbs);
            lbl_FreeMemory.Text = String.Format("Свободно {0:F} Гб из {1:F} Гб. Файловая система: {2}", ResultDiskFreeMemoryGB, ResultDiskFullMemory, SelectedDisk.DriveFormat);

            tb_leftPartPath.Clear();
            tb_leftPartPath.Text += cb_Disks.Text;
            lv_leftPartFiles.Items.Clear();

            //Получаєм список папок
            DirectoryInfo dir = new DirectoryInfo(cb_Disks.Text);

            DirectoryInfo[] Dirs = dir.GetDirectories();

            ImageList imgs = new ImageList();
            imgs.Images.Add(Image.FromFile("back.png"));
            imgs.Images.Add(Image.FromFile("./1492783388_folder.jpeg"));
            imgs.Images.Add(Image.FromFile("exe.png"));
            imgs.Images.Add(Image.FromFile("notepad.jpg"));
            imgs.Images.Add(Image.FromFile("system.png"));
            lv_leftPartFiles.SmallImageList = imgs;
            lv_leftPartFiles.Items.Add("...", 0);

            foreach (var Dir in Dirs)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = Dir.Name;
                lvi.SubItems.Add("Папка");
                lvi.SubItems.Add("");
                lvi.ImageIndex = 1;
                lvi.SubItems.Add(Dir.LastWriteTime.ToShortDateString() + " " + Dir.LastWriteTime.ToShortTimeString());
                lv_leftPartFiles.Items.Add(lvi);
            }

            //Получаєм список файлів
            FileInfo[] Files = dir.GetFiles();


            foreach (var f in Files)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = f.Name;
                try
                {
                    lvi.SubItems.Add(f.Name.Split('.')[1]);
                    if (f.Name.Split('.')[1] == "exe")
                        lvi.ImageIndex = 2;
                    else if (f.Name.Split('.')[1] == "txt" || f.Name.Split('.')[1] == "cs" || f.Name.Split('.')[1] == "php" || f.Name.Split('.')[1] == "log")
                        lvi.ImageIndex = 3;
                    else
                        lvi.ImageIndex = 4;
                }
                catch
                {
                    lvi.SubItems.Add("Файл");
                    lvi.ImageIndex = 4;
                }

                long FileSize = f.Length;
                int CountIncrease = 0;
                while (FileSize > 1024)
                {
                    FileSize /= 1024;
                    CountIncrease++;
                }

                string OdinVim = ConvertToOdinVim(CountIncrease);

                lvi.SubItems.Add(FileSize + " " + OdinVim);
                lvi.SubItems.Add(f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString());
                lv_leftPartFiles.Items.Add(lvi);

            }

        }

        private void cb_Disk2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriveInfo SelectedDisk = new DriveInfo(cb_Disk2.Text);
            lbl_freeMemoryDisk2.Visible = true;
            //Свободна пам'ять
            int DiskFreeMemoryGB = (int)(((SelectedDisk.TotalFreeSpace / 1024) / 1024) / 1024);
            double DiskFreeMemoryMB = ((SelectedDisk.TotalFreeSpace - DiskFreeMemoryGB) / 1024) / 1024;
            string ConvertNumbs = DiskFreeMemoryGB + "," + DiskFreeMemoryMB;
            double ResultDiskFreeMemoryGB = Convert.ToDouble(ConvertNumbs);

            //Повна пам'ять діска
            int DiskFullMemoryGB = (int)(((SelectedDisk.TotalSize / 1024) / 1024) / 1024);
            double DiskFullMemoryMB = ((SelectedDisk.TotalSize - DiskFullMemoryGB) / 1024) / 1024;
            string Convertnumbs = DiskFullMemoryGB + "," + DiskFullMemoryMB;
            double ResultDiskFullMemory = Convert.ToDouble(Convertnumbs);
            lbl_freeMemoryDisk2.Text = String.Format("Свободно {0:F} Гб из {1:F} Гб. Файловая система: {2}", ResultDiskFreeMemoryGB, ResultDiskFullMemory, SelectedDisk.DriveFormat);

            tb_rightPartPath.Clear();
            tb_rightPartPath.Text += cb_Disk2.Text;
            lv_rightPartFiles.Items.Clear();

            //Получаєм список папок
            DirectoryInfo dir = new DirectoryInfo(cb_Disk2.Text);

            DirectoryInfo[] Dirs = dir.GetDirectories();

            ImageList imgs = new ImageList();
            imgs.Images.Add(Image.FromFile("back.png"));
            imgs.Images.Add(Image.FromFile("./1492783388_folder.jpeg"));
            imgs.Images.Add(Image.FromFile("exe.png"));
            imgs.Images.Add(Image.FromFile("notepad.jpg"));
            imgs.Images.Add(Image.FromFile("system.png"));
            lv_rightPartFiles.SmallImageList = imgs;
            lv_rightPartFiles.Items.Add("...", 0);

            foreach (var Dir in Dirs)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = 1;
                lvi.Text = Dir.Name;
                lvi.SubItems.Add("Папка");
                lvi.SubItems.Add("");
                lvi.SubItems.Add(Dir.LastWriteTime.ToShortDateString() + " " + Dir.LastWriteTime.ToShortTimeString());
                lv_rightPartFiles.Items.Add(lvi);
            }

            //Получаєм список файлів
            FileInfo[] Files = dir.GetFiles();

            foreach (var f in Files)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = f.Name;
                try
                {
                    lvi.SubItems.Add(f.Name.Split('.')[1]);
                    if (f.Name.Split('.')[1] == "exe")
                        lvi.ImageIndex = 2;
                    else if (f.Name.Split('.')[1] == "txt" || f.Name.Split('.')[1] == "cs" || f.Name.Split('.')[1] == "php" || f.Name.Split('.')[1] == "log")
                        lvi.ImageIndex = 3;
                    else
                        lvi.ImageIndex = 4;
                }
                catch
                {
                    lvi.SubItems.Add("Файл");
                    lvi.ImageIndex = 4;
                }

                long FileSize = f.Length;
                int CountIncrease = 0;
                while (FileSize > 1024)
                {
                    FileSize /= 1024;
                    CountIncrease++;
                }

                string OdinVim = ConvertToOdinVim(CountIncrease);

                lvi.SubItems.Add(FileSize.ToString() + " " + OdinVim);
                lvi.SubItems.Add(f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString());
                lv_rightPartFiles.Items.Add(lvi);
            }
        }

        public string ConvertToOdinVim(int k)
        {
            switch (k)
            {
                case 0:
                    return "Байт";
                case 1:
                    return "Кб";
                case 2:
                    return "Мб";
                case 3:
                    return "Гб";
            }

            return "Can't convert";
        }

        private void lv_leftPartFiles_DoubleClick(object sender, EventArgs e)
        {
            if (Path.GetExtension(lv_leftPartFiles.SelectedItems[0].Text) == String.Empty)
            {
                DirectoryInfo dir = new DirectoryInfo(tb_leftPartPath.Text + lv_leftPartFiles.SelectedItems[0].Text);
                if (lv_leftPartFiles.SelectedItems[0].Text != "...")
                    tb_leftPartPath.Text += lv_leftPartFiles.SelectedItems[0].Text + "\\";
                else
                {
                    string[] someData = tb_leftPartPath.Text.Split('\\');
                    if (someData.Length > 2)
                        tb_leftPartPath.Clear();
                    for (int i = 0; i < someData.Length - 2; i++)
                        tb_leftPartPath.Text += someData[i] + "\\";
                }

                DirectoryInfo[] Dirs = dir.GetDirectories();

                lv_leftPartFiles.Items.Clear();
                lv_leftPartFiles.Items.Add("...", 0);
                foreach (var Dir in Dirs)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = Dir.Name;
                    lvi.SubItems.Add("Папка");
                    lvi.SubItems.Add("");
                    lvi.ImageIndex = 1;
                    lvi.SubItems.Add(Dir.LastWriteTime.ToShortDateString() + " " + Dir.LastWriteTime.ToShortTimeString());
                    lv_leftPartFiles.Items.Add(lvi);
                }

                FileInfo[] Files = dir.GetFiles();

                foreach (var f in Files)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = f.Name;
                    try
                    {
                        lvi.SubItems.Add(f.Name.Split('.')[1]);
                        if (f.Name.Split('.')[1] == "exe")
                            lvi.ImageIndex = 2;
                        else if (f.Name.Split('.')[1] == "txt" || f.Name.Split('.')[1] == "cs" || f.Name.Split('.')[1] == "php" || f.Name.Split('.')[1] == "log")
                            lvi.ImageIndex = 3;
                        else
                            lvi.ImageIndex = 4;
                    }
                    catch
                    {
                        lvi.SubItems.Add("Файл");
                        lvi.ImageIndex = 4;
                    }

                    long FileSize = f.Length;
                    int CountIncrease = 0;
                    while (FileSize > 1024)
                    {
                        FileSize /= 1024;
                        CountIncrease++;
                    }

                    string OdinVim = ConvertToOdinVim(CountIncrease);

                    lvi.SubItems.Add(FileSize + " " + OdinVim);
                    lvi.SubItems.Add(f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString());
                    lv_leftPartFiles.Items.Add(lvi);
                }
            }
            else
            {
                Process.Start(tb_leftPartPath.Text + lv_leftPartFiles.SelectedItems[0].Text);
            }


        }

        private void lv_rightPartFiles_DoubleClick(object sender, EventArgs e)
        {
            if (Path.GetExtension(lv_rightPartFiles.SelectedItems[0].Text) == String.Empty)
            {
                DirectoryInfo dir = new DirectoryInfo(tb_rightPartPath.Text + lv_rightPartFiles.SelectedItems[0].Text);
                if (lv_rightPartFiles.SelectedItems[0].Text != "...")
                    tb_rightPartPath.Text += lv_rightPartFiles.SelectedItems[0].Text + "\\";
                else
                {
                    string[] someData = tb_rightPartPath.Text.Split('\\');
                    if (someData.Length > 2)
                        tb_rightPartPath.Clear();
                    for (int i = 0; i < someData.Length - 2; i++)
                        tb_rightPartPath.Text += someData[i] + "\\";
                }

                DirectoryInfo[] Dirs = dir.GetDirectories();

                lv_rightPartFiles.Items.Clear();
                lv_rightPartFiles.Items.Add("...", 0);
                foreach (var Dir in Dirs)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = Dir.Name;
                    lvi.SubItems.Add("Папка");
                    lvi.SubItems.Add("");
                    lvi.ImageIndex = 1;
                    lvi.SubItems.Add(Dir.LastWriteTime.ToShortDateString() + " " + Dir.LastWriteTime.ToShortTimeString());
                    lv_rightPartFiles.Items.Add(lvi);
                }

                FileInfo[] Files = dir.GetFiles();

                foreach (var f in Files)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = f.Name;
                    try
                    {
                        lvi.SubItems.Add(f.Name.Split('.')[1]);
                        if (f.Name.Split('.')[1] == "exe")
                            lvi.ImageIndex = 2;
                        else if (f.Name.Split('.')[1] == "txt" || f.Name.Split('.')[1] == "cs" ||
                                 f.Name.Split('.')[1] == "php" ||
                                 f.Name.Split('.')[1] == "log")
                            lvi.ImageIndex = 3;
                        else
                            lvi.ImageIndex = 4;
                    }
                    catch
                    {
                        lvi.SubItems.Add("Файл");
                        lvi.ImageIndex = 4;
                    }

                    long FileSize = f.Length;
                    int CountIncrease = 0;
                    while (FileSize > 1024)
                    {
                        FileSize /= 1024;
                        CountIncrease++;
                    }

                    string OdinVim = ConvertToOdinVim(CountIncrease);

                    lvi.SubItems.Add(FileSize + " " + OdinVim);
                    lvi.SubItems.Add(f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString());
                    lv_rightPartFiles.Items.Add(lvi);
                }
            }
            else
            {
                Process.Start(tb_rightPartPath.Text + lv_rightPartFiles.SelectedItems[0].Text);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                button2.PerformClick();
            }
            if(e.KeyCode == Keys.F4)
                button3.PerformClick();
            if(e.KeyCode == Keys.F5)
                button1.PerformClick();
            if(e.KeyCode == Keys.F6)
                button4.PerformClick();
            if(e.KeyCode == Keys.F7)
                button6.PerformClick();
            
        }

        private void lv_leftPartFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            lv_left = true;
            lv_right = false;
        }

        private void lv_rightPartFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            lv_right = true;
            lv_left = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateDirectory cd = new CreateDirectory();
            cd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lv_left)
            {
                if(Path.GetExtension(tb_leftPartPath.Text + lv_leftPartFiles.SelectedItems[0].Text) == "")
                    return;

                Process.Start(tb_leftPartPath.Text + lv_leftPartFiles.SelectedItems[0].Text);
            }
            if (lv_right)
            {
                if (Path.GetExtension(tb_rightPartPath.Text + lv_rightPartFiles.SelectedItems[0].Text) == "")
                    return;

                Process.Start(tb_rightPartPath.Text + lv_rightPartFiles.SelectedItems[0].Text);
            }
        }

        void CopyDir(string FromDir, string ToDir)
        {
            th = new Thread(() =>
            {
                Directory.CreateDirectory(ToDir);
                foreach (string s1 in Directory.GetFiles(FromDir))
                {
                    string s2 = ToDir + "\\" + Path.GetFileName(s1);
                    if (Exists(s2))
                        continue;
                    Copy(s1, s2, true);
                }
                foreach (string s in Directory.GetDirectories(FromDir))
                {
                    CopyDir(s, ToDir + "\\" + Path.GetFileName(s));
                }
            });
            th.Start();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (lv_left)
            {
                if (tb_rightPartPath.Text != "")
                {
                    for (int i = 0; i < lv_leftPartFiles.SelectedItems.Count; i++)
                    {
                        if (lv_leftPartFiles.SelectedItems[i].SubItems[1].Text == "Папка")
                        {
                            CopyDir(tb_leftPartPath.Text + lv_leftPartFiles.SelectedItems[i].Text,
                                tb_rightPartPath.Text + lv_leftPartFiles.SelectedItems[i].Text);
                        }
                        else
                        {
                            Copy(tb_leftPartPath.Text + lv_leftPartFiles.SelectedItems[i].Text,
                                tb_rightPartPath.Text + lv_leftPartFiles.SelectedItems[i].Text, true);
                        }
                    }

                    th.Join();
                    DirectoryInfo dir = new DirectoryInfo(tb_rightPartPath.Text);


                    DirectoryInfo[] Dirs = dir.GetDirectories();

                    lv_rightPartFiles.Items.Clear();
                    lv_rightPartFiles.Items.Add("...", 0);
                    foreach (var Dir in Dirs)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = Dir.Name;
                        lvi.SubItems.Add("Папка");
                        lvi.SubItems.Add("");
                        lvi.ImageIndex = 1;
                        lvi.SubItems.Add(Dir.LastWriteTime.ToShortDateString() + " " + Dir.LastWriteTime.ToShortTimeString());
                        lv_rightPartFiles.Items.Add(lvi);
                    }

                    FileInfo[] Files = dir.GetFiles();

                    foreach (var f in Files)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = f.Name;
                        try
                        {
                            lvi.SubItems.Add(f.Name.Split('.')[1]);
                            if (f.Name.Split('.')[1] == "exe")
                                lvi.ImageIndex = 2;
                            else if (f.Name.Split('.')[1] == "txt" || f.Name.Split('.')[1] == "cs" ||
                                     f.Name.Split('.')[1] == "php" ||
                                     f.Name.Split('.')[1] == "log")
                                lvi.ImageIndex = 3;
                            else
                                lvi.ImageIndex = 4;
                        }
                        catch
                        {
                            lvi.SubItems.Add("Файл");
                            lvi.ImageIndex = 4;
                        }

                        long FileSize = f.Length;
                        int CountIncrease = 0;
                        while (FileSize > 1024)
                        {
                            FileSize /= 1024;
                            CountIncrease++;
                        }

                        string OdinVim = ConvertToOdinVim(CountIncrease);

                        lvi.SubItems.Add(FileSize + " " + OdinVim);
                        lvi.SubItems.Add(f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString());
                        lv_rightPartFiles.Items.Add(lvi);

                    }
                }
                else
                {
                    MessageBox.Show("Выберите путь справа куда копировать", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            if (lv_right)
            {
                if (tb_leftPartPath.Text != "")
                {
                    for (int i = 0; i < lv_rightPartFiles.SelectedItems.Count; i++)
                    {
                        if (lv_rightPartFiles.SelectedItems[i].SubItems[1].Text == "Папка")
                        {
                            CopyDir(tb_rightPartPath.Text + lv_rightPartFiles.SelectedItems[i].Text, tb_leftPartPath.Text + lv_rightPartFiles.SelectedItems[i].Text);
                        }
                        else
                        {
                            Copy(tb_rightPartPath.Text + lv_rightPartFiles.SelectedItems[i].Text, tb_leftPartPath.Text + lv_rightPartFiles.SelectedItems[i].Text, true);
                        }
                    }

                    th.Join();

                    DirectoryInfo dir = new DirectoryInfo(tb_leftPartPath.Text);

                    DirectoryInfo[] Dirs = dir.GetDirectories();

                    lv_leftPartFiles.Items.Clear();
                    lv_leftPartFiles.Items.Add("...", 0);
                    foreach (var Dir in Dirs)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = Dir.Name;
                        lvi.SubItems.Add("Папка");
                        lvi.SubItems.Add("");
                        lvi.ImageIndex = 1;
                        lvi.SubItems.Add(Dir.LastWriteTime.ToShortDateString() + " " + Dir.LastWriteTime.ToShortTimeString());
                        lv_leftPartFiles.Items.Add(lvi);
                    }

                    FileInfo[] Files = dir.GetFiles();

                    foreach (var f in Files)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = f.Name;
                        try
                        {
                            lvi.SubItems.Add(f.Name.Split('.')[1]);
                            if (f.Name.Split('.')[1] == "exe")
                                lvi.ImageIndex = 2;
                            else if (f.Name.Split('.')[1] == "txt" || f.Name.Split('.')[1] == "cs" ||
                                     f.Name.Split('.')[1] == "php" || f.Name.Split('.')[1] == "log")
                                lvi.ImageIndex = 3;
                            else
                                lvi.ImageIndex = 4;
                        }
                        catch
                        {
                            lvi.SubItems.Add("Файл");
                            lvi.ImageIndex = 4;
                        }

                        long FileSize = f.Length;
                        int CountIncrease = 0;
                        while (FileSize > 1024)
                        {
                            FileSize /= 1024;
                            CountIncrease++;
                        }

                        string OdinVim = ConvertToOdinVim(CountIncrease);

                        lvi.SubItems.Add(FileSize + " " + OdinVim);
                        lvi.SubItems.Add(f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString());
                        lv_leftPartFiles.Items.Add(lvi);
                    }

                }
                else
                {
                    MessageBox.Show("Выберите путь справа куда копировать", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        void MoveTo(string FromDir, string ToDir)
        {
            new Thread(() =>
            {
                Directory.CreateDirectory(ToDir);
                foreach (string s1 in Directory.GetFiles(FromDir))
                {
                    string s2 = ToDir + "\\" + Path.GetFileName(s1);
                    if (Exists(s2))
                        continue;
                    File.Move(s1, s2);
                    Delete(s1);
                }
                foreach (string s in Directory.GetDirectories(FromDir))
                {
                    CopyDir(s, ToDir + "\\" + Path.GetFileName(s));
                }
                Directory.Delete(FromDir);
                
            }).Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lv_left)
            {
                if (tb_rightPartPath.Text != "")
                {
                    for (int i = 0; i < lv_leftPartFiles.SelectedItems.Count; i++)
                    {
                        if (lv_leftPartFiles.SelectedItems[i].SubItems[1].Text == "Папка")
                        {
                            MoveTo(tb_leftPartPath.Text + lv_leftPartFiles.SelectedItems[i].Text, tb_rightPartPath.Text + lv_leftPartFiles.SelectedItems[i].Text);
                        }
                        else
                        {
                            File.Move(tb_leftPartPath.Text + lv_leftPartFiles.SelectedItems[i].Text,
                                tb_rightPartPath.Text + lv_leftPartFiles.SelectedItems[i].Text);
                            File.Delete(tb_leftPartPath.Text + lv_leftPartFiles.SelectedItems[i].Text);
                        }
                    }

                    DirectoryInfo dir = new DirectoryInfo(tb_rightPartPath.Text);


                    DirectoryInfo[] Dirs = dir.GetDirectories();

                    lv_rightPartFiles.Items.Clear();
                    lv_rightPartFiles.Items.Add("...", 0);
                    foreach (var Dir in Dirs)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = Dir.Name;
                        lvi.SubItems.Add("Папка");
                        lvi.SubItems.Add("");
                        lvi.ImageIndex = 1;
                        lvi.SubItems.Add(Dir.LastWriteTime.ToShortDateString() + " " + Dir.LastWriteTime.ToShortTimeString());
                        lv_rightPartFiles.Items.Add(lvi);
                    }

                    FileInfo[] Files = dir.GetFiles();

                    foreach (var f in Files)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = f.Name;
                        try
                        {
                            lvi.SubItems.Add(f.Name.Split('.')[1]);
                            if (f.Name.Split('.')[1] == "exe")
                                lvi.ImageIndex = 2;
                            else if (f.Name.Split('.')[1] == "txt" || f.Name.Split('.')[1] == "cs" ||
                                     f.Name.Split('.')[1] == "php" ||
                                     f.Name.Split('.')[1] == "log")
                                lvi.ImageIndex = 3;
                            else
                                lvi.ImageIndex = 4;
                        }
                        catch
                        {
                            lvi.SubItems.Add("Файл");
                            lvi.ImageIndex = 4;
                        }

                        long FileSize = f.Length;
                        int CountIncrease = 0;
                        while (FileSize > 1024)
                        {
                            FileSize /= 1024;
                            CountIncrease++;
                        }

                        string OdinVim = ConvertToOdinVim(CountIncrease);

                        lvi.SubItems.Add(FileSize + " " + OdinVim);
                        lvi.SubItems.Add(f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString());
                        lv_rightPartFiles.Items.Add(lvi);

                    }

                    DirectoryInfo dir1 = new DirectoryInfo(tb_leftPartPath.Text);

                    DirectoryInfo[] Dirs2 = dir1.GetDirectories();

                    lv_leftPartFiles.Items.Clear();
                    lv_leftPartFiles.Items.Add("...", 0);
                    foreach (var Dir in Dirs2)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = Dir.Name;
                        lvi.SubItems.Add("Папка");
                        lvi.SubItems.Add("");
                        lvi.ImageIndex = 1;
                        lvi.SubItems.Add(Dir.LastWriteTime.ToShortDateString() + " " + Dir.LastWriteTime.ToShortTimeString());
                        lv_leftPartFiles.Items.Add(lvi);
                    }

                    FileInfo[] Files1 = dir1.GetFiles();

                    foreach (var f in Files1)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = f.Name;
                        try
                        {
                            lvi.SubItems.Add(f.Name.Split('.')[1]);
                            if (f.Name.Split('.')[1] == "exe")
                                lvi.ImageIndex = 2;
                            else if (f.Name.Split('.')[1] == "txt" || f.Name.Split('.')[1] == "cs" ||
                                     f.Name.Split('.')[1] == "php" || f.Name.Split('.')[1] == "log")
                                lvi.ImageIndex = 3;
                            else
                                lvi.ImageIndex = 4;
                        }
                        catch
                        {
                            lvi.SubItems.Add("Файл");
                            lvi.ImageIndex = 4;
                        }

                        long FileSize = f.Length;
                        int CountIncrease = 0;
                        while (FileSize > 1024)
                        {
                            FileSize /= 1024;
                            CountIncrease++;
                        }

                        string OdinVim = ConvertToOdinVim(CountIncrease);

                        lvi.SubItems.Add(FileSize + " " + OdinVim);
                        lvi.SubItems.Add(f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString());
                        lv_leftPartFiles.Items.Add(lvi);
                    }



                }
                else
                {
                    MessageBox.Show("Выберите путь справа куда копировать", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (lv_right)
            {
                if (tb_leftPartPath.Text != "")
                {
                    for (int i = 0; i < lv_rightPartFiles.SelectedItems.Count; i++)
                    {
                        if (lv_rightPartFiles.SelectedItems[i].SubItems[1].Text == "Папка")
                        {
                            MoveTo(tb_rightPartPath.Text + lv_rightPartFiles.SelectedItems[i].Text, tb_leftPartPath.Text + lv_rightPartFiles.SelectedItems[i].Text);
                        }
                        else
                        {
                            File.Move(tb_rightPartPath.Text + lv_rightPartFiles.SelectedItems[i].Text,
                                tb_leftPartPath.Text + lv_rightPartFiles.SelectedItems[i].Text);
                            File.Delete(tb_rightPartPath.Text + lv_rightPartFiles.SelectedItems[i].Text);
                        }
                    }

                    DirectoryInfo dir = new DirectoryInfo(tb_rightPartPath.Text);


                    DirectoryInfo[] Dirs = dir.GetDirectories();

                    lv_rightPartFiles.Items.Clear();
                    lv_rightPartFiles.Items.Add("...", 0);
                    foreach (var Dir in Dirs)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = Dir.Name;
                        lvi.SubItems.Add("Папка");
                        lvi.SubItems.Add("");
                        lvi.ImageIndex = 1;
                        lvi.SubItems.Add(Dir.LastWriteTime.ToShortDateString() + " " + Dir.LastWriteTime.ToShortTimeString());
                        lv_rightPartFiles.Items.Add(lvi);
                    }

                    FileInfo[] Files = dir.GetFiles();

                    foreach (var f in Files)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = f.Name;
                        try
                        {
                            lvi.SubItems.Add(f.Name.Split('.')[1]);
                            if (f.Name.Split('.')[1] == "exe")
                                lvi.ImageIndex = 2;
                            else if (f.Name.Split('.')[1] == "txt" || f.Name.Split('.')[1] == "cs" ||
                                     f.Name.Split('.')[1] == "php" ||
                                     f.Name.Split('.')[1] == "log")
                                lvi.ImageIndex = 3;
                            else
                                lvi.ImageIndex = 4;
                        }
                        catch
                        {
                            lvi.SubItems.Add("Файл");
                            lvi.ImageIndex = 4;
                        }

                        long FileSize = f.Length;
                        int CountIncrease = 0;
                        while (FileSize > 1024)
                        {
                            FileSize /= 1024;
                            CountIncrease++;
                        }

                        string OdinVim = ConvertToOdinVim(CountIncrease);

                        lvi.SubItems.Add(FileSize + " " + OdinVim);
                        lvi.SubItems.Add(f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString());
                        lv_rightPartFiles.Items.Add(lvi);

                    }

                    DirectoryInfo dir1 = new DirectoryInfo(tb_leftPartPath.Text);

                    DirectoryInfo[] Dirs2 = dir1.GetDirectories();

                    lv_leftPartFiles.Items.Clear();
                    lv_leftPartFiles.Items.Add("...", 0);
                    foreach (var Dir in Dirs2)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = Dir.Name;
                        lvi.SubItems.Add("Папка");
                        lvi.SubItems.Add("");
                        lvi.ImageIndex = 1;
                        lvi.SubItems.Add(Dir.LastWriteTime.ToShortDateString() + " " + Dir.LastWriteTime.ToShortTimeString());
                        lv_leftPartFiles.Items.Add(lvi);
                    }

                    FileInfo[] Files1 = dir1.GetFiles();

                    foreach (var f in Files1)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = f.Name;
                        try
                        {
                            lvi.SubItems.Add(f.Name.Split('.')[1]);
                            if (f.Name.Split('.')[1] == "exe")
                                lvi.ImageIndex = 2;
                            else if (f.Name.Split('.')[1] == "txt" || f.Name.Split('.')[1] == "cs" ||
                                     f.Name.Split('.')[1] == "php" || f.Name.Split('.')[1] == "log")
                                lvi.ImageIndex = 3;
                            else
                                lvi.ImageIndex = 4;
                        }
                        catch
                        {
                            lvi.SubItems.Add("Файл");
                            lvi.ImageIndex = 4;
                        }

                        long FileSize = f.Length;
                        int CountIncrease = 0;
                        while (FileSize > 1024)
                        {
                            FileSize /= 1024;
                            CountIncrease++;
                        }

                        string OdinVim = ConvertToOdinVim(CountIncrease);

                        lvi.SubItems.Add(FileSize + " " + OdinVim);
                        lvi.SubItems.Add(f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString());
                        lv_leftPartFiles.Items.Add(lvi);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите путь справа куда копировать", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (lv_left)
            {
                if (lv_leftPartFiles.SelectedItems.Count != 0)
                {
                    FileManager.RenameDir rd = new RenameDir(lv_leftPartFiles.SelectedItems[0].Text);
                    rd.Show();
                }
            }
            if (lv_right)
            {
                if (lv_rightPartFiles.SelectedItems.Count != 0)
                {
                    FileManager.RenameDir rd = new RenameDir(lv_rightPartFiles.SelectedItems[0].Text);
                    rd.Show();
                }
            }
        }

        public void RenameDir(string NewName)
        {
            if (lv_left)
            {
                Directory.Move(tb_leftPartPath.Text + lv_leftPartFiles.SelectedItems[0].Text,
                    tb_leftPartPath.Text + "\\" + NewName);


                DirectoryInfo dir1 = new DirectoryInfo(tb_leftPartPath.Text);

                DirectoryInfo[] Dirs2 = dir1.GetDirectories();

                lv_leftPartFiles.Items.Clear();
                lv_leftPartFiles.Items.Add("...", 0);
                foreach (var Dir in Dirs2)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = Dir.Name;
                    lvi.SubItems.Add("Папка");
                    lvi.SubItems.Add("");
                    lvi.ImageIndex = 1;
                    lvi.SubItems.Add(Dir.LastWriteTime.ToShortDateString() + " " + Dir.LastWriteTime.ToShortTimeString());
                    lv_leftPartFiles.Items.Add(lvi);
                }

                FileInfo[] Files1 = dir1.GetFiles();

                foreach (var f in Files1)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = f.Name;
                    try
                    {
                        lvi.SubItems.Add(f.Name.Split('.')[1]);
                        if (f.Name.Split('.')[1] == "exe")
                            lvi.ImageIndex = 2;
                        else if (f.Name.Split('.')[1] == "txt" || f.Name.Split('.')[1] == "cs" ||
                                 f.Name.Split('.')[1] == "php" || f.Name.Split('.')[1] == "log")
                            lvi.ImageIndex = 3;
                        else
                            lvi.ImageIndex = 4;
                    }
                    catch
                    {
                        lvi.SubItems.Add("Файл");
                        lvi.ImageIndex = 4;
                    }

                    long FileSize = f.Length;
                    int CountIncrease = 0;
                    while (FileSize > 1024)
                    {
                        FileSize /= 1024;
                        CountIncrease++;
                    }

                    string OdinVim = ConvertToOdinVim(CountIncrease);

                    lvi.SubItems.Add(FileSize + " " + OdinVim);
                    lvi.SubItems.Add(f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString());
                    lv_leftPartFiles.Items.Add(lvi);
                }

            }
            if (lv_right)
            {
                Directory.Move(tb_rightPartPath.Text + lv_rightPartFiles.SelectedItems[0].Text,
                    tb_rightPartPath.Text + "\\" + NewName);

                DirectoryInfo dir = new DirectoryInfo(tb_rightPartPath.Text);


                DirectoryInfo[] Dirs = dir.GetDirectories();

                lv_rightPartFiles.Items.Clear();
                lv_rightPartFiles.Items.Add("...", 0);
                foreach (var Dir in Dirs)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = Dir.Name;
                    lvi.SubItems.Add("Папка");
                    lvi.SubItems.Add("");
                    lvi.ImageIndex = 1;
                    lvi.SubItems.Add(Dir.LastWriteTime.ToShortDateString() + " " + Dir.LastWriteTime.ToShortTimeString());
                    lv_rightPartFiles.Items.Add(lvi);
                }

                FileInfo[] Files = dir.GetFiles();

                foreach (var f in Files)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = f.Name;
                    try
                    {
                        lvi.SubItems.Add(f.Name.Split('.')[1]);
                        if (f.Name.Split('.')[1] == "exe")
                            lvi.ImageIndex = 2;
                        else if (f.Name.Split('.')[1] == "txt" || f.Name.Split('.')[1] == "cs" ||
                                 f.Name.Split('.')[1] == "php" ||
                                 f.Name.Split('.')[1] == "log")
                            lvi.ImageIndex = 3;
                        else
                            lvi.ImageIndex = 4;
                    }
                    catch
                    {
                        lvi.SubItems.Add("Файл");
                        lvi.ImageIndex = 4;
                    }

                    long FileSize = f.Length;
                    int CountIncrease = 0;
                    while (FileSize > 1024)
                    {
                        FileSize /= 1024;
                        CountIncrease++;
                    }

                    string OdinVim = ConvertToOdinVim(CountIncrease);

                    lvi.SubItems.Add(FileSize + " " + OdinVim);
                    lvi.SubItems.Add(f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString());
                    lv_rightPartFiles.Items.Add(lvi);

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lv_left)
            {
                if(lv_leftPartFiles.SelectedItems[0].SubItems[1].Text == "Папка")
                    DeleteFiles(tb_leftPartPath.Text + lv_leftPartFiles.SelectedItems[0].Text);
                else
                    File.Delete(tb_leftPartPath.Text + lv_leftPartFiles.SelectedItems[0].Text);

                DirectoryInfo dir1 = new DirectoryInfo(tb_leftPartPath.Text);

                DirectoryInfo[] Dirs2 = dir1.GetDirectories();

                lv_leftPartFiles.Items.Clear();
                lv_leftPartFiles.Items.Add("...", 0);
                foreach (var Dir in Dirs2)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = Dir.Name;
                    lvi.SubItems.Add("Папка");
                    lvi.SubItems.Add("");
                    lvi.ImageIndex = 1;
                    lvi.SubItems.Add(Dir.LastWriteTime.ToShortDateString() + " " + Dir.LastWriteTime.ToShortTimeString());
                    lv_leftPartFiles.Items.Add(lvi);
                }

                FileInfo[] Files1 = dir1.GetFiles();

                foreach (var f in Files1)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = f.Name;
                    try
                    {
                        lvi.SubItems.Add(f.Name.Split('.')[1]);
                        if (f.Name.Split('.')[1] == "exe")
                            lvi.ImageIndex = 2;
                        else if (f.Name.Split('.')[1] == "txt" || f.Name.Split('.')[1] == "cs" ||
                                 f.Name.Split('.')[1] == "php" || f.Name.Split('.')[1] == "log")
                            lvi.ImageIndex = 3;
                        else
                            lvi.ImageIndex = 4;
                    }
                    catch
                    {
                        lvi.SubItems.Add("Файл");
                        lvi.ImageIndex = 4;
                    }

                    long FileSize = f.Length;
                    int CountIncrease = 0;
                    while (FileSize > 1024)
                    {
                        FileSize /= 1024;
                        CountIncrease++;
                    }

                    string OdinVim = ConvertToOdinVim(CountIncrease);

                    lvi.SubItems.Add(FileSize + " " + OdinVim);
                    lvi.SubItems.Add(f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString());
                    lv_leftPartFiles.Items.Add(lvi);
                }
            }
            if (lv_right)
            {
                if (lv_rightPartFiles.SelectedItems[0].SubItems[1].Text == "Папка")
                    DeleteFiles(tb_rightPartPath.Text + lv_rightPartFiles.SelectedItems[0].Text);
                else
                    File.Delete(tb_rightPartPath.Text + lv_rightPartFiles.SelectedItems[0].Text);

                DirectoryInfo dir = new DirectoryInfo(tb_rightPartPath.Text);


                DirectoryInfo[] Dirs = dir.GetDirectories();

                lv_rightPartFiles.Items.Clear();
                lv_rightPartFiles.Items.Add("...", 0);
                foreach (var Dir in Dirs)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = Dir.Name;
                    lvi.SubItems.Add("Папка");
                    lvi.SubItems.Add("");
                    lvi.ImageIndex = 1;
                    lvi.SubItems.Add(Dir.LastWriteTime.ToShortDateString() + " " + Dir.LastWriteTime.ToShortTimeString());
                    lv_rightPartFiles.Items.Add(lvi);
                }

                FileInfo[] Files = dir.GetFiles();

                foreach (var f in Files)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = f.Name;
                    try
                    {
                        lvi.SubItems.Add(f.Name.Split('.')[1]);
                        if (f.Name.Split('.')[1] == "exe")
                            lvi.ImageIndex = 2;
                        else if (f.Name.Split('.')[1] == "txt" || f.Name.Split('.')[1] == "cs" ||
                                 f.Name.Split('.')[1] == "php" ||
                                 f.Name.Split('.')[1] == "log")
                            lvi.ImageIndex = 3;
                        else
                            lvi.ImageIndex = 4;
                    }
                    catch
                    {
                        lvi.SubItems.Add("Файл");
                        lvi.ImageIndex = 4;
                    }

                    long FileSize = f.Length;
                    int CountIncrease = 0;
                    while (FileSize > 1024)
                    {
                        FileSize /= 1024;
                        CountIncrease++;
                    }

                    string OdinVim = ConvertToOdinVim(CountIncrease);

                    lvi.SubItems.Add(FileSize + " " + OdinVim);
                    lvi.SubItems.Add(f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString());
                    lv_rightPartFiles.Items.Add(lvi);

                }
            }
        }

        void DeleteFiles(string FromDir)
        {
            foreach (var s1 in Directory.GetFiles(FromDir))
            {
                File.Delete(s1);
            }
            foreach (var s2 in Directory.GetDirectories(FromDir))
            {
                DeleteFiles(s2);
            }
            Directory.Delete(FromDir);
        }

   

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            var f = new Form2();

            f.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lbl_FreeMemory_Click(object sender, EventArgs e)
        {

        }

        public void CreateDir(string nameDir)
        {
            if (lv_left)
            {
                Directory.CreateDirectory(tb_leftPartPath.Text + nameDir);

                DirectoryInfo dir = new DirectoryInfo(tb_leftPartPath.Text);

                DirectoryInfo[] Dirs = dir.GetDirectories();

                lv_leftPartFiles.Items.Clear();
                lv_leftPartFiles.Items.Add("...", 0);
                foreach (var Dir in Dirs)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = Dir.Name;
                    lvi.SubItems.Add("Папка");
                    lvi.SubItems.Add("");
                    lvi.ImageIndex = 1;
                    lvi.SubItems.Add(Dir.LastWriteTime.ToShortDateString() + " " + Dir.LastWriteTime.ToShortTimeString());
                    lv_leftPartFiles.Items.Add(lvi);
                }

                FileInfo[] Files = dir.GetFiles();

                foreach (var f in Files)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = f.Name;
                    try
                    {
                        lvi.SubItems.Add(f.Name.Split('.')[1]);
                        if (f.Name.Split('.')[1] == "exe")
                            lvi.ImageIndex = 2;
                        else if (f.Name.Split('.')[1] == "txt" || f.Name.Split('.')[1] == "cs" ||
                                 f.Name.Split('.')[1] == "php" || f.Name.Split('.')[1] == "log")
                            lvi.ImageIndex = 3;
                        else
                            lvi.ImageIndex = 4;
                    }
                    catch
                    {
                        lvi.SubItems.Add("Файл");
                        lvi.ImageIndex = 4;
                    }

                    long FileSize = f.Length;
                    int CountIncrease = 0;
                    while (FileSize > 1024)
                    {
                        FileSize /= 1024;
                        CountIncrease++;
                    }

                    string OdinVim = ConvertToOdinVim(CountIncrease);

                    lvi.SubItems.Add(FileSize + " " + OdinVim);
                    lvi.SubItems.Add(f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString());
                    lv_leftPartFiles.Items.Add(lvi);
                }
            }
            if (lv_right)
            {
                Directory.CreateDirectory(tb_rightPartPath.Text + nameDir);

                DirectoryInfo dir = new DirectoryInfo(tb_rightPartPath.Text);


                DirectoryInfo[] Dirs = dir.GetDirectories();

                lv_rightPartFiles.Items.Clear();
                lv_rightPartFiles.Items.Add("...", 0);
                foreach (var Dir in Dirs)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = Dir.Name;
                    lvi.SubItems.Add("Папка");
                    lvi.SubItems.Add("");
                    lvi.ImageIndex = 1;
                    lvi.SubItems.Add(Dir.LastWriteTime.ToShortDateString() + " " + Dir.LastWriteTime.ToShortTimeString());
                    lv_rightPartFiles.Items.Add(lvi);
                }

                FileInfo[] Files = dir.GetFiles();

                foreach (var f in Files)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = f.Name;
                    try
                    {
                        lvi.SubItems.Add(f.Name.Split('.')[1]);
                        if (f.Name.Split('.')[1] == "exe")
                            lvi.ImageIndex = 2;
                        else if (f.Name.Split('.')[1] == "txt" || f.Name.Split('.')[1] == "cs" ||
                                 f.Name.Split('.')[1] == "php" ||
                                 f.Name.Split('.')[1] == "log")
                            lvi.ImageIndex = 3;
                        else
                            lvi.ImageIndex = 4;
                    }
                    catch
                    {
                        lvi.SubItems.Add("Файл");
                        lvi.ImageIndex = 4;
                    }

                    long FileSize = f.Length;
                    int CountIncrease = 0;
                    while (FileSize > 1024)
                    {
                        FileSize /= 1024;
                        CountIncrease++;
                    }

                    string OdinVim = ConvertToOdinVim(CountIncrease);

                    lvi.SubItems.Add(FileSize + " " + OdinVim);
                    lvi.SubItems.Add(f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString());
                    lv_rightPartFiles.Items.Add(lvi);
                }
            }

        }

    }
}
