// Compactando un fichero
// Hay que agregar la referencia a Ionic.ZIP
Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile(DirectorioResultado + Path.GetFileName(FichBCKUP)+".zip" );
zip.AddFile(FicheroACompactar, "");
zip.Save();
zip.Dispose();

// Descompactando Fichero

try
{
    using (ZipFile zip = ZipFile.Read(filePath))
    {
        foreach (ZipEntry e1 in zip)
        if (e1.FileName.ToUpper().Contains("REMOTO"))
            {
                File.Delete( Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\" + e1.FileName);
                e1.Extract(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
                if (!File.Exists(CadDirectorioEnvio.Text + @"\" + e1.FileName) ||(File.GetCreationTime(Environment.SpecialFolder.LocalApplicationData + @"\" +e1.FileName) >File.GetCreationTime(CadDirectorioEnvio.Text + @"\" + e1.FileName)))
                {
                    File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\" + e1.FileName,CadDirectorioEnvio.Text + @"\" + e1.FileName);
                }
             }
        zip.Dispose();
    }
}
catch
{
}
