            if (FicheroFT.ShowDialog() == DialogResult.OK)
            {
                FileStream FlujoFichero = File.OpenRead(FicheroFT.FileName);
                byte[] ArregloBytes = new byte[(int) FlujoFichero.Length];
                FlujoFichero.Read(ArregloBytes, 0, Convert.ToInt32(FlujoFichero.Length));
                GVOfertas.SetRowCellValue(GVOfertas.FocusedRowHandle, "Ficha Tecnica", ArregloBytes);
            }
