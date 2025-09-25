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
    /// Adds a retriever to your Amazon Q Business application.
    /// </summary>
    [Cmdlet("New", "QBUSRetriever", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QBusiness.Model.CreateRetrieverResponse")]
    [AWSCmdlet("Calls the Amazon QBusiness CreateRetriever API operation.", Operation = new[] {"CreateRetriever"}, SelectReturnType = typeof(Amazon.QBusiness.Model.CreateRetrieverResponse))]
    [AWSCmdletOutput("Amazon.QBusiness.Model.CreateRetrieverResponse",
        "This cmdlet returns an Amazon.QBusiness.Model.CreateRetrieverResponse object containing multiple properties."
    )]
    public partial class NewQBUSRetrieverCmdlet : AmazonQBusinessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The identifier of your Amazon Q Business application.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter NativeIndexConfiguration_BoostingOverride
        /// <summary>
        /// <para>
        /// <para>Overrides the default boosts applied by Amazon Q Business to supported document attribute
        /// data types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_NativeIndexConfiguration_BoostingOverride")]
        public System.Collections.Hashtable NativeIndexConfiguration_BoostingOverride { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The name of your retriever.</para>
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
        /// <para>The identifier for the Amazon Q Business index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_NativeIndexConfiguration_IndexId")]
        public System.String NativeIndexConfiguration_IndexId { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role used by Amazon Q Business to access the basic authentication
        /// credentials stored in a Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that identify or categorize the retriever. You can also
        /// use tags to help control access to the retriever. Tag keys and values can consist
        /// of Unicode letters, digits, white space, and any of the following symbols: _ . : /
        /// = + - @.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.QBusiness.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of retriever you are using.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QBusiness.RetrieverType")]
        public Amazon.QBusiness.RetrieverType Type { get; set; }
        #endregion
        
        #region Parameter NativeIndexConfiguration_Version
        /// <summary>
        /// <para>
        /// <para>A read-only field that specifies the version of the <c>NativeIndexConfiguration</c>.</para><para>Amazon Q Business introduces enhanced document retrieval capabilities in version 2
        /// of <c>NativeIndexConfiguration</c>, focusing on streamlined metadata boosting that
        /// prioritizes recency and source relevance to deliver more accurate responses to your
        /// queries. Version 2 has the following differences from version 1:</para><ul><li><para>Version 2 supports a single Date field (created_at OR last_updated_at) for recency
        /// boosting</para></li><li><para>Version 2 supports a single String field with an ordered list of up to 5 values</para></li><li><para>Version 2 introduces number-based boost levels (ONE, TWO) alongside the text-based
        /// levels</para></li><li><para>Version 2 allows specifying prioritization between Date and String fields</para></li><li><para>Version 2 maintains backward compatibility with existing configurations</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_NativeIndexConfiguration_Version")]
        public System.Int64? NativeIndexConfiguration_Version { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that you provide to identify the request to create your Amazon Q Business
        /// application retriever.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QBusiness.Model.CreateRetrieverResponse).
        /// Specifying the name of a property of type Amazon.QBusiness.Model.CreateRetrieverResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QBUSRetriever (CreateRetriever)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QBusiness.Model.CreateRetrieverResponse, NewQBUSRetrieverCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.KendraIndexConfiguration_IndexId = this.KendraIndexConfiguration_IndexId;
            if (this.NativeIndexConfiguration_BoostingOverride != null)
            {
                context.NativeIndexConfiguration_BoostingOverride = new Dictionary<System.String, Amazon.QBusiness.Model.DocumentAttributeBoostingConfiguration>(StringComparer.Ordinal);
                foreach (var hashKey in this.NativeIndexConfiguration_BoostingOverride.Keys)
                {
                    context.NativeIndexConfiguration_BoostingOverride.Add((String)hashKey, (Amazon.QBusiness.Model.DocumentAttributeBoostingConfiguration)(this.NativeIndexConfiguration_BoostingOverride[hashKey]));
                }
            }
            context.NativeIndexConfiguration_IndexId = this.NativeIndexConfiguration_IndexId;
            context.NativeIndexConfiguration_Version = this.NativeIndexConfiguration_Version;
            context.DisplayName = this.DisplayName;
            #if MODULAR
            if (this.DisplayName == null && ParameterWasBound(nameof(this.DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.QBusiness.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QBusiness.Model.CreateRetrieverRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
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
            Dictionary<System.String, Amazon.QBusiness.Model.DocumentAttributeBoostingConfiguration> requestConfiguration_configuration_NativeIndexConfiguration_nativeIndexConfiguration_BoostingOverride = null;
            if (cmdletContext.NativeIndexConfiguration_BoostingOverride != null)
            {
                requestConfiguration_configuration_NativeIndexConfiguration_nativeIndexConfiguration_BoostingOverride = cmdletContext.NativeIndexConfiguration_BoostingOverride;
            }
            if (requestConfiguration_configuration_NativeIndexConfiguration_nativeIndexConfiguration_BoostingOverride != null)
            {
                requestConfiguration_configuration_NativeIndexConfiguration.BoostingOverride = requestConfiguration_configuration_NativeIndexConfiguration_nativeIndexConfiguration_BoostingOverride;
                requestConfiguration_configuration_NativeIndexConfigurationIsNull = false;
            }
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
            System.Int64? requestConfiguration_configuration_NativeIndexConfiguration_nativeIndexConfiguration_Version = null;
            if (cmdletContext.NativeIndexConfiguration_Version != null)
            {
                requestConfiguration_configuration_NativeIndexConfiguration_nativeIndexConfiguration_Version = cmdletContext.NativeIndexConfiguration_Version.Value;
            }
            if (requestConfiguration_configuration_NativeIndexConfiguration_nativeIndexConfiguration_Version != null)
            {
                requestConfiguration_configuration_NativeIndexConfiguration.Version = requestConfiguration_configuration_NativeIndexConfiguration_nativeIndexConfiguration_Version.Value;
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
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.QBusiness.Model.CreateRetrieverResponse CallAWSServiceOperation(IAmazonQBusiness client, Amazon.QBusiness.Model.CreateRetrieverRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QBusiness", "CreateRetriever");
            try
            {
                #if DESKTOP
                return client.CreateRetriever(request);
                #elif CORECLR
                return client.CreateRetrieverAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String KendraIndexConfiguration_IndexId { get; set; }
            public Dictionary<System.String, Amazon.QBusiness.Model.DocumentAttributeBoostingConfiguration> NativeIndexConfiguration_BoostingOverride { get; set; }
            public System.String NativeIndexConfiguration_IndexId { get; set; }
            public System.Int64? NativeIndexConfiguration_Version { get; set; }
            public System.String DisplayName { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.QBusiness.Model.Tag> Tag { get; set; }
            public Amazon.QBusiness.RetrieverType Type { get; set; }
            public System.Func<Amazon.QBusiness.Model.CreateRetrieverResponse, NewQBUSRetrieverCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
