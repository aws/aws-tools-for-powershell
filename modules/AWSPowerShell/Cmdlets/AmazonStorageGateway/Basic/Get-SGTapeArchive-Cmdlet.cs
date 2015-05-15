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
    /// Retrieves an archived virtual tape from the virtual tape shelf (VTS) to a gateway-VTL.
    /// Virtual tapes archived in the VTS are not associated with any gateway. However after
    /// a tape is retrieved, it is associated with a gateway, even though it is also listed
    /// in the VTS.
    /// 
    ///  
    /// <para>
    /// Once a tape is successfully retrieved to a gateway, it cannot be retrieved again to
    /// another gateway. You must archive the tape again before you can retrieve it to another
    /// gateway.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SGTapeArchive")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the RetrieveTapeArchive operation against AWS Storage Gateway.", Operation = new[] {"RetrieveTapeArchive"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type RetrieveTapeArchiveResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetSGTapeArchiveCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the gateway you want to retrieve the virtual tape
        /// to. Use the <a>ListGateways</a> operation to return a list of gateways for your account
        /// and region.</para><para>You retrieve archived virtual tapes to only one gateway and the gateway must be a
        /// gateway-VTL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String GatewayARN { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the virtual tape you want to retrieve from the virtual
        /// tape shelf (VTS). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String TapeARN { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.GatewayARN = this.GatewayARN;
            context.TapeARN = this.TapeARN;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new RetrieveTapeArchiveRequest();
            
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
            }
            if (cmdletContext.TapeARN != null)
            {
                request.TapeARN = cmdletContext.TapeARN;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.RetrieveTapeArchive(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TapeARN;
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
            public String GatewayARN { get; set; }
            public String TapeARN { get; set; }
        }
        
    }
}
