using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMiddleware;

namespace super_chat
{
    internal class message
    {
        public int type;//1为私聊，0为群聊
        public DateTime dateTime;
        public String Avatar;//头像
        public String Uid; //自己的id
        public String Id; //发送对象的id
        public String Content; //内容
        public bool Aalid; //是否被读
        public string category; //1为文字 ，2为图片 
        public IDatabase db;
        public message(int type, DateTime dateTime,string avatar, string uid, string id, string content, bool valid, IDatabase db, string category)
        {
            this.type = type;
            this.dateTime = dateTime;
            this.Uid = uid;
            this.Id = id;
            this.Content = content;
            this.Aalid = valid;
            this.Avatar = avatar;
            this.db = db;
            this.category = category;
        }
        public message (IDatabase db) 
        {
            this.db = db;
        }
        public void SendMessage(List<message> ts)
        {
            var s = this;
            ts.Add(s);
            new DbMessage(db).InsertM(s);
        }
        public bool SaveM(message m)
        {
            var sql = "UPDATE public.user_history SET aalid=:alid WHERE datetime=:datetime AND uid=:act AND id=:id AND content=:content AND category=:category";
            var flag = db.Query(sql, 1, new[] { ("alid", (object)m.Aalid), ("datetime", (object)m.dateTime), ("act", (object)m.Uid), ("id", (object)m.Id) , ("content", (object)m.Content) , ("category", (object)m.category) });
            if (flag == 1) return true;
            else return false;
        }
        public List<message> ReceiveMessage(List<message> ts ,string user)
        {
            List<message> msgs = new List<message>();
            if (ts.Count > 0)
            {
                for (int i = 0; i < ts.Count; i++)
                {
                    if (ts[i].type == 1)//私聊消息
                    {
                        if (ts[i].Id == user && ts[i].Aalid == false)
                        {
                            ts[i].Aalid = true;
                            var r = ts[i];
                            msgs.Add(ts[i]);
                            SaveM(r);
                        }
                    }
                    else if (ts[i].type == 0) //接受群聊消息
                    {  
                        var op = new chatoperation(db);
                        var r = op.select(user);
                        foreach (var l in r)
                        { 
                            if (ts[i].Id == l)
                            { 
                                ts[i].Aalid = true;
                                msgs.Add(ts[i]);        
                                SaveM(ts[i]);
                            } 
                        }
                    }
                }
            }
            return msgs;
        }
        public List<message>? LoadM(string user ,string friend,int type)
        {
            var result = new List<message>();
            var r = new DbMessage(db).SelectM();
            if (r != null ) 
            {
                foreach (var i in r)
                {
                    if ((i.Id == user && i.Uid==friend)||(i.Id==friend&&i.Uid==user))//私聊
                    {
                        if (i.type==1)
                        {
                            result.Add(i);
                        }
                    }
                    if (i.Id == friend&&i.type==0) //群聊
                    {
                        result.Add(i);
                    }
                }
            }
            return result;
        }
    }
    internal class DbMessage
    {
        IDatabase db;
        public DbMessage(IDatabase db)
        {
            this.db = db;
        }
        public bool InsertM(message m)
        {
                var sql = "INSERT INTO public.user_history (datetime,avatar,uid,id,content,aalid,category,type) " +
                "VALUES(:datetime,:avatar,:uid,:id,:content,:aalid,:category,:type)";
                var flag = db.Query(sql, 1, new[] {
                    ("datetime",(object)m.dateTime),
                    ("avatar",(object)m.Avatar),
                    ("uid",(object)m.Uid),
                    ("id",(object)m.Id),
                    ("content",(object)m.Content),
                    ("aalid",(object)m.Aalid),
                    ("category",(object)m.category),
                    ("type",(object)m.type)
                });
                if (flag == 1)
                {
                    return true;
                }
            
            return false;
        }
        public List<message>? SelectM (){
            List<message> l = new List<message>();
            var sql = "select * from public.user_history";
            var result = db.QueryForTable(sql, null);
            if (result != null)
            {
                foreach (var row in result)
                {
                    var model = new message(
                        (int)row["type"],
                        (DateTime)row["datetime"],
                        (string)row["avatar"],
                        (string)row["uid"],
                        (string)row["id"],
                        (string)row["content"],
                        (bool)row["aalid"],
                        db,
                        (string)row["category"]
                        );
                    if ((DateTime.Now.Date-model.dateTime.Date).Days<=1)
                    {
                        l.Add(model);
                    } 
                }
            }
            return l;
        }
    }

    internal class Bubble
    {
        public static List<message> L = new List<message>();
    }
}
