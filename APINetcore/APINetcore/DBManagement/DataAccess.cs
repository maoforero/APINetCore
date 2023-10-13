namespace APINetcore.DBManagement
{
    public class DataAccess
    {
        private string _sqlConnectionString;

        public string SQLConnectionString { get => _sqlConnectionString; }

        public DataAccess(string sqlConnectionString)
        {
            this._sqlConnectionString = sqlConnectionString;
        }

    }
}
