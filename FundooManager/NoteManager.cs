using FundooModel.Models;
using FundooRepositiory.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using FundooManager;

namespace FundooManager
{
    public class NoteManager : INoteManager
    {
        private readonly INoteRepository repository;

        /// <summary>
        /// UserManager Constructor initializing IRepository
        /// </summary>
        /// <param name="repository">initializing IRepository</param>
        public NoteManager(INoteRepository repository)
        {
            this.repository = repository;
        }

        public bool AddNotes(NoteModel model)
        {
            bool result = repository.AddNote(model);
            return result;
        }

        public IEnumerable<NoteModel> RetriveAllNotes()
        {
            var result = repository.RetriveAllNotes();
            return result;
        }

        public NoteModel RetrieveNotes(int noteId)
        {
            var result = repository.RetrieveNotesById(noteId);
            return result;
        }

        public bool RemoveNotes(int noteId)
        {
            bool result = repository.RemoveNote(noteId);
            return result;
        }

        public bool UpdateNotes(NoteModel model)
        {
            bool result = repository.UpdateNotes(model);
            return result;
        }

        public string CheckPin(int noteId)
        {
            var result = repository.CheckPin(noteId);
            return result;
        }

        public string CheckArchive(int noteId)
        {
            var result = repository.CheckArchive(noteId);
            return result;
        }

        public IEnumerable<NoteModel> RetriveArchiveNotes()
        {
            var result = repository.RetriveArchiveNotes();
            return result;
        }

        public IEnumerable<NoteModel> RetriveTrashedNotes()
        {
            var result = repository.RetriveTrashedNotes();
            return result;
        }

        public string RestoreTrashed(int noteId)
        {
            var result = repository.RestoreTrash(noteId);
            return result;
        }

        public bool DeletNoteForever(int noteId)
        {
            bool result = repository.DeletNoteForever(noteId);
            return result;
        }

        public bool EmptyTrash()
        {
            bool result = repository.EmptyTrash();
            return result;
        }

        public bool ChangeColor(int id, string color)
        {
            bool result = repository.ChangeColor(id, color);
            return result;
        }

        public bool SetReminder(int noteId, string dateTime)
        {
            bool result = repository.SetReminder(noteId, dateTime);
            return result;
        }
    }
}
