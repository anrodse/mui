using System;
using System.Threading.Tasks;
using System.Windows;

namespace FirstFloor.ModernUI.App
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		/// <summary>
		/// Raises the <see cref="E:System.Windows.Application.Startup"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.StartupEventArgs"/> that contains the event data.</param>
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			SetupExceptionHandling();
		}

		private void Application_Exit(object sender, ExitEventArgs e)
		{
		}

		private void SetupExceptionHandling()
		{
			AppDomain.CurrentDomain.UnhandledException += (s, e) =>
				LogUnhandledException((Exception)e.ExceptionObject, "AppDomain.CurrentDomain.UnhandledException");

			DispatcherUnhandledException += (s, e) =>
			{
				LogUnhandledException(e.Exception, "Application.Current.DispatcherUnhandledException");
				e.Handled = true;
			};

			TaskScheduler.UnobservedTaskException += (s, e) =>
			{
				LogUnhandledException(e.Exception, "TaskScheduler.UnobservedTaskException");
				e.SetObserved();
			};
		}

		private void LogUnhandledException(Exception exception, string source)
		{
			string message = $"Unhandled exception ({source})";
			try
			{
				System.Reflection.AssemblyName assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
				message = string.Format("Unhandled exception in {0} v{1}", assemblyName.Name, assemblyName.Version);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Exception in LogUnhandledException");
			}
			finally
			{
				// Inner exceptions read
				string ex_msg = String.Empty;
				for (Exception i = exception; i != null; i = i.InnerException)
					ex_msg += $"{i.GetType()} : {i.Message}\r\n\r\n";

				MessageBox.Show(ex_msg, "Exception: " + message);
				Application.Current.Shutdown();
			}
		}

	}
}
