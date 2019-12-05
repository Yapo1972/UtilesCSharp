// Esto se coloca en la entrada del programa justo debajo del main de Program.cs

System.Diagnostics.Process[] procesos = System.Diagnostics.Process.GetProcesses();
bool DosInstancias = true;
// recorrer los procesos existentes
foreach (System.Diagnostics.Process proceso in procesos)
{
// verificar si existe el que buscamos
if (proceso.ProcessName.ToUpper().Contains("VIGILEMAIL"))
{
if (!DosInstancias)
{
MessageBox.Show("Ya esta corriendo una instancia del programa");
return;
}
DosInstancias = false;
}
} // end foreach
