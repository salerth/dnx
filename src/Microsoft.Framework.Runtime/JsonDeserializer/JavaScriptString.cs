// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Micrsoft.Framework.Runtime.JsonDeserializer
{
    using System;

    internal class JavaScriptString
    {
        private string _s;
        private int _index;

        internal JavaScriptString(string s)
        {
            _s = s;
        }

        internal Nullable<char> GetNextNonEmptyChar()
        {
            while (_s.Length > _index)
            {
                char c = _s[_index++];
                if (!Char.IsWhiteSpace(c))
                {
                    return c;
                }
            }

            return null;
        }

        internal Nullable<char> MoveNext()
        {
            if (_s.Length > _index)
            {
                return _s[_index++];
            }

            return null;
        }

        internal string MoveNext(int count)
        {
            if (_s.Length >= _index + count)
            {
                string result = _s.Substring(_index, count);
                _index += count;

                return result;
            }

            return null;
        }

        internal void MovePrev()
        {
            if (_index > 0)
            {
                _index--;
            }
        }

        public override string ToString()
        {
            if (_s.Length > _index)
            {
                return _s.Substring(_index);
            }

            return String.Empty;
        }

        internal string GetDebugString(string message)
        {
            return message + " (" + _index + "): " + _s;
        }
    }
}
