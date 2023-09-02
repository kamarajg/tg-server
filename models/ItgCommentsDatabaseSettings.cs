namespace tg_server.models
{
    public interface ItgCommentsDatabaseSettings
    {
       string CommentsCollectionName { get; set; }
       string ConnectionString { get; set; }
       string DatabaseName { get; set; }

    }
}
