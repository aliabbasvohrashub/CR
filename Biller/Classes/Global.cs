using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Bajaj.Dinesh.Biller.Properties;

namespace Bajaj.Dinesh.Biller
{
    internal static class Global
    {
        public static readonly string DATABASE_FILE_EXTENSION = "bcz";
        public static readonly string DATABASE_NAME_PREFIX;

        public static readonly string ROOT_DATA_FOLDER;
        public static MDIForm MDIForm;

        public static SqlCeConnection connection = null;

        private static FinancialYear currentFinancialYear;

        static Global()
        {
            DATABASE_NAME_PREFIX = AssemblyTitle + "-FY-";
            ROOT_DATA_FOLDER = AssemblyTitle + "-Data";
        }

        public static FinancialYear CurrentFinancialYear
        {
            get
            {
                return currentFinancialYear;
            }

            set
            {
                currentFinancialYear = value;
                bool enableState = (value == null ? false : true);
                ToolStripItemCollection items = MDIForm.toolStrip1.Items;

                string name;
                foreach (ToolStripItem toolStripItem in items)
                {
                    name = toolStripItem.Name.ToLower();
                    if (!(name.Contains("Calculator") || name.Contains("configuration")))
                    {
                        toolStripItem.Enabled = enableState;
                    }
                }
            }
        }

        public static string getExceptionText(Exception ex)
        {
            if (ex == null)
            {
                return string.Empty;
            }

            if (ex.GetType() == typeof(SqlCeException))
            {
                return getSQLCEExceptionText((SqlCeException)ex);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(string.IsNullOrWhiteSpace(ex.Message) ? "" : ex.Message);

            string str;
            while ((ex = ex.InnerException) != null)
            {
                str = ex.Message;
                if (!string.IsNullOrWhiteSpace(str))
                {
                    sb.Append("\n" + str);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="errorText">Exception message received while creating a new connection. If no error is encountered, then null is assigned to the parameter</param>
        /// <param name="newConnection">Whether the existing or a new database connection is to be returned</param>
        /// <returns>Returns the database connection.</returns>
        public static SqlCeConnection getDatabaseConnection(out string errorText,
            bool newConnection = false)
        {
            if (!newConnection && connection != null && connection.State ==
                System.Data.ConnectionState.Open)
            {
                errorText = null;
                return connection;
            }

            SqlCeConnection connect = CreateDatabaseConnection(CurrentFinancialYear.FilePath,
                out errorText);

            if (connection == null || connection.State != System.Data.ConnectionState.Open)
            {
                connection = connect;
            }

            return connect;
        }

        public static SqlCeConnection CreateDatabaseConnection(string databasePath, out string errorText)
        {
            SqlCeConnection conn = null;
            string connectionString = "Data Source=" + databasePath + "; Password=" +
                Settings.Default.PASSWORD;

            try
            {
                conn = new SqlCeConnection(connectionString);
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    errorText = null;
                    return conn;
                }

                throw new Exception("Connection to the database couldn't be made due to some unknown reason.");
            }
            catch (Exception ex)
            {
                errorText = getExceptionText(ex);
                return null;
            }
        }

        public static void CloseDatabaseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }

            connection = null;
        }

        private static string getSQLCEExceptionText(SqlCeException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("Argument can't be null");
            }

            StringBuilder sb = new StringBuilder();
            foreach (SqlCeError error in exception.Errors)
            {
                sb.AppendLine(error.Message);
            }

            return sb.ToString();
        }

        internal static void DisplayConnectionErrorMessage()
        {
            SystemSounds.Exclamation.Play();

            string errorMessage = "An error occurred in connecting to the database.\n" +
                "Please ensure that the database is located at " +
                CurrentFinancialYear.FilePath +
                ", and that you have read & write permission to this file.";
            Cursor.Current = Cursors.Default;
            MessageBox.Show(errorMessage, "Error Occurred", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }
    }
}