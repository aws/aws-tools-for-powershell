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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Returns an array of Challenge-Handshake Authentication Protocol (CHAP) credentials
    /// information for a specified iSCSI target, one for each target-initiator pair.
    /// </summary>
    [Cmdlet("Get", "SGChapCredential")]
    [OutputType("Amazon.StorageGateway.Model.ChapInfo")]
    [AWSCmdlet("Invokes the DescribeChapCredentials operation against AWS Storage Gateway.", Operation = new[] {"DescribeChapCredentials"}, LegacyAlias="Get-SGChapCredentials")]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.ChapInfo",
        "This cmdlet returns a collection of ChapInfo objects.",
        "The service call response (type Amazon.StorageGateway.Model.DescribeChapCredentialsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSGChapCredentialCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter TargetARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the iSCSI volume target. Use the <a>DescribeStorediSCSIVolumes</a>
        /// operation to return to retrieve the TargetARN for specified VolumeARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TargetARN { get; set; }
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
            
            context.TargetARN = this.TargetARN;
            
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
            var request = new Amazon.StorageGateway.Model.DescribeChapCredentialsRequest();
            
            if (cmdletContext.TargetARN != null)
            {
                request.TargetARN = cmdletContext.TargetARN;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ChapCredentials;
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
        
        private Amazon.StorageGateway.Model.DescribeChapCredentialsResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.DescribeChapCredentialsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "DescribeChapCredentials");
            #if DESKTOP
            return client.DescribeChapCredentials(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeChapCredentialsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String TargetARN { get; set; }
        }
        
    }
}
