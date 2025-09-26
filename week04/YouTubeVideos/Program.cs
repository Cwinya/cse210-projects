using System;
using System.Collections.Generic;

class Program
{
    // Write a program to keep track of YouTube videos and comments left on them. As mentioned this could be part of a larger project to analyze them, but for this assignment, you will only need to worry about storing the information about a video and the comments.

    // Your program should have a class for a Video that has the responsibility to track the title, author, and length (in seconds) of the video. Each video also has responsibility to store a list of comments, and should have a method to return the number of comments. A comment should be defined by the Comment class which has the responsibility for tracking both the name of the person who made the comment and the text of the comment.

    // Once you have the classes in place, write a program that creates 3-4 videos, sets the appropriate values, and for each one add a list of 3-4 comments (with the commenter's name and text). Put each of these videos in a list.

    // Then, have your program iterate through the list of videos and for each one, display the title, author, length, number of comments (from the method) and then list out all of the comments for that video. Repeat this display for each video in the list.
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        // Create 3 video objects with their respective details
        Video video1 = new Video("Introduction to C#", "CodeGuru", 600);
        Video video2 = new Video("SQL Fundamentals", "DataGeek", 900);
        Video video3 = new Video("Advanced JavaScript", "WebWizard", 1200);

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "Great introduction! Very clear."));
        video1.AddComment(new Comment("Bob", "This helped me a lot with my project."));
        video1.AddComment(new Comment("Charlie", "Thanks for the great content!"));

        // Add comments to video2
        video2.AddComment(new Comment("Diana", "I wish you covered joins in more detail."));
        video2.AddComment(new Comment("Eve", "Excellent video for beginners."));
        video2.AddComment(new Comment("Frank", "Loved the examples."));
        video2.AddComment(new Comment("Grace", "Could you do a video on database normalization?"));

        // Add comments to video3
        video3.AddComment(new Comment("Heidi", "The section on closures was confusing."));
        video3.AddComment(new Comment("Ivan", "Very advanced, but super helpful."));
        video3.AddComment(new Comment("Judy", "Best explanation of async/await I've seen."));

        // Create a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Iterate through the list of videos and display their information
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }

    }
}