/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Generates a CloudFormation template that streamlines and automates the integration
    /// of VPC flow logs with Amazon Athena. This make it easier for you to query and gain
    /// insights from VPC flow logs data. Based on the information that you provide, we configure
    /// resources in the template to do the following:
    /// 
    ///  <ul><li><para>
    /// Create a table in Athena that maps fields to a custom log format
    /// </para></li><li><para>
    /// Create a Lambda function that updates the table with new partitions on a daily, weekly,
    /// or monthly basis
    /// </para></li><li><para>
    /// Create a table partitioned between two timestamps in the past
    /// </para></li><li><para>
    /// Create a set of named queries in Athena that you can use to get started quickly
    /// </para></li></ul><note><para><c>GetFlowLogsIntegrationTemplate</c> does not support integration between Amazon
    /// Web Services Transit Gateway Flow Logs and Amazon Athena.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "EC2FlowLogsIntegrationTemplate")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) GetFlowLogsIntegrationTemplate API operation.", Operation = new[] {"GetFlowLogsIntegrationTemplate"}, SelectReturnType = typeof(Amazon.EC2.Model.GetFlowLogsIntegrationTemplateResponse))]
    [AWSCmdletOutput("System.String or Amazon.EC2.Model.GetFlowLogsIntegrationTemplateResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EC2.Model.GetFlowLogsIntegrationTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2FlowLogsIntegrationTemplateCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IntegrateServices_AthenaIntegration
        /// <summary>
        /// <para>
        /// <para>Information about the integration with Amazon Athena.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrateServices_AthenaIntegrations")]
        public Amazon.EC2.Model.AthenaIntegration[] IntegrateServices_AthenaIntegration { get; set; }
        #endregion
        
        #region Parameter ConfigDeliveryS3DestinationArn
        /// <summary>
        /// <para>
        /// <para>To store the CloudFormation template in Amazon S3, specify the location in Amazon
        /// S3.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ConfigDeliveryS3DestinationArn { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter FlowLogId
        /// <summary>
        /// <para>
        /// <para>The ID of the flow log.</para>
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
        public System.String FlowLogId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Result'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.GetFlowLogsIntegrationTemplateResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.GetFlowLogsIntegrationTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Result";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.GetFlowLogsIntegrationTemplateResponse, GetEC2FlowLogsIntegrationTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigDeliveryS3DestinationArn = this.ConfigDeliveryS3DestinationArn;
            #if MODULAR
            if (this.ConfigDeliveryS3DestinationArn == null && ParameterWasBound(nameof(this.ConfigDeliveryS3DestinationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigDeliveryS3DestinationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DryRun = this.DryRun;
            context.FlowLogId = this.FlowLogId;
            #if MODULAR
            if (this.FlowLogId == null && ParameterWasBound(nameof(this.FlowLogId)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowLogId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.IntegrateServices_AthenaIntegration != null)
            {
                context.IntegrateServices_AthenaIntegration = new List<Amazon.EC2.Model.AthenaIntegration>(this.IntegrateServices_AthenaIntegration);
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
            var request = new Amazon.EC2.Model.GetFlowLogsIntegrationTemplateRequest();
            
            if (cmdletContext.ConfigDeliveryS3DestinationArn != null)
            {
                request.ConfigDeliveryS3DestinationArn = cmdletContext.ConfigDeliveryS3DestinationArn;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.FlowLogId != null)
            {
                request.FlowLogId = cmdletContext.FlowLogId;
            }
            
             // populate IntegrateServices
            var requestIntegrateServicesIsNull = true;
            request.IntegrateServices = new Amazon.EC2.Model.IntegrateServices();
            List<Amazon.EC2.Model.AthenaIntegration> requestIntegrateServices_integrateServices_AthenaIntegration = null;
            if (cmdletContext.IntegrateServices_AthenaIntegration != null)
            {
                requestIntegrateServices_integrateServices_AthenaIntegration = cmdletContext.IntegrateServices_AthenaIntegration;
            }
            if (requestIntegrateServices_integrateServices_AthenaIntegration != null)
            {
                request.IntegrateServices.AthenaIntegrations = requestIntegrateServices_integrateServices_AthenaIntegration;
                requestIntegrateServicesIsNull = false;
            }
             // determine if request.IntegrateServices should be set to null
            if (requestIntegrateServicesIsNull)
            {
                request.IntegrateServices = null;
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
        
        private Amazon.EC2.Model.GetFlowLogsIntegrationTemplateResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetFlowLogsIntegrationTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "GetFlowLogsIntegrationTemplate");
            try
            {
                return client.GetFlowLogsIntegrationTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfigDeliveryS3DestinationArn { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String FlowLogId { get; set; }
            public List<Amazon.EC2.Model.AthenaIntegration> IntegrateServices_AthenaIntegration { get; set; }
            public System.Func<Amazon.EC2.Model.GetFlowLogsIntegrationTemplateResponse, GetEC2FlowLogsIntegrationTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Result;
        }
        
    }
}
