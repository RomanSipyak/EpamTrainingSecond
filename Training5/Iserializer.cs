// <copyright file="Iserializer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training5
{
    using System.Collections.Generic;

    public interface ISerializer<T>
    {
        List<T> DeserializeForBinary();

        void SerializeForBinary(List<T> objects);

        List<T> DeserializeForXML();

        void SerializeForXML(List<T> objects);

        List<T> DeserializeForJson(string jsonData);

        string SerializeForJson(List<T> objects);
    }
}
