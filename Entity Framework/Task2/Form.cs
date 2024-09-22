using ENTITYFRAMEWORK.MODELS;
namespace ENTITYFRAMEWORK
{
    public partial class Form1 : Form
    {
        Testcontext context;
        public Form1()
        {
            InitializeComponent();
            context = new Testcontext();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            News news = new News();
            dgv_news.DataSource = context.News.Select(x => new { x.id, x.title, x.bref, x.desc, x.time, x.date, x.author_id, x.cat_id }).ToList();
            dgv_news.Visible = false;
            Author x = new Author()
            {
                name = txt_author.Text,
                age = (int)nud_age.Value,
                username = txt_username.Text,
                password = txt_password.Text,
                joindate = txt_joindate.Text,
            };
            dgv_author.DataSource = context.Author.Select(x => new { x.id, x.name, x.age, x.username, x.password, x.joindate }).ToList();
            authpage();
        }
        #region clear
        public void clear()
        {
            txt_author.Text = txt_joindate.Text = txt_password.Text = txt_username.Text = string.Empty;
            nud_age.Value = 0;
        }
        #endregion
        #region add
        private void btn_add_Click(object sender, EventArgs e)
        {
            Author x = new Author()
            {
                name = txt_author.Text,
                age = (int)nud_age.Value,
                username = txt_username.Text,
                password = txt_password.Text,
                joindate = txt_joindate.Text,
            };
            context.Author.Add(x);
            context.SaveChanges();
            dgv_author.DataSource = context.Author.Select(x => new { x.id, x.name, x.age, x.username, x.password, x.joindate }).ToList();
            clear();
        }
        #endregion
        int id;
        #region doubleclk
        private void dgv_author_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dgv_author.SelectedRows[0].Cells[0].Value);
            Author x = context.Author.Where(x => x.id == id).SingleOrDefault();
            txt_author.Text = x.name;
            txt_username.Text = x.username;
            nud_age.Value = (Int32)x.age;
            txt_password.Text = x.password;
            txt_joindate.Text = x.joindate;
        }
        #endregion
        #region edit
        private void btn_edit_Click(object sender, EventArgs e)
        {
            Author x = context.Author.Where(x => x.id == id).SingleOrDefault();
            x.joindate = txt_joindate.Text;
            x.age = (int)nud_age.Value;
            x.username = txt_username.Text;
            x.password = txt_password.Text;
            x.name = txt_author.Text;
            context.SaveChanges();
            dgv_author.DataSource = context.Author.Select(x => new { x.id, x.name, x.age, x.username, x.password, x.joindate }).ToList();
            clear();
        }
        #endregion
        #region delete
        private void btn_delete_Click(object sender, EventArgs e)
        {
            Author x = context.Author.Where(x => x.id == id).SingleOrDefault();
            context.Author.Remove(x);
            context.SaveChanges();
            dgv_author.DataSource = context.Author.Select(x => new { x.id, x.name, x.age, x.username, x.password, x.joindate }).ToList();
            clear();
        }
        #endregion
        #region login
        private void btn_login_Click(object sender, EventArgs e)
        {
            newspage();
            cb_cat.DataSource = context.Catalog.ToList();
            cb_cat.DisplayMember = "name";
            cb_cat.ValueMember = "id";
            cb_cat.SelectedIndex = -1;
            context.SaveChanges();
        }
        #endregion
        #region addnew
        private void btn_addnews_Click(object sender, EventArgs e)
        {
            News l = new News()
            {
                title = txt_author.Text,
                bref = txt_joindate.Text,
                desc = txt_password.Text,
                cat_id = (int)nud_age.Value,
                author_id = Convert.ToInt32(txt_username.Text),
                time = DateTime.Now,
                date = DateTime.Now.AddDays(1).AddHours(1).AddMinutes(1).AddSeconds(1),
            };
            context.News.Add(l);
            context.SaveChanges();
            dgv_news.DataSource = context.News.Select(x => new { x.id, x.title, x.bref, x.desc, x.time, x.date, x.author_id, x.cat_id }).ToList();
            dgv_news.Visible = true;
        }
        #endregion
        #region doubleclk 
        private void dgv_news_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dgv_news.SelectedRows[0].Cells[0].Value);
            News x = context.News.Where(x => x.id == id).SingleOrDefault();
            txt_author.Text = x.title;
            txt_username.Text = Convert.ToString(x.author_id);
            nud_age.Value = (Int32)x.cat_id;
            txt_password.Text = x.desc;
            txt_joindate.Text = x.bref;
        }
        #endregion
        #region delete news
        private void btn_deletenews_Click(object sender, EventArgs e)
        {
            News x = context.News.Where(x => x.id == id).SingleOrDefault();
            context.News.Remove(x);
            context.SaveChanges();
            dgv_news.DataSource = context.News.Select(x => new { x.id, x.title, x.bref, x.desc, x.time, x.date, x.author_id, x.cat_id }).ToList();
            clear();
            context.SaveChanges();
        }
        #endregion
        #region editnews
        private void btn_editnews_Click(object sender, EventArgs e)
        {
            News x = context.News.Where(x => x.id == id).SingleOrDefault();
            x.bref = txt_joindate.Text;
            x.cat_id = (int)nud_age.Value;
            x.author_id = Convert.ToInt32(txt_username.Text);
            x.desc = txt_password.Text;
            x.title = txt_author.Text;
            context.SaveChanges();
            dgv_news.DataSource = context.News.Select(x => new { x.id, x.title, x.bref, x.desc, x.time, x.date, x.author_id, x.cat_id }).ToList();
            clear();
        }
        #endregion
        private void btn_register_Click(object sender, EventArgs e)
        {
            authorpage();
        }
        public void authpage()
        {
            btn_signout.Visible = false;
            lbl_author.Text = "Author";
            lbl_join.Text = "JoinDate";
            lbl_password.Text = "Password";
            lbl_username.Text = "User Name";
            lbl_age.Text = "Age";
            btn_login.Visible = true;
            btn_register.Visible = true;
            btn_add.Visible = false;
            btn_delete.Visible = false;
            btn_edit.Visible = false;
            btn_deletenews.Visible = false;
            btn_addnews.Visible = false;
            btn_editnews.Visible = false;
            dgv_author.Visible = false;
            dgv_news.Visible = false;
            cb_cat.Visible = false;
            nud_age.Visible = true;
        }
        public void newspage()
        {
            btn_signout.Visible = true;
            lbl_author.Text = "Title";
            lbl_join.Text = "brief";
            lbl_password.Text = "Description";
            lbl_username.Text = "Author Id";
            lbl_age.Text = "Catalog";
            btn_login.Visible = false;
            btn_register.Visible = false;
            btn_deletenews.Visible = true;
            btn_addnews.Visible = true;
            btn_editnews.Visible = true;
            btn_add.Visible = false;
            btn_delete.Visible = false;
            btn_edit.Visible = false;
            dgv_author.Visible = false;
            dgv_news.Visible = true;
            cb_cat.Visible = true;
            nud_age.Visible = false;
        }
        public void authorpage()
        {
            btn_signout.Visible = true;
            btn_login.Visible = false;
            btn_register.Visible = false;
            btn_deletenews.Visible = false;
            btn_addnews.Visible = false;
            btn_editnews.Visible = false;
            btn_add.Visible = true;
            btn_delete.Visible = true;
            btn_edit.Visible = true;
            dgv_author.Visible = true;
            dgv_news.Visible = false;
        }
        private void btn_signout_Click(object sender, EventArgs e)
        {
            authpage();
        }
    }
}
