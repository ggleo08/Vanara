﻿using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable UnusedMethodReturnValue.Global

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
        [Flags]
        public enum IEIFLAG
        {
            /// <summary>Used to ask the object to use the supplied aspect ratio. If this flag is set, a rectangle with the desired aspect ratio will be passed in prgSize. This flag cannot be used with IEIFLAG_SCREEN.</summary>
            IEIFLAG_ASPECT = 0x0004,
            /// <summary>Not used. The thumbnail is always extracted on a background thread. Microsoft Windows XP and earlier. Used to ask if this instance supports asynchronous (free-threaded) extraction. If this flag is set by the calling applications, IExtractImage::GetLocation may return E_PENDING, indicating to the calling application to extract the image on another thread. If E_PENDING is returned, the priority of the item is returned in pdwPriority.</summary>
            IEIFLAG_ASYNC = 0x0001,
            /// <summary>Not supported. Windows XP and earlier: Set by the object to indicate that it will not cache the image. If this flag is returned, the Shell will cache a copy of the image.</summary>
            IEIFLAG_CACHE = 0x0002,
            /// <summary>Not supported.</summary>
            IEIFLAG_GLEAM = 0x0010,
            /// <summary>Not supported.</summary>
            IEIFLAG_NOBORDER = 0x0100,
            /// <summary>Not supported.</summary>
            IEIFLAG_NOSTAMP = 0x0080,
            /// <summary>Used to tell the object to use only local content for rendering.</summary>
            IEIFLAG_OFFLINE = 0x0008,
            /// <summary>Version 5.0. Used to tell the object to render the image to the approximate size passed in prgSize, but crop it if necessary.</summary>
            IEIFLAG_ORIGSIZE = 0x0040,
            /// <summary>Passed to the IExtractImage::Extract method to indicate that a higher quality image is requested. If this flag is not set, IExtractImage retrieves an embedded thumbnail if the file has one, no matter what size the user requests. For example, if the file is 2000x2000 pixels but the embedded thumbnail is only 100x100 pixels and the user does not set this flag, yet requests a 1000x1000 pixel thumbnail, IExtractImage always returns the 100x100 pixel thumbnail. This is by design, since IExtractImage does not scale up. If a larger thumbnail is desired (usually embedded thumbnails are 160x160), this flag must be set.</summary>
            IEIFLAG_QUALITY = 0x0200,
            /// <summary>Returned by the object to indicate that Refresh Thumbnail should be displayed on the item's shortcut menu.</summary>
            IEIFLAG_REFRESH = 0x0400,
            /// <summary>Used to tell the object to render as if for the screen. This flag cannot be used with IEIFLAG_ASPECT.</summary>
            IEIFLAG_SCREEN = 0x0020,
        }

        /// <summary>Exposes methods that request a thumbnail image from a Shell folder.</summary>
        [ComImport, Guid("BB2E617C-0920-11d1-9A0B-00C04FC2D6C1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [PInvokeData("Shobjidl.h", MSDNShortId = "bb761848")]
        public interface IExtractImage
        {
            /// <summary>Gets a path to the image that is to be extracted.</summary>
            /// <param name="pszPathBuffer">The buffer used to return the path description. This value identifies the image so you can avoid loading the same one more than once.</param>
            /// <param name="cchMax">The size of pszPathBuffer in characters.</param>
            /// <param name="pdwPriority">Not used.</param>
            /// <param name="prgSize">A pointer to a SIZE structure with the desired width and height of the image. Must not be NULL.</param>
            /// <param name="dwRecClrDepth">The recommended color depth in units of bits per pixel. Must not be NULL.</param>
            /// <param name="pdwFlags">Flags that specify how the image is to be handled.</param>
            /// <returns>This method may return a COM-defined error code or one of the following:
            /// <list type="table">
            /// <listheader><term>Return code</term><term>Description</term></listheader>
            /// <item><term>S_OK</term><definition>Success</definition></item>
            /// <item><term>E_PENDING</term><definition>Windows XP and earlier: If the IEIFLAG_ASYNC flag is set, this return value is used to indicate to the Shell that the object is free-threaded.</definition></item>
            /// </list></returns>
            [PreserveSig]
            HRESULT GetLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszPathBuffer, uint cchMax,
                [Optional] IntPtr pdwPriority, ref SIZE prgSize, uint dwRecClrDepth, ref IEIFLAG pdwFlags);

            /// <summary>Requests an image from an object, such as an item in a Shell folder.</summary>
            /// <param name="phBmpImage">The HBITMAP of the image.</param>
            IntPtr Extract();
        }
    }
}