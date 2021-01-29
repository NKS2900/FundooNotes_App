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

        public IEnumerable<NoteModel> RetrieveNotes()
        {
            var result = repository.RetrieveNotes();
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
    }
}
