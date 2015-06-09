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
    /// This operation returns the description of the gateway volumes specified in the request.
    /// The list of gateway volumes in the request must be from one gateway. In the response
    /// Amazon Storage Gateway returns volume information sorted by volume ARNs.
    /// </summary>
    [Cmdlet("Get", "SGStorediSCSIVolume")]
    [OutputType("Amazon.StorageGateway.Model.StorediSCSIVolume")]
    [AWSCmdlet("Invokes the DescribeStorediSCSIVolumes operation against AWS Storage Gateway.", Operation = new[] {"DescribeStorediSCSIVolumes"})]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.StorediSCSIVolume",
        "This cmdlet returns a collection of StorediSCSIVolume objects.",
        "The service call response (type DescribeStorediSCSIVolumesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetSGStorediSCSIVolumeCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>An array of strings where each string represents the Amazon Resource Name (ARN) of
        /// a stored volume. All of the specified stored volumes must from the same gateway. Use
        /// <a>ListVolumes</a> to get volume ARNs for a gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String[] VolumeARNs { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.VolumeARNs != null)
            {
                context.VolumeARNs = new List<String>(this.VolumeARNs);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeStorediSCSIVolumesRequest();
            
            if (cmdletContext.VolumeARNs != null)
            {
                request.VolumeARNs = cmdletContext.VolumeARNs;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeStorediSCSIVolumes(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.StorediSCSIVolumes;
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
            public List<String> VolumeARNs { get; set; }
        }
        
    }
}
