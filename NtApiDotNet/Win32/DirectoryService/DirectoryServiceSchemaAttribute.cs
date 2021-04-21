﻿//  Copyright 2021 Google Inc. All Rights Reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

using System;

namespace NtApiDotNet.Win32.DirectoryService
{
    /// <summary>
    /// Class to represent a directory service schema attribute.
    /// </summary>
    public sealed class DirectoryServiceSchemaAttribute : DirectoryServiceSchemaObject
    {
        internal DirectoryServiceSchemaAttribute(string domain, string dn, Guid schema_id,
            string name, string ldap_name, string object_class)
            : base(domain, dn, schema_id, name, ldap_name, object_class)
        {
        }

        internal DirectoryServiceSchemaAttribute(string domain, Guid schema_id)
            : this(domain, string.Empty, schema_id,
          schema_id.ToString(), schema_id.ToString(), string.Empty)
        {
        }
    }
}
