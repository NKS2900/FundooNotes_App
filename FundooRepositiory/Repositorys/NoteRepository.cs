// ----------------------------------------------------------------------------------------------------
// <copyright file="NoteRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooRepositiory.Repositorys
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using FundooModel.Models;
    using FundooRepositiory.IRepositorys;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class NoteRepository : INoteRepository
    {
        private readonly FundooContext fundooContext;

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor to Initializing FundooContext and IConfiguration
        /// </summary>
        /// <param name="fundooContext">FundooContext instance</param>
        /// <param name="configuration">Configuration instance</param>
        public NoteRepository(FundooContext fundooContext, IConfiguration configuration)
        {
            this.fundooContext = fundooContext;
            Configuration = configuration;
        }

        /// <summary>
        /// Add New Notes
        /// </summary>
        /// <param name="noteModel">NoteModel</param>
        /// <returns>returns true or false</returns>
        public bool AddNote(NoteModel noteModel)
        {
            try
            {
                fundooContext.NoteTable.Add(noteModel);
                var note = fundooContext.SaveChanges();
                if (note > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retriving All Notes
        /// </summary>
        /// <returns>returns NoteModel</returns>
        public IEnumerable<NoteModel> RetriveAllNotes()
        {
            try
            {
                IEnumerable<NoteModel> result = fundooContext.NoteTable.Where(x => x.Trash == false && x.Archive == false).ToList();
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
        /// <param name="id">note ID</param>
        /// <returns>returns noteModel</returns>
        public NoteModel RetrieveNotesById(int noteId)
        {
            try
            {
                NoteModel notes = this.fundooContext.NoteTable.Where(x => x.NoteId == noteId).SingleOrDefault();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removing note to Trash
        /// </summary>
        /// <param name="noteId">Note ID</param>
        /// <returns>returns true or false</returns>
        public bool RemoveNote(int noteId)
        {
            try
            {
                var note = fundooContext.NoteTable.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (note != null)
                {
                    note.Trash = true;
                    fundooContext.Entry(note).State = EntityState.Modified;
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updating Notes
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateNotes(NoteModel model)
        {
            try
            {
                var note = fundooContext.NoteTable.Where(x => x.NoteId == model.NoteId).SingleOrDefault();
                if (note != null)
                {
                    fundooContext.Entry(model).State = EntityState.Modified;
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Pin or Unpin Notes
        /// </summary>
        /// <param name="id">User iD</param>
        /// <returns>return True or false</returns>
        public string PinOrUnpin(int id)
        {
            try
            {
                var note = fundooContext.NoteTable.Where(x => x.NoteId == id).SingleOrDefault();
                if (note.Pin == false)
                {
                    note.Pin = true;
                    fundooContext.Entry(note).State = EntityState.Modified;
                    fundooContext.SaveChanges();
                    string pin= "PIN";
                    return pin;
                }
                else
                {
                    note.Pin = false;
                    fundooContext.Entry(note).State = EntityState.Modified;
                    fundooContext.SaveChanges();
                    string unpin = "UNPIN";
                    return unpin;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method ro delet all notes from Trash.
        /// </summary>
        /// <returns>returns true or false</returns>
        public string IsArchive(int id)
        {
            try
            {
                var note = fundooContext.NoteTable.Where(x => x.NoteId == id).SingleOrDefault();
                if (note.Archive == false)
                {
                    note.Archive = true;
                    fundooContext.Entry(note).State = EntityState.Modified;
                    fundooContext.SaveChanges();
                    string acrch = "ARCHIVE";
                    return acrch;
                }
                else
                {
                    note.Archive = false;
                    fundooContext.Entry(note).State = EntityState.Modified;
                    fundooContext.SaveChanges();
                    string unacrch = "UNARCHIVE";
                    return unacrch;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retriving All Archived Notes
        /// </summary>
        /// <returns>returns all archived notes</returns>
        public IEnumerable<NoteModel> RetriveArchiveNotes()
        {
            try
            {
                IEnumerable<NoteModel> result = fundooContext.NoteTable.Where(x => x.Archive == true).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retriving Trashed Notes
        /// </summary>
        /// <returns>returns Trashed Notes</returns>
        public IEnumerable<NoteModel> RetriveTrashedNotes()
        {
            try
            {
                IEnumerable<NoteModel> result = fundooContext.NoteTable.Where(x => x.Trash == true).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Restoring Note from trash.
        /// </summary>
        /// <param name="noteId">note ID</param>
        /// <returns>return true or false</returns>
        public string RestoreTrash(int noteId)
        {
            try
            {
                var note = fundooContext.NoteTable.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (note.Trash == true)
                {
                    note.Trash = false;
                    fundooContext.Entry(note).State = EntityState.Modified;
                    fundooContext.SaveChanges();
                    string trashed = "RESTORE";
                    return trashed;
                }
                return "FAILED";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deleting Trashed not forever.
        /// </summary>
        /// <returns>returns true or false</returns>
        public bool DeletNoteForever(int noteId)
        {
            try
            {
                var note = fundooContext.NoteTable.Where(x => x.NoteId == noteId && x.Trash == true).SingleOrDefault();
                if (note != null)
                {
                    fundooContext.NoteTable.Remove(note);
                    fundooContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false; 
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method ro delet all notes from Trash.
        /// </summary>
        /// <returns>returns true or false</returns>
        public bool EmptyTrash()
        {
            try
            {
                IEnumerable<NoteModel> result = fundooContext.NoteTable.Where(x => x.Trash == true).ToList();
                if (result != null)
                {
                    foreach (var trash in result)
                    {
                        fundooContext.NoteTable.Remove(trash);
                        fundooContext.SaveChangesAsync();
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updating Color in DB
        /// </summary>
        /// <param name="id">Note ID</param>
        /// <param name="color">Color</param>
        /// <returns></returns>
        public bool ChangeColor(int id, string color)
        {
            try
            {
                var note = fundooContext.NoteTable.Find(id);
                if (note != null)
                {
                    note.Colour = color;
                    fundooContext.Entry(note).State = EntityState.Modified;
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Set reminder
        /// </summary>
        /// <param name="noteId">Note ID</param>
        /// <param name="dateTime">Date and Time</param>
        /// <returns></returns>
        public bool SetReminder(int noteId, string dateTime)
        {
            try
            {
                if (noteId > 0)
                {
                    var note = fundooContext.NoteTable.Where(x => x.NoteId == noteId).FirstOrDefault();
                    note.Reminder = dateTime;
                    fundooContext.Entry(note).State = EntityState.Modified;
                    fundooContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get all Reminder Notes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NoteModel> GetAllReminderNotes()
        {
            try
            {
                IEnumerable<NoteModel> notes = fundooContext.NoteTable.Where(x => x.Reminder != null);
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Reminder Unset 
        /// </summary>
        /// <param name="noteId">Note ID</param>
        /// <returns></returns>
        public bool UnsetReminder(int noteId)
        {
            try
            {
                var note = fundooContext.NoteTable.Where(x => x.NoteId == noteId ).SingleOrDefault();
                if (note != null)
                {
                    note.Reminder = null;
                    fundooContext.Entry(note).State = EntityState.Modified;
                    fundooContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Uploading Imange on Cloud and adding URL in DB
        /// </summary>
        /// <param name="noteId">note ID</param>
        /// <param name="noteimage">image</param>
        /// <returns></returns>
        [Obsolete]
        public bool UploadImage(int noteId, IFormFile noteimage)
        {
            try
            {
                var notes = fundooContext.NoteTable.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (notes != null)
                {
                    Account account = new Account
                    (
                        Configuration["CloudinaryAccount:CloudName"],
                        Configuration["CloudinaryAccount:ApiKey"],
                        Configuration["CloudinaryAccount:ApiSecret"]
                    );
                    
                    var path = noteimage.OpenReadStream();
                    Cloudinary cloudinary = new Cloudinary(account);
                    ImageUploadParams uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(noteimage.FileName, path)
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    notes.Image = uploadResult.Uri.AbsolutePath;
                    fundooContext.Entry(notes).State = EntityState.Modified;
                    fundooContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
