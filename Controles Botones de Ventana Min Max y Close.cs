        private bool Salvar = false;
        const int WM_SYSCOMMAND = 0x112;
        const int SC_MINIMIZE = 0xF020;
        const int SC_MAXIMIZE = 0xF030;
        const int SC_CLOSE = 0xF060;

        // El siguiente procedimiento se hace con el objetivo de interceptar las peticiones de
        // Minimizar, Maximizar o Cerrar la aplicacion, a traves de los tres botones del Form
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
                switch (m.WParam.ToInt32())
                {
                    case SC_MINIMIZE:
                        this.Hide();
                        //MessageBox.Show("Hacer lo que quieras en vez de minimizar");
                        break;
                    case SC_MAXIMIZE:
                        //MessageBox.Show("Hacer lo que quieras en vez de maximizar");
                        break;
                    case SC_CLOSE:
                        this.Hide();
                        //base.WndProc(ref m);
                        break;
                    default:
                        base.WndProc(ref m);
                        break;
                }
            else
                base.WndProc(ref m);
        }
