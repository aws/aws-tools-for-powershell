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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Updates a gateway's metadata, which includes the gateway's name, time zone, and metadata
    /// cache size. To specify which gateway to update, use the Amazon Resource Name (ARN)
    /// of the gateway in your request.
    /// 
    ///  <note><para>
    /// For gateways activated after September 2, 2015, the gateway's ARN contains the gateway
    /// ID rather than the gateway name. However, changing the name of the gateway has no
    /// effect on the gateway's ARN.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "SGGatewayInformation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StorageGateway.Model.UpdateGatewayInformationResponse")]
    [AWSCmdlet("Calls the AWS Storage Gateway UpdateGatewayInformation API operation.", Operation = new[] {"UpdateGatewayInformation"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.UpdateGatewayInformationResponse))]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.UpdateGatewayInformationResponse",
        "This cmdlet returns an Amazon.StorageGateway.Model.UpdateGatewayInformationResponse object containing multiple properties."
    )]
    public partial class UpdateSGGatewayInformationCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CloudWatchLogGroupARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon CloudWatch log group that you want to
        /// use to monitor and log events in the gateway.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/WhatIsCloudWatchLogs.html">What
        /// is Amazon CloudWatch Logs?</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloudWatchLogGroupARN { get; set; }
        #endregion
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter GatewayCapacity
        /// <summary>
        /// <para>
        /// <para>Specifies the size of the gateway's metadata cache. This setting impacts gateway performance
        /// and hardware recommendations. For more information, see <a href="https://docs.aws.amazon.com/filegateway/latest/files3/performance-multiple-file-shares.html">Performance
        /// guidance for gateways with multiple file shares</a> in the <i>Amazon S3 File Gateway
        /// User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StorageGateway.GatewayCapacity")]
        public Amazon.StorageGateway.GatewayCapacity GatewayCapacity { get; set; }
        #endregion
        
        #region Parameter GatewayName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String GatewayName { get; set; }
        #endregion
        
        #region Parameter GatewayTimezone
        /// <summary>
        /// <para>
        /// <para>A value that indicates the time zone of the gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String GatewayTimezone { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.UpdateGatewayInformationResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.UpdateGatewayInformationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SGGatewayInformation (UpdateGatewayInformation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.UpdateGatewayInformationResponse, UpdateSGGatewayInformationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CloudWatchLogGroupARN = this.CloudWatchLogGroupARN;
            context.GatewayARN = this.GatewayARN;
            #if MODULAR
            if (this.GatewayARN == null && ParameterWasBound(nameof(this.GatewayARN)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GatewayCapacity = this.GatewayCapacity;
            context.GatewayName = this.GatewayName;
            context.GatewayTimezone = this.GatewayTimezone;
            
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
            var request = new Amazon.StorageGateway.Model.UpdateGatewayInformationRequest();
            
            if (cmdletContext.CloudWatchLogGroupARN != null)
            {
                request.CloudWatchLogGroupARN = cmdletContext.CloudWatchLogGroupARN;
            }
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
            }
            if (cmdletContext.GatewayCapacity != null)
            {
                request.GatewayCapacity = cmdletContext.GatewayCapacity;
            }
            if (cmdletContext.GatewayName != null)
            {
                request.GatewayName = cmdletContext.GatewayName;
            }
            if (cmdletContext.GatewayTimezone != null)
            {
                request.GatewayTimezone = cmdletContext.GatewayTimezone;
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
        
        private Amazon.StorageGateway.Model.UpdateGatewayInformationResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.UpdateGatewayInformationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "UpdateGatewayInformation");
            try
            {
                #if DESKTOP
                return client.UpdateGatewayInformation(request);
                #elif CORECLR
                return client.UpdateGatewayInformationAsync(request).GetAwaiter().GetResult();
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
            public System.String CloudWatchLogGroupARN { get; set; }
            public System.String GatewayARN { get; set; }
            public Amazon.StorageGateway.GatewayCapacity GatewayCapacity { get; set; }
            public System.String GatewayName { get; set; }
            public System.String GatewayTimezone { get; set; }
            public System.Func<Amazon.StorageGateway.Model.UpdateGatewayInformationResponse, UpdateSGGatewayInformationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
