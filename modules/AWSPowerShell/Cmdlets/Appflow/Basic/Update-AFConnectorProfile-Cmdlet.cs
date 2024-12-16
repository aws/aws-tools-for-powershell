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
    /// Updates a given connector profile associated with your account.
    /// </summary>
    [Cmdlet("Update", "AFConnectorProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Appflow UpdateConnectorProfile API operation.", Operation = new[] {"UpdateConnectorProfile"}, SelectReturnType = typeof(Amazon.Appflow.Model.UpdateConnectorProfileResponse))]
    [AWSCmdletOutput("System.String or Amazon.Appflow.Model.UpdateConnectorProfileResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Appflow.Model.UpdateConnectorProfileResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateAFConnectorProfileCmdlet : AmazonAppflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectionMode
        /// <summary>
        /// <para>
        /// <para> Indicates the connection mode and if it is public or private. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Appflow.ConnectionMode")]
        public Amazon.Appflow.ConnectionMode ConnectionMode { get; set; }
        #endregion
        
        #region Parameter ConnectorProfileConfig
        /// <summary>
        /// <para>
        /// <para> Defines the connector-specific profile configuration and credentials. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Appflow.Model.ConnectorProfileConfig ConnectorProfileConfig { get; set; }
        #endregion
        
        #region Parameter ConnectorProfileName
        /// <summary>
        /// <para>
        /// <para> The name of the connector profile and is unique for each <c>ConnectorProfile</c>
        /// in the Amazon Web Services account. </para>
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
        public System.String ConnectorProfileName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The <c>clientToken</c> parameter is an idempotency token. It ensures that your <c>UpdateConnectorProfile</c>
        /// request completes only once. You choose the value to pass. For example, if you don't
        /// receive a response from your request, you can safely retry the request with the same
        /// <c>clientToken</c> parameter value.</para><para>If you omit a <c>clientToken</c> value, the Amazon Web Services SDK that you are using
        /// inserts a value for you. This way, the SDK can safely retry requests multiple times
        /// after a network error. You must provide your own value for other use cases.</para><para>If you specify input parameters that differ from your first request, an error occurs.
        /// If you use a different value for <c>clientToken</c>, Amazon AppFlow considers it a
        /// new call to <c>UpdateConnectorProfile</c>. The token is active for 8 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectorProfileArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Appflow.Model.UpdateConnectorProfileResponse).
        /// Specifying the name of a property of type Amazon.Appflow.Model.UpdateConnectorProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectorProfileArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectorProfileName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AFConnectorProfile (UpdateConnectorProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Appflow.Model.UpdateConnectorProfileResponse, UpdateAFConnectorProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ConnectionMode = this.ConnectionMode;
            #if MODULAR
            if (this.ConnectionMode == null && ParameterWasBound(nameof(this.ConnectionMode)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConnectorProfileConfig = this.ConnectorProfileConfig;
            #if MODULAR
            if (this.ConnectorProfileConfig == null && ParameterWasBound(nameof(this.ConnectorProfileConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorProfileConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConnectorProfileName = this.ConnectorProfileName;
            #if MODULAR
            if (this.ConnectorProfileName == null && ParameterWasBound(nameof(this.ConnectorProfileName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorProfileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Appflow.Model.UpdateConnectorProfileRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConnectionMode != null)
            {
                request.ConnectionMode = cmdletContext.ConnectionMode;
            }
            if (cmdletContext.ConnectorProfileConfig != null)
            {
                request.ConnectorProfileConfig = cmdletContext.ConnectorProfileConfig;
            }
            if (cmdletContext.ConnectorProfileName != null)
            {
                request.ConnectorProfileName = cmdletContext.ConnectorProfileName;
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
        
        private Amazon.Appflow.Model.UpdateConnectorProfileResponse CallAWSServiceOperation(IAmazonAppflow client, Amazon.Appflow.Model.UpdateConnectorProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Appflow", "UpdateConnectorProfile");
            try
            {
                #if DESKTOP
                return client.UpdateConnectorProfile(request);
                #elif CORECLR
                return client.UpdateConnectorProfileAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Appflow.ConnectionMode ConnectionMode { get; set; }
            public Amazon.Appflow.Model.ConnectorProfileConfig ConnectorProfileConfig { get; set; }
            public System.String ConnectorProfileName { get; set; }
            public System.Func<Amazon.Appflow.Model.UpdateConnectorProfileResponse, UpdateAFConnectorProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectorProfileArn;
        }
        
    }
}
