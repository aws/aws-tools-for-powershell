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
using Amazon.Route53;
using Amazon.Route53.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Updates the features configuration for a hosted zone. This operation allows you to
    /// enable or disable specific features for your hosted zone, such as accelerated recovery.
    /// 
    ///  
    /// <para>
    /// Accelerated recovery enables you to update DNS records in your public hosted zone
    /// even when the us-east-1 region is unavailable.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "R53HostedZoneFeature", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Route 53 UpdateHostedZoneFeatures API operation.", Operation = new[] {"UpdateHostedZoneFeatures"}, SelectReturnType = typeof(Amazon.Route53.Model.UpdateHostedZoneFeaturesResponse))]
    [AWSCmdletOutput("None or Amazon.Route53.Model.UpdateHostedZoneFeaturesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Route53.Model.UpdateHostedZoneFeaturesResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateR53HostedZoneFeatureCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EnableAcceleratedRecovery
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable accelerated recovery for the hosted zone. Set to <c>true</c>
        /// to enable accelerated recovery, or <c>false</c> to disable it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableAcceleratedRecovery { get; set; }
        #endregion
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone for which you want to update features. This is the unique
        /// identifier for your hosted zone.</para>
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
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.UpdateHostedZoneFeaturesResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HostedZoneId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53HostedZoneFeature (UpdateHostedZoneFeatures)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.UpdateHostedZoneFeaturesResponse, UpdateR53HostedZoneFeatureCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HostedZoneId = this.HostedZoneId;
            #if MODULAR
            if (this.HostedZoneId == null && ParameterWasBound(nameof(this.HostedZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter HostedZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnableAcceleratedRecovery = this.EnableAcceleratedRecovery;
            
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
            var request = new Amazon.Route53.Model.UpdateHostedZoneFeaturesRequest();
            
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            if (cmdletContext.EnableAcceleratedRecovery != null)
            {
                request.EnableAcceleratedRecovery = cmdletContext.EnableAcceleratedRecovery.Value;
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
        
        private Amazon.Route53.Model.UpdateHostedZoneFeaturesResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.UpdateHostedZoneFeaturesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "UpdateHostedZoneFeatures");
            try
            {
                return client.UpdateHostedZoneFeaturesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String HostedZoneId { get; set; }
            public System.Boolean? EnableAcceleratedRecovery { get; set; }
            public System.Func<Amazon.Route53.Model.UpdateHostedZoneFeaturesResponse, UpdateR53HostedZoneFeatureCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
