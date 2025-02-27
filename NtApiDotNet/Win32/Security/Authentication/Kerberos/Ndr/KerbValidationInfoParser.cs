//  Copyright 2020 Google Inc. All Rights Reserved.
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

using NtApiDotNet.Ndr.Marshal;
using NtApiDotNet.Win32.Rpc;
using System;
using System.Linq;

namespace NtApiDotNet.Win32.Security.Authentication.Kerberos.Ndr
{
#pragma warning disable 1591

    #region Marshal Helpers
    internal class _Unmarshal_HelperKerbValidationInfo : NdrUnmarshalBuffer
    {
        internal _Unmarshal_HelperKerbValidationInfo(NdrPickledType pickled_type) :
                base(pickled_type)
        {
        }
        internal KERB_VALIDATION_INFO Read_0()
        {
            return ReadStruct<KERB_VALIDATION_INFO>();
        }
        internal FILETIME Read_1()
        {
            return ReadStruct<FILETIME>();
        }
        internal RPC_UNICODE_STRING Read_2()
        {
            return ReadStruct<RPC_UNICODE_STRING>();
        }
        internal USER_SESSION_KEY Read_3()
        {
            return ReadStruct<USER_SESSION_KEY>();
        }
        internal CYPHER_BLOCK Read_4()
        {
            return ReadStruct<CYPHER_BLOCK>();
        }
        internal RPC_SID Read_5()
        {
            return ReadStruct<RPC_SID>();
        }
        internal RPC_SID_IDENTIFIER_AUTHORITY Read_6()
        {
            return ReadStruct<RPC_SID_IDENTIFIER_AUTHORITY>();
        }
        internal GROUP_MEMBERSHIP[] Read_GROUP_MEMBERSHIP()
        {
            return ReadConformantStructArray<GROUP_MEMBERSHIP>();
        }
        internal int[] Read_9()
        {
            return ReadFixedPrimitiveArray<int>(2);
        }
        internal int[] Read_10()
        {
            return ReadFixedPrimitiveArray<int>(7);
        }
        internal KERB_SID_AND_ATTRIBUTES[] Read_11()
        {
            return ReadConformantStructArray<KERB_SID_AND_ATTRIBUTES>();
        }
        internal char[] Read_13()
        {
            return ReadConformantVaryingArray<char>();
        }
        internal CYPHER_BLOCK[] Read_14()
        {
            return ReadFixedStructArray<CYPHER_BLOCK>(2);
        }
        internal byte[] Read_15()
        {
            return ReadFixedPrimitiveArray<byte>(8);
        }
        internal int[] Read_16()
        {
            return ReadConformantArray<int>();
        }
        internal byte[] Read_17()
        {
            return ReadFixedByteArray(6);
        }
    }
    internal class _Marshal_HelperKerbValidationInfo : NdrMarshalBuffer
    {
        internal void Write_0(KERB_VALIDATION_INFO p0)
        {
            WriteStruct(p0);
        }
        internal void Write_1(FILETIME p0)
        {
            WriteStruct(p0);
        }
        internal void Write_2(RPC_UNICODE_STRING p0)
        {
            WriteStruct(p0);
        }
        internal void Write_3(USER_SESSION_KEY p0)
        {
            WriteStruct(p0);
        }
        internal void Write_4(CYPHER_BLOCK p0)
        {
            WriteStruct(p0);
        }
        internal void Write_5(RPC_SID p0)
        {
            WriteStruct(p0);
        }
        internal void Write_6(RPC_SID_IDENTIFIER_AUTHORITY p0)
        {
            WriteStruct(p0);
        }
        internal void Write_7(KERB_SID_AND_ATTRIBUTES p0)
        {
            WriteStruct(p0);
        }
        internal void Write_GROUP_MEMBERSHIP(GROUP_MEMBERSHIP[] p0, long p1)
        {
            WriteConformantStructArray(p0, p1);
        }
        internal void Write_9(int[] p0)
        {
            WriteFixedPrimitiveArray(p0, 2);
        }
        internal void Write_10(int[] p0)
        {
            WriteFixedPrimitiveArray(p0, 7);
        }
        internal void Write_11(KERB_SID_AND_ATTRIBUTES[] p0, long p1)
        {
            WriteConformantStructArray(p0, p1);
        }
        internal void Write_13(char[] p0, long p1, long p2)
        {
            WriteConformantVaryingArray(p0, p1, p2);
        }
        internal void Write_14(CYPHER_BLOCK[] p0)
        {
            WriteFixedStructArray(p0, 2);
        }
        internal void Write_15(byte[] p0)
        {
            WriteFixedPrimitiveArray(p0, 8);
        }
        internal void Write_16(int[] p0, long p1)
        {
            WriteConformantArray(p0, p1);
        }
        internal void Write_17(byte[] p0)
        {
            WriteFixedByteArray(p0, 6);
        }
    }
    #endregion
    #region Complex Types
    internal struct KERB_VALIDATION_INFO : INdrStructure
    {
        void INdrStructure.Marshal(NdrMarshalBuffer m)
        {
            Marshal((_Marshal_HelperKerbValidationInfo)m);
        }
        private void Marshal(_Marshal_HelperKerbValidationInfo m)
        {
            m.Write_1(LogonTime);
            m.Write_1(LogoffTime);
            m.Write_1(KickOffTime);
            m.Write_1(PasswordLastSet);
            m.Write_1(PasswordCanChange);
            m.Write_1(PasswordMustChange);
            m.Write_2(EffectiveName);
            m.Write_2(FullName);
            m.Write_2(LogonScript);
            m.Write_2(ProfilePath);
            m.Write_2(HomeDirectory);
            m.Write_2(HomeDirectoryDrive);
            m.WriteInt16(LogonCount);
            m.WriteInt16(BadPasswordCount);
            m.WriteInt32(UserId);
            m.WriteInt32(PrimaryGroupId);
            m.WriteInt32(GroupCount);
            m.WriteEmbeddedPointer(GroupIds, new Action<GROUP_MEMBERSHIP[], long>(m.Write_GROUP_MEMBERSHIP), GroupCount);
            m.WriteInt32(UserFlags);
            m.Write_3(UserSessionKey);
            m.Write_2(LogonServer);
            m.Write_2(LogonDomainName);
            m.WriteEmbeddedPointer(LogonDomainId, m.Write_5);
            m.Write_9(RpcUtils.CheckNull(Reserved1, "Reserved1"));
            m.WriteInt32(UserAccountControl);
            m.Write_10(RpcUtils.CheckNull(Reserved3, "Reserved3"));
            m.WriteInt32(SidCount);
            m.WriteEmbeddedPointer(ExtraSids, new Action<KERB_SID_AND_ATTRIBUTES[], long>(m.Write_11), SidCount);
            m.WriteEmbeddedPointer(ResourceGroupDomainSid, m.Write_5);
            m.WriteInt32(ResourceGroupCount);
            m.WriteEmbeddedPointer(ResourceGroupIds, new Action<GROUP_MEMBERSHIP[], long>(m.Write_GROUP_MEMBERSHIP), ResourceGroupCount);
        }

        void INdrStructure.Unmarshal(NdrUnmarshalBuffer u)
        {
            Unmarshal((_Unmarshal_HelperKerbValidationInfo)u);
        }
        private void Unmarshal(_Unmarshal_HelperKerbValidationInfo u)
        {
            LogonTime = u.Read_1();
            LogoffTime = u.Read_1();
            KickOffTime = u.Read_1();
            PasswordLastSet = u.Read_1();
            PasswordCanChange = u.Read_1();
            PasswordMustChange = u.Read_1();
            EffectiveName = u.Read_2();
            FullName = u.Read_2();
            LogonScript = u.Read_2();
            ProfilePath = u.Read_2();
            HomeDirectory = u.Read_2();
            HomeDirectoryDrive = u.Read_2();
            LogonCount = u.ReadInt16();
            BadPasswordCount = u.ReadInt16();
            UserId = u.ReadInt32();
            PrimaryGroupId = u.ReadInt32();
            GroupCount = u.ReadInt32();
            GroupIds = u.ReadEmbeddedPointer(u.Read_GROUP_MEMBERSHIP, false);
            UserFlags = u.ReadInt32();
            UserSessionKey = u.Read_3();
            LogonServer = u.Read_2();
            LogonDomainName = u.Read_2();
            LogonDomainId = u.ReadEmbeddedPointer(u.Read_5, false);
            Reserved1 = u.Read_9();
            UserAccountControl = u.ReadInt32();
            Reserved3 = u.Read_10();
            SidCount = u.ReadInt32();
            ExtraSids = u.ReadEmbeddedPointer(u.Read_11, false);
            ResourceGroupDomainSid = u.ReadEmbeddedPointer(u.Read_5, false);
            ResourceGroupCount = u.ReadInt32();
            ResourceGroupIds = u.ReadEmbeddedPointer(u.Read_GROUP_MEMBERSHIP, false);
        }
        int INdrStructure.GetAlignment()
        {
            return 4;
        }
        internal FILETIME LogonTime;
        internal FILETIME LogoffTime;
        internal FILETIME KickOffTime;
        internal FILETIME PasswordLastSet;
        internal FILETIME PasswordCanChange;
        internal FILETIME PasswordMustChange;
        internal RPC_UNICODE_STRING EffectiveName;
        internal RPC_UNICODE_STRING FullName;
        internal RPC_UNICODE_STRING LogonScript;
        internal RPC_UNICODE_STRING ProfilePath;
        internal RPC_UNICODE_STRING HomeDirectory;
        internal RPC_UNICODE_STRING HomeDirectoryDrive;
        internal short LogonCount;
        internal short BadPasswordCount;
        internal int UserId;
        internal int PrimaryGroupId;
        internal int GroupCount;
        internal NdrEmbeddedPointer<GROUP_MEMBERSHIP[]> GroupIds;
        internal int UserFlags;
        internal USER_SESSION_KEY UserSessionKey;
        internal RPC_UNICODE_STRING LogonServer;
        internal RPC_UNICODE_STRING LogonDomainName;
        internal NdrEmbeddedPointer<RPC_SID> LogonDomainId;
        internal int[] Reserved1;
        internal int UserAccountControl;
        internal int[] Reserved3;
        internal int SidCount;
        internal NdrEmbeddedPointer<KERB_SID_AND_ATTRIBUTES[]> ExtraSids;
        internal NdrEmbeddedPointer<RPC_SID> ResourceGroupDomainSid;
        internal int ResourceGroupCount;
        internal NdrEmbeddedPointer<GROUP_MEMBERSHIP[]> ResourceGroupIds;

        internal static KERB_VALIDATION_INFO CreateDefault()
        {
            return new KERB_VALIDATION_INFO()
            {
                Reserved1 = new int[2],
                Reserved3 = new int[7],
                UserSessionKey = USER_SESSION_KEY.CreateDefault()
            };
        }
    }
    internal struct FILETIME : INdrStructure
    {
        void INdrStructure.Marshal(NdrMarshalBuffer m)
        {
            m.WriteUInt32(LowerValue);
            m.WriteInt32(UpperValue);
        }

        void INdrStructure.Unmarshal(NdrUnmarshalBuffer u)
        {
            LowerValue = u.ReadUInt32();
            UpperValue = u.ReadInt32();
        }

        int INdrStructure.GetAlignment()
        {
            return 4;
        }
        internal uint LowerValue;
        internal int UpperValue;

        public DateTime ToTime()
        {
            LargeIntegerStruct li = new LargeIntegerStruct()
            {
                LowPart = LowerValue,
                HighPart = UpperValue
            };

            try
            {
                return DateTime.FromFileTime(li.QuadPart);
            }
            catch (ArgumentOutOfRangeException)
            {
                return DateTime.MaxValue;
            }
        }

        public void Set(DateTime time)
        {
            LargeIntegerStruct li = new LargeIntegerStruct()
            {
                QuadPart = time.ToFileTime()
            };

            LowerValue = li.LowPart;
            UpperValue = li.HighPart;
        }
    }
    internal struct GROUP_MEMBERSHIP : INdrStructure
    {
        void INdrStructure.Marshal(NdrMarshalBuffer m)
        {
            m.WriteInt32(RelativeId);
            m.WriteInt32(Attributes);
        }

        void INdrStructure.Unmarshal(NdrUnmarshalBuffer u)
        {
            RelativeId = u.ReadInt32();
            Attributes = u.ReadInt32();
        }

        int INdrStructure.GetAlignment()
        {
            return 4;
        }
        internal int RelativeId;
        internal int Attributes;
    }
    internal struct RPC_UNICODE_STRING : INdrStructure
    {
        void INdrStructure.Marshal(NdrMarshalBuffer m)
        {
            Marshal((_Marshal_HelperKerbValidationInfo)m);
        }
        private void Marshal(_Marshal_HelperKerbValidationInfo m)
        {
            m.WriteUInt16(Length);
            m.WriteUInt16(MaximumLength);
            m.WriteEmbeddedPointer(Buffer, new Action<char[], long, long>(m.Write_13), MaximumLength / 2, Length / 2);
        }
        void INdrStructure.Unmarshal(NdrUnmarshalBuffer u)
        {
            Unmarshal((_Unmarshal_HelperKerbValidationInfo)u);
        }
        private void Unmarshal(_Unmarshal_HelperKerbValidationInfo u)
        {
            Length = u.ReadUInt16();
            MaximumLength = u.ReadUInt16();
            Buffer = u.ReadEmbeddedPointer(u.Read_13, false);
        }
        int INdrStructure.GetAlignment()
        {
            return 4;
        }
        internal ushort Length;
        internal ushort MaximumLength;
        internal NdrEmbeddedPointer<char[]> Buffer;

        internal void Set(string str)
        {
            if (str == null)
            {
                Buffer = null;
                Length = 0;
                MaximumLength = 0;
            }
            else
            {
                Buffer = str.ToCharArray();
                Length = (ushort)(str.Length * 2);
                MaximumLength = Length;
            }
        }

        public override string ToString()
        {
            if (Buffer == null)
                return null;
            return new string(Buffer, 0, Length / 2);
        }
    }
    internal struct USER_SESSION_KEY : INdrStructure
    {
        void INdrStructure.Marshal(NdrMarshalBuffer m)
        {
            Marshal((_Marshal_HelperKerbValidationInfo)m);
        }
        private void Marshal(_Marshal_HelperKerbValidationInfo m)
        {
            m.Write_14(RpcUtils.CheckNull(data, "data"));
        }
        void INdrStructure.Unmarshal(NdrUnmarshalBuffer u)
        {
            Unmarshal((_Unmarshal_HelperKerbValidationInfo)u);
        }
        private void Unmarshal(_Unmarshal_HelperKerbValidationInfo u)
        {
            data = u.Read_14();
        }
        int INdrStructure.GetAlignment()
        {
            return 1;
        }
        internal CYPHER_BLOCK[] data;

        internal static USER_SESSION_KEY CreateDefault()
        {
            return new USER_SESSION_KEY()
            {
                data = new[] { CYPHER_BLOCK.CreateDefault(), CYPHER_BLOCK.CreateDefault() }
            };
        }

        internal byte[] ToArray()
        {
            byte[] ret = new byte[16];
            if (data == null || data.Length != 2)
                return ret;
            Array.Copy(data[0].ToArray(), 0, ret, 0, 8);
            Array.Copy(data[1].ToArray(), 0, ret, 8, 8);
            return ret;
        }

        internal void Set(byte[] ba)
        {
            if (ba is null)
                throw new ArgumentNullException(nameof(ba));
            if (ba.Length != 16)
                throw new ArgumentOutOfRangeException(nameof(ba), "Session key must be 16 bytes in size.");
            data = new CYPHER_BLOCK[2];
            data[0].data = new byte[8];
            Array.Copy(ba, 0, data[0].data, 0, 8);
            data[1].data = new byte[8];
            Array.Copy(ba, 8, data[1].data, 0, 8);
        }
    }
    internal struct CYPHER_BLOCK : INdrStructure
    {
        void INdrStructure.Marshal(NdrMarshalBuffer m)
        {
            Marshal((_Marshal_HelperKerbValidationInfo)m);
        }
        private void Marshal(_Marshal_HelperKerbValidationInfo m)
        {
            m.Write_15(RpcUtils.CheckNull(data, "data"));
        }
        void INdrStructure.Unmarshal(NdrUnmarshalBuffer u)
        {
            Unmarshal((_Unmarshal_HelperKerbValidationInfo)u);
        }
        private void Unmarshal(_Unmarshal_HelperKerbValidationInfo u)
        {
            data = u.Read_15();
        }
        int INdrStructure.GetAlignment()
        {
            return 1;
        }
        internal byte[] data;
        internal byte[] ToArray()
        {
            if (data == null)
                return new byte[8];
            byte[] ret = (byte[])data.Clone();
            Array.Resize(ref ret, 8);
            return ret;
        }

        internal static CYPHER_BLOCK CreateDefault()
        {
            return new CYPHER_BLOCK() { data = new byte[8] };
        }
    }
    internal struct RPC_SID : INdrConformantStructure
    {
        void INdrStructure.Marshal(NdrMarshalBuffer m)
        {
            Marshal((_Marshal_HelperKerbValidationInfo)m);
        }
        private void Marshal(_Marshal_HelperKerbValidationInfo m)
        {
            m.WriteByte(Revision);
            m.WriteByte(SubAuthorityCount);
            m.Write_6(IdentifierAuthority);
            m.Write_16(RpcUtils.CheckNull(SubAuthority, "SubAuthority"), SubAuthorityCount);
        }
        void INdrStructure.Unmarshal(NdrUnmarshalBuffer u)
        {
            Unmarshal((_Unmarshal_HelperKerbValidationInfo)u);
        }
        private void Unmarshal(_Unmarshal_HelperKerbValidationInfo u)
        {
            Revision = u.ReadByte();
            SubAuthorityCount = u.ReadByte();
            IdentifierAuthority = u.Read_6();
            SubAuthority = u.Read_16();
        }
        int INdrConformantStructure.GetConformantDimensions()
        {
            return 1;
        }
        int INdrStructure.GetAlignment()
        {
            return 4;
        }

        internal RPC_SID(Sid sid)
        {
            Revision = 1;
            SubAuthorityCount = (byte)sid.SubAuthorities.Count;
            IdentifierAuthority = new RPC_SID_IDENTIFIER_AUTHORITY(sid.Authority);
            SubAuthority = sid.SubAuthorities.Select(r => (int)r).ToArray();
        }

        internal Sid ToSid()
        {
            return new Sid(new SidIdentifierAuthority(IdentifierAuthority.Value),
                SubAuthority.Select(r => (uint)r).ToArray());
        }

        internal byte Revision;
        internal byte SubAuthorityCount;
        internal RPC_SID_IDENTIFIER_AUTHORITY IdentifierAuthority;
        internal int[] SubAuthority;
    }
    internal struct RPC_SID_IDENTIFIER_AUTHORITY : INdrStructure
    {
        void INdrStructure.Marshal(NdrMarshalBuffer m)
        {
            Marshal((_Marshal_HelperKerbValidationInfo)m);
        }
        private void Marshal(_Marshal_HelperKerbValidationInfo m)
        {
            m.Write_17(RpcUtils.CheckNull(Value, "Value"));
        }
        void INdrStructure.Unmarshal(NdrUnmarshalBuffer u)
        {
            Unmarshal((_Unmarshal_HelperKerbValidationInfo)u);
        }
        private void Unmarshal(_Unmarshal_HelperKerbValidationInfo u)
        {
            Value = u.Read_17();
        }
        int INdrStructure.GetAlignment()
        {
            return 1;
        }
        internal byte[] Value;
        internal RPC_SID_IDENTIFIER_AUTHORITY(SidIdentifierAuthority id)
        {
            Value = id.Value;
        }
    }
    internal struct KERB_SID_AND_ATTRIBUTES : INdrStructure
    {
        void INdrStructure.Marshal(NdrMarshalBuffer m)
        {
            Marshal((_Marshal_HelperKerbValidationInfo)m);
        }
        private void Marshal(_Marshal_HelperKerbValidationInfo m)
        {
            m.WriteEmbeddedPointer(Sid, m.Write_5);
            m.WriteInt32(Attributes);
        }
        void INdrStructure.Unmarshal(NdrUnmarshalBuffer u)
        {
            Unmarshal((_Unmarshal_HelperKerbValidationInfo)u);
        }
        private void Unmarshal(_Unmarshal_HelperKerbValidationInfo u)
        {
            Sid = u.ReadEmbeddedPointer(u.Read_5, false);
            Attributes = u.ReadInt32();
        }
        int INdrStructure.GetAlignment()
        {
            return 4;
        }
        internal NdrEmbeddedPointer<RPC_SID> Sid;
        internal int Attributes;

        internal static UserGroup ToGroup(KERB_SID_AND_ATTRIBUTES s)
        {
            return new UserGroup(s.Sid.GetValue().ToSid(), (GroupAttributes)s.Attributes);
        }

        internal static KERB_SID_AND_ATTRIBUTES ToStruct(UserGroup group)
        {
            return new KERB_SID_AND_ATTRIBUTES()
            {
                Sid = new RPC_SID(group.Sid),
                Attributes = (int)group.Attributes
            };
        }
    }
    #endregion
    #region Complex Type Encoders
    internal static class KerbValidationInfoParser
    {
        internal static KERB_VALIDATION_INFO? Decode(NdrPickledType pickled_type)
        {
            _Unmarshal_HelperKerbValidationInfo u = new _Unmarshal_HelperKerbValidationInfo(pickled_type);
            return u.ReadReferentValue(u.Read_0, false);
        }
        internal static NdrPickledType Encode(KERB_VALIDATION_INFO? o)
        {
            _Marshal_HelperKerbValidationInfo m = new _Marshal_HelperKerbValidationInfo();
            m.WriteReferent(o, new Action<KERB_VALIDATION_INFO>(m.Write_0));
            return m.ToPickledType();
        }
    }
    #endregion
}