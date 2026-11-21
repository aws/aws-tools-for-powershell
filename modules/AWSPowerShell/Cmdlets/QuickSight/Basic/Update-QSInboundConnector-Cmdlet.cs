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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Updates an inbound connector. You can change its name, description, status, and configuration.
    /// You can't change the connector type after the connector is created.
    /// </summary>
    [Cmdlet("Update", "QSInboundConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.UpdateInboundConnectorResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateInboundConnector API operation.", Operation = new[] {"UpdateInboundConnector"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateInboundConnectorResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.UpdateInboundConnectorResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.UpdateInboundConnectorResponse object containing multiple properties."
    )]
    public partial class UpdateQSInboundConnectorCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that contains the Quick Sight account.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The new description of the inbound connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InboundConnectorId
        /// <summary>
        /// <para>
        /// <para>The ID of the inbound connector.</para>
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
        public System.String InboundConnectorId { get; set; }
        #endregion
        
        #region Parameter InboundConnectorStatus
        /// <summary>
        /// <para>
        /// <para>The new status of the inbound connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.InboundConnectorStatus")]
        public Amazon.QuickSight.InboundConnectorStatus InboundConnectorStatus { get; set; }
        #endregion
        
        #region Parameter InboundConnectorConfiguration_InboundConnectorType
        /// <summary>
        /// <para>
        /// <para>The type of the inbound connector. You can't change the type after the connector is
        /// created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.InboundConnectorType")]
        public Amazon.QuickSight.InboundConnectorType InboundConnectorConfiguration_InboundConnectorType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The new name of the inbound connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateInboundConnectorResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateInboundConnectorResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InboundConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSInboundConnector (UpdateInboundConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateInboundConnectorResponse, UpdateQSInboundConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.InboundConnectorConfiguration_InboundConnectorType = this.InboundConnectorConfiguration_InboundConnectorType;
            context.InboundConnectorId = this.InboundConnectorId;
            #if MODULAR
            if (this.InboundConnectorId == null && ParameterWasBound(nameof(this.InboundConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter InboundConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InboundConnectorStatus = this.InboundConnectorStatus;
            context.Name = this.Name;
            
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
            var request = new Amazon.QuickSight.Model.UpdateInboundConnectorRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate InboundConnectorConfiguration
            var requestInboundConnectorConfigurationIsNull = true;
            request.InboundConnectorConfiguration = new Amazon.QuickSight.Model.InboundConnectorConfig();
            Amazon.QuickSight.InboundConnectorType requestInboundConnectorConfiguration_inboundConnectorConfiguration_InboundConnectorType = null;
            if (cmdletContext.InboundConnectorConfiguration_InboundConnectorType != null)
            {
                requestInboundConnectorConfiguration_inboundConnectorConfiguration_InboundConnectorType = cmdletContext.InboundConnectorConfiguration_InboundConnectorType;
            }
            if (requestInboundConnectorConfiguration_inboundConnectorConfiguration_InboundConnectorType != null)
            {
                request.InboundConnectorConfiguration.InboundConnectorType = requestInboundConnectorConfiguration_inboundConnectorConfiguration_InboundConnectorType;
                requestInboundConnectorConfigurationIsNull = false;
            }
             // determine if request.InboundConnectorConfiguration should be set to null
            if (requestInboundConnectorConfigurationIsNull)
            {
                request.InboundConnectorConfiguration = null;
            }
            if (cmdletContext.InboundConnectorId != null)
            {
                request.InboundConnectorId = cmdletContext.InboundConnectorId;
            }
            if (cmdletContext.InboundConnectorStatus != null)
            {
                request.InboundConnectorStatus = cmdletContext.InboundConnectorStatus;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.QuickSight.Model.UpdateInboundConnectorResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateInboundConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateInboundConnector");
            try
            {
                return client.UpdateInboundConnectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String Description { get; set; }
            public Amazon.QuickSight.InboundConnectorType InboundConnectorConfiguration_InboundConnectorType { get; set; }
            public System.String InboundConnectorId { get; set; }
            public Amazon.QuickSight.InboundConnectorStatus InboundConnectorStatus { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateInboundConnectorResponse, UpdateQSInboundConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
