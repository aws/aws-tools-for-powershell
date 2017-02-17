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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Deprecated in favor of <a>DescribeHostedConnections</a>.
    /// 
    ///  
    /// <para>
    /// Returns a list of connections that have been provisioned on the given interconnect.
    /// </para><note><para>
    /// This is intended for use by AWS Direct Connect partners only.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "DCConnectionsOnInterconnect")]
    [OutputType("Amazon.DirectConnect.Model.Connection")]
    [AWSCmdlet("Invokes the DescribeConnectionsOnInterconnect operation against AWS Direct Connect.", Operation = new[] {"DescribeConnectionsOnInterconnect"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.Connection",
        "This cmdlet returns a collection of Connection objects.",
        "The service call response (type Amazon.DirectConnect.Model.DescribeConnectionsOnInterconnectResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDCConnectionsOnInterconnectCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter InterconnectId
        /// <summary>
        /// <para>
        /// <para>ID of the interconnect on which a list of connection is provisioned.</para><para>Example: dxcon-abc123</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InterconnectId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.InterconnectId = this.InterconnectId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DirectConnect.Model.DescribeConnectionsOnInterconnectRequest();
            
            if (cmdletContext.InterconnectId != null)
            {
                request.InterconnectId = cmdletContext.InterconnectId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Connections;
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
        
        #region AWS Service Operation Call
        
        private static Amazon.DirectConnect.Model.DescribeConnectionsOnInterconnectResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.DescribeConnectionsOnInterconnectRequest request)
        {
            #if DESKTOP
            return client.DescribeConnectionsOnInterconnect(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeConnectionsOnInterconnectAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String InterconnectId { get; set; }
        }
        
    }
}
