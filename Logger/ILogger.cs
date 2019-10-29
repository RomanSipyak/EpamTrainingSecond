// <copyright file="FileLogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logger
{
    using System;

    public interface ILogger
    {
        void ReadMessage();

        void WriteMessage(Exception e);
    }
}
