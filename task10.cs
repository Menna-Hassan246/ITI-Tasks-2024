using entity_framework.Models;
using Microsoft.EntityFrameworkCore;
namespace entity_framework
{
    public partial class Form1 : Form
    {
        ItiContext context;
        public Form1()
        {
          InitializeComponent();
            context = new ItiContext();
        }
        #region Show
        public void show(bool flage)
        {
            btn_add.Visible = flage;
            btn_delete.Visible = !flage;
            btn_update.Visible = !flage;
        }
        #endregion
        #region LoadForm
        private void Form1_Load(object sender, EventArgs e)
        {
          dgv_instructors.DataSource = context.Instructors.Select(x => new { x.InsId, x.InsName, x.InsDegree, x.Salary, x.DeptId }).ToList();
            cb_department.DataSource = context.Departments.ToList();
            cb_department.DisplayMember = "DeptName";
            cb_department.ValueMember = "DeptId";
            cb_department.SelectedIndex = -1;
            show(true);
        }
        #endregion
        #region Clear
        public void clear()
        {
            txt_degree.Text=txt_name.Text=string.Empty;
            nud_salary.Value=0;
            cb_department.SelectedIndex=0;
        }
        #endregion
        #region Add
        int id;
        private void button3_Click(object sender, EventArgs e)
        {
            Instructor x = new Instructor()
            {
                InsName = txt_name.Text,
                InsDegree = txt_degree.Text,
                Salary = nud_salary.Value,
                DeptId = (int)cb_department.SelectedValue,
            };
            context.Instructors.Add(x);
            context.SaveChanges();
            dgv_instructors.DataSource = context.Instructors.Select(x => new { x.InsId, x.InsName, x.InsDegree, x.Salary, x.DeptId }).ToList();
            MessageBox.Show(" instructor added successfully");
            clear();
        }
        #endregion
        #region Update
        private void btn_update_Click(object sender, EventArgs e)
        {
            Instructor x = context.Instructors.Where(x => x.InsId == id).SingleOrDefault();
            x.InsName = txt_name.Text;
            x.InsDegree = txt_degree.Text;
            x.Salary = (int)nud_salary.Value;
            x.DeptId = (int)cb_department.SelectedValue;
            context.SaveChanges();
            dgv_instructors.DataSource = context.Instructors.Select(x => new { x.InsId, x.InsName, x.InsDegree, x.Salary, x.DeptId }).ToList();
            MessageBox.Show("instructor updated successfully ");
            clear();
        }
        #endregion
        #region MouseDoubleClk
        private void dgv_instructors_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = (int)dgv_instructors.SelectedRows[0].Cells[0].Value;
            Instructor x = context.Instructors.Where(x => x.InsId == id).SingleOrDefault();
            txt_name.Text = x.InsName;
            txt_degree.Text = x.InsDegree;
            nud_salary.Value = Convert.ToInt32(x.Salary);
            cb_department.SelectedValue = (int)x.DeptId;
            show(false);
        }
        #endregion
        #region Delete
        private void btn_delete_Click(object sender, EventArgs e)
        {
            Instructor x = context.Instructors.Where(x => x.InsId == id).SingleOrDefault();
            context.Instructors.Remove(x);
            context.SaveChanges();
            dgv_instructors.DataSource = context.Instructors.Select(x => new { x.InsId, x.InsName, x.InsDegree, x.Salary, x.DeptId }).ToList();
            MessageBox.Show("deletion is done successfylly");
            clear();
        }
        #endregion
    }
}
