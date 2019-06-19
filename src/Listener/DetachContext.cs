//  ------------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation
//  All rights reserved. 
//  
//  Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this 
//  file except in compliance with the License. You may obtain a copy of the License at 
//  http://www.apache.org/licenses/LICENSE-2.0  
//  
//  THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, 
//  EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR 
//  CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR 
//  NON-INFRINGEMENT. 
// 
//  See the Apache Version 2.0 License for specific language governing permissions and 
//  limitations under the License.
//  ------------------------------------------------------------------------------------

namespace Amqp.Listener
{
    using Amqp.Framing;

    /// <summary>
    /// Provides the context to <see cref="ILinkProcessor"/> to process the received performative.
    /// </summary>
    public class DetachContext
    {
        internal DetachContext(ListenerLink link, Detach detach)
        {
            this.Link = link;
            this.Detach = detach;
        }

        /// <summary>
        /// Gets the link associated with the context.
        /// </summary>
        public ListenerLink Link
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the detach performative associated with the context.
        /// </summary>
        public Detach Detach
        {
            get;
            private set;
        }

        /// <summary>
        /// Completes the processing of the detach performative.
        /// </summary>
        public void Complete()
        {
            this.Complete(this.Detach.Closed, null);
        }

        /// <summary>
        /// Completes the processing of the detach performative.
        /// </summary>
        /// <param name="closed">True if the link endpoint is closed.</param>
        /// <param name="error">The error to be sent to the remote peer.</param>
        public void Complete(bool closed, Error error)
        {
            this.Link.CompleteDetach(this.Detach, closed, error);
        }
    }
}
