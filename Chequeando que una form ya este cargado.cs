        private bool CheckForm(string formName)
        {
            foreach (Form f in Application.OpenForms)
                if (f.Name == formName)
                    return true;

            return false;
        }