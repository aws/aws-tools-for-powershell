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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Obtains information about the directory snapshots that belong to this account.
    /// 
    ///  
    /// <para>
    /// This operation supports pagination with the use of the <i>NextToken</i> request and
    /// response parameters. If more results are available, the <i>DescribeSnapshots.NextToken</i>
    /// member contains a token that you pass in the next call to <a>DescribeSnapshots</a>
    /// to retrieve the next set of items.
    /// </para><para>
    /// You can also specify a maximum number of return results with the <i>Limit</i> parameter.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DSSnapshot")]
    [OutputType("Amazon.DirectoryService.Model.Snapshot")]
    [AWSCmdlet("Invokes the DescribeSnapshots operation against AWS Directory Service.", Operation = new[] {"DescribeSnapshots"})]
    [AWSCmdletOutput("Amazon.DirectoryService.Model.Snapshot",
        "This cmdlet returns a collection of Snapshot objects.",
        "The service call response (type DescribeSnapshotsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetDSSnapshotCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The identifier of the directory to retrieve snapshot information for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String DirectoryId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of identifiers of the snapshots to obtain the information for. If this member
        /// is null or empty, all snapshots are returned using the <i>Limit</i> and <i>NextToken</i>
        /// members.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SnapshotIds")]
        public System.String[] SnapshotId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum number of objects to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Limit { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The <i>DescribeSnapshotsResult.NextToken</i> value from a previous call to <a>DescribeSnapshots</a>.
        /// Pass null if this is the first call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DirectoryId = this.DirectoryId;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            if (this.SnapshotId != null)
            {
                context.SnapshotIds = new List<String>(this.SnapshotId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeSnapshotsRequest();
            
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.SnapshotIds != null)
            {
                request.SnapshotIds = cmdletContext.SnapshotIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeSnapshots(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Snapshots;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String DirectoryId { get; set; }
            public Int32? Limit { get; set; }
            public String NextToken { get; set; }
            public List<String> SnapshotIds { get; set; }
        }
        
    }
}
