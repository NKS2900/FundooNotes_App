// ----------------------------------------------------------------------------------------------------
// <copyright file="NoteManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooManager
{
    using FundooModel.Models;
    using FundooRepositiory.IRepositorys;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;

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

        /// <summary>
        /// Add note 
        /// </summary>
        /// <param name="model">NoteModel</param>
        /// <returns>returns true or false</returns>
        public bool AddNotes(NoteModel model)
        {
            try
            {
                bool result = repository.AddNote(model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retriving all notes
        /// </summary>
        /// <returns>returns NoteModel</returns>
        public IEnumerable<NoteModel> RetriveAllNotes()
        {
            try
            {
                var result = repository.RetriveAllNotes();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retriving Note By ID
        /// </summary>
        /// <param name="noteId">Note id</param>
        /// <returns>returns Note Model</returns>
        public NoteModel RetrieveNotes(int noteId)
        {
            try
            {
                var result = repository.RetrieveNotesById(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removing Notes
        /// </summary>
        /// <param name="noteId">Note ID</param>
        /// <returns>returns true or false</returns>
        public bool RemoveNotes(int noteId)
        {
            try
            {
                bool result = repository.RemoveNote(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updating Notes
        /// </summary>
        /// <param name="model">Note model</param>
        /// <returns>returns true or false</returns>
        public bool UpdateNotes(NoteModel model)
        {
            try
            {
                bool result = repository.UpdateNotes(model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// PinOrUnpin Note
        /// </summary>
        /// <param name="noteId">Note ID</param>
        /// <returns>returns Pin or Unpin</returns>
        public string PinOrUnpin(int noteId)
        {
            try
            {
                var result = repository.PinOrUnpin(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// checking archive
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns>returns string ARCHIVE</returns>
        public string IsArchive(int noteId)
        {
            try
            {
                var result = repository.IsArchive(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retriving archived notes.
        /// </summary>
        /// <returns>returns NoteModel</returns>
        public IEnumerable<NoteModel> RetriveArchiveNotes()
        {
            try
            {
                var result = repository.RetriveArchiveNotes();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retriving Trashed Notes.
        /// </summary>
        /// <returns>returns NoteModel</returns>
        public IEnumerable<NoteModel> RetriveTrashedNotes()
        {
            try
            {
                var result = repository.RetriveTrashedNotes();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Restoring Trashed Notes
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public string RestoreTrashed(int noteId)
        {
            try
            {
                var result = repository.RestoreTrash(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deleting notes forever
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public bool DeletNoteForever(int noteId)
        {
            try
            {
                bool result = repository.DeletNoteForever(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deleting all notes from Trash.
        /// </summary>
        /// <returns></returns>
        public bool EmptyTrash()
        {
            try
            {
                bool result = repository.EmptyTrash();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Changing Colot of notes.
        /// </summary>
        /// <param name="id">NOTE id</param>
        /// <param name="color">COLOR</param>
        /// <returns></returns>
        public bool ChangeColor(int id, string color)
        {
            try
            {
                bool result = repository.ChangeColor(id, color);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Set reminder for note
        /// </summary>
        /// <param name="noteId">Note id</param>
        /// <param name="dateTime">Date and Time</param>
        /// <returns>return True or False</returns>
        public bool SetReminder(int noteId, string dateTime)
        {
            try
            {
                bool result = repository.SetReminder(noteId, dateTime);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get all reminder notes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NoteModel> GetAllReminderNotes()
        {
            try
            {
                var result = repository.GetAllReminderNotes();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Unset Reminder
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns>returns true or false</returns>
        public bool UnsetReminder(int noteId)
        {
            try
            {
                bool result = repository.UnsetReminder(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Uploding image for note using cloudinary.
        /// </summary>
        /// <param name="noteId">Note ID</param>
        /// <param name="noteimage">image</param>
        /// <returns>returns true or false</returns>
        public bool UploadImage(int noteId, IFormFile noteimage)
        {
            try
            {
                bool result = repository.UploadImage(noteId, noteimage);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
