﻿using System;

namespace Iwentys.Models.Exceptions
{
    public class InnerLogicException : IwentysException
    {
        public InnerLogicException(string message) : base(message)
        {
        }

        public static InnerLogicException NotEnoughPermission(int userId)
        {
            return new InnerLogicException($"Not enough user permission for user {userId}");
        }

        public static InnerLogicException NotSupportedEnumValue<T>(T value) where T : Enum
        {
            return new InnerLogicException($"Unsupported [{value.GetType()}] type: {value}");
        }

        public static InnerLogicException NotEnoughBarsPoints()
        {
            return new InnerLogicException("Student don't have enough points for this operation.");
        }

        public static class Guild
        {
            public static InnerLogicException IsNotGuildMember(int studentId, int? guildId)
            {
                return new InnerLogicException(string.Format(Strings.ExceptionMessages.Guild_IsNotGuildMember, studentId, guildId));
            }

            public static InnerLogicException IsNotGuildEditor(int studentId) => new InnerLogicException($"Student is not guild editor. Id: [{studentId}]");
        }
    }
}