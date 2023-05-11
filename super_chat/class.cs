using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMiddleware;
using DbMiddlewarePostgresImpl;
namespace super_chat
{
    public class UserModel
    {
        public IDatabase db;
        public string useraccount;
        public string password;
        public string mail;
        public bool flag;
        public int count;
        public bool if_Online;
        public DateTime lastTime;
        public UserModel(IDatabase db, string useraccount, string password, string mail, bool flag, int count, bool if_Online, DateTime lastTime)
        {
            this.db = db;
            this.useraccount = useraccount;
            this.password = password;
            this.mail = mail;
            this.flag = flag;
            this.count = count;
            this.if_Online = if_Online;
            this.lastTime = lastTime;
        }
    }
    public class UserOperation
    {
        public IDatabase db;
        public UserOperation(IDatabase db)
        {
            this.db = db;
        }
        public bool CreateUser(UserModel user)
        {
            var sql = "INSERT INTO public.user_account (user_act,user_pwd,mail,flag,cnt,if_online,last_time) " +
                "VALUES(:user_account,:user_pwd,:mail,:flag,:cnt,:if_online,:last_time)";
            var flag = db.Query(sql, 1, new[] {
                ("user_account",(object)user.useraccount),
                ("user_pwd", (object)user.password),
                ("mail",(object)user.mail),
                ("flag", (object)user.flag),
                ("cnt",(object)user.count),
                ("if_online", (object)user.if_Online),
                ("last_time",(object)user.lastTime)});
            if (flag == 1) {
                var usIm = new UserImModel(user.useraccount, "", "", DateTime.Now.Date, "", "", "", db);
                var end = CreateIm(usIm);
                if (end)
                {
                    return true;
                }
                else
                    return false;
            } 
            else return false;
        }
        public bool DeleteUser(string account)
        {
            var sql = "DELETE FROM public.user_account where user_act=:user_act";
            var flag = db.Query(sql, 1, new[] { ("user_act", (object)account) });
            if (flag == 1) return true;
            else return false;
        }
        public UserModel? GetUser(string act, string pwd)
        {
            var sql = "select * from public.user_account where user_act=:act and user_pwd=:pwd";
            var result = db.QueryForFirstRow(sql, new[] { ("act", (object)act), ("pwd", (object)pwd) });
            if (result == null)
                return null;
            else
            {
                var user = new UserModel(
                    db,
                    (string)result["user_act"],
                    (string)result["user_pwd"],
                    (string)result["mail"],
                    (bool)result["flag"],
                    (int)result["cnt"],
                    (bool)result["if_online"],
                    (DateTime)result["last_time"]);
                return user;
            }
        }
        public UserModel? GetUser(string act)
        {
            var sql = "select * from public.user_account where user_act=:act";
            var result = db.QueryForFirstRow(sql, new[] { ("act", (object)act) });
            if (result == null)
                return null;
            else
            {
                var user = new UserModel(
                    db,
                    (string)result["user_act"],
                    (string)result["user_pwd"],
                    (string)result["mail"],
                    (bool)result["flag"],
                    (int)result["cnt"],
                    (bool)result["if_online"],
                    (DateTime)result["last_time"]);
                return user;
            }
        }
        public bool UpdateAccount(string act, string pwd, string newact)
        {
            var sql = "UPDATE public.user_account SET user_act=:newact " +
                "WHERE user_act=:act AND user_pwd=:pwd";
            var flag = db.Query(sql, 1, new[] { ("newact", (object)newact), ("act", (object)act), ("pwd", (object)pwd) });
            if (flag == 1) return true;
            else return false;
        }
        public bool UpdatePwd(string act, string mail, string newpwd)
        {
            var sql = "UPDATE public.user_account SET user_pwd=:newpwd WHERE user_act=:act AND mail=:mail";
            var flag = db.Query(sql, 1, new[] { ("newpwd", (object)newpwd), ("act", (object)act), ("mail", (object)mail) });
            if (flag == 1) return true;
            else return false;
        }
        public bool UpdateMail(string act, string pwd, string newmail)
        {
            var sql = "UPDATE public.user_account SET mail=:newmail " +
                "WHERE user_act=:act AND user_pwd=:pwd";
            var flag = db.Query(sql, 1, new[] { ("newmail", (object)newmail), ("act", (object)act), ("pwd", (object)pwd) });
            if (flag == 1) return true;
            else return false;
        }
        public bool UpdateYes(string act)
        {
            var sql = "UPDATE public.user_account SET flag=:flag ,cnt=:count , if_online=:online ,last_time=:last_time WHERE user_act=:act";
            var flag = db.Query(sql, 1, new[] { ("flag", true), ("count", 0), ("online", true), ("last_time", (object)DateTime.Now), ("act", (object)act) });
            if (flag == 1) return true;
            else return false;
        }
        public int UpdateNo(string act)
        {
            var us = GetUser(act);
            if (us == null) return 0;
            else
            {
                if (us.flag == false)
                    return 1;
                if (us.flag == true && (us.count + 1) < 3)
                {
                    var sql = "UPDATE public.user_account SET cnt=:count WHERE user_act=:act";
                    var flag = db.Query(sql, 1, new[] { ("count", (us.count + 1)), ("act", (object)act) });
                    return 2;
                }
                if (us.count + 1 == 3)
                {
                    var sql = "UPDATE public.user_account SET flag=:flag ,cnt=:count ,last_time=:time WHERE user_act=:act";
                    var flag = db.Query(sql, 1, new[] { ("flag", false), ("count", 0), ("act", (object)act), ("time", (object)DateTime.Now) });
                    return 3;
                }
                return -1;
            }
        }
        public bool CreateIm(UserImModel us)
        {
            if (us!=null)
            {
                var sql = "INSERT INTO public.user_detail (u_act,user_nickname,sex,birthday,constellation,personalized_signature,avatar) " +
                "VALUES(:user_act,:nickname,:sex,:birthday,:constell,:signature,:avatar)";
                var flag = db.Query(sql, 1, new[] {
                ("user_act", (object)us.act),
                ("nickname",(object)us.Name),
                ("sex", (object)us.Sex),
                ("birthday",(object)us.Birthday),
                ("constell", (object)us.constellation),
                ("signature",(object)us.Signature),
                ("avatar",(object)us.Avatar)});
                if (flag != 0)
                    return true;
                else 
                    return false;
            } 
            else 
                return false;
        }
        public UserImModel? getIm(string act)
        {
            var sql = "select * from public.user_detail where u_act=:act";
            var result = db.QueryForFirstRow(sql, new[] { ("act", (object)act) });
            if (result == null)
                return null;
            else
            {
                string avatar = "";
                if (result["avatar"] != null)
                {
                    avatar = (string)result["avatar"];
                }
                var usim = new UserImModel(
                    (string)result["u_act"],
                    (string)result["user_nickname"],
                    (string)result["sex"],
                    (DateTime)result["birthday"],
                    (string)result["constellation"],
                    (string)result["personalized_signature"],
                    (string)avatar,
                    db) ;
                return usim;
            }
        }
        public UserImModel? getIm(string name ,int n)
        {
            var sql = "select * from public.user_detail where user_nickname=:name";
            var result = db.QueryForFirstRow(sql, new[] { ("name", (object)name) });
            if (result == null)
                return null;
            else
            {
                string avatar = "";
                if (result["avatar"] != null)
                {
                    avatar = (string)result["avatar"];
                }
                var usim = new UserImModel(
                    (string)result["u_act"],
                    (string)result["user_nickname"],
                    (string)result["sex"],
                    (DateTime)result["birthday"],
                    (string)result["constellation"],
                    (string)result["personalized_signature"],
                    (string)avatar,
                    db);
                return usim;
            }
        }
        public bool UpdateIm(UserImModel uIm)
        {
            var sql = "UPDATE public.user_detail SET user_nickname=:name,sex=:sex,birthday=:birth,constellation=:cons,personalized_signature=:sig,avatar=:at WHERE u_act=:act";
            var flag = db.Query(sql, 1, new[] { ("name", (object)uIm.Name), ("sex", (object)uIm.Sex), ("birth", (object)uIm.Birthday),("cons",(object)uIm.constellation),("sig",(uIm.Signature)),("act",(object)uIm.act),("at",(object)uIm.Avatar) });
            if (flag == 1) return true;
            else return false;
        }
    }
    public class User
    {
        public IDatabase db;
        public string Useraccount
        {
            get;
            set;
        }
        public string Password
        {
            get
            {
                string pwd = "";
                UserOperation op = new UserOperation(db);
                var us = op.GetUser(this.Useraccount);
                if (us != null)
                    pwd = us.password;
                return pwd;
            }
            set { }
        }
        public string Mail
        {
            get
            {
                string mail = "";
                UserOperation op = new UserOperation(db);
                var us = op.GetUser(this.Useraccount);
                if (us != null)
                    mail = us.mail;
                return mail;
            }
            set { }
        }
        public bool Flag
        {
            get
            {
                UserOperation op = new UserOperation(db);
                var us = op.GetUser(this.Useraccount);
                if (us != null)
                    return us.flag;
                else return false;
            }
            set { }
        }
        public int Count
        {
            get
            {
                UserOperation op = new UserOperation(db);
                var us = op.GetUser(this.Useraccount);
                if (us != null)
                    return us.count;
                else return -1;
            }
            set { }
        }
        public bool If_Online
        {
            get
            {
                UserOperation op = new UserOperation(db);
                var us = op.GetUser(this.Useraccount);
                if (us != null)
                    return us.if_Online;
                else return false;
            }
            set { }
        }
        public DateTime LastTime
        {
            get
            {
                UserOperation op = new UserOperation(db);
                var us = op.GetUser(this.Useraccount);
                if (us != null)
                    return (DateTime)us.lastTime;
                else return DateTime.Now;
            }
            set { }
        }
        public User(UserModel model)
        {
            this.db = model.db;
            this.Useraccount = model.useraccount;
            this.Useraccount = model.useraccount;
            this.Password = model.password;
            this.Mail = model.mail;
            this.Flag = model.flag;
            this.Count = model.count;
            this.LastTime = model.lastTime;
            this.If_Online = model.if_Online;
        }
    }
    public class UserImModel
    {
        public IDatabase db;
        public string act;
        public string Name;
        public string Sex;
        public DateTime Birthday;
        public string constellation;
        public string Signature;
        public string Avatar;
        public UserImModel(string act, string name, string sex, DateTime birthday, string constellation, string signature,string avatar, IDatabase db)
        {
            this.act = act;
            this.Name = name;
            this.Sex = sex;
            this.Birthday = birthday;
            this.constellation = constellation;
            this.Signature = signature;
            this.Avatar = avatar;
            this.db = db;
        }
    }
    public class UserIm
    {
        public IDatabase db;
        public string act {
            get; set;
        }
        public string Name {
            get
            {
                string n = "";
                UserOperation op = new UserOperation(db);
                var us = op.getIm(this.act);
                if (us != null)
                    n = (string)us.Name;
                return n;
            }
            set { } 
        }
        public string Sex {
            get
            {
                string sex = "";
                UserOperation op = new UserOperation(db);
                var us = op.getIm(this.act);
                if (us != null)
                    sex = (string)us.Sex;
                return sex;
            }
            set { }
        }
        public DateTime Birthday { 
            get
            {
                UserOperation op = new UserOperation(db);
                var us = op.getIm(this.act);
                if (us != null)
                    return us.Birthday;
                return DateTime.Now.Date;
            }
            set { }
        }
        public string constellation {
            get
            {
                string constellation = "";
                UserOperation op = new UserOperation(db);
                var us = op.getIm(this.act);
                if (us != null)
                    constellation = (string)us.constellation;
                return constellation;
            }
            set { }
        }
        public string Signature {
            get
            {
                string sig = "";
                UserOperation op = new UserOperation(db);
                var us = op.getIm(this.act);
                if (us != null)
                    sig = (string)us.Signature;
                return sig;
            }
            set { } 
        }
        public string avatar
        {
            get
            {
                string sig = "";
                UserOperation op = new UserOperation(db);
                var us = op.getIm(this.act);
                if (us != null && us.Avatar!=null)
                    sig = (string)us.Avatar;
                return sig;
            }
            set { }
        }
        public UserIm(UserImModel im)
        {
            this.act = im.act;
            this.Name = im.Name;
            this.Sex = im.Sex;
            this.Birthday = im.Birthday;
            this.constellation = im.constellation;
            this.Signature = im.Signature;
            this.avatar = im.Avatar;
            this.db =im.db; 
        }
    }
    public class RelateModel
    {
        public string useract;
        public string friendact;
        public IDatabase db;
        public RelateModel(string s1 ,string s2,IDatabase db)
        {
            this.useract = s1;
            this.friendact = s2;
            this.db = db;
        }
    }
    public class Roperation
    {
        public IDatabase db;
        public Roperation(IDatabase db)
        {
            this.db = db;
        }
        public bool CreateRelate (RelateModel model)
        {
            var sql = "INSERT INTO public.chat (user_account,friend_account) " +
                "VALUES(:useraccount,:friendaccount)";
            var flag = db.Query(sql, 1, new[] {
                ("useraccount", (object)model.useract),
                ("friendaccount",(object)model.friendact) });
            if (flag==1)
                return true;
            else return false;
        }
        public bool DeleteRelate (RelateModel model)
        {
            var sql = "DELETE FROM public.chat where (user_account=:useract,friendaccount=:friendact) or (user_account=:friendact,friendaccount=:useract)";
            var flag = db.Query(sql, 1, new[] { ("useract", (object)model.useract),("friendact",(object)model.friendact) });
            if (flag == 1) return true;
            else return false;
        }
        public List<RelateModel> GetRelate(string act)
        {
            var ret1 = new List<RelateModel>();
            var ret2 = new List<RelateModel>();
            var sql = "select * from public.chat";
            var result = db.QueryForTable(sql, null);
            foreach (var row in result)
            {
                var model = new RelateModel(
                    (string)row["user_account"],
                    (string)row["friend_account"],
                    db);
                ret1.Add(model);
            }
            foreach(var row in ret1)
            {
                if (row.friendact == act || row.useract == act)
                {
                    ret2.Add(row);
                }
            }
            return ret2;
        }
    }
    public class chatgroupM
    {
        public string name  = "";
        public string user1 = "";
        public string user2 = "";
        public chatgroupM(string name, string user1, string user2)
        {
            this.name = name;
            this.user1 = user1;
            this.user2 = user2;
        }
    }
    public class chatoperation
    {
        public IDatabase db;
        public chatoperation (IDatabase database)
        {
            db = database;
        }
        public bool create(string name,List<string> user)
        {
            for (int i = 0; i < user.Count; i++)
                for (int j=i+1; j < user.Count; j++)
                {
                    var sql = "INSERT INTO public.group (group_name,user_id,friend_id) " +
                       "VALUES(:name,:useraccount,:friendaccount)";
                    var flag = db.Query(sql, 1, new[] {
                        ("name",(object)name),
                        ("useraccount", (object)user[i]),
                        ("friendaccount",(object)user[j]) });
                }
            return true;
        }
        public bool delete(string name ,User model)
        {
            var sql = "DELETE FROM public.group where (user_id=:useract or friend_id=:useract,group_name=:name)";
            var flag = db.Query(sql, 1, new[] { 
                ("useract", (object)model.Useraccount),
                ("name", (object)name) });
            if (flag == 1) 
                return true;
            else 
                return false;
        }
        public List<string> select(string userid)
        {
            var sql = "select * from public.group";
            var result = db.QueryForTable(sql, null);
            List<chatgroupM> ret = new List<chatgroupM>();
            foreach (var row in result)
            {
                var model = new chatgroupM(
                    (string)row["group_name"],
                    (string)row["user_id"],
                    (string)row["friend_id"]);
                ret.Add(model);
            }
            List<string> list = new List<string>();
            foreach (var item in ret)
            {
                list.Add(item.name);
            }
            List<string> distinctList = list.Distinct().ToList();
            return distinctList;
        }
    }
}