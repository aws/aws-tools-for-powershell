/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Returns details about the specified delivery channel. If a delivery channel is not
    /// specified, this action returns the details of all delivery channels associated with
    /// the account.
    /// 
    ///  <note><para>
    /// Currently, you can specify only one delivery channel per region in your account.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CFGDeliveryChannel")]
    [OutputType("Amazon.ConfigService.Model.DeliveryChannel")]
    [AWSCmdlet("Calls the AWS Config DescribeDeliveryChannels API operation.", Operation = new[] {"DescribeDeliveryChannels"}, SelectReturnType = typeof(Amazon.ConfigService.Model.DescribeDeliveryChannelsResponse), LegacyAlias="Get-CFGDeliveryChannels")]
    [AWSCmdletOutput("Amazon.ConfigService.Model.DeliveryChannel or Amazon.ConfigService.Model.DescribeDeliveryChannelsResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.DeliveryChannel objects.",
        "The service call response (type Amazon.ConfigService.Model.DescribeDeliveryChannelsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFGDeliveryChannelCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeliveryChannelName
        /// <summary>
        /// <para>
        /// <para>A list of delivery channel names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("DeliveryChannelNames")]
        public System.String[] DeliveryChannelName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DeliveryChannels'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.DescribeDeliveryChannelsResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.DescribeDeliveryChannelsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DeliveryChannels";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.DescribeDeliveryChannelsResponse, GetCFGDeliveryChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DeliveryChannelName != null)
            {
                context.DeliveryChannelName = new List<System.String>(this.DeliveryChannelName);
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
            var request = new Amazon.ConfigService.Model.DescribeDeliveryChannelsRequest();
            
            if (cmdletContext.DeliveryChannelName != null)
            {
                request.DeliveryChannelNames = cmdletContext.DeliveryChannelName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.ConfigService.Model.DescribeDeliveryChannelsResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.DescribeDeliveryChannelsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "DescribeDeliveryChannels");
            try
            {
                #if DESKTOP
                return client.DescribeDeliveryChannels(request);
                #elif CORECLR
                return client.DescribeDeliveryChannelsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> DeliveryChannelName { get; set; }
            public System.Func<Amazon.ConfigService.Model.DescribeDeliveryChannelsResponse, GetCFGDeliveryChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DeliveryChannels;
        }
        
    }
}
