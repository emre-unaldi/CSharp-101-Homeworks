using System;

namespace ToDoApplication
{
    public class Card
    {
        private string title;
        private string content;
        private Sizes size;
        private Member member;
        private Status status;

        public Card(string title, string content, Sizes size, Member member, Status status)
        {
            this.Title = title;
            this.Content = content;
            this.Size = size;
            this.Member = member;
            this.Status = status;
        }

        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public Sizes Size { get => size; set => size = value; }
        public Member Member { get => member; set => member = value; }
        public Status Status { get => status; set => status = value; }
    }
}
