using MEC;
using Qurre.API;
using Qurre.API.DataBase;
using Qurre.API.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using TextChatXR;
using UnityEngine;
namespace TextChatXR
{
    public enum MessageType
    {
        Public,
        Team,
        Ally,
        Private,
        Position,
    }
    public enum CampType
    {
        SideWorker,
        Hostile,
        Containment,
        Total,
        None
    }
    public class Message
    {
        internal DateTime Date = DateTime.Now;
        internal string Text = "";
        internal Player Author;
        internal MessageType Type = MessageType.Public;
        internal CampType Camp = CampType.None;
        internal Player PrivateTo;
        internal Vector3 Position;
        public Message(string text, Player author, MessageType type, CampType camp = CampType.None, Player privateTo = null)
        {
            Text = text;
            Author = author;
            Type = type;
            Camp = camp;
            PrivateTo = privateTo;
            Date = DateTime.Now;
        }
        public Message(string text, Player author, MessageType type,  Vector3 pos, CampType camp = CampType.None, Player privateTo = null)
        {
            Text = text;
            Author = author;
            Type = type;
            Camp = camp;
            PrivateTo = privateTo;
            Date = DateTime.Now;
            Position = pos;
        }
    }
}
