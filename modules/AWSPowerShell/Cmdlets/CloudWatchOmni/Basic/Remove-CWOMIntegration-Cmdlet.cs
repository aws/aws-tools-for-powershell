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
using Amazon.CloudWatchOmni;
using Amazon.CloudWatchOmni.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWOM
{
    /// <summary>
    /// Deletes an integration. Returns the resulting status.
    /// </summary>
    [Cmdlet("Remove", "CWOMIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the CloudWatch Omni DeleteIntegration API operation.", Operation = new[] {"DeleteIntegration"}, SelectReturnType = typeof(Amazon.CloudWatchOmni.Model.DeleteIntegrationResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatchOmni.Model.DeleteIntegrationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatchOmni.Model.DeleteIntegrationResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveCWOMIntegrationCmdlet : AmazonCloudWatchOmniClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Identifier_IntegrationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name of the integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Identifier_IntegrationArn { get; set; }
        #endregion
        
        #region Parameter Identifier_IntegrationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Identifier_IntegrationId { get; set; }
        #endregion
        
        #region Parameter Identifier_IntegrationName
        /// <summary>
        /// <para>
        /// <para>The name of the integration; unique within the account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Identifier_IntegrationName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchOmni.Model.DeleteIntegrationResponse).
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CWOMIntegration (DeleteIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchOmni.Model.DeleteIntegrationResponse, RemoveCWOMIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Identifier_IntegrationArn = this.Identifier_IntegrationArn;
            context.Identifier_IntegrationId = this.Identifier_IntegrationId;
            context.Identifier_IntegrationName = this.Identifier_IntegrationName;
            
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
            var request = new Amazon.CloudWatchOmni.Model.DeleteIntegrationRequest();
            
            
             // populate Identifier
            var requestIdentifierIsNull = true;
            request.Identifier = new Amazon.CloudWatchOmni.Model.IntegrationIdentifier();
            System.String requestIdentifier_identifier_IntegrationArn = null;
            if (cmdletContext.Identifier_IntegrationArn != null)
            {
                requestIdentifier_identifier_IntegrationArn = cmdletContext.Identifier_IntegrationArn;
            }
            if (requestIdentifier_identifier_IntegrationArn != null)
            {
                request.Identifier.IntegrationArn = requestIdentifier_identifier_IntegrationArn;
                requestIdentifierIsNull = false;
            }
            System.String requestIdentifier_identifier_IntegrationId = null;
            if (cmdletContext.Identifier_IntegrationId != null)
            {
                requestIdentifier_identifier_IntegrationId = cmdletContext.Identifier_IntegrationId;
            }
            if (requestIdentifier_identifier_IntegrationId != null)
            {
                request.Identifier.IntegrationId = requestIdentifier_identifier_IntegrationId;
                requestIdentifierIsNull = false;
            }
            System.String requestIdentifier_identifier_IntegrationName = null;
            if (cmdletContext.Identifier_IntegrationName != null)
            {
                requestIdentifier_identifier_IntegrationName = cmdletContext.Identifier_IntegrationName;
            }
            if (requestIdentifier_identifier_IntegrationName != null)
            {
                request.Identifier.IntegrationName = requestIdentifier_identifier_IntegrationName;
                requestIdentifierIsNull = false;
            }
             // determine if request.Identifier should be set to null
            if (requestIdentifierIsNull)
            {
                request.Identifier = null;
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
        
        private Amazon.CloudWatchOmni.Model.DeleteIntegrationResponse CallAWSServiceOperation(IAmazonCloudWatchOmni client, Amazon.CloudWatchOmni.Model.DeleteIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Omni", "DeleteIntegration");
            try
            {
                return client.DeleteIntegrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Identifier_IntegrationArn { get; set; }
            public System.String Identifier_IntegrationId { get; set; }
            public System.String Identifier_IntegrationName { get; set; }
            public System.Func<Amazon.CloudWatchOmni.Model.DeleteIntegrationResponse, RemoveCWOMIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
