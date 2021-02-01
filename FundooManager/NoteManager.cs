using FundooModel.Models;
using FundooRepositiory.Interface;
using System;
using System.Collections.Generic;
using System.Text;

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
            var result = repository.AddNote(model);
            return result;
        }

        public NoteModel RetrieveNotes(int noteId)
        {
            var result = repository.RetrieveNotesById(noteId);
            return result;
        }

        public bool RemoveNotes(int noteId)
        {
            var result = repository.RemoveNote(noteId);
            return result;
        }

        public bool UpdateNotes(NoteModel model)
        {
            var result = repository.UpdateNotes(model);
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
    }
}
