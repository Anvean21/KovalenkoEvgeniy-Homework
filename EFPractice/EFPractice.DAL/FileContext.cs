using EFPractice.Core.Entities;
using EFPractice.Core.Entities.Files;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.DAL
{
    public class FileContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Directory> Directories { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<DirectoryPermission> DirectoryPermissions { get; set; }
        public DbSet<FilePermission> FilePermissions { get; set; }
        public DbSet<AudioFile> AudioFiles { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<TextFile> TextFiles { get; set; }
        public DbSet<VideoFile> VideoFiles { get; set; }


        public FileContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public FileContext(DbContextOptions<FileContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FileContext).Assembly);

            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { Id=1, UserName="user1", Email="user1@email.com", PasswordHash = "fdgsdfgr"},
                    new User { Id=2, UserName="user2", Email="user2@gmail.com", PasswordHash = "sfdasdf"},
                    new User { Id=3, UserName="user3", Email="user3@gmail.com", PasswordHash = ";fasdfase"}
                });

            modelBuilder.Entity<Directory>().HasData(
                new Directory[]
                {
                    new Directory { Id=1, ParentDirectoryId = null, Title=@"D:"},
                    new Directory { Id=2, ParentDirectoryId = 1, Title=@"\Anvean"},
                    new Directory { Id=3, ParentDirectoryId = 2, Title=@"\Nix"},
                });

            modelBuilder.Entity<AudioFile>().HasData(
                new AudioFile[]
                {
                    new AudioFile { Id = 1, BitRate = 5, ChannelCount = 2,Type = "AudioFile", DirectoryId = 2, Duration = new TimeSpan(1,2,3), Extention="mp4" ,SampleRate = 55, Size = 5 , Title="audiofile1"},
                    new AudioFile { Id = 2, BitRate = 5, ChannelCount = 2, DirectoryId = 2, Duration = new TimeSpan(1,2,3), Extention="mp4" ,SampleRate = 55, Size = 5 ,Type = "AudioFile", Title="audiofile2"},
                    new AudioFile { Id = 3, BitRate = 5, ChannelCount = 2, Type = "AudioFile", DirectoryId = 3, Duration = new TimeSpan(1,2,3), Extention="mp4" ,SampleRate = 55, Size = 5 , Title="audiofile3"},
                    new AudioFile { Id = 4, BitRate = 5, ChannelCount = 2, Type = "AudioFile", DirectoryId = 2, Duration = new TimeSpan(1,2,3), Extention="mp4" ,SampleRate = 55, Size = 5 , Title="audiofile4"},
                });
            modelBuilder.Entity<ImageFile>().HasData(
                new ImageFile[]
                {
                    new ImageFile { Id = 5, DirectoryId = 3, Extention = "png",Type = "ImageFile", Size = 12, Height = 1080, Weight = 1920, Title = "imagefile1" },
                    new ImageFile { Id = 6, DirectoryId = 3, Extention = "png",Type = "ImageFile", Size = 12, Height = 1080, Weight = 1920, Title = "imagefile2" },
                    new ImageFile { Id = 7, DirectoryId = 3, Extention = "png",Type = "ImageFile", Size = 12, Height = 1080, Weight = 1920, Title = "imagefile3" },
                    new ImageFile { Id = 8, DirectoryId = 1, Extention = "png",Type = "ImageFile", Size = 12, Height = 1080, Weight = 1920, Title = "imagefile4" }
                });
            modelBuilder.Entity<VideoFile>().HasData(
                new VideoFile[]
                {
                    new VideoFile { Id = 9, DirectoryId = 3, Extention = "avi",Type = "VideoFile", Size = 256, Height = 1080, Weight = 1920, Duration = new TimeSpan(1,1,1), Title = "videofile1"},
                    new VideoFile { Id = 10, DirectoryId = 3, Extention = "avi",Type = "VideoFile", Size = 256, Height = 1080, Weight = 1920, Duration = new TimeSpan(1,1,1), Title = "videofile2"},
                    new VideoFile { Id = 11, DirectoryId = 2, Extention = "avi",Type = "VideoFile", Size = 256, Height = 1080, Weight = 1920, Duration = new TimeSpan(1,1,1), Title = "videofile3"},
                    new VideoFile { Id = 12, DirectoryId = 3, Extention = "avi",Type = "VideoFile", Size = 256, Height = 1080, Weight = 1920, Duration = new TimeSpan(1,1,1), Title = "videofile4S"}
                });
            modelBuilder.Entity<TextFile>().HasData(
                new TextFile[]
                {
                    new TextFile { Id = 13, DirectoryId = 1, Extention = "txt",Type = "TextFile", Size = 0.12, Content = "So,e contextdfasfsdf", Title = "textfile1"},
                    new TextFile { Id = 14, DirectoryId = 3, Extention = "txt",Type = "TextFile", Size = 0.12, Content = "So,e contextdfasfsdf", Title = "textfile2"},
                    new TextFile { Id = 15, DirectoryId = 2, Extention = "txt",Type = "TextFile", Size = 0.12, Content = "So,e contextdfasfsdf", Title = "textfile3"},
                    new TextFile { Id = 16, DirectoryId = 2, Extention = "txt",Type = "TextFile", Size = 0.12, Content = "So,e contextdfasfsdf", Title = "textfile4"}
                });

            modelBuilder.Entity<FilePermission>().HasData(
                new FilePermission[]
                {
                    new FilePermission {FileId = 1, UserId = 1, CanRead = false, CanWrite = true },
                    new FilePermission {FileId = 2, UserId = 2, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 3, UserId = 3, CanRead = false, CanWrite = true },
                    new FilePermission {FileId = 4, UserId = 1, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 5, UserId = 2, CanRead = false, CanWrite = true },
                    new FilePermission {FileId = 6, UserId = 3, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 7, UserId = 1, CanRead = false, CanWrite = true },
                    new FilePermission {FileId = 8, UserId = 2, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 9, UserId = 3, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 10, UserId = 1, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 11, UserId = 2, CanRead = false, CanWrite = true },
                    new FilePermission {FileId = 12, UserId = 3, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 13, UserId = 1, CanRead = false, CanWrite = true },
                    new FilePermission {FileId = 14, UserId = 2, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 15, UserId = 2, CanRead = false, CanWrite = false },
                    new FilePermission {FileId = 16, UserId = 3, CanRead = true, CanWrite = false },
                });

            modelBuilder.Entity<DirectoryPermission>().HasData(
                new DirectoryPermission[]
                {
                    new DirectoryPermission {DirectoryId = 1, UserId = 1, CanRead = true, CanWrite = true },
                    new DirectoryPermission {DirectoryId = 2, UserId = 3, CanRead = true, CanWrite = true },
                    new DirectoryPermission {DirectoryId = 3, UserId = 3, CanRead = false, CanWrite = true }
                });
        }
    }
}
