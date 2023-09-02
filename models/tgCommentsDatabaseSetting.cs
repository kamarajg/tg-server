namespace tg_server.models
{
    public class tgCommentsDatabaseSetting : ItgCommentsDatabaseSettings
    {
        public string CommentsCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
