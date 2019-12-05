// Inicializo el Cliente SMTP
ConexionSMTP = new SmtpClient(HostSMTP.Text, Convert.ToInt32(PuertoSMTP.Text));
ConexionSMTP.Credentials = new NetworkCredential(UsuarioSMTP.Text, Password.Text, "");
//Creo el correo electronico
MailMessage Mensaje = new MailMessage();
try
{
Mensaje.To.Add(new MailAddress(DireccionEnvio.Text));
Mensaje.From = new MailAddress(UsuarioSMTP.Text);
Mensaje.Subject = AsuntoME.Text;
Mensaje.Body = CuerpoME.Text;
Mensaje.Body += "\r\n\r\nServidor de Correo ----->" + HostSMTP.Text + "\r\n\r\nServidor Assets ----->" + ListaServidores.Text + "\r\n\r\nBase de Datos----->" + ListaBD.Text + "\r\n\r\nFecha Actual ----->" + DateTime.Now.ToString();
// Borro todos los ficheros de la carpeta resultados OJO TENGO QUE PENSAR BUSCAR UNA CARPETA PUBLICA PARA ESTO
Attachment Adjunto = new Attachment(DirectorioResultado + Path.GetFileName(FichBCKUP) + ".zip");
Mensaje.Attachments.Add(Adjunto);
ConexionSMTP.Send(Mensaje);
Adjunto.Dispose();
Mensaje.Attachments.RemoveAt(0);
}
