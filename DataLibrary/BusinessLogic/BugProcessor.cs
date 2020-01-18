using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class BugProcessor
    {
        public static int CreateBug(string title, string source, string description, int priority, string deadline1, string deadline2,
            string deadlinefinal, string errormsg, string assignteam, string patchdetails, bool isresolved, string status )
        {
            string varbool = null;
            if (isresolved == true)
            {
                varbool = "true";
            }
            else
            {
                varbool = "false";
            }

            BugModel data = new BugModel
            {
                Title = title,
                Source=source,
                Description=description,
                Priority=priority,
                Deadline1=deadline1,
                Deadline2=deadline2,
                DeadLineFinal=deadlinefinal,
                ErrorMsg=errormsg,
                AssignTeam=assignteam,
                PatchDetails=patchdetails,
                IsResolved=varbool,
                Status=status
            };

            string sql = @"insert into dbo.BugRecords (Title, Source, Description, Priority, DeadLine1, DeadLine2, DeadLineFinal, ErrorMsg,
                            AssignTeam, PatchDetails, IsResolved, Status)
                           values (@Title, @Source, @Description, @Priority, @DeadLine1, @DeadLine2, @DeadLineFinal, @ErrorMsg,
                            @AssignTeam, @PatchDetails, @IsResolved, @Status)";
            return BugSqlDataAccess.SaveData(sql, data);
        }
        public static List<BugModel> LoadBugs()
        {
            string sql = @"select * from
                            dbo.BugRecords";
            return BugSqlDataAccess.LoadData<BugModel>(sql);
        }



        public static List<BugModel> UpdateBug(int id, string title, string source, string description, int priority, string deadline1, string deadline2,
            string deadlinefinal, string errormsg, string assignteam, string patchdetails, string isresolved, string status)
        {
            

            BugModel data = new BugModel
            {   ID=id,
                Title = title,
                Source = source,
                Description = description,
                Priority = priority,
                Deadline1 = deadline1,
                Deadline2 = deadline2,
                DeadLineFinal = deadlinefinal,
                ErrorMsg = errormsg,
                AssignTeam = assignteam,
                PatchDetails = patchdetails,
                IsResolved = "false",
                Status = status
            };


            return BugSqlDataAccess.LoadData2(data);
        }

        public static List<BugModel> RemoveBug(int id)
        {

            return BugSqlDataAccess.DataRemove(id);
        }
        public static int UpdateBug2(BugModel model)
        {
            string sql = "UPDATE BugRecords set Title = @Title, BugRecords.Source = @Source, Description = @Description, Priority = @Priority, DeadLine1 = @DeadLine1, " +
                "DeadLine2 = @DeadLine2, DeadLineFinal = @DeadLineFinal, ErrorMsg = @ErrorMsg,AssignTeam = @AssignTeam, PatchDetails = @PatchDetails," +
                "IsResolved = @IsResolved, Status = @Status where Id = @ID";
            return BugSqlDataAccess.SaveData(sql, model);
        }

        public static int RemoveById(int id)
        {
            string sql = "delete from dbo.BugRecords where Id= " + id;
            return BugSqlDataAccess.SqlRemove(sql);
        }

        public static List<BugModel> GetUpdates()
        {
            string sql = "select Priority,Title, Source, ErrorMsg from dbo.BugRecords group by Priority, Title, Source, ErrorMsg order by Priority desc";
            return BugSqlDataAccess.SqlFetch(sql);

        }
    }
    
}
