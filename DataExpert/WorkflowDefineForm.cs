using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;
using DataExpert;
using System.IO;

namespace DataExpert
{
    public partial class WorkflowDefineForm : Form
    {
        string workflowPath = ".\\workflow\\";
        string userPassword = "12345678";
        string reportPath = ".\\report\\";
        [System.Runtime.InteropServices.DllImport("user32.dll")] //申明API函数
        public static extern bool RegisterHotKey(
            IntPtr hWnd, // handle to window 
            int id, // hot key identifier 
            uint fsModifiers, // key-modifier options 
            Keys vk // virtual-key code 
        );
        [System.Runtime.InteropServices.DllImport("user32.dll")] //申明API函数
        public static extern bool UnregisterHotKey(
            IntPtr hWnd, // handle to window 
            int id // hot key identifier 
        );
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8,
            Modkeyup = 0x1000,
        }
        protected override void WndProc(ref Message m)//监视Windows消息
        {
            const int WM_HOTKEY = 0x0312;//如果m.Msg的值为0x0312那么表示用户按下了热键
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    ProcessHotkey(m);//按下热键时调用ProcessHotkey()函数
                    break;
            }

            base.WndProc(ref m); //将系统消息传递自父类的WndProc
        }
        private void ProcessHotkey(Message m) //按下设定的键时调用该函数
        {
            IntPtr id = m.WParam; //IntPtr用于表示指针或句柄的平台特定类型
            //MessageBox.Show(id.ToString());
            string sid = id.ToString();
            if ("101".Equals(sid) && focusedItem != null)
            {
                Hashtable copyItem = (Hashtable)focusedItem.Clone();
                copyItem["pointX"] = "" + curX;
                copyItem["pointY"] = "" + curY;
                copyItem["guid"] = System.Guid.NewGuid().ToString();
                items.Add(copyItem);
                drawItems();
            }
        }

        System.Drawing.Graphics g;
        string drawingItem;
        Hashtable attributes = new Hashtable();
        Hashtable defaultWorkflow = new Hashtable();
        ArrayList mainItems = new ArrayList();
        ArrayList validateItems = new ArrayList();
        ArrayList items = new ArrayList();
        Hashtable selectedItem;
        Hashtable focusedItem;
        Point[] routePoint = new Point[2];
        int defaultScale = 5;
        int scale = 5;
        int x = 0;
        int y = 0;
        int tempX = 0;
        int tempY = 0;
        int tempX1 = 0;
        int tempY1 = 0;
        int curX = 0;
        int curY = 0;

        public WorkflowDefineForm()
        {
            InitializeComponent();
            scale = defaultScale;
            x = 0;
            y = 0;
            labelXY.Text = "x=" + x + "; y=" + y + "\nscale=" + scale;
            g = this.splitContainer1.Panel2.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; 
            refleshTreeViewWorkflows();
            items = mainItems;
        }

        private void lblStart_Click(object sender, EventArgs e)
        {
            setDrawingItem("start");
        }

        private void lblNode_Click(object sender, EventArgs e)
        {
            setDrawingItem("node");
        }

        private void lblRoute_Click(object sender, EventArgs e)
        {
            setDrawingItem("route");
        }

        private void lblEnd_Click(object sender, EventArgs e)
        {
            setDrawingItem("end");
        }

        private void splitContainer1_Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            curX = (e.X - x) * scale;
            curY = (e.Y - y) * scale;
            if (!"route".Equals(drawingItem) && selectedItem != null)
            {
                selectedItem["pointX"] = "" + (e.X - x) * scale;
                selectedItem["pointY"] = "" + (e.Y - y) * scale;
                drawItems();
            }
            else if ("start".Equals(drawingItem))
            {
                drawItems();
                Functions.FillRoundRectangle(g, Brushes.Green, new Rectangle(e.X, e.Y, 40 * defaultScale / scale, 40 * defaultScale / scale), 20 * defaultScale / scale);
            }
            else if ("node".Equals(drawingItem))
            {
                drawItems();
                Functions.FillRoundRectangle(g, Brushes.Blue, new Rectangle(e.X, e.Y, 60 * defaultScale / scale, 60 * defaultScale / scale), 10 * defaultScale / scale);
            }
            else if ("end".Equals(drawingItem))
            {
                drawItems();
                Functions.FillRoundRectangle(g, Brushes.Red, new Rectangle(e.X, e.Y, 40 * defaultScale / scale, 40 * defaultScale / scale), 20 * defaultScale / scale);
            }
            if (selectedItem == null && (tempX != 0 || tempY != 0))
            {
                x = tempX1 + e.X - tempX;
                y = tempY1 + e.Y - tempY;
                labelXY.Text = "x=" + x + "; y=" + y + "\nscale=" + scale;
                drawItems();
            }
            if (routePoint[0].X != 0 && routePoint[0].Y != 0)
            {
                drawItems();
                routePoint[1] = new Point(e.X, e.Y);
                Pen pen = new Pen(Brushes.Black);
                pen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(pen.Width * 5 * defaultScale / scale, pen.Width * 40 * defaultScale / scale, true);
                g.DrawLine(pen, routePoint[0], routePoint[1]);
            }

        }

        private void splitContainer1_Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tempX = e.X;
                tempY = e.Y;
                tempX1 = x;
                tempY1 = y;
                focusedItem = selectItemExceptRoute(new Point((e.X - x) * scale, (e.Y - y) * scale));
                if ("route".Equals(drawingItem))
                {
                    selectedItem = selectItemExceptRoute(new Point((e.X -x) * scale, (e.Y -y) * scale));
                    if (selectedItem != null)
                    {
                        routePoint = new Point[2];
                        routePoint[0] = new Point(int.Parse((string)selectedItem["pointX"]) / scale + x, int.Parse((string)selectedItem["pointY"]) / scale + y);
                    }
                }
                else
                {
                    selectedItem = selectItem(new Point((e.X - x) * scale, (e.Y - y) * scale));
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                selectedItem = selectItem(new Point((e.X - x) * scale, (e.Y - y) * scale));
                if (selectedItem != null && MessageBox.Show(this, "remove item", "remove item", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    removeItem(selectedItem);
                }
                setDrawingItem("");
                drawItems();
                routePoint = new Point[2];
                if (selectedItem == focusedItem) focusedItem = null;
                selectedItem = null;
            }
        }

        private void splitContainer1_Panel2_MouseUp(object sender, MouseEventArgs e)
        {
            tempX = 0;
            tempY = 0;
            tempX1 = 0;
            tempY1 = 0;
            if (e.Button == MouseButtons.Left)
            {
                if (!"route".Equals(drawingItem) && selectedItem != null)
                {
                }
                else if ("start".Equals(drawingItem))
                {
                    Hashtable item = new Hashtable();
                    item.Add("pointX", "" + ((e.X - x) * scale));
                    item.Add("pointY", "" + ((e.Y - y) * scale));
                    item.Add("type", drawingItem);
                    item.Add("guid", System.Guid.NewGuid().ToString());
                    items.Add(item);
                }
                else if ("node".Equals(drawingItem))
                {
                    Hashtable item = new Hashtable();
                    item.Add("pointX", "" + ((e.X - x) * scale));
                    item.Add("pointY", "" + ((e.Y - y) * scale));
                    item.Add("type", drawingItem);
                    item.Add("guid", System.Guid.NewGuid().ToString());
                    items.Add(item);
                    setDrawingItem("");
                }
                else if ("end".Equals(drawingItem))
                {
                    Hashtable item = new Hashtable();
                    item.Add("pointX", "" + ((e.X - x) * scale));
                    item.Add("pointY", "" + ((e.Y - y) * scale));
                    item.Add("type", drawingItem);
                    item.Add("guid", System.Guid.NewGuid().ToString());
                    items.Add(item);
                }
                else if ("route".Equals(drawingItem) && routePoint[0].X != 0 && routePoint[0].Y != 0)
                {
                    Hashtable item1 = selectItemExceptRoute(new Point((routePoint[0].X - x) * scale, (routePoint[0].Y - y) * scale));
                    Hashtable item2 = selectItemExceptRoute(new Point((e.X - x) * scale, (e.Y - y) * scale));
                    if (item1 != null && item2 != null && !((string)item1["guid"]).Equals((string)item2["guid"]))
                    {
                        Hashtable item = new Hashtable();
                        item.Add("pointX", item1["guid"]);
                        item.Add("pointY", item2["guid"]);
                        item.Add("type", drawingItem);
                        item.Add("guid", System.Guid.NewGuid().ToString());
                        items.Add(item);
                    }
                }
                setDrawingItem("");
                drawItems();
                routePoint = new Point[2];
                selectedItem = null;
            }
        }
        private void drawItems()
        {
            g.Clear(System.Drawing.Color.White);
            if (focusedItem != null)
            {
                if ("node".Equals(focusedItem["type"]))
                {
                    int pointX = int.Parse((string)focusedItem["pointX"]);
                    int pointY = int.Parse((string)focusedItem["pointY"]);
                    Functions.FillRoundRectangle(g, Brushes.Black, new Rectangle(pointX / scale + x, pointY / scale + y, 62 * defaultScale / scale, 62 * defaultScale / scale), 10 * defaultScale / scale);
                }
                else if ("start".Equals(focusedItem["type"]))
                {
                    int pointX = int.Parse((string)focusedItem["pointX"]);
                    int pointY = int.Parse((string)focusedItem["pointY"]);
                    Functions.FillRoundRectangle(g, Brushes.Black, new Rectangle(pointX / scale + x, pointY / scale + y, 42 * defaultScale / scale, 42 * defaultScale / scale), 21 * defaultScale / scale);
                }
                else if ("end".Equals(focusedItem["type"]))
                {
                    int pointX = int.Parse((string)focusedItem["pointX"]);
                    int pointY = int.Parse((string)focusedItem["pointY"]);
                    Functions.FillRoundRectangle(g, Brushes.Black, new Rectangle(pointX / scale + x, pointY / scale + y, 42 * defaultScale / scale, 42 * defaultScale / scale), 21 * defaultScale / scale);
                }
                else if ("route".Equals(focusedItem["type"]))
                {
                    Hashtable routeStart = getItemByGuid((string)focusedItem["pointX"]);
                    Hashtable routeEnd = getItemByGuid((string)focusedItem["pointY"]);
                    int point1X = int.Parse((string)routeStart["pointX"]);
                    int point1Y = int.Parse((string)routeStart["pointY"]);
                    int point2X = int.Parse((string)routeEnd["pointX"]);
                    int point2Y = int.Parse((string)routeEnd["pointY"]);
                    Pen pen = new Pen(Brushes.Black);
                    pen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(pen.Width * 5 * defaultScale / scale, pen.Width * 40 * defaultScale / scale, true);
                    g.DrawLine(pen, new Point(point1X / scale + x, point1Y / scale + y), new Point(point2X / scale + x, point2Y / scale + y));
                    Functions.FillRoundRectangle(g, Brushes.Black, new Rectangle((point1X + point2X) / 2 / scale + x, (point1Y + point2Y) / 2 / scale + y, 10 * defaultScale / scale, 10 * defaultScale / scale), 5 * defaultScale / scale);
                }
            }
            foreach (Hashtable item in items)
            {
                if ("node".Equals(item["type"]))
                {
                    int pointX = int.Parse((string)item["pointX"]);
                    int pointY = int.Parse((string)item["pointY"]);
                    Functions.FillRoundRectangle(g, Brushes.Blue, new Rectangle(pointX / scale + x, pointY / scale + y, 60 * defaultScale / scale, 60 * defaultScale / scale), 10 * defaultScale / scale);
                    g.DrawString((string)item["description"], this.Font, Brushes.Black, new Point(pointX / scale + x, pointY / scale + y));
                }
                else if ("start".Equals(item["type"]))
                {
                    int pointX = int.Parse((string)item["pointX"]);
                    int pointY = int.Parse((string)item["pointY"]);
                    Functions.FillRoundRectangle(g, Brushes.Green, new Rectangle(pointX / scale + x, pointY / scale + y, 40 * defaultScale / scale, 40 * defaultScale / scale), 20 * defaultScale / scale);
                    g.DrawString((string)item["description"], this.Font, Brushes.Black, new Point(pointX / scale + x, pointY / scale + y));
                }
                else if ("end".Equals(item["type"]))
                {
                    int pointX = int.Parse((string)item["pointX"]);
                    int pointY = int.Parse((string)item["pointY"]);
                    Functions.FillRoundRectangle(g, Brushes.Red, new Rectangle(pointX / scale + x, pointY / scale + y, 40 * defaultScale / scale, 40 * defaultScale / scale), 20 * defaultScale / scale);
                    g.DrawString((string)item["description"], this.Font, Brushes.Black, new Point(pointX / scale + x, pointY / scale + y));
                }
                else if ("route".Equals(item["type"]))
                {
                    Hashtable routeStart = getItemByGuid((string)item["pointX"]);
                    Hashtable routeEnd = getItemByGuid((string)item["pointY"]);
                    int point1X = int.Parse((string)routeStart["pointX"]);
                    int point1Y = int.Parse((string)routeStart["pointY"]);
                    int point2X = int.Parse((string)routeEnd["pointX"]);
                    int point2Y = int.Parse((string)routeEnd["pointY"]);
                    Pen pen = new Pen(Brushes.Black);
                    pen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(pen.Width * 5 * defaultScale / scale, pen.Width * 40 * defaultScale / scale, true);
                    g.DrawLine(pen, new Point(point1X / scale + x, point1Y / scale + y), new Point(point2X / scale + x, point2Y / scale + y));
                    Functions.FillRoundRectangle(g, Brushes.Black, new Rectangle((point1X + point2X) / 2 / scale + x, (point1Y + point2Y) / 2 / scale + y, 10 * defaultScale / scale, 10 * defaultScale / scale), 5 * defaultScale / scale);
                    g.DrawString((string)item["description"], this.Font, Brushes.Black, new Point((point1X + point2X) / 2 / scale + x, (point1Y + point2Y) / 2 / scale + y));
                }
            }
        }
        private void setDrawingItem(string drawingItem)
        {
            this.drawingItem = drawingItem;

            this.lblStart.BackColor = System.Drawing.Color.White;
            this.lblNode.BackColor = System.Drawing.Color.White;
            this.lblRoute.BackColor = System.Drawing.Color.White;
            this.lblEnd.BackColor = System.Drawing.Color.White;
            if ("start".Equals(drawingItem))
            {
                this.lblStart.BackColor = System.Drawing.Color.Green;
            }
            else if ("node".Equals(drawingItem))
            {
                this.lblNode.BackColor = System.Drawing.Color.Blue;
            }
            else if ("route".Equals(drawingItem))
            {
                this.lblRoute.BackColor = System.Drawing.Color.Yellow;
            }
            else if ("end".Equals(drawingItem))
            {
                this.lblEnd.BackColor = System.Drawing.Color.Red;
            }
        }
        private Hashtable selectItemExceptRoute(Point curPoint)
        {
            int i = 0;
            foreach (Hashtable item in items)
            {
                if ("node".Equals(item["type"]))
                {
                    int pointX = int.Parse((string)item["pointX"]);
                    int pointY = int.Parse((string)item["pointY"]);
                    if (Math.Sqrt(Math.Pow(curPoint.X - pointX, 2) + Math.Pow(curPoint.Y - pointY, 2)) < 30 * defaultScale)
                    {
                        return item;
                    }
                }
                else if ("start".Equals(item["type"]))
                {
                    int pointX = int.Parse((string)item["pointX"]);
                    int pointY = int.Parse((string)item["pointY"]);
                    if (Math.Sqrt(Math.Pow(curPoint.X - pointX, 2) + Math.Pow(curPoint.Y - pointY, 2)) < 20 * defaultScale)
                    {
                        return item;
                    }
                }
                else if ("end".Equals(item["type"]))
                {
                    int pointX = int.Parse((string)item["pointX"]);
                    int pointY = int.Parse((string)item["pointY"]);
                    if (Math.Sqrt(Math.Pow(curPoint.X - pointX, 2) + Math.Pow(curPoint.Y - pointY, 2)) < 20 * defaultScale)
                    {
                        return item;
                    }
                }
                i++;
            }
            return null;
        }
        private void removeItem(Hashtable toDelItem)
        {
            foreach (Hashtable item in items)
            {
                if ("route".Equals(item["type"]))
                {
                    string pointX = (string)item["pointX"];
                    string pointY = (string)item["pointY"];
                    if (pointX.Equals((string)toDelItem["guid"]) || pointY.Equals((string)toDelItem["guid"]))
                    {
                        MessageBox.Show("删除节点前必须先删除所有经过它的路由");
                        return;
                    }
                }
            }
            items.Remove(toDelItem);
        }
        private Hashtable getItemByGuid(string guid)
        {
            foreach (Hashtable item in items)
            {
                if (guid.Equals((string)item["guid"]))
                {
                    return item;
                }
            }
            return null;
        }
        private Hashtable selectItem(Point curPoint)
        {
            int i = 0;
            foreach (Hashtable item in items)
            {
                if ("route".Equals(item["type"]))
                {
                    Hashtable routeStart = getItemByGuid((string)item["pointX"]);
                    Hashtable routeEnd = getItemByGuid((string)item["pointY"]);
                    int point1X = int.Parse((string)routeStart["pointX"]);
                    int point1Y = int.Parse((string)routeStart["pointY"]);
                    int point2X = int.Parse((string)routeEnd["pointX"]);
                    int point2Y = int.Parse((string)routeEnd["pointY"]);
                    if (Math.Sqrt(Math.Pow(curPoint.X - (point1X + point2X) / 2, 2) + Math.Pow(curPoint.Y - (point1Y + point2Y) / 2, 2)) < 10 * defaultScale)
                    {
                        setDrawingItem("route");
                        return item;
                    }
                }
                else if ("node".Equals(item["type"]))
                {
                    int pointX = int.Parse((string)item["pointX"]);
                    int pointY = int.Parse((string)item["pointY"]);
                    if (Math.Sqrt(Math.Pow(curPoint.X - pointX, 2) + Math.Pow(curPoint.Y - pointY, 2)) < 30 * defaultScale)
                    {
                        setDrawingItem("node");
                        return item;
                    }
                }
                else if ("start".Equals(item["type"]))
                {
                    int pointX = int.Parse((string)item["pointX"]);
                    int pointY = int.Parse((string)item["pointY"]);
                    if (Math.Sqrt(Math.Pow(curPoint.X - pointX, 2) + Math.Pow(curPoint.Y - pointY, 2)) < 20 * defaultScale)
                    {
                        setDrawingItem("start");
                        return item;
                    }
                }
                else if ("end".Equals(item["type"]))
                {
                    int pointX = int.Parse((string)item["pointX"]);
                    int pointY = int.Parse((string)item["pointY"]);
                    if (Math.Sqrt(Math.Pow(curPoint.X - pointX, 2) + Math.Pow(curPoint.Y - pointY, 2)) < 20 * defaultScale)
                    {
                        setDrawingItem("end");
                        return item;
                    }
                }
                i++;
            }
            return null;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeViewWorkflows.SelectedNode != null)
                {
                    Functions.XmlToData(out attributes, out mainItems, out validateItems, workflowPath + treeViewWorkflows.SelectedNode.Text + ".aflow", "12345678");
                    scale = defaultScale;
                    x = 0;
                    y = 0;
                    labelXY.Text = "x=" + x + "; y=" + y + "\nscale=" + scale;
                    focusedItem = null;
                    items = mainItems;
                    drawItems();
                }
                else
                {
                    MessageBox.Show("no workflow selected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            new WorkflowAttributesForm(attributes).ShowDialog();
            try
            {
                if (attributes["workflowName"] != null && !((string)attributes["workflowName"]).Trim().Equals(""))
                {
                    if (!Directory.Exists(workflowPath))
                    {
                        Directory.CreateDirectory(workflowPath);
                    }
                    if (File.Exists(workflowPath + Functions.FormatString((string)attributes["workflowName"] + ".aflow")))
                    {
                        if (MessageBox.Show("replace " + Functions.FormatString((string)attributes["workflowName"]) + @"?", "replace", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            Functions.DataToXML(attributes, mainItems, validateItems, workflowPath + Functions.FormatString((string)attributes["workflowName"] + ".aflow"), userPassword);
                            MessageBox.Show("workflow saved");
                            refleshTreeViewWorkflows();
                        }
                    }
                    else
                    {
                        Functions.DataToXML(attributes, mainItems, validateItems, workflowPath + Functions.FormatString((string)attributes["workflowName"]) + ".aflow", userPassword);
                        MessageBox.Show("workflow saved");
                        refleshTreeViewWorkflows();
                    }
                }
                else
                {
                    MessageBox.Show("save workflow error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void splitContainer1_Panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedItem = selectItem(new Point((e.X - x) * scale, (e.Y - y) * scale));
                if (selectedItem != null)
                {
                    if (DBConnector.getDBConnection() != null)
                    {
                        if (selectedItem["type"].Equals("start"))
                        {
                            StartEditForm itemEditForm = new StartEditForm(selectedItem, items);
                            itemEditForm.ShowDialog();
                        }
                        else if (selectedItem["type"].Equals("node"))
                        {
                            NodeEditForm itemEditForm = new NodeEditForm(selectedItem, items);
                            itemEditForm.ShowDialog();
                        }
                        else if (selectedItem["type"].Equals("route"))
                        {
                            RouteEditForm itemEditForm = new RouteEditForm(selectedItem, items);
                            itemEditForm.ShowDialog();
                        }
                        else if (selectedItem["type"].Equals("end"))
                        {
                            EndEditForm itemEditForm = new EndEditForm(selectedItem, items);
                            itemEditForm.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("no database connection");
                    }
                }
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            new WorkflowAttributesForm(attributes).ShowDialog();
            items.RemoveRange(0, items.Count);
            mainItems.RemoveRange(0, mainItems.Count);
            validateItems.RemoveRange(0, validateItems.Count);
            scale = defaultScale;
            x = 0;
            y = 0;
            labelXY.Text = "x=" + x + "; y=" + y + "\nscale=" + scale;
            focusedItem = null;
            drawItems();
        }

        private void buttonDBConnect_Click(object sender, EventArgs e)
        {
            DBConnectForm dbConnectForm = new DBConnectForm(attributes);
            dbConnectForm.ShowDialog();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeViewWorkflows.SelectedNode != null)
                {
                    Hashtable tempAttributes;
                    ArrayList tempItems;
                    ArrayList tempItems1;
                    Functions.XmlToData(out tempAttributes, out tempItems, out tempItems1, workflowPath + treeViewWorkflows.SelectedNode.Text + ".aflow", userPassword);
                    foreach (Hashtable tempItem in tempItems)
                    {
                        items.Add(tempItem);
                    }
                    focusedItem = null;
                    drawItems();
                }
                else
                {
                    MessageBox.Show("no workflow selected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            string timeString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                DBProcessor.runWorkflow(attributes, mainItems, reportPath + Functions.FormatString((string)attributes["workflowName"]) + "\\");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            g = this.splitContainer1.Panel2.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            drawItems();
        }

        private void labelScaleUp_Click(object sender, EventArgs e)
        {
            scale++;
            if (scale > 20) scale = 20;
            labelXY.Text = "x=" + x + "; y=" + y + "\nscale=" + scale;
        }

        private void labelScaleDown_Click(object sender, EventArgs e)
        {
            scale--;
            if (scale < 1) scale = 1;
            labelXY.Text = "x=" + x + "; y=" + y + "\nscale=" + scale;
        }

        private void labelXY_Click(object sender, EventArgs e)
        {
            scale = defaultScale;
            x = 0;
            y = 0;
            labelXY.Text = "x=" + x + "; y=" + y + "\nscale=" + scale;
        }

        private void splitContainer1_Panel2_MouseEnter(object sender, EventArgs e)
        {
            RegisterHotKey(Handle, 101, 2, Keys.R);
        }

        private void splitContainer1_Panel2_MouseLeave(object sender, EventArgs e)
        {
            UnregisterHotKey(Handle, 101);
        }

        private void buttonAttributes_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
        private void refleshTreeViewWorkflows()
        {
            try
            {
                treeViewWorkflows.Nodes.Clear();
                if (!Directory.Exists(workflowPath))
                {
                    Directory.CreateDirectory(workflowPath);
                }
                foreach (string filename in Directory.GetFiles(workflowPath, "*.aflow"))
                {
                    TreeNode treeNode = new TreeNode(filename.Replace(workflowPath, "").Replace(".aflow",""));
                    treeViewWorkflows.Nodes.Add(treeNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}