using (Pop3Client client = new Pop3Client())
try
{
// Conectandose al servidor
client.Connect(TBServidorPOP3.Text, Convert.ToInt32(TBPuerto.Text), CHKSSL.Checked);

// Authenticate ourselves towards the server
client.Authenticate(TBDCorreo.Text, TBContrasena.Text);
int messageCount = client.GetMessageCount();
List<Message> Messages = new List<OpenPop.Mime.Message>(messageCount);

    for (int i = 0; i < messageCount; i++)
{
    Message getMessage = client.GetMessage(i + 1);
    Messages.Add(getMessage);
}
DateTime FechaUltimaActualizacion = new DateTime();
FechaUltimaActualizacion = Settings1.Default.FechaUltAct;
foreach (Message msg in Messages)
{
    if (msg.Headers.DateSent > FechaUltimaActualizacion)
        foreach (MessagePart attachment in msg.FindAllAttachments())
        {
            string filePath =
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    attachment.FileName);
            if (!attachment.FileName.Contains("Remoto")) continue;

            FileStream Stream = new FileStream(filePath, FileMode.Create);
            BinaryWriter BinaryStream = new BinaryWriter(Stream);
            BinaryStream.Write(attachment.Body);
            BinaryStream.Close();
            try
            {
                using (ZipFile zip = ZipFile.Read(filePath))
                {
                    foreach (ZipEntry e1 in zip)
                        if (e1.FileName.ToUpper().Contains("REMOTO"))
                        {
                            File.Delete(
                                Environment.GetFolderPath(Environment.SpecialFolder
                                    .LocalApplicationData) + @"\" + e1.FileName);
                            e1.Extract(Environment.GetFolderPath(Environment.SpecialFolder
                                .LocalApplicationData));
                            if (!File.Exists(CadDirectorioEnvio.Text + @"\" + e1.FileName) ||
                                (File.GetCreationTime(
                                     Environment.SpecialFolder.LocalApplicationData + @"\" +
                                     e1.FileName) >
                                 File.GetCreationTime(CadDirectorioEnvio.Text + @"\" + e1.FileName))
                            )
                            {
                                File.Copy(
                                    Environment.GetFolderPath(Environment.SpecialFolder
                                        .LocalApplicationData) + @"\" + e1.FileName,
                                    CadDirectorioEnvio.Text + @"\" + e1.FileName);
                            }
                        }
                    zip.Dispose();
                }
            }
            catch
            {
            }
        }
}
}
catch (Exception ex)
{
Console.WriteLine("", ex.Message);
}

finally
{
if (client.Connected)
client.Dispose();
}
