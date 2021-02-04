using FundooModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepositiory.Interface
{
    public interface INoteRepository
    {
        public bool AddNote(NoteModel model);

        public NoteModel RetrieveNotesById(int id);

        public IEnumerable<NoteModel> RetriveAllNotes();

        public bool RemoveNote(int Id);

        public bool UpdateNotes(NoteModel model);

        public string CheckPin(int uid);

        public string CheckArchive(int uid);

        public IEnumerable<NoteModel> RetriveArchiveNotes();

        public IEnumerable<NoteModel> RetriveTrashedNotes();

        public string RestoreTrash(int noteId);

        public bool DeletNoteForever(int noteId);

        public bool EmptyTrash();

        public bool ChangeColor(int id, string color);

        public bool SetReminder(int noteId, string dateTime);

        public IEnumerable<NoteModel> GetAllReminderNotes();

        public bool UnsetReminder(int noteId);

    }
}
