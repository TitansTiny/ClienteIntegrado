using System;
using System.Web.UI;

namespace VistaCliente
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Verificar credenciales
            if (username == "admin" && password == "password123")
            {
                // Establecer sesión de autenticación
                Session["Authenticated"] = true;
                // Redirigir a la página principal si las credenciales son correctas
                Response.Redirect("Form1.aspx");
            }
            else
            {
                // Mostrar mensaje de error si las credenciales son incorrectas
                lblError.Text = "Invalid username or password.";
                lblError.Visible = true;
            }
        }
    }
}