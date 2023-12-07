using SQLite;
using Nutricion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutricion
{
    public class Repository
    {
        private readonly string _path;
        
        public string StatusMessage { get; set; }

        private SQLiteConnection conn;

        private void Init()
        {
            if (conn is not null)
            {
                return;
            }
            else
            {
                conn = new(_path);
            }
            conn.CreateTable<Note>();
            conn.CreateTable<User>();
        }
        
        public Repository(string path) {
            _path = path;
        }

        public void addRegisterNote(Note note)
        {
            try
            {
                Init();
                if(note == null)
                {
                    throw new Exception("Error al guardar");
                }
                else
                {
                    Note noteSaved = new Note();
                    noteSaved = note;
                    noteSaved.lastModified = DateTime.Now;
                    conn.Insert(noteSaved);
                    StatusMessage = "Saved";
                }
            }
            catch
            {
                StatusMessage = "Not saved";
            }
        }
        public void deleteNote(Note note)
        {
            try
            {
                Init();
                if (note == null)
                {
                    throw new Exception("Error");
                }
                else
                {
                    int ID_note = note.ID;
                    var toDelete = conn.Table<Note>().FirstOrDefault(x => x.ID == ID_note);
                    if (toDelete != null)
                    {
                        conn.Delete(toDelete);

                    }
                        
                }
            }
            catch
            {
                StatusMessage = "Not saved";
            }
        }
        public List<Note> getAllNotes() 
        {
            try
            {
                Init();
                return conn.Table<Note>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = "Error " + ex.Message;
            }
                
            return new List<Note>();
        }
    }
}
