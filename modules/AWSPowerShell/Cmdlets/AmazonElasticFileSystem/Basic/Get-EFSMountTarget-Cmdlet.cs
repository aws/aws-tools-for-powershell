/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Returns the descriptions of all the current mount targets, or a specific mount target,
    /// for a file system. When requesting all of the current mount targets, the order of
    /// mount targets returned in the response is unspecified.
    /// 
    ///  
    /// <para>
    /// This operation requires permission for the <code>elasticfilesystem:DescribeMountTargets</code>
    /// action, on either the file system id that you specify in <code>FileSystemId</code>,
    /// or on the file system of the mount target that you specify in <code>MountTargetId</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EFSMountTarget")]
    [OutputType("Amazon.ElasticFileSystem.Model.MountTargetDescription")]
    [AWSCmdlet("Invokes the DescribeMountTargets operation against Amazon Elastic File System.", Operation = new[] {"DescribeMountTargets"})]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.MountTargetDescription",
        "This cmdlet returns a collection of MountTargetDescription objects.",
        "The service call response (type Amazon.ElasticFileSystem.Model.DescribeMountTargetsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type System.String), NextMarker (type System.String)"
    )]
    public class GetEFSMountTargetCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Optional. String. The ID of the file system whose mount targets you want to list.
        /// It must be included in your request if <code>MountTargetId</code> is not included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FileSystemId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Optional. String. The ID of the mount target that you want to have described. It must
        /// be included in your request if <code>FileSystemId</code> is not included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MountTargetId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Optional. String. Opaque pagination token returned from a previous <code>DescribeMountTargets</code>
        /// operation. If present, it specifies to continue the list from where the previous returning
        /// call left off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Optional. Maximum number of mount targets to return in the response. It must be an
        /// integer with a value greater than zero.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int MaxItem { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.FileSystemId = this.FileSystemId;
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
            context.MountTargetId = this.MountTargetId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.ElasticFileSystem.Model.DescribeMountTargetsRequest();
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            if (cmdletContext.MountTargetId != null)
            {
                request.MountTargetId = cmdletContext.MountTargetId;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxItems))
            {
                _emitLimit = cmdletContext.MaxItems;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.Marker) || AutoIterationHelpers.HasValue(cmdletContext.MaxItems);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = client.DescribeMountTargets(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.MountTargets;
                        notes = new Dictionary<string, object>();
                        notes["Marker"] = response.Marker;
                        notes["NextMarker"] = response.NextMarker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.MountTargets.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.NextMarker;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String FileSystemId { get; set; }
            public System.String Marker { get; set; }
            public int? MaxItems { get; set; }
            public System.String MountTargetId { get; set; }
        }
        
    }
}
