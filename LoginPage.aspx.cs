﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormProject2
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignInButton_Click(object sender, EventArgs e)
        {
            string usernametext = username.Value; 
            string passwordtext = password.Value;

            if (usernametext == "admin" && passwordtext == "admin")
            {
                Response.RedirectToRoute("WebForm.aspx");
            }
            else
            {
                Label1.Text = "Invalid username or password.";
            }
        }
    }
}