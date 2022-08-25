// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void TestStageConstructor()
	    {
			Stage stage = new Stage();
			Assert.IsNotNull(stage);
		}
		[Test]
		public void TestPerformers()
		{
			Stage stage = new Stage();
			Assert.AreEqual(stage.Performers.Count,0);
		}
		[Test]
		public void TestValidate()
        {
			Type type = typeof(Stage);
			var method = type.GetMethods(BindingFlags.Instance| BindingFlags.NonPublic).FirstOrDefault(x => x.Name == "ValidateNullValue");
			var instance  = Activator.CreateInstance(type);
			object First = null;
			string name = "name";
			string error = "error";	
			Assert.Throws<TargetInvocationException>(() =>
			{
				method.Invoke(instance, new object[] {First,name,error});

			});

        }
		[Test]
		public void TestAddPerformerNull()
        {
			Performer performer = null;
			Stage stage = new Stage();
			Assert.Throws<ArgumentNullException>(() =>
			{
				stage.AddPerformer(performer);
			});
		}
		[Test]
		public void TestAddPerformerMinor()
		{
			Performer performer = new Performer("name", "secondName",10);
			Stage stage = new Stage();
			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddPerformer(performer);
			});
		}
		[Test]
		public void TestAddPerformer()
		{
			Performer performer = new Performer("name", "secondName", 19);
			Stage stage = new Stage();
			stage.AddPerformer(performer);
			CollectionAssert.AreEqual(stage.Performers,new List<Performer> { performer});
			Assert.AreEqual(stage.Performers.Count,1);
		}
		[Test]
		public void AddSongNull()
        {
			Song song = null;
			Stage stage = new Stage();
			Assert.Throws<ArgumentNullException>(() =>
			{
				stage.AddSong(song);
			});

		}
		[Test]
		public void AddSongLowMinutes()
		{
			Song song = new Song("name",new TimeSpan(0,0,10));
			Stage stage = new Stage();
			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSong(song);
			});

		}
		[Test]
		public void AddSong()
		{
			Song song = new Song("name", new TimeSpan(0, 1, 10));
			Stage stage = new Stage();
			stage.AddSong(song);
			Type type = typeof(Stage);
			var dataSong = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(x => x.Name == "Songs");
			List<Song> list = dataSong.GetValue(stage) as List<Song>;
			CollectionAssert.AreEqual(list, new List<Song> { song });


		}
		[Test]
		public void AddSongToPerformerNullSong()
        {
			string songName = null;
			string performerName = "name";
			Stage stage = new Stage();
			Assert.Throws<ArgumentNullException>(() =>
			{
				stage.AddSongToPerformer(songName, performerName);
			});

		}
		[Test]
		public void AddSongToPerformerNullPerformer()
		{
			string songName = "name";
			string performerName = null;
			Stage stage = new Stage();
			Assert.Throws<ArgumentNullException>(() =>
			{
				stage.AddSongToPerformer(songName, performerName);
			});

		}
		[Test]
		public void AddSongToPerformerWithNotExistingPerformer()
		{
			string songName = "name";
			string performerName = "name";
			Stage stage = new Stage();
			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSongToPerformer(songName, performerName);
			});

		}
		[Test]
		public void AddSongToPerformerWithNotExistingSong()
		{
			string songName = "name";
			string performerName = "name";
			Stage stage = new Stage();
			stage.AddPerformer(new Performer("name", "second", 20));
			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSongToPerformer(songName, performerName);
			});

		}
		[Test]
		public void AddSongToPerformer()
		{
			string songName = "Name";
			string performerName = "name second";
			Stage stage = new Stage();
			Performer performer = new Performer("name", "second", 20);
			Song song = new Song("Name", new TimeSpan(0, 1, 10));
			stage.AddPerformer(performer);
			stage.AddSong(song);
			string result = stage.AddSongToPerformer(songName, performerName);
			CollectionAssert.AreEqual(performer.SongList, new List<Song> {song });
			Assert.AreEqual(result, $"{song} will be performed by {performer}");

		}
		[Test]
		public void TestPlay()
		{
			string songName = "Name1";
			string song2Name = "name";
			string song3Name = "Name";
			string performerName = "name second";
			string performer2Name = "name second1";
			Stage stage = new Stage();
			Performer performer = new Performer("name", "second", 20);
			Performer performer2 = new Performer("name", "second1", 20);
			Song song = new Song("Name1", new TimeSpan(0, 1, 10));	
			Song song2 = new Song("name", new TimeSpan(0, 1, 10));
			Song song3 = new Song("Name", new TimeSpan(0, 1, 10));
			stage.AddPerformer(performer);
			stage.AddPerformer(performer2);
			stage.AddSong(song);
			stage.AddSong(song2);
			stage.AddSong(song3);
			stage.AddSongToPerformer(songName, performerName);
			stage.AddSongToPerformer(song2Name, performer2Name);
			stage.AddSongToPerformer(song3Name, performer2Name);
			stage.AddSongToPerformer(song3Name, performerName);
			string count = stage.Play();
			Assert.AreEqual( count, $"{2} performers played {4} songs");


		}

	}
}