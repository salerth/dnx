//------------------------------------------------------------------------------
// <copyright file="JavaScriptSerializer.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace System.Web.Script.Serialization
{
    using System;

    public class JavaScriptSerializer
    {
        internal const int DefaultRecursionLimit = 100;
        internal const int DefaultMaxJsonLength = 2097152;

        private int _recursionLimit;
        private int _maxJsonLength;

        public JavaScriptSerializer()
        {
            RecursionLimit = DefaultRecursionLimit;
            MaxJsonLength = DefaultMaxJsonLength;
        }

        public int MaxJsonLength
        {
            get
            {
                return _maxJsonLength;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(AtlasWeb.JSON_InvalidMaxJsonLength);
                }
                _maxJsonLength = value;
            }
        }

        public int RecursionLimit
        {
            get
            {
                return _recursionLimit;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(AtlasWeb.JSON_InvalidRecursionLimit);
                }
                _recursionLimit = value;
            }
        }

        public object DeserializeObject(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            if (input.Length > MaxJsonLength)
            {
                throw new ArgumentException(AtlasWeb.JSON_MaxJsonLengthExceeded, "input");
            }

            object o = JavaScriptObjectDeserializer.BasicDeserialize(input, RecursionLimit, this);
            return o;
        }
    }
}
