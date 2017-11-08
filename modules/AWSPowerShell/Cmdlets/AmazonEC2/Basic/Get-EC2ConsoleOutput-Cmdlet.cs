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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Gets the console output for the specified instance.
    /// 
    ///  
    /// <para>
    /// Instances do not have a physical monitor through which you can view their console
    /// output. They also lack physical controls that allow you to power up, reboot, or shut
    /// them down. To allow these actions, we provide them through the Amazon EC2 API and
    /// command line interface.
    /// </para><para>
    /// Instance console output is buffered and posted shortly after instance boot, reboot,
    /// and termination. Amazon EC2 preserves the most recent 64 KB output, which is available
    /// for at least one hour after the most recent post.
    /// </para><para>
    /// For Linux instances, the instance console output displays the exact console output
    /// that would normally be displayed on a physical monitor attached to a computer. This
    /// output is buffered because the instance produces it and then posts it to a store where
    /// the instance's owner can retrieve it.
    /// </para><para>
    /// For Windows instances, the instance console output includes output from the EC2Config
    /// service.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2ConsoleOutput")]
    [OutputType("Amazon.EC2.Model.GetConsoleOutputResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud GetConsoleOutput API operation.", Operation = new[] {"GetConsoleOutput"})]
    [AWSCmdletOutput("Amazon.EC2.Model.GetConsoleOutputResponse",
        "This cmdlet returns a Amazon.EC2.Model.GetConsoleOutputResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2ConsoleOutputCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
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
            
            context.InstanceId = this.InstanceId;
            
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
            var request = new Amazon.EC2.Model.GetConsoleOutputRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.EC2.Model.GetConsoleOutputResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetConsoleOutputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "GetConsoleOutput");
            try
            {
                #if DESKTOP
                return client.GetConsoleOutput(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetConsoleOutputAsync(request);
                return task.Result;
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String InstanceId { get; set; }
        }
        
    }
}
