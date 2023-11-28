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
using Amazon.QBusiness;
using Amazon.QBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.QBUS
{
    /// <summary>
    /// Updates the retriever used for your Amazon Q application.
    /// </summary>
    [Cmdlet("Update", "QBUSRetriever", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon QBusiness UpdateRetriever API operation.", Operation = new[] {"UpdateRetriever"}, SelectReturnType = typeof(Amazon.QBusiness.Model.UpdateRetrieverResponse))]
    [AWSCmdletOutput("None or Amazon.QBusiness.Model.UpdateRetrieverResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.QBusiness.Model.UpdateRetrieverResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateQBUSRetrieverCmdlet : AmazonQBusinessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The identifier of your Amazon Q application.</para>
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
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The name of your retriever.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter KendraIndexConfiguration_IndexId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Kendra index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_KendraIndexConfiguration_IndexId")]
        public System.String KendraIndexConfiguration_IndexId { get; set; }
        #endregion
        
        #region Parameter NativeIndexConfiguration_IndexId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Amazon Q index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_NativeIndexConfiguration_IndexId")]
        public System.String NativeIndexConfiguration_IndexId { get; set; }
        #endregion
        
        #region Parameter RetrieverId
        /// <summary>
        /// <para>
        /// <para>The identifier of your retriever.</para>
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
        public System.String RetrieverId { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role with permission to access the retriever
        /// and required resources. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QBusiness.Model.UpdateRetrieverResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RetrieverId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RetrieverId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RetrieverId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RetrieverId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QBUSRetriever (UpdateRetriever)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QBusiness.Model.UpdateRetrieverResponse, UpdateQBUSRetrieverCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RetrieverId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KendraIndexConfiguration_IndexId = this.KendraIndexConfiguration_IndexId;
            context.NativeIndexConfiguration_IndexId = this.NativeIndexConfiguration_IndexId;
            context.DisplayName = this.DisplayName;
            context.RetrieverId = this.RetrieverId;
            #if MODULAR
            if (this.RetrieverId == null && ParameterWasBound(nameof(this.RetrieverId)))
            {
                WriteWarning("You are passing $null as a value for parameter RetrieverId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.QBusiness.Model.UpdateRetrieverRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.QBusiness.Model.RetrieverConfiguration();
            Amazon.QBusiness.Model.KendraIndexConfiguration requestConfiguration_configuration_KendraIndexConfiguration = null;
            
             // populate KendraIndexConfiguration
            var requestConfiguration_configuration_KendraIndexConfigurationIsNull = true;
            requestConfiguration_configuration_KendraIndexConfiguration = new Amazon.QBusiness.Model.KendraIndexConfiguration();
            System.String requestConfiguration_configuration_KendraIndexConfiguration_kendraIndexConfiguration_IndexId = null;
            if (cmdletContext.KendraIndexConfiguration_IndexId != null)
            {
                requestConfiguration_configuration_KendraIndexConfiguration_kendraIndexConfiguration_IndexId = cmdletContext.KendraIndexConfiguration_IndexId;
            }
            if (requestConfiguration_configuration_KendraIndexConfiguration_kendraIndexConfiguration_IndexId != null)
            {
                requestConfiguration_configuration_KendraIndexConfiguration.IndexId = requestConfiguration_configuration_KendraIndexConfiguration_kendraIndexConfiguration_IndexId;
                requestConfiguration_configuration_KendraIndexConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_KendraIndexConfiguration should be set to null
            if (requestConfiguration_configuration_KendraIndexConfigurationIsNull)
            {
                requestConfiguration_configuration_KendraIndexConfiguration = null;
            }
            if (requestConfiguration_configuration_KendraIndexConfiguration != null)
            {
                request.Configuration.KendraIndexConfiguration = requestConfiguration_configuration_KendraIndexConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.QBusiness.Model.NativeIndexConfiguration requestConfiguration_configuration_NativeIndexConfiguration = null;
            
             // populate NativeIndexConfiguration
            var requestConfiguration_configuration_NativeIndexConfigurationIsNull = true;
            requestConfiguration_configuration_NativeIndexConfiguration = new Amazon.QBusiness.Model.NativeIndexConfiguration();
            System.String requestConfiguration_configuration_NativeIndexConfiguration_nativeIndexConfiguration_IndexId = null;
            if (cmdletContext.NativeIndexConfiguration_IndexId != null)
            {
                requestConfiguration_configuration_NativeIndexConfiguration_nativeIndexConfiguration_IndexId = cmdletContext.NativeIndexConfiguration_IndexId;
            }
            if (requestConfiguration_configuration_NativeIndexConfiguration_nativeIndexConfiguration_IndexId != null)
            {
                requestConfiguration_configuration_NativeIndexConfiguration.IndexId = requestConfiguration_configuration_NativeIndexConfiguration_nativeIndexConfiguration_IndexId;
                requestConfiguration_configuration_NativeIndexConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_NativeIndexConfiguration should be set to null
            if (requestConfiguration_configuration_NativeIndexConfigurationIsNull)
            {
                requestConfiguration_configuration_NativeIndexConfiguration = null;
            }
            if (requestConfiguration_configuration_NativeIndexConfiguration != null)
            {
                request.Configuration.NativeIndexConfiguration = requestConfiguration_configuration_NativeIndexConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.RetrieverId != null)
            {
                request.RetrieverId = cmdletContext.RetrieverId;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.QBusiness.Model.UpdateRetrieverResponse CallAWSServiceOperation(IAmazonQBusiness client, Amazon.QBusiness.Model.UpdateRetrieverRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QBusiness", "UpdateRetriever");
            try
            {
                #if DESKTOP
                return client.UpdateRetriever(request);
                #elif CORECLR
                return client.UpdateRetrieverAsync(request).GetAwaiter().GetResult();
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
            public System.String KendraIndexConfiguration_IndexId { get; set; }
            public System.String NativeIndexConfiguration_IndexId { get; set; }
            public System.String DisplayName { get; set; }
            public System.String RetrieverId { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.QBusiness.Model.UpdateRetrieverResponse, UpdateQBUSRetrieverCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
