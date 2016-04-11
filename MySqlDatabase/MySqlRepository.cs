using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using System.Data.Entity;

namespace MySqlDatabase
{
    public class MySqlRepository
    {

        // Test Methods
        public IEnumerable<User> GetUsers()
        {
            using(var db = new SovaContext())
            {
                return db.Users.Take(8).ToList();
            }

            
        }

        public IEnumerable<Post> GetPosts()
        {
            using (var db = new SovaContext())
            {
                return db.Posts.Include("User").Include("Comment").Take(8).ToList();
                
               // return db.Posts.Take(8).ToList();
            }
        }

        public IEnumerable<Comment> GetComments()
        {
            using (var db = new SovaContext())
            {
                return db.Comments.Include("User").Take(8).ToList();
            }
        }


        //Search Methods

        public List<Post> SearchInTitle(string statement)
        {
            using (var db = new SovaContext())
            {
                return db.Posts.Where(p => p.Title.Contains(statement)).ToList();

            }
        }

        public List<Post> SearchBody(string statement)
        {
            using (var db = new SovaContext())
            {
                return db.Posts.Where(p => p.Body.Contains(statement)).ToList();

            }
        }
        


        // Comment Methods

        public List<Comment> GetCommentOfAPost(int postid)
        {
            using (var db = new SovaContext())
            {
                return db.Comments.Where(u => u.PostId == postid).ToList();
                
            }
        }




        // Mark Methods
        public void Mark(int postid, string note )
        {
            using (var db = new SovaContext())
            {
                db.Marks.Add(new Mark(0,postid, note));
                db.SaveChanges();
            }
        }

        public void Unmark(int id)
        {
            using (var db = new SovaContext())
            {
                db.Marks.RemoveRange(db.Marks.Where(x => x.Id == id));
                db.SaveChanges();
            }
        }

        public void DeleteAllMarks()
        {
            using (var db = new SovaContext())
            {

                db.Database.ExecuteSqlCommand("TRUNCATE TABLE Mark");
                db.SaveChanges();
            }
        }

        public List<Post> GetMarkedPosts()
        {
            using (var db = new SovaContext())
            {
                List<Post> markedPosts = new List<Post>();
                List<int> postIds = new List<int>();
                postIds = db.Marks.Select(u => u.PostId).ToList();

                foreach(int id in postIds)
                {
                    markedPosts.Add(db.Posts.Where(p => p.Id == id).First());
                }

                return markedPosts;
            }

        }





        // History Methods
        public void AddToHistory(int id, string statement)
        {
            using(var db = new SovaContext())
            {
                db.Histories.Add(new History(id, statement, DateTime.Now));
                db.SaveChanges();
            }
        }

        public void DeleteFromHistory(int id)
        {
            using(var db = new SovaContext())
            {
                db.Histories.RemoveRange(db.Histories.Where(x => x.Id == id));
                db.SaveChanges();
            }
        }

        public void DeleteAllHistory()
        {
            using (var db = new SovaContext())
            {

                db.Database.ExecuteSqlCommand("TRUNCATE TABLE History");
                db.SaveChanges();
            }
        }

        public List<History> GetAllHistory()
        {
            using (var db = new SovaContext())
            {
                List<History> history = new List<History>();
                var _history = db.Set<History>();
                foreach (var historyEntity in _history)
                {
                    history.Add(historyEntity);
                }

                return history;
            }

        }




    }
}
