using tg_server.models;
using MongoDB.Driver;

namespace tg_server.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMongoCollection<comment> _comments;

        public CommentService(ItgCommentsDatabaseSettings Settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("tg-data");
            _comments = database.GetCollection<comment>("comments");
        }
        public comment Create(comment comment)
        {
            _comments.InsertOne(comment);
            return comment;
        }

        public void Delete(string id)
        {
            _comments.DeleteOne(comment => comment.Id == id);
        }

        public List<comment> Get()
        {
            return _comments.Find(comment => true).ToList();
        }

        public comment Get(string id)
        {
            return _comments.Find(comment => comment.RefId == id).FirstOrDefault();
        }
    }
}
