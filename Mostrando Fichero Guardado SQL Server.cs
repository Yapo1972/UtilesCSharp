           FileStream FlujoFichero = File.Create(@"e:temporal.pdf");
           DataTable TablaOfertas = new DataTable();
           TablaOfertas =
                ofertas_Solicitudes_ComprasTableAdapter.GetData();
            string IDOferta = GVOfertas.GetRowCellValue(GVOfertas.FocusedRowHandle, "IDOferta").ToString();
            DataRow Fila = TablaOfertas.Rows.Find(IDOferta);

            int Longitud = (Fila["Ficha Tecnica"] as byte[]).Length;
            byte[] ArregloBytes = new byte[Longitud];
            ArregloBytes = Fila["Ficha Tecnica"] as byte[];
            FlujoFichero.Write(ArregloBytes, 0, Longitud);
            FlujoFichero.Close();
            VisorPDF FVisor = new VisorPDF(@"e:temporal.pdf");
            FVisor.MdiParent = this.MdiParent;
