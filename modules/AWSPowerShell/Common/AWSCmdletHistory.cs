/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Amazon.Runtime;

namespace Amazon.PowerShell.Common
{          
    /// <summary>
    /// Execution history of AWS cmdlets, exposed as the $AWSHistory session variable.
    /// </summary>
    public class AWSCmdletHistoryBuffer
    {
        static object _syncLock = new object();

        const int DEFAULT_HISTORY_LENGTH = 5;
        const int DEFAULT_SERVICECALL_HISTORY_LENGTH = 5;

        static AWSCmdletHistoryBuffer _instance;
        internal static AWSCmdletHistoryBuffer Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                        _instance = new AWSCmdletHistoryBuffer();
                    return _instance;
                }
            }
        }

        HistoryBuffer<AWSCmdletHistory> _historyBuffer;
        private HistoryBuffer<AWSCmdletHistory> History
        {
            get
            {
                HistoryBuffer<AWSCmdletHistory> historyBuffer = null;
                lock (_syncLock)
                    historyBuffer = _historyBuffer;

                return historyBuffer;
            }
            set
            {
                lock (_syncLock)
                    _historyBuffer = value;
            }
        }

        internal AWSCmdletHistory StartCmdletHistory(string cmdletName)
        {
            return new AWSCmdletHistory(cmdletName);
        }

        int _historyLength = DEFAULT_HISTORY_LENGTH;
        internal int MaxHistoryLength
        {
            get
            {
                lock (_syncLock)
                {
                    return _historyLength;
                }
            }

            set
            {
                lock (_syncLock)
                {
                    if (value == _historyLength)
                        return;

                    if (value == 0)
                    {
                        History.Clear();
                        _historyLength = 0;
                        return;
                    }

                    History = new HistoryBuffer<AWSCmdletHistory>(value, History);
                    _historyLength = value;
                }
            }
        }

        int _serviceCallHistoryLength = DEFAULT_SERVICECALL_HISTORY_LENGTH;
        internal int ServiceCallHistoryLength 
        {
            get { return _serviceCallHistoryLength; }
            set 
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException();

                // might want to ripple down existing buffer and update existing service 
                // call instances here

                _serviceCallHistoryLength = value; 
            } 
        }

        public AWSCmdletHistory this[int index]
        {
            get
            {
                if (!RecordingEnabled)
                    return null;

                if (index >= 0 && index < MaxHistoryLength)
                {
                    lock (_syncLock)
                    {
                        return History.ElementAt(index);
                    }
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal void Clear()
        {
            lock (_syncLock)
            {
                History.Clear();
            }
        }

        internal void Save(string fileName)
        {
        }

        public override string ToString()
        {
            if (!RecordingEnabled)
                return "AWS History Disabled";

            return string.Format("{0} command(s) recorded{1}.", 
                                  this.History.Count, 
                                  LastCommand != null 
                                    ? ", last  = " + LastCommand
                                    : "");
        }

        bool _recordServiceRequests = false;
        internal bool RecordServiceRequests
        {
            get
            {
                lock (_syncLock)
                {
                    return _recordServiceRequests;
                }
            }
            set
            {
                lock (_syncLock)
                {
                    _recordServiceRequests = value;
                }
            }
        }

        private bool RecordingEnabled
        {
            get
            {
                int historyLength;
                lock (_syncLock)
                    historyLength = _historyLength;

                return historyLength != 0;
            }
        }

        internal void PushCmdletHistory(AWSCmdletHistory cmdletHistory)
        {
            if (RecordingEnabled)
            {
                cmdletHistory.CmdletEnd = DateTime.Now;
                History.Add(cmdletHistory);
            }
        }

        /// <summary>
        /// Exposes the inner command trace to the shell
        /// </summary>
        public IEnumerable<AWSCmdletHistory> Commands 
        {
            get { return History.History; } 
        }

        /// <summary>
        /// Helper property to access the very last cmdlet that was run
        /// </summary>
        public AWSCmdletHistory LastCommand
        {
            get
            {
                lock (_syncLock)
                {
                    return History.Last;
                }
            }
        }

        /// <summary>
        /// Helper property to access the very last service response that was recorded on
        /// the last invocation.
        /// </summary>
        public object LastServiceResponse
        {
            get
            {
                lock (_syncLock)
                {
                    var lastInvoke = LastCommand;
                    if (lastInvoke != null)
                        return lastInvoke.LastServiceResponse;
                }

                return null;
            }
        }

        /// <summary>
        /// Helper property to access the very last service response that was recorded on
        /// the last invocation.
        /// </summary>
        public object LastServiceRequest
        {
            get
            {
                lock (_syncLock)
                {
                    var lastInvoke = LastCommand;
                    if (lastInvoke != null)
                        return lastInvoke.LastServiceRequest;
                }

                return null;
            }
        }

        private AWSCmdletHistoryBuffer()
        {
            History = new HistoryBuffer<AWSCmdletHistory>(_historyLength);
        }
    }

    /// <summary>
    /// Records the responses and optionally requests that the cmdlet made, together
    /// with other diagnostic info.
    /// </summary>
    public class AWSCmdletHistory
    {
        readonly object _syncLock = new object();
        public string CmdletName { get; private set; }
        public DateTime CmdletStart { get; private set; }
        public DateTime CmdletEnd { get; internal set; }
        public int EmittedObjectsCount { get; internal set; }

        private AWSCmdletHistory() { }

        public HistoryBuffer<PSObject> Requests { get; private set; }
        public HistoryBuffer<PSObject> Responses { get; private set; }

        // indexer returns composed object with both request and response
        public PSObject this[int index]
        {
            get
            {
                if (index >= 0 && index < AWSCmdletHistoryBuffer.Instance.ServiceCallHistoryLength)
                {
                    lock (_syncLock)
                    {
                        var pso = new PSObject();

                        PSObject requestObj = null;
                        if (Requests.Count != 0)
                            requestObj = new PSObject(Requests.ElementAt(index));

                        PSObject responseObj = null;
                        if (Responses.Count != 0)
                            responseObj = new PSObject(Responses.ElementAt(index));

                        pso.Properties.Add(new PSNoteProperty("Request", requestObj));
                        pso.Properties.Add(new PSNoteProperty("Response", responseObj));
                        return pso;
                    }
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }


        /// <summary>
        /// Helper property to access the very last service response that was recorded
        /// </summary>
        public PSObject LastServiceResponse
        {
            get
            {
                lock (_syncLock)
                {
                    return Responses.Last;
                }
            }
        }

        /// <summary>
        /// Helper property to access the very last service request that was recorded,
        /// if request logging is turned on.
        /// </summary>
        public PSObject LastServiceRequest
        {
            get
            {
                lock (_syncLock)
                {
                    return Requests.Last;
                }
            }
        }

        public override string ToString()
        {
            return this.CmdletName;
        }

        internal AWSCmdletHistory(string cmdletName)
        {
            this.CmdletName = cmdletName;
            Requests = new HistoryBuffer<PSObject>(AWSCmdletHistoryBuffer.Instance.ServiceCallHistoryLength);
            Responses = new HistoryBuffer<PSObject>(AWSCmdletHistoryBuffer.Instance.ServiceCallHistoryLength);
            this.EmittedObjectsCount = 0;
            this.CmdletEnd = this.CmdletStart = DateTime.Now;
        }

        internal void PushServiceRequest(AmazonWebServiceRequest request, InvocationInfo invocationInfo)
        {
            if (!AWSCmdletHistoryBuffer.Instance.RecordServiceRequests)
                return;

            var pso = new PSObject(request);
            if (invocationInfo != null)
                pso.Properties.Add(new PSNoteProperty("InvocationLine", invocationInfo.Line));

            pso.Properties.Add(new PSNoteProperty("LoggedAt", DateTime.Now));
            lock (_syncLock)
            {
                Requests.Add(pso);
            }
        }

        internal void PushServiceRequest(AmazonWebServiceRequest request, Dictionary<string, object> noteProperties)
        {
            if (!AWSCmdletHistoryBuffer.Instance.RecordServiceRequests)
                return;

            var pso = new PSObject(request);
            if (noteProperties != null)
            {
                foreach (var kvp in noteProperties)
                {
                    pso.Properties.Add(new PSNoteProperty(kvp.Key, kvp.Value));
                }
            }

            pso.Properties.Add(new PSNoteProperty("LoggedAt", DateTime.Now));
            lock (_syncLock)
            {
                Requests.Add(pso);
            }
        }

        internal void PushServiceResponse(object responseOrError)
        {
            this.PushServiceResponse(responseOrError, null);
        }

        internal void PushServiceResponse(object responseOrError, Dictionary<string, object> noteProperties)
        {
            if (responseOrError == null && (noteProperties == null || noteProperties.Count == 0))
                return;

            var pso = responseOrError != null ? new PSObject(responseOrError) : new PSObject();
            if (noteProperties != null)
            {
                foreach (var kvp in noteProperties)
                {
                    pso.Properties.Add(new PSNoteProperty(kvp.Key, kvp.Value));
                }
            }

            pso.Properties.Add(new PSNoteProperty("LoggedAt", DateTime.Now));

            lock (_syncLock)
            {
                Responses.Add(pso);
            }
        }
    }

    /// <summary>
    /// Simplistic fixed-size buffer implementation that can be used to
    /// keep track of cmdlet exec history and the request/response calls 
    /// that each cmdlet makes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HistoryBuffer<T>
    {
        readonly Queue<T> _queue;
        readonly int _maxLength;

        public HistoryBuffer(int maxLength)
        {
            _queue = new Queue<T>(maxLength);
            _maxLength = maxLength;
        }

        public HistoryBuffer(int maxLength, HistoryBuffer<T> currentBuffer)
        {
            _queue = new Queue<T>(maxLength);
            int oldestToCopy = maxLength > currentBuffer.Count ? 0 : currentBuffer.Count - maxLength;
            for (int i = oldestToCopy; i < currentBuffer.Count; i++)
            {
                _queue.Enqueue(currentBuffer._queue.ElementAt<T>(i));
            }

            _maxLength = maxLength;
        }

        public IEnumerable<T> History
        {
            get { return _queue; }
        }

        public void Add(T obj)
        {
            if (_queue.Count == _maxLength)
            {
                _queue.Dequeue();
                _queue.Enqueue(obj);
            }
            else
                _queue.Enqueue(obj);
        }

        public T Read()
        {
            return _queue.Dequeue();
        }

        public void Clear()
        {
            _queue.Clear();
        }

        public T ElementAt(int index)
        {
            return _queue.ElementAtOrDefault<T>(index);
        }

        public T Last
        {
            get
            {
                return _queue.LastOrDefault<T>();
            }
        }

        public int Count
        {
            get { return _queue.Count; }
        }

        public T this[int index]
        {
            get
            {
                return this.ElementAt(index);
            }
        }

        HistoryBuffer() {}
    }
}
