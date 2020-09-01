using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using Bajaj.Dinesh.Biller.Properties;

namespace Bajaj.Dinesh.Biller
{
    internal sealed partial class FirmDetails : Form
    {
        public FirmDetails()
        {
            InitializeComponent();
        }

        private void FirmDetails_Load(object sender, EventArgs e)
        {
            this.Icon = this.MdiParent.Icon;

            this.StartPosition = FormStartPosition.CenterScreen;

            if (!loadData())
            {
                this.Close();
                return;
            }
        }

        private bool loadData()
        {
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            if (errorText != null)
            {
                Global.DisplayConnectionErrorMessage();
                return false;
            }

            return loadData(connection);
        }

        private bool loadData(SqlCeConnection connection)
        {
            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = "FIRMDETAILS";
                    command.CommandType = CommandType.TableDirect;

                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) //  no record exists
                        {
                            return true;
                        }

                        populateControlsWithData(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "An error occurred in fetching data from the database." +
                    "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                MessageBox.Show(message, "Error in Fetching Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }

        private void populateControlsWithData(SqlCeDataReader reader)
        {
            nameField.Text = (string)reader["FirmName"];

            object obj = reader["Address"];
            if (obj != DBNull.Value)
            {
                addressField.Text = (string)obj;
            }

            obj = reader["PhoneNumbers"];
            if (obj != DBNull.Value)
            {
                phoneNumbersField.Text = (string)obj;
            }
        }

        private void nameField_Validating(object sender, CancelEventArgs e)
        {
            string str = nameField.Text.Trim();
            if (string.IsNullOrWhiteSpace(str))
            {
                errorProvider.SetError(nameField, "Firm name not provided");
                e.Cancel = true;
            }
        }

        private void nameField_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(nameField, null);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!ValidateChildren())
            {
                Cursor.Current = Cursors.Default;
                SystemSounds.Exclamation.Play();
                return;
            }

            if (!SaveData())
            {
                return;
            }

            Cursor.Current = Cursors.Default;
            this.Close();
        }

        private bool SaveData()
        {
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            if (errorText != null)
            {
                Global.DisplayConnectionErrorMessage();
                return false;
            }

            return SaveData(connection);
        }

        private bool SaveData(SqlCeConnection connection)
        {
            try
            {
                using (SqlCeCommand command = GetSaveCommand(connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                SystemSounds.Exclamation.Play();
                string message = "An error occurred in saving the data. " +
                    "\nThe error text is as follows:\n" +
                    Global.getExceptionText(ex);
                MessageBox.Show(message, "Error in Saving Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }

        private SqlCeCommand GetSaveCommand(SqlCeConnection connection)
        {
            bool recordExists = RecordExists(connection);
            string sql;

            if (recordExists)
            {
                sql = "UPDATE FirmDetails SET FirmName = @FirmName, " +
                    "Address = @Address, PhoneNumbers = @PhoneNumbers";
            }
            else
            {
                sql = "INSERT INTO FIRMDETAILS VALUES(@FirmName, @Address, @PhoneNumbers)";
            }

            SqlCeCommand command = connection.CreateCommand();

            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            SqlCeParameterCollection parameters = command.Parameters;

            SqlCeParameter parameter = new SqlCeParameter("@FirmName", SqlDbType.NVarChar);
            parameter.Value = nameField.Text.Trim();
            parameters.Add(parameter);

            parameter = new SqlCeParameter("@Address", SqlDbType.NVarChar);

            if (string.IsNullOrWhiteSpace(addressField.Text))
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = addressField.Text.Trim();
            }
            parameters.Add(parameter);

            parameter = new SqlCeParameter("@PhoneNumbers", SqlDbType.NVarChar);

            if (string.IsNullOrWhiteSpace(phoneNumbersField.Text))
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = phoneNumbersField.Text.Trim();
            }
            parameters.Add(parameter);

            return command;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool RecordExists(SqlCeConnection connection)
        {
            using (SqlCeCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM FIRMDETAILS";
                command.CommandType = CommandType.Text;

                int count = (int)command.ExecuteScalar();

                return count == 1 ? true : false;
            }
        }
    }
}