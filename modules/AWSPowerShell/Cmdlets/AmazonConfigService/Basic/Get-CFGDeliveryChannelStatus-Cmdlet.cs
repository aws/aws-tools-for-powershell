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
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns the current status of the specified delivery channel. If a delivery channel
    /// is not specified, this action returns the current status of all delivery channels
    /// associated with the account.
    /// 
    ///  <note><para>
    /// Currently, you can specify only one delivery channel per region in your account.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CFGDeliveryChannelStatus")]
    [OutputType("Amazon.ConfigService.Model.DeliveryChannelStatus")]
    [AWSCmdlet("Calls the AWS Config DescribeDeliveryChannelStatus API operation.", Operation = new[] {"DescribeDeliveryChannelStatus"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.DeliveryChannelStatus",
        "This cmdlet returns a collection of DeliveryChannelStatus objects.",
        "The service call response (type Amazon.ConfigService.Model.DescribeDeliveryChannelStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFGDeliveryChannelStatusCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DeliveryChannelName
        /// <summary>
        /// <para>
        /// <para>A list of delivery channel names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("DeliveryChannelNames")]
        public System.String[] DeliveryChannelName { get; set; }
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
            
            if (this.DeliveryChannelName != null)
            {
                context.DeliveryChannelNames = new List<System.String>(this.DeliveryChannelName);
            }
            
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
            var request = new Amazon.ConfigService.Model.DescribeDeliveryChannelStatusRequest();
            
            if (cmdletContext.DeliveryChannelNames != null)
            {
                request.DeliveryChannelNames = cmdletContext.DeliveryChannelNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DeliveryChannelsStatus;
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
        
        private Amazon.ConfigService.Model.DescribeDeliveryChannelStatusResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.DescribeDeliveryChannelStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "DescribeDeliveryChannelStatus");
            try
            {
                #if DESKTOP
                return client.DescribeDeliveryChannelStatus(request);
                #elif CORECLR
                return client.DescribeDeliveryChannelStatusAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> DeliveryChannelNames { get; set; }
        }
        
    }
}
