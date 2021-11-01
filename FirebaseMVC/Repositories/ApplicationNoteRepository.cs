using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using GoodCompanyMVC.Models;
using GoodCompanyMVC.Utils;


namespace GoodCompanyMVC.Repositories
{
    public class ApplicationNoteRepository : BaseRepository, IApplicationNoteRepository
    {
        public ApplicationNoteRepository(IConfiguration config) : base(config) { }

        public List<ApplicationNote> GetApplicationNotes()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Name FROM ApplicationNote";

                    var reader = cmd.ExecuteReader();

                    List<ApplicationNote> applicationNotes = new List<ApplicationNote>();

                    while (reader.Read())
                    {
                        ApplicationNote applicationNote = new ApplicationNote()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Note = DbUtils.GetString(reader, "Name")
                        };
                        applicationNotes.Add(applicationNote);
                    }

                    reader.Close();

                    return applicationNotes;
                }

            }
        }

        public List<ApplicationNote> GetAllApplicationNotesByCurrentUser(int UserProfileId)
        {
            throw new NotImplementedException();
        }

        public void AddApplicationNote(ApplicationNote applicationNote)
        {
            throw new NotImplementedException();
        }

        public void UpdateApplicationNote(ApplicationNote applicationNote)
        {
            throw new NotImplementedException();
        }

        public ApplicationNote GetApplicationNotesById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationNote> DeleteApplicationNote(int id)
        {
            throw new NotImplementedException();
        }
    }
}
