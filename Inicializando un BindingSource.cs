        private void partePorMaquinaBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            DataView FilaParte = partePorMaquinaBindingSource.List as DataView;
            DataRowView MiNuevaFila = FilaParte.AddNew();

            MiNuevaFila["Maquina_IDMaquina"] = (mComplementarioProduccionDataSet.Maquinas_Produccion
                .Select(x => x.IDMaquina).FirstOrDefault()).ToEntero();
            MiNuevaFila["Fecha"] = DateTime.Now;
            MiNuevaFila["Surtido_FichaTecnica"] = mComplementarioProduccionDataSet.Surtidos.Select(x => x.FichaTecnica)
                .FirstOrDefault().ToEntero();
            MiNuevaFila["Operario_IDOperario"] = mComplementarioProduccionDataSet.Operarios.Select(x => x.IDOperario)
                .FirstOrDefault().ToEntero();
            e.NewObject = MiNuevaFila;
            partePorMaquinaBindingSource.MoveLast();
        }