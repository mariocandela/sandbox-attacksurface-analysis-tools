﻿//  Copyright 2020 Google Inc. All Rights Reserved.
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

using NtApiDotNet.Win32.Security.Native;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NtApiDotNet.Win32.Security.Authentication
{
    /// <summary>
    /// Class to represent a credential handle.
    /// </summary>
    public sealed class CredentialHandle : IDisposable
    {
        /// <summary>
        /// Name of the authentication package used.
        /// </summary>
        public string PackageName { get; }

        /// <summary>
        /// Expiry of the credentials.
        /// </summary>
        public long Expiry { get; }

        internal SecHandle CredHandle { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="principal">User principal.</param>
        /// <param name="package">The package name.</param>
        /// <param name="auth_id">Optional authentication ID for the user.</param>
        /// <param name="cred_use_flag">Credential user flags.</param>
        /// <param name="auth_data">Optional authentication data.</param>
        public CredentialHandle(string principal, string package, Luid? auth_id,
            SecPkgCredFlags cred_use_flag, SafeBuffer auth_data)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            OptionalLuid luid = null;
            if (auth_id.HasValue)
            {
                luid = new OptionalLuid() { luid = auth_id.Value };
            }
            SecHandle cred_handle = new SecHandle();
            LargeInteger expiry = new LargeInteger();
            SecurityNativeMethods.AcquireCredentialsHandle(principal, package, cred_use_flag,
                luid, auth_data ?? SafeHGlobalBuffer.Null,
                IntPtr.Zero, IntPtr.Zero, cred_handle, expiry)
                .CheckResult();
            CredHandle = cred_handle;
            PackageName = package;
            Expiry = expiry.QuadPart;
        }

        /// <summary>
        /// Create a new credential handle.
        /// </summary>
        /// <param name="principal">User principal.</param>
        /// <param name="package">The package name.</param>
        /// <param name="auth_id">Optional authentication ID for the user.</param>
        /// <param name="cred_use_flag">Credential user flags.</param>
        /// <param name="credentials">Optional credentials.</param>
        /// <returns>The credential handle.</returns>
        public static CredentialHandle Create(string principal, string package, Luid? auth_id,
            SecPkgCredFlags cred_use_flag, AuthenticationCredentials credentials)
        {
            using (var list = new DisposableList())
            {
                using (var buffer = credentials?.ToBuffer(list, package))
                {
                    return new CredentialHandle(principal, package, auth_id, cred_use_flag, buffer);
                }
            }
        }

        /// <summary>
        /// Create a new credential handle.
        /// </summary>
        /// <param name="package">The package name.</param>
        /// <param name="auth_id">Optional authentication ID for the user.</param>
        /// <param name="cred_use_flag">Credential user flags.</param>
        /// <param name="credentials">Optional credentials.</param>
        /// <returns>The credential handle.</returns>
        public static CredentialHandle Create(string package, Luid? auth_id,
            SecPkgCredFlags cred_use_flag, AuthenticationCredentials credentials)
        {
            return Create(null, package, auth_id, cred_use_flag, credentials);
        }

        /// <summary>
        /// Create a new credential handle.
        /// </summary>
        /// <param name="package">The package name.</param>
        /// <param name="cred_use_flag">Credential user flags.</param>
        /// <param name="credentials">Optional credentials.</param>
        /// <returns>The credential handle.</returns>
        public static CredentialHandle Create(string package,
            SecPkgCredFlags cred_use_flag, AuthenticationCredentials credentials)
        {
            return Create(null, package, null, cred_use_flag, credentials);
        }

        /// <summary>
        /// Create a new credential handle.
        /// </summary>
        /// <param name="package">The package name.</param>
        /// <param name="cred_use_flag">Credential user flags.</param>
        /// <returns>The credential handle.</returns>
        public static CredentialHandle Create(string package,
            SecPkgCredFlags cred_use_flag)
        {
            return Create(package, cred_use_flag, null);
        }

        /// <summary>
        /// Set the KDC proxy.
        /// </summary>
        /// <param name="proxy_server">The proxy server to use.</param>
        /// <param name="force_proxy">True to force the proxy.</param>
        public void SetKdcProxy(string proxy_server, bool force_proxy = false)
        {
            if (proxy_server is null)
            {
                throw new ArgumentNullException(nameof(proxy_server));
            }

            byte[] proxy = Encoding.Unicode.GetBytes(proxy_server);
            using (var buffer = new SafeStructureInOutBuffer<SecPkgCredentials_KdcProxySettings>(proxy.Length, true))
            {
                buffer.Data.WriteBytes(proxy);
                buffer.Result = new SecPkgCredentials_KdcProxySettings()
                {
                    Version = SecPkgCredentials_KdcProxySettings.KDC_PROXY_SETTINGS_V1,
                    Flags = force_proxy ? SecPkgCredentials_KdcProxySettings.KDC_PROXY_SETTINGS_FLAGS_FORCEPROXY : 0,
                    ProxyServerLength = (ushort)proxy.Length,
                    ProxyServerOffset = (ushort)buffer.DataOffset
                };
                SetAttribute(SECPKG_CRED_ATTR.SECPKG_CRED_ATTR_KDC_PROXY_SETTINGS, buffer);
            }
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool _)
        {
            SecurityNativeMethods.FreeCredentialsHandle(CredHandle);
        }

        private void SetAttribute(SECPKG_CRED_ATTR attr, SafeBufferGeneric buffer)
        {
            SecurityNativeMethods.SetCredentialsAttributes(CredHandle, 
                attr, buffer, buffer.Length).CheckResult();
        }

        /// <summary>
        /// Finalizer.
        /// </summary>
        ~CredentialHandle()
        {
            Dispose(false);
        }
    }
}
