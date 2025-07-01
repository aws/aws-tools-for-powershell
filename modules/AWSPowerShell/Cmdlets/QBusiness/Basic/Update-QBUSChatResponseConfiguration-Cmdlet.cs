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
using Amazon.QBusiness;
using Amazon.QBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.QBUS
{
    /// <summary>
    /// Updates an existing chat response configuration in an Amazon Q Business application.
    /// This operation allows administrators to modify configuration settings, display name,
    /// and response parameters to refine how the system generates responses.
    /// </summary>
    [Cmdlet("Update", "QBUSChatResponseConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon QBusiness UpdateChatResponseConfiguration API operation.", Operation = new[] {"UpdateChatResponseConfiguration"}, SelectReturnType = typeof(Amazon.QBusiness.Model.UpdateChatResponseConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.QBusiness.Model.UpdateChatResponseConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.QBusiness.Model.UpdateChatResponseConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateQBUSChatResponseConfigurationCmdlet : AmazonQBusinessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Amazon Q Business application containing the chat response
        /// configuration to update.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter ChatResponseConfigurationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the chat response configuration to update within the specified
        /// application.</para>
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
        public System.String ChatResponseConfigurationId { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The new human-readable name to assign to the chat response configuration, making it
        /// easier to identify among multiple configurations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter ResponseConfiguration
        /// <summary>
        /// <para>
        /// <para>The updated collection of response configuration settings that define how Amazon Q
        /// Business generates and formats responses to user queries.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ResponseConfigurations")]
        public System.Collections.Hashtable ResponseConfiguration { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotency of the request. This helps
        /// prevent the same update from being processed multiple times if retries occur.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QBusiness.Model.UpdateChatResponseConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ChatResponseConfigurationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ChatResponseConfigurationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ChatResponseConfigurationId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QBUSChatResponseConfiguration (UpdateChatResponseConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QBusiness.Model.UpdateChatResponseConfigurationResponse, UpdateQBUSChatResponseConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ChatResponseConfigurationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChatResponseConfigurationId = this.ChatResponseConfigurationId;
            #if MODULAR
            if (this.ChatResponseConfigurationId == null && ParameterWasBound(nameof(this.ChatResponseConfigurationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ChatResponseConfigurationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.DisplayName = this.DisplayName;
            if (this.ResponseConfiguration != null)
            {
                context.ResponseConfiguration = new Dictionary<System.String, Amazon.QBusiness.Model.ResponseConfiguration>(StringComparer.Ordinal);
                foreach (var hashKey in this.ResponseConfiguration.Keys)
                {
                    context.ResponseConfiguration.Add((String)hashKey, (Amazon.QBusiness.Model.ResponseConfiguration)(this.ResponseConfiguration[hashKey]));
                }
            }
            #if MODULAR
            if (this.ResponseConfiguration == null && ParameterWasBound(nameof(this.ResponseConfiguration)))
            {
                WriteWarning("You are passing $null as a value for parameter ResponseConfiguration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QBusiness.Model.UpdateChatResponseConfigurationRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.ChatResponseConfigurationId != null)
            {
                request.ChatResponseConfigurationId = cmdletContext.ChatResponseConfigurationId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.ResponseConfiguration != null)
            {
                request.ResponseConfigurations = cmdletContext.ResponseConfiguration;
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
        
        private Amazon.QBusiness.Model.UpdateChatResponseConfigurationResponse CallAWSServiceOperation(IAmazonQBusiness client, Amazon.QBusiness.Model.UpdateChatResponseConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QBusiness", "UpdateChatResponseConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateChatResponseConfiguration(request);
                #elif CORECLR
                return client.UpdateChatResponseConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String ChatResponseConfigurationId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DisplayName { get; set; }
            public Dictionary<System.String, Amazon.QBusiness.Model.ResponseConfiguration> ResponseConfiguration { get; set; }
            public System.Func<Amazon.QBusiness.Model.UpdateChatResponseConfigurationResponse, UpdateQBUSChatResponseConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
