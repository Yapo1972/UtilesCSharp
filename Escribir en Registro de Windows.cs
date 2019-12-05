            if (MessageBox.Show("Va a escribir en el Registro de Windows, Confirma?", "ADVERTENCIA",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Microsoft.Win32.RegistryKey rk1 = Microsoft.Win32.Registry.CurrentUser;
                Microsoft.Win32.RegistryKey ClaveVigilante =
                    rk1.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                if (ClaveVigilante == null) return;
                try
                {
                    if (InicioWindows.Checked)
                    {
                        ClaveVigilante.SetValue("VigilCorreo",
                            Application.StartupPath + @"\" + AppDomain.CurrentDomain.FriendlyName);
                        ClaveVigilante.Flush();
                    }
                    else if (ClaveVigilante.GetValue("VigilCorreo") != null)
                        ClaveVigilante.DeleteValue("VigilCorreo");
                }
                catch
                {
                    MessageBox.Show(
                        "Ocurrio un error en el acceso al Registro de Windows, verifique los permisos de la aplicacion",
                        "ERROR", MessageBoxButtons.OK);
                }
            }
