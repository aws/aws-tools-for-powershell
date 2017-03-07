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
using Amazon.OpsWorksCM;
using Amazon.OpsWorksCM.Model;

namespace Amazon.PowerShell.Cmdlets.OWCM
{
    /// <summary>
    /// Returns the current status of an existing association or disassociation request.
    /// 
    /// 
    ///  
    /// <para>
    ///  A <code>ResourceNotFoundException</code> is thrown when no recent association or
    /// disassociation request with the specified token is found, or when the server does
    /// not exist. A <code>ValidationException</code> is raised when parameters of the request
    /// are not valid. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "OWCMNodeAssociationStatus")]
    [OutputType("Amazon.OpsWorksCM.NodeAssociationStatus")]
    [AWSCmdlet("Invokes the DescribeNodeAssociationStatus operation against AWS OpsWorksCM.", Operation = new[] {"DescribeNodeAssociationStatus"})]
    [AWSCmdletOutput("Amazon.OpsWorksCM.NodeAssociationStatus",
        "This cmdlet returns a NodeAssociationStatus object.",
        "The service call response (type Amazon.OpsWorksCM.Model.DescribeNodeAssociationStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetOWCMNodeAssociationStatusCmdlet : AmazonOpsWorksCMClientCmdlet, IExecutor
    {
        
        #region Parameter NodeAssociationStatusToken
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NodeAssociationStatusToken { get; set; }
        #endregion
        
        #region Parameter ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the server from which to disassociate the node. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ServerName { get; set; }
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
            
            context.NodeAssociationStatusToken = this.NodeAssociationStatusToken;
            context.ServerName = this.ServerName;
            
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
            var request = new Amazon.OpsWorksCM.Model.DescribeNodeAssociationStatusRequest();
            
            if (cmdletContext.NodeAssociationStatusToken != null)
            {
                request.NodeAssociationStatusToken = cmdletContext.NodeAssociationStatusToken;
            }
            if (cmdletContext.ServerName != null)
            {
                request.ServerName = cmdletContext.ServerName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.NodeAssociationStatus;
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
        
        private static Amazon.OpsWorksCM.Model.DescribeNodeAssociationStatusResponse CallAWSServiceOperation(IAmazonOpsWorksCM client, Amazon.OpsWorksCM.Model.DescribeNodeAssociationStatusRequest request)
        {
            #if DESKTOP
            return client.DescribeNodeAssociationStatus(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeNodeAssociationStatusAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String NodeAssociationStatusToken { get; set; }
            public System.String ServerName { get; set; }
        }
        
    }
}
