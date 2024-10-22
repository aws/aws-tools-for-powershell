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
using Amazon.Appflow;
using Amazon.Appflow.Model;

namespace Amazon.PowerShell.Cmdlets.AF
{
    /// <summary>
    /// Updates a custom connector that you've previously registered. This operation updates
    /// the connector with one of the following:
    /// 
    ///  <ul><li><para>
    /// The latest version of the AWS Lambda function that's assigned to the connector
    /// </para></li><li><para>
    /// A new AWS Lambda function that you specify
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "AFConnectorRegistration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Appflow UpdateConnectorRegistration API operation.", Operation = new[] {"UpdateConnectorRegistration"}, SelectReturnType = typeof(Amazon.Appflow.Model.UpdateConnectorRegistrationResponse))]
    [AWSCmdletOutput("System.String or Amazon.Appflow.Model.UpdateConnectorRegistrationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Appflow.Model.UpdateConnectorRegistrationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAFConnectorRegistrationCmdlet : AmazonAppflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectorLabel
        /// <summary>
        /// <para>
        /// <para>The name of the connector. The name is unique for each connector registration in your
        /// AWS account.</para>
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
        public System.String ConnectorLabel { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description about the update that you're applying to the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Lambda_LambdaArn
        /// <summary>
        /// <para>
        /// <para>Lambda ARN of the connector being registered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorProvisioningConfig_Lambda_LambdaArn")]
        public System.String Lambda_LambdaArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The <c>clientToken</c> parameter is an idempotency token. It ensures that your <c>UpdateConnectorRegistration</c>
        /// request completes only once. You choose the value to pass. For example, if you don't
        /// receive a response from your request, you can safely retry the request with the same
        /// <c>clientToken</c> parameter value.</para><para>If you omit a <c>clientToken</c> value, the Amazon Web Services SDK that you are using
        /// inserts a value for you. This way, the SDK can safely retry requests multiple times
        /// after a network error. You must provide your own value for other use cases.</para><para>If you specify input parameters that differ from your first request, an error occurs.
        /// If you use a different value for <c>clientToken</c>, Amazon AppFlow considers it a
        /// new call to <c>UpdateConnectorRegistration</c>. The token is active for 8 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectorArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Appflow.Model.UpdateConnectorRegistrationResponse).
        /// Specifying the name of a property of type Amazon.Appflow.Model.UpdateConnectorRegistrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectorArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectorLabel), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AFConnectorRegistration (UpdateConnectorRegistration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Appflow.Model.UpdateConnectorRegistrationResponse, UpdateAFConnectorRegistrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ConnectorLabel = this.ConnectorLabel;
            #if MODULAR
            if (this.ConnectorLabel == null && ParameterWasBound(nameof(this.ConnectorLabel)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorLabel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Lambda_LambdaArn = this.Lambda_LambdaArn;
            context.Description = this.Description;
            
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
            var request = new Amazon.Appflow.Model.UpdateConnectorRegistrationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConnectorLabel != null)
            {
                request.ConnectorLabel = cmdletContext.ConnectorLabel;
            }
            
             // populate ConnectorProvisioningConfig
            var requestConnectorProvisioningConfigIsNull = true;
            request.ConnectorProvisioningConfig = new Amazon.Appflow.Model.ConnectorProvisioningConfig();
            Amazon.Appflow.Model.LambdaConnectorProvisioningConfig requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda = null;
            
             // populate Lambda
            var requestConnectorProvisioningConfig_connectorProvisioningConfig_LambdaIsNull = true;
            requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda = new Amazon.Appflow.Model.LambdaConnectorProvisioningConfig();
            System.String requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda_lambda_LambdaArn = null;
            if (cmdletContext.Lambda_LambdaArn != null)
            {
                requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda_lambda_LambdaArn = cmdletContext.Lambda_LambdaArn;
            }
            if (requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda_lambda_LambdaArn != null)
            {
                requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda.LambdaArn = requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda_lambda_LambdaArn;
                requestConnectorProvisioningConfig_connectorProvisioningConfig_LambdaIsNull = false;
            }
             // determine if requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda should be set to null
            if (requestConnectorProvisioningConfig_connectorProvisioningConfig_LambdaIsNull)
            {
                requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda = null;
            }
            if (requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda != null)
            {
                request.ConnectorProvisioningConfig.Lambda = requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda;
                requestConnectorProvisioningConfigIsNull = false;
            }
             // determine if request.ConnectorProvisioningConfig should be set to null
            if (requestConnectorProvisioningConfigIsNull)
            {
                request.ConnectorProvisioningConfig = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
        
        private Amazon.Appflow.Model.UpdateConnectorRegistrationResponse CallAWSServiceOperation(IAmazonAppflow client, Amazon.Appflow.Model.UpdateConnectorRegistrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Appflow", "UpdateConnectorRegistration");
            try
            {
                #if DESKTOP
                return client.UpdateConnectorRegistration(request);
                #elif CORECLR
                return client.UpdateConnectorRegistrationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ConnectorLabel { get; set; }
            public System.String Lambda_LambdaArn { get; set; }
            public System.String Description { get; set; }
            public System.Func<Amazon.Appflow.Model.UpdateConnectorRegistrationResponse, UpdateAFConnectorRegistrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectorArn;
        }
        
    }
}
